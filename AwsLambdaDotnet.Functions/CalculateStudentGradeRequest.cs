namespace AwsLambdaDotnet.Functions
{
    public class CalculateStudentGradeRequest
    {
        public double LectureGrade { get; set; }
        public double ExerciseGrade { get; set; }
        public double WorkshopGrade { get; set; }
    }
}
