using Library.Core.Domain.Books.Data;

namespace Library.Core.Domain.Books.Models;

public class Book
{
    private Book()
    {
        // Required for EF Core
    }

    private Book(
        string title,
        string? description,
        string? isbn,
        DateTime publishedDate)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Isbn = isbn;
        PublishedDate = publishedDate;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public string? Isbn { get; private set; }
    public DateTime PublishedDate { get; private set; }

    public static Book Create(CreateBookData data)
    {
        return new Book(
            data.Title,
            data.Description,
            data.Isbn,
            data.PublishedDate);
    }

    public void Update(UpdateBookData data)
    {
        Title = data.Title;
        Description = data.Description;
        Isbn = data.Isbn;
        PublishedDate = data.PublishedDate;
    }
}
