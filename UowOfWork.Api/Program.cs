using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWork.Application.User;
using UnitOfWork.Contracts.User;
using UnitOfWork.Domain.User;
using UnitOfWork.Infrastructure.EfCore;
using UnitOfWork.Infrastructure.User;
using UnitOfWork.Shared.InfraStructure.Repository;
using UnitOfWork.Shared.InfraStructure.UnitOfWork;

namespace UowOfWork.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ShopDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddTransient<IRepository<User, Guid>, EfRepository<ShopDbContext, User, Guid>>();
            builder.Services.AddTransient<IUnitOfWorkManager<ShopDbContext>, UnitOfWorkManager<ShopDbContext>>();

            builder.Services.AddTransient<IUserRepository,UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/", () => "You Did It Javad , You Fucking Did It!");

            app.MapControllers();

            app.Run();
        }
    }
}
