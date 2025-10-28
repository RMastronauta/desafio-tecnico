using DesafioTecnicoUnicont.Data.Context;
using DesafioTecnicoUnicont.Domain.Entity.Base;
using DesafioTecnicoUnicont.Domain.Interface.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Data.Repository.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        private DesafioTecnicoUnicontContext _context;
        private DbSet<TEntity> _dbSet;
        public RepositoryBase(DesafioTecnicoUnicontContext context) 
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
        }
        public virtual async Task<TEntity>  AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id) ?? throw new KeyNotFoundException("Não Foi possível encontrar a entidade.");
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            var entity = _dbSet.FirstOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException($"Não Foi possível encontrar a entidade para o id {id}.");
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
