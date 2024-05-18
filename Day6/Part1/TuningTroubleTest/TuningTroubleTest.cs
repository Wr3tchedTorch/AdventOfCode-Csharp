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

    [Fact]
    public void TestThirdSample() => new TuningTrouble($"{basePath}/files/thirdSample.txt").GetStartOfPacketMarker().Should().Be(10);

    [Fact]
    public void TestFourthSample() => new TuningTrouble($"{basePath}/files/fourthSample.txt").GetStartOfPacketMarker().Should().Be(11);

    [Fact]
    public void TestPuzzleSample() => new TuningTrouble($"{basePath}/files/puzzleSample.txt").GetStartOfPacketMarker().Should().Be(1361);
}