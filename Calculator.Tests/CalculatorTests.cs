using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        CalculatorEngine _calculator;
        public CalculatorTests()
        {
            _calculator = new CalculatorEngine();
        }

        [Fact]
        public void should_first_test_pass()
        {
            Assert.True(10 == 10);
        }

        [Fact]
        public void should_return_zero_given_empty()
        {
            // Arrange
            var calculator = new CalculatorEngine();
            var expected = 0;
            // Act
            var result = calculator.Add("");

            // Assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void should_return_number_given_single_number()
        {
            // Arrange
            var calculator = new CalculatorEngine();
            var expected = 5;
            // Act
            var result = calculator.Add("5");

            // Assert
            Assert.Equal(result, expected);
        }

        [Fact(DisplayName ="Should throw error given non-numeric")]
        public void should_throw_exception_given_nonnumeric_input()
        {
            // Arrange
            var calculator = new CalculatorEngine();
            // Act
          
            // Assert
            Assert.Throws<ArgumentException>( () => calculator.Add("5s"));
        }

        // calculator.Add("5, 10")  => 15
        // calculator.Add("5, ")  => 5

        [Fact(DisplayName ="Should sum numbers comma sep.")]
        public void should_return_sum_of_comma_separated_values()
        {
            // Arrange
            var calculator = new CalculatorEngine();
            var expected = 25;
            // Act
            var result = calculator.Add("5,10 , 10");

            // Assert
            Assert.Equal(result, expected);
        }

        [Theory(DisplayName = "Should sum numbers comma sep.")]
        [InlineData("5, ", 5)]
        [InlineData("5, 10", 15)]
        [InlineData("5, 10, 20", 35)]
        public void should_return_sum_of_comma_separated_values_given_empty(string numbers, int expected)
        {
            // Arrange
            var calculator = new CalculatorEngine();

            // Act
            var result = calculator.Add(numbers);

            // Assert
            expected.ShouldBe(result);
        }

        [Fact(DisplayName = "Should throw exception on negative number")]
        public void should_throw_error_given_negative_number()
        {
            // Arrange
            var calculator = new CalculatorEngine();
            // Act
            // Assert
            Should.Throw<ArgumentException>(() => calculator.Add("-5, 10"));
        }
    }
}
