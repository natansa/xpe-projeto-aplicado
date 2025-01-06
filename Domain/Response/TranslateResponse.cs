using System.Diagnostics.CodeAnalysis;

namespace Domain.Response;

[ExcludeFromCodeCoverage]
public record TranslateResponse(string Text);