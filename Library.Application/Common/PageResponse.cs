namespace Library.Application.Common;

public record PageResponse<T>(
    T Data,
    int Count,
    int TotalCount)
    where T : class;
