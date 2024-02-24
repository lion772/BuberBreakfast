var builder = WebApplication.CreateBuilder(args);
{
    //Builder can be used for dependency injection and configuration
    builder.Services.AddControllers();
}

//App is a variable in which one can manage the request pipeline
var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


