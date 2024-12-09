using Domain.Model;
using Domain.Request;

namespace Domain.Mapper;

public static class TranslateMappers
{
    public static TranslateModel ToModel(this TranslateRequest request)
    {
        return new TranslateModel
        (
            request.SourceLanguage,
            request.TargetLanguage,
            request.Text
        );
    }
}