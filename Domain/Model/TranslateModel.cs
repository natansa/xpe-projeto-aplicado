namespace Domain.Model;

public class TranslateModel(
    string sourceLanguageCode,
    string targetLanguageCode,
    string text)
{
    public string SourceLanguageCode { get; } = sourceLanguageCode;
    public string TargetLanguageCode { get; } = targetLanguageCode;
    public string Text { get; private set; } = text;

    public void SetText(string text)
    {
        Text = text;
    }
}