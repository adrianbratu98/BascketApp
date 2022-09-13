using System;
using BascketApp.Application.Common;
using BascketApp.Application.Models;
using BascketApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BascketApp.Application.Commands
{
    public class PutBascketArticleCommand : IRequest<int>
    {
        public int BascketId { get; set; }

        public PutBascketArticleDTO Model { get; set; }

        public PutBascketArticleCommand(int bascketId, PutBascketArticleDTO model)
        {
            BascketId = bascketId;
            Model = model;
        }
    }

    public class PutBascketArticleCommandHandler : IRequestHandler<PutBascketArticleCommand, int>
    {
        private IBascketAppDbContext Context { get; set; }

        public PutBascketArticleCommandHandler(IBascketAppDbContext context)
        {
            Context = context;
        }

        public async Task<int> Handle(PutBascketArticleCommand request, CancellationToken cancellationToken)
        {
            var alredyExistArticle = await Context.BascketArticles
                .FirstOrDefaultAsync(article => article.BascketId == request.BascketId &&
                    article.Item == request.Model.Item);
            if(alredyExistArticle != null)
            {
                alredyExistArticle.Price = request.Model.Price;
                await Context.UpdateAsync(alredyExistArticle);
                return alredyExistArticle.Id;
            }
            var newArticle = new BascketArticle(request.Model.Item)
            {
                BascketId = request.BascketId,
                Price = request.Model.Price
            };
            var entityEntry = await Context.AddAsync(newArticle);
            await Context.SaveChangesAsync();
            return entityEntry.Entity.Id;
        }
    }
}

