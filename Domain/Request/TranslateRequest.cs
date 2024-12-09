namespace Domain.Request;

public record TranslateRequest
(
    string SourceLanguage,
    string TargetLanguage,
    string Text
);