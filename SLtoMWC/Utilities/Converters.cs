using System;
namespace SLtoMWC.Utilities
{
    public static class Converters
    {
        public static double PoundsToKg(double pounds)
        {
            return pounds * 0.453592d;
        }

        public static double KgToPounds(double kg)
        {
            return kg * 2.20462d;
        }

        public static int ProgramNameToMWCId(string programName)
        {
            switch (programName.ToLower())
            {
                case "starting strength - phase 1":
                    return 1;
                case "starting strength - phase 2":
                    return 2;
                case "starting strength - phase 3":
                    return 3;
                case "stronglifts 5x5":
                    return 4;
                case "push pull legs":
                    return 5;
                case "boring but big - variation 1":
                    return 6;
                case "boring but big - variation 2":
                    return 7;
                case "boring but big - first set last":
                    return 8;
                case "greyskull lp with arms":
                    return 9;
                case "greyskull lp - phraks variant":
                    return 10;
                case "lvysaur's beginner 4-4-8 program":
                    return 11;
                case "practical programming":
                    return 12;
                case "practical programming - alternative version":
                    return 13;
                case "practical programming for advanced novice":
                    return 14;
                case "beginner 5/3/1 3 day program":
                    return 15;
                case "the triumvirate":
                    return 16;
                case "i’m not doing jack shit":
                    return 17;
                case "periodization bible":
                    return 18;
                case "bodyweight":
                    return 19;
                case "bodybuilder (from men's fitness)":
                    return 20;
                case "bodybuilder (from blood and chalk 8 and wendler's blog)":
                    return 21;
                case "nsuns 531 lp 4 day version":
                    return 22;
                case "nsuns 531 lp 5 day version":
                    return 23;
                case "nsuns 531 lp 6 day squat version":
                    return 24;
                case "nsuns 531 lp 6 day deadlift version":
                    return 25;
                case "madcow 5x5 training program - overhead press version":
                    return 26;
                case "madcow 5x5 training program - incline press version":
                    return 27;
                case "texas method":
                    return 28;
                case "wendler + smolov 753":
                    return 29;
                case "wendler + smolov jr. 543":
                    return 30;
                default:
                    return 0;
            }
        }

        public static int ExerciseNameToMWCId(string exerciseName)
        {
            switch (exerciseName.ToLower())
            {
                case "front dumbbell raises":
                    return 1;
                case "squat":
                    return 2;
                case "overhead press":
                    return 3;
                case "deadlift":
                    return 4;
                case "bench press":
                    return 5;
                case "barbell row":
                    return 6;
                case "dumbbell row":
                    return 7;
                case "chinups":
                    return 8;
                case "curls":
                    return 9;
                case "dips":
                    return 10;
                case "close grip bench press":
                    return 11;
                case "leg press":
                    return 12;
                case "calf raises":
                    return 13;
                case "pull ups":
                    return 14;
                case "rack chins":
                    return 15;
                case "dumbbell bench press":
                    return 16;
                case "dumbbell shoulder press":
                    return 17;
                case "skull crushers":
                    return 18;
                case "hack squats":
                    return 19;
                case "stiff legged deadlift":
                    return 20;
                case "standing leg curls":
                    return 21;
                case "standing calf raises":
                    return 22;
                case "seated calf raises":
                    return 23;
                case "cable row":
                    return 24;
                case "close grip pulldown":
                    return 25;
                case "upright row":
                    return 26;
                case "side lateral raise":
                    return 27;
                case "leg extension":
                    return 28;
                case "romanian deadlift":
                    return 29;
                case "lying leg curls":
                    return 30;
                case "seated leg curls":
                    return 31;
                case "donkey calf raises":
                    return 32;
                case "incline dumbbell press":
                    return 33;
                case "hammer strength chest press":
                    return 34;
                case "incline cable flyes":
                    return 35;
                case "preacher curls":
                    return 36;
                case "dumbbell concentration curls":
                    return 37;
                case "spider curls":
                    return 38;
                case "seated tricep extension":
                    return 39;
                case "cable pushdown":
                    return 40;
                case "power clean":
                    return 41;
                case "cable kickbacks":
                    return 42;
                case "crunches":
                    return 43;
                case "hanging leg raises":
                    return 44;
                case "lying leg raises":
                    return 45;
                case "plank":
                    return 46;
                case "side plank":
                    return 47;
                case "shrugs":
                    return 48;
                case "good mornings":
                    return 49;
                case "decline bench press":
                    return 50;
                case "reverse grip bent over rows":
                    return 51;
                case "one-legged squats":
                    return 52;
                case "standing overhead triceps extension":
                    return 53;
                case "lying triceps press":
                    return 54;
                case "reverse lunges":
                    return 55;
                case "ab rollout":
                    return 56;
                case "front squat":
                    return 57;
                case "standing tricep extension":
                    return 58;
                case "push up":
                    return 59;
                case "sit ups":
                    return 60;
                case "glute ham raise":
                    return 61;
                case "back extension":
                    return 62;
                case "tricep pushdown":
                    return 63;
                case "face pull":
                    return 64;
                case "bent over dumbbell raise":
                    return 65;
                case "one legged squat":
                    return 66;
                case "chest supported rows":
                    return 67;
                case "ab wheel":
                    return 68;
                case "dumbbell fly":
                    return 69;
                case "rear lateral raise":
                    return 70;
                case "blast strap pushup":
                    return 71;
                case "sumo deadlift":
                    return 72;
                case "incline bench press":
                    return 73;
                case "lat pulldowns":
                    return 74;
                default:
                    return 0;
            }
        }
    }
}
