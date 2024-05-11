using LivrariaMud.Application.Extensions;
using LivrariaMud.Domain.Entities;
using LivrariaMud.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LivrariaMud.Application.DTOs;

public class EditBook
    ( string title,
     string author,
     Category category,
     PublishingCompany publishingCompany,
     DateTime publishedAt,
     int id = 0,
     string cover = "",
     string synopsis = "" )
{
    public static implicit operator EditBook ( Book book )
        => book.ToEditBook();
    public static implicit operator Book ( EditBook editBook )
        => editBook.ToBook();

    public int Id { get; set; } = id;
    [Required( ErrorMessage = "Título do livro é obrigatório" )]
    [StringLength( 150 )]
    public string Title { get; set; } = title;

    [Required( ErrorMessage = "Autor do livro é obrigatório" )]
    [StringLength( 150 )]
    public string Author { get; set; } = author;

    [Required( ErrorMessage = "Data de publicação do livro é obrigatória" )]
    [DataType( DataType.Date )]
    public DateTime PublishedAt { get; set; } = publishedAt;

    public DateTime RegistetredAt { get; set; } = DateTime.Now;

    [Required( ErrorMessage = "Editora do livro é obrigatória" )]
    [EnumDataType( typeof( PublishingCompany ), ErrorMessage = "Selecione uma editora válida" )]
    public PublishingCompany PublishingCompany { get; set; } = publishingCompany;

    [StringLength( 300, ErrorMessage = "Campo pode ter até 300 caracteres" )]
    public string Cover { get; set; } = cover;

    [StringLength( 500, ErrorMessage = "Campo pode ter até 500 caracteres" )]
    public string Synopsis { get; set; } = synopsis;

    [Required( ErrorMessage = "Categoria do livro é obrigatória" )]
    [EnumDataType( typeof( Category ), ErrorMessage = "Selecione uma categoria válida" )]
    public Category Category { get; set; } = category;
}
