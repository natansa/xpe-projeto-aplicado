using Domain.Model;
using Domain.Request;

namespace Domain.Mapper;

public static class TranslateMappers
{
    public static TranslateModel ToModel(this TranslateRequest request, string translateMethod)
    {
        return new TranslateModel
        (
            translateMethod,
            request.CustomerId,
            request.OriginId,
            correlationId: Guid.NewGuid().ToString(),
            request.SourceLanguage,
            request.TargetLanguage,
            request.Text
        );
    }
}