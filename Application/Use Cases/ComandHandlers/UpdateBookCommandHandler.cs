using Application.DTOs;
using Application.Use_Cases.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Use_Cases.ComandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository repository;

        public UpdateBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var oldBook = await repository.GetByIdAsync(request.Id);
            oldBook.Title = request.Title;
            oldBook.Author = request.Author;
            oldBook.ISBN = request.ISBN;
            oldBook.PublicationDate = request.PublicationDate;
            await repository.UpdateAsync(oldBook);
        }
    }
}
