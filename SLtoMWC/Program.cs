using System;
using System.IO;
using NDesk.Options;
using SLtoMWC.Utilities;
using SLtoMWC.Backups;

namespace SLtoMWC
{
    class MainClass
    {
        static string execName = System.AppDomain.CurrentDomain.FriendlyName;
        static Version version = new Version("1.0.0.0");


        static bool verbose = false;
        static string csvPath = string.Empty;
        static string dbPath = string.Empty;

        static string workingDir = Directory.GetCurrentDirectory();
        public static void Main(string[] args)
        {

            try
            {
                p.Parse(args);

            }
            catch (OptionException)
            {
                Console.WriteLine("Try '{0} --help' for more information.", execName);
                return;
            }

#if DEBUG
            csvPath = "/Users/jsimon/Dropbox/Workouts/spreadsheet-stronglifts.csv";
            dbPath = "/Users/jsimon/Dropbox/Workouts/MyApp.db";
#endif


            StrongLiftsBackup slb = null;
            if (File.Exists(csvPath))
            {
                slb = StrongLiftsBackup.LoadFromCSV(csvPath);
            }

            // This doesn't work yet for dll reasons

            //if (File.Exists(dbPath))
            //{
            //    MWCDataSource mwcDataSource = new MWCDataSource(dbPath);
            //    int historyCount = mwcDataSource.HistoryCount;
            //    Console.WriteLine("History Count: {0}", historyCount);
            //}

            int strongliftsProgramId = Converters.ProgramNameToMWCId("StrongLifts 5x5");


        }

        private static void ShowHelp()
        {
            Console.WriteLine("{0} version {1}", execName, version.ToString());
            Console.WriteLine("Usage: {0} [OPTIONS]+", execName);
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }

        private static OptionSet p = new OptionSet()
        {
            {
                "p|csv=",
                "Relative or absolute path to Stronglifts export",
                v =>
                {
                    csvPath = v;
                }
            },
            {
                "o|db=",
                "Relative or absolute path to Personal Training Coach database",
                v =>
                {
                    dbPath = v;
                }
            },
            {
                "v",
                "Verbose mode",
                v =>
                {
                    verbose = v != null;
                }
            },
            {
                "h|help",
                "Show this help message and exit",
                v =>
                {
                    if (v != null)
                    {
                        ShowHelp();
                        Environment.Exit(0);
                    }
                }
            }
        };
    }
}
