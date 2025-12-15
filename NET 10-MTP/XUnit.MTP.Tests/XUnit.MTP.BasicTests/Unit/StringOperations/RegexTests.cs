using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace XUnit.BasicTests.Unit.StringOperations;

[Trait("Category", "Unit")]
[Trait("Component", "String")]
public class RegexTests
{
    [Fact]
    public async Task Regex_EmailValidation_MatchesValidEmail()
    {
        await Task.Delay(100);
        var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        Assert.True(regex.IsMatch("test@example.com"));
    }

    [Fact]
    public async Task Regex_EmailValidation_RejectsInvalidEmail()
    {
        await Task.Delay(100);
        var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        Assert.False(regex.IsMatch("invalid.email"));
    }

    [Fact]
    public async Task Regex_PhoneNumber_MatchesValidFormat()
    {
        await Task.Delay(150);
        var regex = new Regex(@"^\d{3}-\d{3}-\d{4}$");
        Assert.True(regex.IsMatch("123-456-7890"));
    }

    [Fact]
    public async Task Regex_FindAllDigits_ReturnsMatches()
    {
        await Task.Delay(100);
        var regex = new Regex(@"\d+");
        var matches = regex.Matches("abc123def456");
        Assert.Equal(2, matches.Count);
    }

    [Fact]
    public async Task Regex_Replace_SubstitutesText()
    {
        await Task.Delay(120);
        var regex = new Regex(@"\d+");
        var result = regex.Replace("abc123def456", "X");
        Assert.Equal("abcXdefX", result);
    }

    [Fact]
    public async Task Regex_Split_DividesString()
    {
        await Task.Delay(100);
        var regex = new Regex(@"\s+");
        var parts = regex.Split("Hello   World  Test");
        Assert.Equal(3, parts.Length);
    }

    [Fact]
    public async Task Regex_CaseInsensitive_Matches()
    {
        await Task.Delay(100);
        var regex = new Regex(@"hello", RegexOptions.IgnoreCase);
        Assert.True(regex.IsMatch("HELLO"));
    }

    [Fact]
    public async Task Regex_Groups_CapturesSubstrings()
    {
        await Task.Delay(150);
        var regex = new Regex(@"(\d{3})-(\d{3})-(\d{4})");
        var match = regex.Match("123-456-7890");
        Assert.Equal("123", match.Groups[1].Value);
        Assert.Equal("456", match.Groups[2].Value);
        Assert.Equal("7890", match.Groups[3].Value);
    }

    [Fact]
    public async Task Regex_UrlExtraction_FindsUrls()
    {
        await Task.Delay(200);
        var regex = new Regex(@"https?://[^\s]+");
        var text = "Visit https://example.com or http://test.org";
        var matches = regex.Matches(text);
        Assert.Equal(2, matches.Count);
    }

    [Fact]
    public async Task Regex_ComplexPattern_HandlesMultiline()
    {
        await Task.Delay(150);
        var regex = new Regex(@"^Line\d+$", RegexOptions.Multiline);
        var text = "Line1\nLine2\nLine3";
        var matches = regex.Matches(text);
        Assert.Equal(3, matches.Count);
    }
}
