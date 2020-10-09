using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using Android.App;
using Android.Database.Sqlite;
using Android.Database;

namespace TrialTeacher

{
    class SQLiteDatabaseOperations
    {
        DBHelper db = new DBHelper(Application.Context);
        SQLiteDatabase sqliteDB; 
        public SQLiteDatabaseOperations()
        {

        }
        public int SaveImageRecord(byte[] ba, string name)
        {
            try { 
            string cs = @"URI=file:d:\hottots.db";
            SQLiteConnection conn = new SQLiteConnection(cs);
            conn.Open();
            string sqlQuery = "insert into Images (name,image)values(@a,@d)";
            SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn);
            cmd.Parameters.AddWithValue("@a", name);
            cmd.Parameters.AddWithValue("@d", ba);
            return cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }

        }
        public int SaveSoundRecord(byte[] ba,string name)
        {
            try
            {
                string cs = @"URI=file:d:\hottots.db";
                SQLiteConnection conn = new SQLiteConnection(cs);
                conn.Open();
                string sqlQuery = "insert into Sounds (sound,name)values(@s,@n)";
                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@s", ba);
                cmd.Parameters.AddWithValue("@n", name);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }

        }
        public byte[] getImage(string key)
        {
            sqliteDB = db.WritableDatabase;
            byte[] imageArray = new byte[25000];
            try
            {
                ICursor selectData = sqliteDB.RawQuery("SELECT image FROM Images where name = 'कमल' ", new string[] { });
                if (selectData.Count > 0)
                {
                    selectData.MoveToFirst();
                    do
                    {
                        
                        imageArray = selectData.GetBlob(0);
                    }
                    while (selectData.MoveToNext());
                    selectData.Close();
                }
                return imageArray;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public byte[] getSound(string key)
        {
         try
            {
                string cs = @"URI=file:d:\hottots.db";
                SQLiteConnection conn = new SQLiteConnection(cs);
                conn.Open();
                string sqlQuery = "SELECT sound FROM sounds where name = @n ";
                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@n", key);
                SQLiteDataReader reader = cmd.ExecuteReader();
                List<byte[]> records = new List<byte[]>();
                while (reader.Read())
                {
                    byte[] soundArray = new byte[60000];
                    reader.GetBytes(0, 0, soundArray, 0, 60000);
                    records.Add(soundArray);
                }
                return records[0];

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
}

    }
}
