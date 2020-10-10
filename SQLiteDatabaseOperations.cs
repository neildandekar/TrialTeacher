using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using Android.App;
using Android.Database.Sqlite;
using Android.Database;
using System.Text;

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
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT image FROM Images where trim(name) = ");
                sb.Append("'");
                sb.Append(key);
                sb.Append("' ");
                ICursor selectData = sqliteDB.RawQuery(sb.ToString(), null);
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
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT sound FROM sounds where trim(name) = ");
                sb.Append(" '");
                sb.Append(key);
                sb.Append("' ");
                ICursor selectData = sqliteDB.RawQuery(sb.ToString(), null);
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
        public List<string> getNames()
        {
            sqliteDB = db.WritableDatabase;
            List<string> names = new List<string>();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT name FROM sounds");
                ICursor selectData = sqliteDB.RawQuery(sb.ToString(), null);
                if (selectData.Count > 0)
                {
                    selectData.MoveToFirst();
                    do
                    {

                        names.Add(selectData.GetString(0));
                    }
                    while (selectData.MoveToNext());
                    selectData.Close();
                }
                return names;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
