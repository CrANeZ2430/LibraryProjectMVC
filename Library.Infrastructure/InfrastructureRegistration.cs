using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Books.Common;
using Library.Infrastructure.Core.Common;
using Library.Infrastructure.Core.Domain.Authors;
using Library.Infrastructure.Core.Domain.Books;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Library.Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAuthorsRepository, AuthorsRepository>();
        services.AddScoped<IBooksRepository, BooksRepository>();
    }
}
