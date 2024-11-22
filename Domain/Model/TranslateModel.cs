namespace Domain.Model;

public class TranslateModel(string translateMethod,
    string customerId,
    string originId,
    string correlationId,
    string sourceLanguageCode,
    string targetLanguageCode,
    string text)
{
    public string TranslateMethod { get; } = translateMethod;
    public string CustomerId { get; } = customerId;
    public string OriginId { get; } = originId;
    public string CorrelationId { get; } = correlationId;
    public string SourceLanguageCode { get; } = sourceLanguageCode;
    public string TargetLanguageCode { get; } = targetLanguageCode;
    public string Text { get; private set; } = text;

    public void SetText(string text)
    {
        Text = text;
    }
}