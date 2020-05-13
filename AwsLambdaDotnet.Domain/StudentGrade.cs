using System;

namespace AwsLambdaDotnet.Domain
{
    public class StudentGrade
    {
        public double Value { get; }

        public StudentGrade(double value)
        {
            if (value < 2 || value > 5)
            {
                throw new ArgumentException("Wrong grade value.");
            }

            Value = value;
        }
    }
}
