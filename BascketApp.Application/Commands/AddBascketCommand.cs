using System;
using BascketApp.Application.Common;
using BascketApp.Application.Models;
using BascketApp.Domain.Entities;
using MediatR;

namespace BascketApp.Application.Commands
{
    public class AddBascketCommand : IRequest<int>
    {
        public AddBascketDTO Model { get; set; }

        public AddBascketCommand(AddBascketDTO model)
        {
            Model = model;
        }
    }

    public class AddBascketCommandHandler : IRequestHandler<AddBascketCommand, int>
    {
        private IBascketAppDbContext Context { get; set; }

        public AddBascketCommandHandler(IBascketAppDbContext context)
        {
            Context = context;
        }

        public async Task<int> Handle(AddBascketCommand request, CancellationToken cancellationToken)
        {
            var entityAdded = await Context.AddAsync(new Bascket(request.Model.Customer, request.Model.PaysVAT));
            await Context.SaveChangesAsync();
            return entityAdded.Entity.Id;
        }
    }
}

