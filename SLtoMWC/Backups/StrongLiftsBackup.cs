using System;
using System.Collections.Generic;
using System.IO;

using SLtoMWC.Utilities;
namespace SLtoMWC.Backups
{
    public class StrongLiftsBackup
    {
        public StrongLiftsBackup(List<Workout> workouts)
        {
            Workouts = workouts;
        }

        private List<Workout> workouts;
        public List<Workout> Workouts
        {
            get
            {
                if (workouts == null)
                {
                    workouts = new List<Workout>();
                }

                return workouts;
            }
            set
            {
                workouts = value;
            }
        }

        public static StrongLiftsBackup LoadFromCSV(string csvPath)
        {
            List<Workout> csvWorkouts = new List<Workout>();

            int dateCol = 0;
            int bodyWeightKgCol = 2;
            int bodyWeightLbsCol = 3;

            List<int> exerciseStartColumns = new List<int>();

            try
            {
                using (StreamReader sr = new StreamReader(csvPath)) 
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lineSplits = line.Split(',');

                        if (lineSplits.Length < 28)
                        {
                            throw new Exception("There aren't enough columns to import");
                        }

                        string dateStr = lineSplits[dateCol];
                        if (string.IsNullOrWhiteSpace(dateStr) == false && string.Compare(dateStr, "Date", true) == 0)
                        {
                            // identify exercise layout assuming date and body weight columns are 0, 2, and 3

                            for (int i = 0; i < lineSplits.Length; i++)
                            {
                                string columnHeader = lineSplits[i];
                                if (string.IsNullOrWhiteSpace(columnHeader))
                                {
                                    continue;
                                }

                                if (columnHeader.ToLower().Contains("exercise"))
                                {
                                    exerciseStartColumns.Add(i);
                                }
                            }


                            if (exerciseStartColumns.Count < 3)
                            {
                                throw new Exception("There aren't enough exercises to import");
                            }

                            continue;
                        }

                        DateTime date;
                        DateTime.TryParse(dateStr, out date);

                        double bodyWeightKg;
                        Double.TryParse(lineSplits[bodyWeightKgCol], out bodyWeightKg);

                        double bodyWeightLbs;
                        Double.TryParse(lineSplits[bodyWeightLbsCol], out bodyWeightLbs);

                        if (bodyWeightKg.Equals(0d) && bodyWeightLbs.Equals(0d) == false)
                        {
                            bodyWeightKg = Converters.PoundsToKg(bodyWeightLbs);
                        }

                        if (bodyWeightLbs.Equals(0d) && bodyWeightKg.Equals(0d) == false)
                        {
                            bodyWeightKg = Converters.KgToPounds(bodyWeightKg);
                        }

                        // Exercise record pattern is
                        // StartColumn = Name
                        // StartColumn + 1 = weight in KG
                        // StartColumn + 2 = weight in LBS
                        // (NextStartColumn OR (LISTCOUNT - 1)) - StartColumn - 3 = Set Count
                        // StartColumn + 3 = Set 1
                        // StartColumn + 4 = Set 2
                        // StartColumn + 5 = Set 3
                        // ...
                        // StartColumn + n = Set i

                        List<Exercise> exercises = new List<Exercise>();

                        for (int i = 0; i < exerciseStartColumns.Count; i++)
                        {
                            int exerciseStart = exerciseStartColumns[i];

                            string exerciseName = lineSplits[exerciseStart];

                            if (string.IsNullOrWhiteSpace(exerciseName))
                            {
                                continue;
                            }

                            double exerciseWeightKg;
                            Double.TryParse(lineSplits[exerciseStart + 1], out exerciseWeightKg);

                            double exerciseWeightLbs;
                            Double.TryParse(lineSplits[exerciseStart + 2], out exerciseWeightLbs);

                            if (exerciseWeightKg.Equals(0d) && exerciseWeightLbs.Equals(0d) == false)
                            {
                                exerciseWeightKg = Converters.PoundsToKg(exerciseWeightLbs);
                            }

                            if (exerciseWeightLbs.Equals(0d) && exerciseWeightKg.Equals(0d) == false)
                            {
                                exerciseWeightKg = Converters.KgToPounds(exerciseWeightKg);
                            }

                            int nextExerciseStart = -1;
                            if (i == exerciseStartColumns.Count - 1)
                            {
                                nextExerciseStart = lineSplits.Length - 1;
                            }
                            else
                            {
                                nextExerciseStart = exerciseStartColumns[i + 1];
                            }

                            int setCount = nextExerciseStart - exerciseStart - 3;

                            List<Set> sets = new List<Set>();

                            for (int j = 0; j < setCount; j++)
                            {
                                int repCount;
                                int.TryParse(lineSplits[exerciseStart + 3 + j], out repCount);

                                if (repCount == 0)
                                {
                                    continue;
                                }

                                Set set = new Set(repCount);
                                sets.Add(set);
                            }

                            if (sets.Count == 0)
                            {
                                continue;
                            }

                            Exercise exercise = new Exercise(exerciseName, exerciseWeightKg, exerciseWeightLbs, sets);

                            exercises.Add(exercise);
                        }

                        Workout workout = new Workout(date, bodyWeightKg, bodyWeightLbs, exercises);

#if DEBUG
                        Console.WriteLine("\r\n" + workout.ToString());
                        foreach (Exercise exercise in exercises)
                        {
                            Console.WriteLine(exercise.ToString());
                        }
#endif
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Exception during SL load: {0}", e);
            }

            return new StrongLiftsBackup(csvWorkouts);
        }
    }
}
