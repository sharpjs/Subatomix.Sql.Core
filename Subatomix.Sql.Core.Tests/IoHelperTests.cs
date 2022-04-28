using System.Text;

namespace Subatomix.Sql.Core;

[TestFixture]
internal class IoHelperTests
{
    [Test]
    public void HasExceptionFallbacks_True()
    {
        var encoding = (Encoding) Encoding.UTF8.Clone();
        encoding.EncoderFallback = EncoderFallback.ExceptionFallback;
        encoding.DecoderFallback = DecoderFallback.ExceptionFallback;

        IoHelper.HasExceptionFallbacks(encoding).Should().BeTrue();
    }

    [Test]
    public void HasExceptionFallbacks_FalseViaEncoder()
    {
        var encoding = (Encoding) Encoding.UTF8.Clone();
        encoding.EncoderFallback = EncoderFallback.ReplacementFallback;
        encoding.DecoderFallback = DecoderFallback.ExceptionFallback;

        IoHelper.HasExceptionFallbacks(encoding).Should().BeFalse();
    }

    [Test]
    public void HasExceptionFallbacks_FalseViaDecoder()
    {
        var encoding = (Encoding) Encoding.UTF8.Clone();
        encoding.EncoderFallback = EncoderFallback.ExceptionFallback;
        encoding.DecoderFallback = DecoderFallback.ReplacementFallback;

        IoHelper.HasExceptionFallbacks(encoding).Should().BeFalse();
    }
}
