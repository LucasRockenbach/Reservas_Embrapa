using Aula7.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

var connectionStringPgSql =
 builder.Configuration.GetConnectionString("PostgreConn");
builder.Services.AddDbContext<AulaDbContext>(
 context => context.UseNpgsql(connectionStringPgSql));


#region[Cors]
builder.Services.AddCors();
#endregion


/*var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                      });
});*/





// Add services to the container.

/*var connectionStringMySql = builder.Configuration.GetConnectionString("ConnectionMySql");
builder.Services.AddDbContext<AulaDbContext>(x => x.UseMySQL(connectionStringMySql));*/

var connection = builder.Configuration.GetConnectionString("ConnectionPostgres");

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

//app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

#region [Cors]
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
