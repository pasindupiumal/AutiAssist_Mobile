using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace AutiAssist_Mobile
{
    public static class Config
    {
        public const string DatabaseFilename = "Coffees.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            //Open database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            //Create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            //Enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = FileSystem.AppDataDirectory;
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
