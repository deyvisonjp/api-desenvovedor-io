using FundamentalApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    //Configure as opções de comportamento da API
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true; // Retiro a validação do Model, chega no controller
    }); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuração DBContext
builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Identity Framework (<IdentityUser: Usuário, IdentityRole: perfil>)
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApiDbContext>(); //Mesmo contextos das tabelas do sistema.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Acesse /swagger para mais informações");
app.MapGet("/teste-get", () => "Teste");

app.Run();
