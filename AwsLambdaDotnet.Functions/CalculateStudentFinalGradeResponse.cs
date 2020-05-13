namespace AwsLambdaDotnet.Functions
{
    public class CalculateStudentFinalGradeResponse
    {
        public double FinalGrade { get; set; }
        public bool HasPassed { get; set; }
    }
}
