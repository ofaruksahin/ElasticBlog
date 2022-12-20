using ElasticBlog.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ElasticBlogDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySqlConnectionString");
    options.UseMySql(connectionString, new MySqlServerVersion(MySqlServerVersion.AutoDetect(connectionString)));

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

