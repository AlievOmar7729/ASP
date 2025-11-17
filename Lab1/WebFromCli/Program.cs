var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/who", () => "Àë³ºâ Îìàð");
app.MapGet("/time", () => DateTime.Now.ToString("HH:mm:ss"));

app.Run();