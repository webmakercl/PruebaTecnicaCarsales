
using _1.__BFF.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registro los servicios 
builder.Services.AddHttpClient<ICharacterService, CharacterService>();
builder.Services.AddHttpClient<IEpisodeService, EpisodeService>();

//Agrego CORS para comunicacion entre componentes
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:51194")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

//Uso politica de CORS
app.UseCors("AllowAngular");

//Comento para usar swaggerUI
app.UseSwagger();

//Se limita el acceso a los schemas
app.UseSwaggerUI(options =>
{
    options.DefaultModelsExpandDepth(-1);
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
