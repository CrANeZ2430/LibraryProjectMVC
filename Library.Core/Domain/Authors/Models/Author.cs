using Library.Core.Domain.Authors.Data;

namespace Library.Core.Domain.Authors.Models;

public class Author
{
    private Author()
    {
        // Required for EF Core
    }

    private Author(
        string firstname,
        string lastName,
        string middleName,
        string? biography,
        string? imageUrl)
    {
        Id = Guid.NewGuid();
        FirstName = firstname;
        LastName = lastName;
        Middlename = middleName;
        Biography = biography;
        ImageUrl = imageUrl;
    }

    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? Middlename { get; private set; }
    public string? Biography { get; private set; }
    public string? ImageUrl { get; private set; }

    public static Author Create(CreateAuthorData data)
    {
        return new Author(
            data.FirstName,
            data.LastName,
            data.MiddleName,
            data.Biography,
            data.ImageUrl);
    }

    public void Update(UpdateAuthorData data)
    {
        FirstName = data.FirstName;
        LastName = data.LastName;
        Middlename = data.MiddleName;
        Biography = data.Biography;
        ImageUrl = data.ImageUrl;
    }
}
