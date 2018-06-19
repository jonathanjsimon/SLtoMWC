using System;
using System.Data.SQLite;

namespace SLtoMWC.Backups
{
    public class MWCDataSource
    {
        //string connectionString = @"Data Source=PATH_TO_DB_FILE\...\file.ABC; Version=3; FailIfMissing=True; Foreign Keys=True;";
        string connectionStringFormat = @"Data Source={0}; Foreign Keys=True;";
        string connectionString;
        public MWCDataSource(string dbPath)
        {
            this.connectionString = string.Format(connectionStringFormat, dbPath);
        }

        public int HistoryCount
        {
            get
            {
                int count = 0;
                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();

                        string sql = "select count(*) from history";
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                        {
                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    count = reader.GetInt16(0);
                                }
                            }
                        }
                        conn.Close();
                    }
                }
                catch (SQLiteException e)
                {
                    int k = 12;
                }
                return count;
            }
        }
    }
}
