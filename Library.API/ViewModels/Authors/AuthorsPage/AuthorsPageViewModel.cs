namespace Library.API.ViewModels.Authors.AuthorsPage;

public record AuthorsPageViewModel(
    IEnumerable<AuthorViewModel> AuthorList,
    AddAuthorViewModel AddAuthor,
    int Page,
    bool HasMorePages);