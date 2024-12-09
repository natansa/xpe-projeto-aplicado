namespace Domain.Configuration;

public sealed class AppConfig
{
    public GoogleConfig GoogleConfig { get; set; } = new();
}