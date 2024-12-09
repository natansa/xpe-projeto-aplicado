using Domain.Configuration;
using Domain.Model;
using Domain.Service;
using Google.Cloud.Translate.V3;

namespace Infrastructure.Service;

public class GoogleTranslateService(AppConfig appConfig) : IGoogleTranslateService
{
    public async Task<string> TranslateTextAsync(TranslateModel translate, CancellationToken cancellationToken)
    {
        var client = TranslationServiceClient.Create();
        var response = await client.TranslateTextAsync(new TranslateTextRequest
        {
            Contents = { translate.Text },
            TargetLanguageCode = translate.TargetLanguageCode,
            SourceLanguageCode = translate.SourceLanguageCode,
            Parent = $"projects/{appConfig.GoogleConfig.ProjectId}"
        }, cancellationToken);

        return response.Translations.FirstOrDefault()?.TranslatedText ?? string.Empty;
    }
}