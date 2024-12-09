using Domain.Request;
using Domain.Response;

namespace Domain.Handler;

public interface ITranslateHandler
{
    Task<TranslateResponse> TranslateAsync(TranslateRequest request, CancellationToken cancellationToken);
}