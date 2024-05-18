using Domain;
using FluentAssertions;

namespace TuningTroubleTest;

public class TuningTroubleTest
{
    string basePath = Path.GetFullPath("./").Replace(@"\bin\Debug\net8.0\", "");

    [Fact]
    public void TestFirstSample() => new TuningTrouble($"{basePath}/files/firstSample.txt").GetStartOfPacketMarker().Should().Be(5);
    
    [Fact]
    public void TestSecondSample() => new TuningTrouble($"{basePath}/files/secondSample.txt").GetStartOfPacketMarker().Should().Be(6);
}