using System.Diagnostics.CodeAnalysis;

namespace Domain.Request;

[ExcludeFromCodeCoverage]
public record TranslateRequest
(
    string SourceLanguage,
    string TargetLanguage,
    string Text
);