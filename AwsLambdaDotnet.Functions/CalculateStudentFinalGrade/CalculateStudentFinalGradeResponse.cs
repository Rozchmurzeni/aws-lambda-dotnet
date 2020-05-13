namespace AwsLambdaDotnet.Functions.CalculateStudentFinalGrade
{
    public class CalculateStudentFinalGradeResponse
    {
        public double FinalGrade { get; set; }
        public bool HasPassed { get; set; }
    }
}
