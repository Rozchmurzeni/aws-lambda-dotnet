using System;

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
            var rawFinalGrade = CalculateRawFinalGrade(lectureGrade, exerciseGrade, workshopGrade);
            Value = RoundToNearestHalf(rawFinalGrade);
            HasPassed = Value >= 3;
        }

        private static double RoundToNearestHalf(StudentGrade rawFinalGrade) => Math.Round(rawFinalGrade.Value * 2, MidpointRounding.AwayFromZero) / 2;

        private static StudentGrade CalculateRawFinalGrade(StudentGrade lectureGrade, StudentGrade exerciseGrade, StudentGrade workshopGrade)
            => new StudentGrade(
                LectureWeight * lectureGrade.Value
              + ExerciseWeight * exerciseGrade.Value
              + WorkshopWeight * workshopGrade.Value
            );
    }
}
