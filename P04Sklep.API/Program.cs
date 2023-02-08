using Microsoft.EntityFrameworkCore;
using P04Sklep.API.Data;
using P04Sklep.API.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>(); //obiekt jest tworzony za ka¿dym razem dla nowego zapytania HTTP od klienta
// - jedno zapytanie tworzy jedn¹ instancjê

//builder.Services.AddSingleton<IProductService, ProductService>(); - nowa instancja klasy Produkt service zostanie utworzna tylko 1 raz na ca³y cykl trwania naszej aplikacji

//builder.Services.AddTransient<IProductService, ProductService>(); - obiekt jest tworzony za ka¿dym razem kiedy odwo³ujemy siê do konstruktora, nawet podczas trwania cyklu jednego zapytania.

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsePolicy", builder =>
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("MyCorsePolicy", builder =>
//        builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("www.przyk³adowastrona.pl"));
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCorsePolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
