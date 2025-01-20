
using dishwasher.api.Models;
using dishwasher.api.Data;
using Microsoft.EntityFrameworkCore;

namespace dishwasher.api.Repository
{
    public class ProgramRepository(DataContext db) : IRepository<ProgramModel, Guid>
    {
        private DataContext _db = db;

        public async Task<ProgramModel> Add(ProgramModel entity)
        {
            await _db.Programs.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            ProgramModel pet = await Get(id);
            _db.Programs.Remove(pet);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ProgramModel> Get(Guid id)
        {
            ProgramModel? pet = await _db.Programs.FindAsync(id);
            if (pet == null)
            {
                throw new ArgumentException();
            }
            return pet;
        }

        public async Task<IEnumerable<ProgramModel>> GetAll()
        {
            return await _db.Programs.ToListAsync();
        }

        public async Task<ProgramModel> Update(ProgramModel entity)
        {
            _db.Programs.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
