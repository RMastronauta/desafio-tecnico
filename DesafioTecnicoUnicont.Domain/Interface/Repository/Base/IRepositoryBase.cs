using DesafioTecnicoUnicont.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Domain.Interface.Repository.Base
{
    /// <summary>
    /// Interface base para repositórios.
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade.</typeparam>
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        /// <summary>
        /// Obtém todos os registros da entidade.
        /// </summary>
        /// <returns>Lista de entidades.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Obtém um registro da entidade pelo identificador.
        /// </summary>
        /// <param name="id">Identificador da entidade.</param>
        /// <returns>Entidade encontrada.</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Adiciona um novo registro da entidade.
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada.</param>
        /// <returns>Entidade adicionada.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Atualiza um registro existente da entidade.
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada.</param>
        /// <returns>Entidade atualizada.</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// Remove um registro da entidade.
        /// </summary>
        /// <param name="entity">Entidade a ser removida.</param>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Remove um registro da entidade pelo identificador.
        /// </summary>
        /// <param name="id">Identificador da entidade.</param>
        Task DeleteAsync(int id);
    }
}
