using Domain.Model;

namespace Domain.Service;

public interface IGoogleTranslateService
{
    Task<string> TranslateTextAsync(TranslateModel translate, CancellationToken cancellationToken);
}