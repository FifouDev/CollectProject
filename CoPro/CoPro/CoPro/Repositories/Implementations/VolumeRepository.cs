
using CoPro.Models;
using CoPro.Repositories;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoPro.Repositories.Implementations
{
    public class VolumeRepository : IVolumeRepository
    {
        private SQLiteAsyncConnection _connection;

        public async Task InitializeAsync(string path, ISQLitePlatform sqlitePlatform)
        {
            _connection = SQLiteDataBase.GetConnection(path, sqlitePlatform);

            // Create MyEntity table if need be
            await _connection.CreateTableAsync<Volume>();
        }

        public async Task<Volume> CreateAsync(string name, string description)
        {
            var entity = new Volume()
            {
                Name = name,
                Description = description
            };
            var count = await _connection.InsertAsync(entity);
            return (count == 1) ? entity : null;
        }

        public async Task<IEnumerable<Volume>> GetAllAsync()
        {
            var entities = await _connection.Table<Volume>().OrderBy(m => m.Name).ToListAsync();
            return entities;
        }
    }
}
