using Infrastructure.Dependency;

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "gcp-neosync-credential.json");

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureApplication(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();