using Domain.Model;
using FluentAssertions;

namespace Domain.UnitTests.Model;

public class TranslateModelTests
{
    [Fact]
    public void Should_Initialize_Properties_Correctly()
    {
        // Arrange
        var sourceLanguage = "en";
        var targetLanguage = "es";
        var text = "Hello World";

        // Act
        var model = new TranslateModel(sourceLanguage, targetLanguage, text);

        // Assert
        model.SourceLanguageCode.Should().Be(sourceLanguage);
        model.TargetLanguageCode.Should().Be(targetLanguage);
        model.Text.Should().Be(text);
    }

    [Fact]
    public void Should_Update_Text_Property()
    {
        // Arrange
        var sourceLanguage = "en";
        var targetLanguage = "es";
        var initialText = "Hello World";
        var updatedText = "Hola Mundo";

        var model = new TranslateModel(sourceLanguage, targetLanguage, initialText);

        // Act
        model.SetText(updatedText);

        // Assert
        model.Text.Should().Be(updatedText);
    }

    [Fact]
    public void Should_Not_ThrowException_WhenTextIsNull()
    {
        // Arrange
        var sourceLanguage = "en";
        var targetLanguage = "es";
        var initialText = "Hello World";

        var model = new TranslateModel(sourceLanguage, targetLanguage, initialText);

        // Act
        var act = () => model.SetText(null);

        // Assert
        act.Should().NotThrow();
        model.Text.Should().BeNull();
    }
}