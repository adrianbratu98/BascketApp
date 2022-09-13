using System;
using BascketApp.Application.Common;
using BascketApp.Application.Models;
using BascketApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BascketApp.Application.Commands
{
    public class UpdateBascketCommand : IRequest<bool>
    {
        public int BascketId { get; set; }

        public UpdateBascketDTO Model { get; set; }

        public UpdateBascketCommand(int bascketId, UpdateBascketDTO model)
        {
            BascketId = bascketId;
            Model = model;
        }
    }

    public class UpdateBascketCommandHandler : IRequestHandler<UpdateBascketCommand, bool>
    {
        private IBascketAppDbContext Context { get; set; }

        public UpdateBascketCommandHandler(IBascketAppDbContext context)
        {
            Context = context;
        }

        public async Task<bool> Handle(UpdateBascketCommand request, CancellationToken cancellationToken)
        {
            var bascket = await Context.Basckets
                .FirstAsync(bascket => bascket.Id == request.BascketId);
            bascket.Close = request.Model.Close;
            bascket.Payed = request.Model.Payed;
            await Context.UpdateAsync(bascket);
            return true;
        }
    }
}

