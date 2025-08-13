namespace Library.API.ViewModels.Authors.AuthorsPage;

public record AddAuthorViewModel(
    string FirstName,
    string LastName,
    string? MiddleName,
    string? Biography,
    string? ImageUrl);
