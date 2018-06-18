using System;
using System.Collections.Generic;
using System.Linq;
namespace SLtoMWC.Backups
{
    public class Workout
    {
        public Workout(DateTime when, double bodyWeightInKg, double bodyWeightInLbs, List<Exercise> exercises)
        {
            When = when;
            BodyWeightInKg = bodyWeightInKg;
            BodyWeightInLbs = bodyWeightInLbs;
            Exercises = exercises;
        }

        public DateTime When { get; set; }

        public double BodyWeightInKg { get; set; }
        public double BodyWeightInLbs { get; set; }

        public int ExerciseCount
        {
            get
            {
                return Exercises.Count;
            }
        }


        private List<Exercise> exercises;
        public List<Exercise> Exercises
        {
            get
            {
                if (exercises == null)
                {
                    exercises = new List<Exercise>();
                }

                return exercises;
            }
            set
            {
                exercises = value;
            }
        }

        public string ToString()
        {
            return string.Format("Date={0}, BodyWeightKg={1}, BodyWeightLbs={2}, ExerciseCount={3}", When, BodyWeightInKg, BodyWeightInLbs, ExerciseCount);
        }
    }
}
