using LivrariaMud.Domain.Abstrations;
using LivrariaMud.Domain.Enums;

namespace LivrariaMud.Domain.Entities;

public class Book
    ( string title,
     string author,
     Category category,
     PublishingCompany publishingCompany,
     DateTime publishedAt,
     int id = 0,
     string cover = "",
     string synopsis = "" )
{
    private string title = title;
    private string author = author;
    private DateTime publishedAt = publishedAt;
    private Category category = category;
    private PublishingCompany publishingCompany = publishingCompany;

    public string Title
    {
        get => title; private set
        {
            if ( string.IsNullOrWhiteSpace( value ) )
                throw new ArgumentException( "Title is required", nameof( value ) );
            title = value;
        }
    }
    public string Author
    {
        get => author; private set
        {
            if ( string.IsNullOrWhiteSpace( value ) )
                throw new ArgumentException( "Author is required", nameof( value ) );
            author = value;
        }
    }
    public DateTime PublishedAt
    {
        get => publishedAt; private set
        {
            if ( value == DateTime.MinValue )
                throw new ArgumentException( "PublisherAt is required", nameof( value ) );
            publishedAt = value;
        }
    }
    public Category Category
    {
        get => category; private set
        {
            if ( value == Category.Nenhum )
                throw new ArgumentException( "Category is required", nameof( value ) );
            category = value;
        }
    }
    public PublishingCompany PublishingCompany
    {
        get => publishingCompany; private set
        {
            if ( value == PublishingCompany.Nenhum )
                throw new ArgumentException( "PublishingCompany is required", nameof( value ) );
            publishingCompany = value;
        }
    }
    public int Id { get; private set; } = id;
    public string Cover { get; private set; } = cover;
    public string Synopsis { get; private set; } = synopsis;

    public void Update ( string title,
                        string author,
                        Category category,
                        PublishingCompany publishingCompany,
                        DateTime publishedAt,
                        int id,
                        string cover,
                        string synopsis )
    {
        Title = title;
        Author = author;
        Category = category;
        PublishingCompany = publishingCompany;
        PublishedAt = publishedAt;
        Id = id;
        Cover = cover;
        Synopsis = synopsis;
    }
}
