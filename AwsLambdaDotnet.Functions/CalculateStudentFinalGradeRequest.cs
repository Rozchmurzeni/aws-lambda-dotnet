namespace AwsLambdaDotnet.Functions
{
    public class CalculateStudentFinalGradeRequest
    {
        public double LectureGrade { get; set; }
        public double ExerciseGrade { get; set; }
        public double WorkshopGrade { get; set; }
    }
}
