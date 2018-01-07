
using CoPro.Models;
using CoPro.Repositories;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoPro.Repositories.Implementations
{
    public class VolumeRepository : IVolumeRepository
    {
        readonly SQLiteAsyncConnection _connection;

        public VolumeRepository(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Volume>().Wait();
        }

        public async Task<IEnumerable<Volume>> GetAllAsync()
        {
            var entities = await _connection.Table<Volume>().OrderBy(m => m.Name).ToListAsync();
            return entities;
        }

        public async Task<Volume> GetAsync(int id)
        {
            var entity = await _connection.Table<Volume>().Where(v => v.Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<Volume> CreateAsync(Volume volume)
        {
            //var entity = new Volume()
            //{
            //    Name = name,
            //    Description = description
            //};
            var volumeList = await GetAllAsync();
            var isExist = volumeList.Any(v => v.Name == volume.Name);
            int count = 0;
            if (!isExist)
            {
                count = await _connection.InsertAsync(volume);
            }
            return (count == 1) ? volume : null;
        }

        public async Task<int> DeleteAsync(Volume volume)
        {
            return await _connection.DeleteAsync(volume);
        }

        public async Task<int> DropAsync()
        {
            return await _connection.DropTableAsync<Volume>();
        }


        //    private SQLiteAsyncConnection _connection;

        //    public async Task InitializeAsync(string path, ISQLitePlatform sqlitePlatform)
        //    {
        //        _connection = SQLiteDataBase.GetConnection(path, sqlitePlatform);

        //        // Create MyEntity table if need be
        //        await _connection.CreateTableAsync<Volume>();
        //    }

        //    public async Task<Volume> CreateAsync(string name, string description)
        //    {
        //        var entity = new Volume()
        //        {
        //            Name = name,
        //            Description = description
        //        };
        //        var count = await _connection.InsertAsync(entity);
        //        return (count == 1) ? entity : null;
        //    }

        //    public async Task<IEnumerable<Volume>> GetAllAsync()
        //    {
        //        var entities = await _connection.Table<Volume>().OrderBy(m => m.Name).ToListAsync();
        //        return entities;
        //    }
    }
}
