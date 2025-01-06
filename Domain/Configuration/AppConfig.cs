using System.Diagnostics.CodeAnalysis;

namespace Domain.Configuration;

[ExcludeFromCodeCoverage]
public sealed class AppConfig
{
    public GoogleConfig GoogleConfig { get; set; } = new();
}