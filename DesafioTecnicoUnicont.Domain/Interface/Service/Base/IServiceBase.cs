using DesafioTecnicoUnicont.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Domain.Interface.Service.Base
{
    /// <summary>
    /// Interface base para serviços.
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade.</typeparam>
    public interface IServiceBase<TEntity> where TEntity : EntityBase
    {

        /// <summary>
        /// Obtém todos os registros relacionados ao identificador informado.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna todos os registros encontrados.</returns>
        Task<TEntity> GetAllAsync(int id);

        /// <summary>
        /// Obtém um registro pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Adiciona um novo registro.
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada.</param>
        /// <returns>Retorna a entidade adicionada.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Atualiza um registro existente.
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada.</param>
        /// <returns>Retorna a entidade atualizada.</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// Exclui um registro pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Operação assíncrona de exclusão.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Exclui um registro informado.
        /// </summary>
        /// <param name="entity">Entidade a ser excluída.</param>
        /// <returns>Operação assíncrona de exclusão.</returns>
        Task DeleteAsync(TEntity entity);


    }
}
