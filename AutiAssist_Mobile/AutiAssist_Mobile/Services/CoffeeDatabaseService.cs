using AutiAssist_Mobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutiAssist_Mobile.Services
{
    class CoffeeDatabaseService
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<CoffeeDatabaseService> Instance = new AsyncLazy<CoffeeDatabaseService>(async () =>
        {
            var instance = new CoffeeDatabaseService();
            CreateTableResult result = await Database.CreateTableAsync<Coffee>();
            return instance;
        });

        public CoffeeDatabaseService()
        {
            Database = new SQLiteAsyncConnection(Config.DatabasePath, Config.Flags);
        }

        public Task<int> AddCoffee(string name, string roaster)
        {
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            var coffee = new Coffee
            {
                Name = name,
                Roaster = roaster,
                Image = image
            };

            return Database.InsertAsync(coffee);
        }
        public Task<int> RemoveCoffee(int id)
        {
            return Database.DeleteAsync<Coffee>(id);
        }
        public Task<List<Coffee>> GetCoffee()
        {
            return Database.Table<Coffee>().ToListAsync();
        }


    }
}
