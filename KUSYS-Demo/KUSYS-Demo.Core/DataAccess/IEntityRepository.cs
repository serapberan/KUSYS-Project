using KUSYS_Demo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Core.DataAccess
{
    /// <summary>
    /// CRUD islemleri
    /// IEntityRepository --> Generic Repository Design Pattern kullanarak Crud işlemlerini gerceklestirip, tekrarın da  önüne geçtik.
    /// <br/> Kısıtlamalar ile hatalı kullanımı engelledik bunlar;
    /// <br/> T --> Class olsun(sadece sınıflar yazılabilsin) ama sadece 
    /// <br/> IEntity --> Classlar IEntity veya implemente olanlar olmalı
    /// <br/> new() --> Newlene bilmeli 
    /// </summary>
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        ///  Datanın Tümünü yada belli bir filtreye göre getirme işlemini yapar.
        ///  filter = null --> Tüm datayı getirir.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Tek bir Datayı getirme islemi gerceklestirir.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Yeni bir Data Ekleme işlemi gerceklestirir.
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Var olan Datayı Güncelleme islemi gerceklestirir.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Datayı silme islemi gerceklestirir.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
