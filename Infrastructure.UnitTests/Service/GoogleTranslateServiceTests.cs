using Bogus;
using Domain.Configuration;
using Domain.Model;
using FluentAssertions;
using NSubstitute;
using Google.Cloud.Translate.V3;
using Infrastructure.Service;
using NSubstitute.ExceptionExtensions;

namespace Infrastructure.UnitTests.Service;

public class GoogleTranslateServiceTests
{
    private readonly AppConfig _appConfig = new()
    {
        GoogleConfig = new GoogleConfig { ProjectId = "test-project" }
    };
    
    private readonly Faker _faker = new();

    private readonly TranslateModel _translateModel;
    private readonly TranslationServiceClient _translationServiceClient = Substitute.For<TranslationServiceClient>();
    private readonly GoogleTranslateService _service;

    public GoogleTranslateServiceTests()
    {
        _translateModel = new TranslateModel(text: _faker.Lorem.Sentence(), sourceLanguageCode: "en", targetLanguageCode: "es");
        _service = new GoogleTranslateService(_appConfig, _translationServiceClient);
    }

    [Fact]
    public async Task Should_Return_TranslatedText_When_Response_IsValid()
    {
        // Arrange
        var expectedTranslation = _faker.Lorem.Sentence();

        var response = new TranslateTextResponse
        {
            Translations = { new Translation { TranslatedText = expectedTranslation } }
        };

        _translationServiceClient.TranslateTextAsync(
            Arg.Is<TranslateTextRequest>(req =>
                req.Contents.Contains(_translateModel.Text) &&
                req.SourceLanguageCode == _translateModel.SourceLanguageCode &&
                req.TargetLanguageCode == _translateModel.TargetLanguageCode &&
                req.Parent == $"projects/{_appConfig.GoogleConfig.ProjectId}"),
        Arg.Any<CancellationToken>())
            .Returns(response);

        // Act
        var result = await _service.TranslateTextAsync(_translateModel, CancellationToken.None);

        // Assert
        result.Should().Be(expectedTranslation);
    }

    [Fact]
    public async Task Should_Return_Empty_String_When_No_Translations()
    {
        // Arrange
        var response = new TranslateTextResponse();

        _translationServiceClient.TranslateTextAsync(
            Arg.Any<TranslateTextRequest>(),
        Arg.Any<CancellationToken>())
            .Returns(response);

        // Act
        var result = await _service.TranslateTextAsync(_translateModel, CancellationToken.None);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Client_Throws_Exception()
    {
        // Arrange
        _translationServiceClient.TranslateTextAsync(
            Arg.Any<TranslateTextRequest>(),
        Arg.Any<CancellationToken>())
            .ThrowsAsync(new Exception("Test Exception"));

        var service = new GoogleTranslateService(_appConfig, _translationServiceClient);

        // Act
        var act = async () => await service.TranslateTextAsync(_translateModel, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<Exception>().WithMessage("Test Exception");
    }
}