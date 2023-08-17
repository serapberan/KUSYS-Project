using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Core.Business
{
    /// <summary>
    /// Temel CRUD işlemlerinin Generic olarak kullanılmasını saglar.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericService<T>
    {
        /// <summary>
        /// Yeni Kayıt Ekleme işlemi gerçekleştirir.
        /// </summary>
        /// <param name="t"></param>
        void TAdd(T t);

        /// <summary>
        /// Kayıt Silme işlemi gerçekleştirir.
        /// </summary>
        /// <param name="t"></param>
        void TDelete(T t);

        /// <summary>
        /// Var olan kaydı güncelleme işlemi gerçekleştirir.
        /// </summary>
        /// <param name="t"></param>
        void TUpdate(T t);

        /// <summary>
        /// Tüm Datayı Listeleme işlemi gerçekleştirir.
        /// </summary>
        /// <returns></returns>
        List<T> TGetList();

        /// <summary>
        /// İstenilen Id ye göre seçim yapılmasınıgerçekleştirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T TGetByID(int id);
    }
}
