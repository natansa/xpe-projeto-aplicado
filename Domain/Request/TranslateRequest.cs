namespace Domain.Request;

public record TranslateRequest
(
    string CustomerId,
    string OriginId,
    string SourceLanguage,
    string TargetLanguage,
    string Text
);