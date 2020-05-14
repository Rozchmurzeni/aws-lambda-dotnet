using System;
using AwsLambdaDotnet.Domain;
using FluentAssertions;
using Xunit;

namespace AwsLambdaDotnet.Tests.Unit
{
    public class StudentGradeTests
    {
        [Theory]
        [InlineData(1.9d)]
        [InlineData(5.1d)]
        public void CreateObject_WithIncorrectValue_ShouldThrowException(double value)
        {
            // When
            Func<StudentGrade> func = () => new StudentGrade(value);

            // Then
            func.Should().ThrowExactly<ArgumentException>();
        }

        [Theory]
        [InlineData(2.1d)]
        [InlineData(2d)]
        [InlineData(4.9d)]
        [InlineData(5d)]
        public void CreateObject_WithCorrectValue_ShouldCreateCorrectObject(double value)
        {
            // When
            var grade = new StudentGrade(value);

            // Then
            grade.Should().NotBeNull();
            grade.Value.Should().Be(value);
        }
    }
}
