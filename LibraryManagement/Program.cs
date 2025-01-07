
using LibraryManagement.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using LibraryManagement.Persistance.Repository;
using LibraryManagement.Application.Interface;
using LibraryManagement.Application.Handler.AuthorFeature.Query;
using LibraryManagement.Application.Handler.GenericFeature.GenericQuery;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Application.Handler.GenericFeature.GenericCommand;
using LibraryManagement.Application.DTO;
namespace LibraryManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllAuthorQueryHandler).Assembly));
            //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAuthorByIdQueryHandler).Assembly));
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            builder.Services.AddTransient<IRequestHandler<GetByIdGenericQuery<Author>, Author>, AddGenericCommandHandler<Author>>();
            builder.Services.AddTransient<IRequestHandler<AddGenericCommand<Author, AuthorDto>, AuthorDto>, AddGenericCommandHandler<Author, AuthorDto>>();


            builder.Services.AddControllers();


            // Add services to the container.

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();   // Generate Swagger JSON
                app.UseSwaggerUI(); // Serve Swagger UI for interactive API documentation
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
