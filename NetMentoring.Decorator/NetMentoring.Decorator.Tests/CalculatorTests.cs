using FluentAssertions;
using NetMentoring.Decorator.Calculator.Builder;
using System;
using Xunit;

namespace NetMentoring.Decorator.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator.Calculator _defaultCalculator;

        public CalculatorTests()
        {
            _defaultCalculator = new CalculatorBuilder()
                .AddDefaultOperations()
                .Build();
        }

        [Fact]
        public void CanAddTwoNumbers()
        {
            _defaultCalculator
                .Perform("+", 5)
                .Perform("+", 5)
                .Result
                .Should()
                .Be(10);
        }

        [Fact]
        public void CanMultiplyTwoNumbers()
        {
            _defaultCalculator
                .Perform("+", 5)
                .Perform("*", 5)
                .Result
                .Should()
                .Be(25);
        }

        [Fact]
        public void CanDivideTwoNumbers()
        {
            _defaultCalculator
                .Perform("+", 5)
                .Perform("/", 5)
                .Result
                .Should()
                .Be(1);
        }

        [Fact]
        public void CanSubtractTwoNumbers()
        {
            _defaultCalculator
                .Perform("+", 5)
                .Perform("-", 5)
                .Result
                .Should()
                .Be(0);
        }

        [Fact]
        public void CanExtendWithSquareRoot()
        {
            var calculator = new CalculatorBuilder()
                .AddDefaultOperations()
                .AddOperation("root", (prev, arg) => Math.Pow(prev, 1 / arg))
                .Build();

            calculator.Perform("+", 4)
                .Perform("root", 2)
                .Result
                .Should()
                .Be(2);
        }

        [Fact]
        public void CanExtendWithSquare()
        {
            var calculator = new CalculatorBuilder()
                .AddDefaultOperations()
                .AddOperation("^", (prev, arg) => Math.Pow(prev, arg))
                .Build();

            calculator.Perform("+", 4)
                .Perform("^", 2)
                .Result
                .Should()
                .Be(16);
        }

        [Fact]
        public void CanExtendWithAnyPower()
        {
            var calculator = new CalculatorBuilder()
                .AddDefaultOperations()
                .AddOperation("^", (prev, arg) => Math.Pow(prev, arg))
                .Build();

            calculator.Perform("+", 3)
                .Perform("^", 3)
                .Result
                .Should()
                .Be(27);
        }

        [Fact]
        public void CanPerformSequenceOfOperations()
        {
            _defaultCalculator
                .Perform("+", 3) // 3
                .Perform("*", 3) // 9
                .Perform("+", 1) // 10
                .Perform("/", 5) // 2
                .Perform("-", 1) // 1
                .Result
                .Should()
                .Be(1);
        }
    }
}
