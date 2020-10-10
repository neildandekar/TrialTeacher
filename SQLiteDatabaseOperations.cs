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
            sqliteDB = db.WritableDatabase;
            byte[] soundArray = new byte[25000];
            try
            {
                ICursor selectData = sqliteDB.RawQuery("SELECT sound FROM sounds where name = 'कमल' ", new string[] { });
                if (selectData.Count > 0)
                {
                    selectData.MoveToFirst();
                    do
                    {

                        soundArray = selectData.GetBlob(0);
                    }
                    while (selectData.MoveToNext());
                    selectData.Close();
                }
                return soundArray;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
