using System;
using System.Collections.Generic;
using System.Linq;
namespace SLtoMWC.Utilities
{
    public class Exercise
    {
        public Exercise(string name, double weightInKg, double weightInLbs, List<Set> sets)
        {
            Name = name;
            WeightInKg = weightInKg;
            WeightInLbs = weightInLbs;
            Sets = sets;
        }

        public string Name { get; set; }
        public double WeightInKg { get; set; }
        public double WeightInLbs { get; set; }
        public int TotalSets
        {
            get
            {
                return this.Sets.Count;
            }
        }

        private List<Set> sets;
        public List<Set> Sets
        {
            get
            {
                if (sets == null)
                {
                    sets = new List<Set>();
                }

                return sets;
            }
            set
            {
                sets = value;
            }
        }

        public int MWCId
        {
            get
            {
                return Converters.ExerciseNameToMWCId(Name);
            }
        }

        public string ToString()
        {
            return string.Format("Name={0}, MWCId={1}, WeightKg={2}, WeightLbs={3}, Sets={4}, SetRepCount={5}"
                                                                                                    ,Name
                                                                                                    ,MWCId
                                                                                                    ,WeightInKg
                                                                                                    ,WeightInLbs
                                                                                                    ,TotalSets
                                                                                                    ,string.Join(",", Sets.Select(s => s.Reps))
                                                                                                    );
        }

    }
}
