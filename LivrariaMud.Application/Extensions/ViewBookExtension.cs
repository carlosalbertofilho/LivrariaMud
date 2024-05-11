using LivrariaMud.Application.DTOs;
using LivrariaMud.Domain.Entities;

namespace LivrariaMud.Application.Extensions;

public static class ViewBookExtension
{
    public static ViewBook ToViewBook ( this Book book )
        => new( book.Title,
               book.Author,
               book.Category,
               book.PublishingCompany,
               book.PublishedAt,
               book.Id,
               book.Cover,
               book.Synopsis );
    public static Book ToBook ( this ViewBook viewBook )
        => new( viewBook.Title,
               viewBook.Author,
               viewBook.Category,
               viewBook.PublishingCompany,
               viewBook.PublishedAt,
               viewBook.Id,
               viewBook.Cover,
               viewBook.Synopsis );
}
