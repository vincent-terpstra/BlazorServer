using MinimalAPIDemo;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.PopulateDbPosts();
    app.PopulateDbUsers();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.RegisterExceptionHandling();
app.RegisterEndpoints();

app.Run();