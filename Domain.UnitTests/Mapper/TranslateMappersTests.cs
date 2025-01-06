using Domain.Mapper;
using Domain.Request;
using FluentAssertions;

namespace Domain.UnitTests.Mapper;

public class TranslateMappersTests
{
    [Fact]
    public void Should_Map_TranslateRequest_To_TranslateModel()
    {
        // Arrange
        var request = new TranslateRequest(
            SourceLanguage: "en",
            TargetLanguage: "es",
            Text: "Hello World"
        );

        // Act
        var model = request.ToModel();

        // Assert
        model.Should().NotBeNull();
        model.SourceLanguageCode.Should().Be(request.SourceLanguage);
        model.TargetLanguageCode.Should().Be(request.TargetLanguage);
        model.Text.Should().Be(request.Text);
    }
}