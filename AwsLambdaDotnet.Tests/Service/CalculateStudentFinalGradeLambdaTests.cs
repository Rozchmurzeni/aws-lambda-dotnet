using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using AwsLambdaDotnet.Functions.CalculateStudentFinalGrade;
using FluentAssertions;
using Xunit;

namespace AwsLambdaDotnet.Tests.Service
{
    public class CalculateStudentFinalGradeLambdaTests
    {
        private readonly IAmazonLambda _lambdaClient = new AmazonLambdaClient();
        private const string CalculateStudentFinalGradeLambdaName = "calculate-student-grade-lambda";

        [Fact]
        public async Task InvokeLambda_WithCorrectParameters_ShouldReturnCorrectResponse()
        {
            // Given
            const double validExerciseGrade = 3.5;
            const double validLectureGrade = 2.1;
            const double validWorkshopGrade = 4.9;

            var requestModel = new CalculateStudentFinalGradeRequest
            {
                ExerciseGrade = validExerciseGrade,
                LectureGrade = validLectureGrade,
                WorkshopGrade = validWorkshopGrade
            };

            var lambdaRequest = new InvokeRequest
            {
                FunctionName = CalculateStudentFinalGradeLambdaName,
                Payload = JsonSerializer.Serialize(requestModel)
            };

            // When
            var lambdaResponse = await _lambdaClient.InvokeAsync(lambdaRequest);

            // Then
            var responseModel = await JsonSerializer.DeserializeAsync<CalculateStudentFinalGradeResponse>(lambdaResponse.Payload);
            responseModel.Should().NotBeNull();
            responseModel.FinalGrade.Should().NotBe(default);
            responseModel.HasPassed.Should().BeTrue();
        }

        [Fact]
        public async Task InvokeLambda_WithIncorrectParameters_ShouldReturnLambdaError()
        {
            // Given
            const string expectedFunctionError = "Unhandled";
            const double validExerciseGrade = 0;
            const double validLectureGrade = -1;
            const double validWorkshopGrade = 10;

            var requestModel = new CalculateStudentFinalGradeRequest
            {
                ExerciseGrade = validExerciseGrade,
                LectureGrade = validLectureGrade,
                WorkshopGrade = validWorkshopGrade
            };

            var lambdaRequest = new InvokeRequest
            {
                FunctionName = CalculateStudentFinalGradeLambdaName,
                Payload = JsonSerializer.Serialize(requestModel)
            };

            // When
            var lambdaResponse = await _lambdaClient.InvokeAsync(lambdaRequest);

            // Then
            lambdaResponse.FunctionError.Should().Be(expectedFunctionError);
        }
    }
}
