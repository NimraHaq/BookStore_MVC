using EadProject.Data;
using EadProject.Repositories;
using EadProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(Program));

//now we have to connect entities to the database
builder.Services.AddDbContext<BookStoreContext>(options=>options.UseSqlServer("Server=.;Database=DastanSara;Integrated Security=True;"));

#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#endif

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=homePage}/{id?}");

app.Run();
