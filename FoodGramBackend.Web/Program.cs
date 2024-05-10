using FoodGramBackend.BLL;
using FoodGramBackend.BLL.Abstract;
using FoodGramBackend.BLL.Services;
using FoodGramBackend.Web.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterBllServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
