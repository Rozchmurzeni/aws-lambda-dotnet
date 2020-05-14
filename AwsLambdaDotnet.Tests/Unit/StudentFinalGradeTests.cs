using AwsLambdaDotnet.Domain;
using FluentAssertions;
using Xunit;

namespace AwsLambdaDotnet.Tests.Unit
{
    public class StudentFinalGradeTests
    {
        public static TheoryData<StudentGrade, StudentGrade, StudentGrade, double, bool> TestCases = new TheoryData<StudentGrade, StudentGrade, StudentGrade, double, bool>
        {
            { new StudentGrade(3), new StudentGrade(3), new StudentGrade(3), 3, true },
            { new StudentGrade(5), new StudentGrade(5), new StudentGrade(5), 5, true },
            { new StudentGrade(2), new StudentGrade(2), new StudentGrade(2), 2, false },
            { new StudentGrade(3.7), new StudentGrade(4.4), new StudentGrade(4.2), 4, true }
        };

        [Theory]
        [MemberData(nameof(TestCases))]
        public void CreateObject_WithGivenGrades_ShouldCalculateCorrectlyFinalGradeAndHasPassedFlag(
            StudentGrade lectureGrade,
            StudentGrade exerciseGrade,
            StudentGrade workshopGrade,
            double expectedFinalGradeValue,
            bool expectedHasPassed
        )
        {
            // When
            var finalGrade = new StudentFinalGrade(lectureGrade, exerciseGrade, workshopGrade);

            // Then
            finalGrade.Should().NotBeNull();
            finalGrade.Value.Should().Be(expectedFinalGradeValue);
            finalGrade.HasPassed.Should().Be(expectedHasPassed);
        }
    }
}
