namespace Library.Application.Domain.Authors.Queries.GetAuthorById;

public record AuthorDto(
    string FirstName,
    string LastName,
    string? MiddleName,
    string? Biography,
    string? ImageUrl);
