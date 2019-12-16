using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetfinal.Models;
using SQLite;

namespace dotnetfinal.Data
{
    public class PhysioReachDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public PhysioReachDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserActivity>().Wait();
        }

        public Task<List<UserActivity>> GetUserActivitiesAsync() => _database.Table<UserActivity>().ToListAsync();

        public Task<UserActivity> GetUserActivityAsync(int id)
        {
            return _database.Table<UserActivity>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveUserActivityAsync(UserActivity userActivity)
        {
            if (userActivity.ID != 0)
            {
                return _database.UpdateAsync(userActivity);
            }
            return _database.InsertAsync(userActivity);
        }

        public Task<int> DeleteUserActivityAsync(UserActivity userActivity) => _database.DeleteAsync(userActivity);
    }
}
