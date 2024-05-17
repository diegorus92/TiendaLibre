using Microsoft.EntityFrameworkCore;
using TiendaLibreAPI_DAL.Data;
using TiendaLibreAPI_BL.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(config =>
{
    config.UseSqlServer(
            builder.Configuration.GetSection("ConnectionData").GetSection("ConnectionString").Value
        );
    
});

builder.Services.AddTransient<DbContext, DatabaseContext>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

//Utilities services
builder.Services.AddScoped<IImageFileManagerService, ImageFileManagerService>();
builder.Services.AddScoped<IPasswordEncryptationService,  PasswordEncryptationService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPurchaseOperationService, PurchaseOperationService>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();


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

app.UseCors(c => 
    c.AllowAnyMethod().
    AllowAnyHeader().
    AllowAnyHeader().
    SetIsOriginAllowed(origin => true).
    AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
