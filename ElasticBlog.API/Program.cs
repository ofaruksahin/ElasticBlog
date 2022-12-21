using ElasticBlog.Application;
using ElasticBlog.Application.Extensions;
using ElasticBlog.Application.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(PackageLoader));
builder.Services.AddAutoMapper(typeof(PackageLoader));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidators();
builder.Services.AddPipelines();
builder.Services.AddRepositories();
builder.Services.AddElasticBlogDbContext(builder.Configuration);
builder.Services.AddElasticBlogServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
