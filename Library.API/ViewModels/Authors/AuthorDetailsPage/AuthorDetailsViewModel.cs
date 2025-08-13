namespace Library.API.ViewModels.Authors.AuthorDetailsPage;

public record AuthorDetailsViewModel(
    string FirstName,
    string LastName,
    string? MiddleName,
    string? Biography,
    string? ImageUrl);
