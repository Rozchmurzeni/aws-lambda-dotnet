using AwsLambdaDotnet.Domain;

namespace AwsLambdaDotnet.Functions
{
    public class CalculateStudentFinalGradeLambda
    {
        public CalculateStudentFinalGradeResponse Invoke(CalculateStudentFinalGradeRequest request)
        {
            var lectureGrade = new StudentGrade(request.LectureGrade);
            var exerciseGrade = new StudentGrade(request.ExerciseGrade);
            var workshopGrade = new StudentGrade(request.WorkshopGrade);
            var finalGrade = new StudentFinalGrade(lectureGrade, exerciseGrade, workshopGrade);

            return new CalculateStudentFinalGradeResponse
            {
                FinalGrade = finalGrade.Value,
                HasPassed = finalGrade.HasPassed
            };
        }
    }
}
