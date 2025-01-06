using Application.Handler;
using Bogus;
using Domain.Handler;
using Domain.Model;
using Domain.Request;
using Domain.Service;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Application.UnitTests.Handler;

public class TranslateHandlerTests
{
    private readonly Faker _faker = new Faker();
    private readonly IGoogleTranslateService _googleTranslateService;
    private readonly ITranslateHandler _handler;
    private readonly TranslateRequest _request;
    private readonly CancellationToken _cancellationToken = CancellationToken.None;

    public TranslateHandlerTests()
    {
        _googleTranslateService = Substitute.For<IGoogleTranslateService>();
        _handler = new TranslateHandler(_googleTranslateService);
        _request = new TranslateRequest
        (
            SourceLanguage: "en",
            TargetLanguage: "es",
            Text: _faker.Lorem.Sentence()
        );
    }

    [Fact]
    public async Task Should_Return_TranslateResponse_When_Translation_Is_Successful()
    {
        // Arrange
        var expectedTranslatedText = _faker.Lorem.Sentence();

        _googleTranslateService.TranslateTextAsync(Arg.Any<TranslateModel>(), Arg.Any<CancellationToken>())
            .Returns(expectedTranslatedText);

        // Act
        var response = await _handler.TranslateAsync(_request, _cancellationToken);

        // Assert
        response.Should().NotBeNull();
        response.Text.Should().Be(expectedTranslatedText);

        await _googleTranslateService.Received(1).TranslateTextAsync(Arg.Any<TranslateModel>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task TranslateAsync_ShouldThrowException_WhenGoogleServiceFails()
    {
        // Arrange
        _googleTranslateService
            .TranslateTextAsync(Arg.Any<TranslateModel>(), Arg.Any<CancellationToken>())
            .ThrowsAsync(new Exception("Translation failed"));

        // Act
        var act = async () => await _handler.TranslateAsync(_request, _cancellationToken);

        // Assert
        await act.Should().ThrowAsync<Exception>()
            .WithMessage("Translation failed");
    }
}