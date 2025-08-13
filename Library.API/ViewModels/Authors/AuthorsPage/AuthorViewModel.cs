namespace Library.API.ViewModels.Authors.AuthorsPage;

public record AuthorViewModel(
    Guid Id,
    string FirstName,
    string LastName,
    string? MiddleName,
    string? Biography,
    string? ImageUrl);