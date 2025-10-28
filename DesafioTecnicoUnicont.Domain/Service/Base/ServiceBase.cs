using DesafioTecnicoUnicont.Domain.Entity.Base;
using DesafioTecnicoUnicont.Domain.Interface.Repository.Base;
using DesafioTecnicoUnicont.Domain.Interface.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Domain.Service.Base
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        protected readonly IRepositoryBase<TEntity> _repository;
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity) =>
            await _repository.AddAsync(entity);


        public virtual async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
        

        public virtual async Task DeleteAsync(TEntity entity) =>
            await _repository.DeleteAsync(entity);
        

        public virtual async Task<TEntity> GetAllAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public virtual async Task<TEntity> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);
        

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)=>
            await _repository.UpdateAsync(entity);
    }
}
