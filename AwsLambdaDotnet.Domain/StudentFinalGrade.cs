namespace AwsLambdaDotnet.Domain
{
    public class StudentFinalGrade
    {
        private const double LectureWeight = 0.2d;
        private const double ExerciseWeight = 0.3d;
        private const double WorkshopWeight = 0.5d;

        public double Value { get; }
        public bool HasPassed { get; }

        public StudentFinalGrade(StudentGrade lectureGrade, StudentGrade exerciseGrade, StudentGrade workshopGrade)
        {
            Value = LectureWeight * lectureGrade.Value
                  + ExerciseWeight * exerciseGrade.Value
                  + WorkshopWeight * workshopGrade.Value;

            HasPassed = Value >= 3;
        }
    }
}
