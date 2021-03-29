using AutiAssist_Mobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AutiAssist_Mobile.Services
{
    public static class CoffeeDataService
    {
        static SQLiteAsyncConnection database;
        static async Task Init()
        {
            if(database != null)
            {
                return;
            }

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            database = new SQLiteAsyncConnection(databasePath);

            await database.CreateTableAsync<Coffee>();
        }

        public static async Task AddCoffee(string name, string roaster)
        {
            await Init();
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            var coffee = new Coffee
            {
                Name = name,
                Roaster = roaster,
                Image = image
            };

            var id = await database.InsertAsync(coffee);
        }
        public static async Task RemoveCoffee(int id)
        {
            await Init();

            await database.DeleteAsync<Coffee>(id);
        }
        public static async Task<IEnumerable<Coffee>> GetCoffee()
        {
            await Init();

            var coffee = await database.Table<Coffee>().ToListAsync();
            return coffee;
        }
    }
}
