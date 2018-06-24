using FluentAssertions;
using NetMentoring.Decorator.Calculation;
using System;
using Xunit;

namespace NetMentoring.Decorator.Tests
{
    public class CalculationServiceTests
    {
        [Fact]
        public void CalculationService_ShouldPerformCalculation ()
        {
            var sut = new CalculationService();

            sut.Calculate(1, 2).Should().Be(17);
        }

        [Fact]
        public void CachedCalculationService_ShouldNotDoRequest_WhenValueIsCached()
        {
            var sut = new CachedCalculationService(new CalculationService());

            Action calculation = () => sut.Calculate(1, 2);

            calculation();

            calculation.ExecutionTime().Should().BeLessThan(TimeSpan.FromMilliseconds(10));
        }

        [Fact]
        public void CorrectedCalculationService_ShouldCorrectResult()
        {
            var sut = new CorrectedCalculationService(new CalculationService());

            Action calculation = () => sut.Calculate(1, 2);

            sut.Calculate(1, 2).Should().Be(27);
        }

        [Fact]
        public void DecoratedCorrectedCalculationService_ShouldUseCache()
        {
            var sut = new CorrectedCalculationService(new CachedCalculationService(new CalculationService()));

            Action calculation = () => sut.Calculate(1, 2);

            calculation();

            calculation.ExecutionTime().Should().BeLessThan(TimeSpan.FromMilliseconds(10));
        }
    }
}
