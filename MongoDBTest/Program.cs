using MongoDBTest.MongoCollection;
using MongoDBTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 將MongoDB連線設定注入
builder.Services.Configure<TestDatabaseSettings>(
    builder.Configuration.GetSection("TestDatabase"));

// 註冊人員服務
builder.Services.AddSingleton<PeopleService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
