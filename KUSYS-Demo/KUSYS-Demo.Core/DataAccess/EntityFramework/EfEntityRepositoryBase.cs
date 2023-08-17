using KUSYS_Demo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Core.DataAccess.EntityFramework
{
    /// <summary>
    /// EntityFrameWork kulanarak Operasyon islemlerimizi Generic olarak gerceklestirdik.
    /// </summary>
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TEntity  : class, IEntity, new()
        where TContext : DbContext, new()
    {
        /// <summary>
        /// VT ile iliskilendir ve Ekleme islemini gerceklestirir.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {

            using (TContext context = new TContext())
            {
                //Entry -->Vt da Entitymizi esletirmemizi saglar
                //State -->Durum Ekleme oldugunu belirtiyoruz.
                //SaveChanges --> Kayıt islemi yapılır.
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// VT ile iliskilendir ve Silme islemini gerceklestirir.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Tek Data Getirme islemini gerceklestirir.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        /// <summary>
        /// Datanın Tamamını yada Filtreleyerek Listeleme İslemini gerceklestirir.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {

            using (TContext context = new TContext())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() //filtreleme yok ise tüm datayı dön 
                    : context.Set<TEntity>().Where(filter).ToList(); //filtreye göre datayı dön 
            }
        }

        /// <summary>
        /// VT ile iliskilendir ve Guncelleme islemini gerceklestirir.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
