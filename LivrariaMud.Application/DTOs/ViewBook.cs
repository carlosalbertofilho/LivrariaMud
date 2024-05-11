using LivrariaMud.Application.Extensions;
using LivrariaMud.Domain.Entities;
using LivrariaMud.Domain.Enums;

namespace LivrariaMud.Application.DTOs;

public record ViewBook
    ( string Title,
     string Author,
     Category Category,
     PublishingCompany PublishingCompany,
     DateTime PublishedAt,
     int Id = 0,
     string Cover = "",
     string Synopsis = "" )
{
    public static implicit operator ViewBook ( Book book )
        => book.ToViewBook();

    public static implicit operator Book ( ViewBook viewBook )
        => viewBook.ToBook();
}
