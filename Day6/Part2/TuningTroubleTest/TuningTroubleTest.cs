using Domain;
using FluentAssertions;

namespace TuningTroubleTest;

public class TuningTroubleTest
{
    string basePath = Path.GetFullPath("./").Replace(@"\bin\Debug\net8.0\", "");

    [Fact]
    public void TestFirstSamplePackageMarker() => new TuningTrouble($"{basePath}/files/firstSample.txt").GetStartOfPacketMarker().Should().Be(5);
    [Fact]
    public void TestSecondSamplePackageMarker() => new TuningTrouble($"{basePath}/files/secondSample.txt").GetStartOfPacketMarker().Should().Be(6);
    [Fact]
    public void TestThirdSamplePackageMarker() => new TuningTrouble($"{basePath}/files/thirdSample.txt").GetStartOfPacketMarker().Should().Be(10);
    [Fact]
    public void TestFourthSamplePackageMarker() => new TuningTrouble($"{basePath}/files/fourthSample.txt").GetStartOfPacketMarker().Should().Be(11);
    [Fact]
    public void TestPuzzlePackageMarker() => new TuningTrouble($"{basePath}/files/puzzleSample.txt").GetStartOfPacketMarker().Should().Be(1361);
    
    [Fact]
    public void TestFirstSampleMessageMarker() => new TuningTrouble($"{basePath}/files/firstSample.txt").GetStartOfMessageMarker().Should().Be(23);
    [Fact]
    public void TestSecondSampleMessageMarker() => new TuningTrouble($"{basePath}/files/secondSample.txt").GetStartOfMessageMarker().Should().Be(23);
    [Fact]
    public void TestPuzzleMessageMarker() => new TuningTrouble($"{basePath}/files/puzzleSample.txt").GetStartOfMessageMarker().Should().Be(3263);
}