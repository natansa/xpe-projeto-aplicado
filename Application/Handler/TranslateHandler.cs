using Domain.Handler;
using Domain.Mapper;
using Domain.Request;
using Domain.Response;
using Domain.Service;

namespace Application.Handler;

public class TranslateHandler(IGoogleTranslateService googleService) : ITranslateHandler
{
    public async Task<TranslateResponse> TranslateAsync(TranslateRequest request, CancellationToken cancellationToken)
    {
        var translate = request.ToModel();

        var googleResult = await googleService.TranslateTextAsync(translate, cancellationToken);
        translate.SetText(googleResult);

        return new TranslateResponse(googleResult);
    }
}