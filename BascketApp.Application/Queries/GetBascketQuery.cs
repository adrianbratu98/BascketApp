using System;
using BascketApp.Application.Common;
using BascketApp.Application.Models;
using BascketApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BascketApp.Application.Queries
{
    public class GetBascketQuery : IRequest<BascketDTO>
    {
        public int Id { get; set; }

        public GetBascketQuery(int id)
        {
            Id = id;
        }
    }

    public class GetBascketQueryHandler : IRequestHandler<GetBascketQuery, BascketDTO>
    {
        private IBascketAppDbContext Context { get; set; }

        public GetBascketQueryHandler(IBascketAppDbContext context)
        {
            Context = context;
        }

        public async Task<BascketDTO> Handle(GetBascketQuery request, CancellationToken cancellationToken)
        {
            var bascketProjection = await Context.Basckets
                .Select(bascket => new
                {
                    Id = bascket.Id,
                    PaysVAT = bascket.PaysVAT,
                    Articles = bascket.Articles!
                        .Select(article => new BascketArticleDTO(article.Item)
                        {
                            Price = article.Price
                        })
                        .ToList()
                        
                })
                .FirstAsync(bascket => bascket.Id == request.Id);
            return new BascketDTO()
            {
                Id = bascketProjection.Id,
                TotalGross = bascketProjection.Articles
                    .Sum(article => article.Price),
                TotalNet = bascketProjection.PaysVAT ?
                    (bascketProjection.Articles
                        .Sum(article => article.Price)) - ((decimal)0.1 * (bascketProjection.Articles
                            .Sum(article => article.Price))) :
                    bascketProjection.Articles
                        .Sum(article => article.Price),
                Articles = bascketProjection.Articles
            };
        }
    }
}

