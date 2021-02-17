using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {   //fonksiyonun içinde değilde burada tanımlanırsa global değişken olur. (Sadece bu classta geçerli bir nesnedir.)
        //Standart isimlendirme _ ile yapılır
        //veritabanı olsun
        List<Car> _car;
        //Aşağıda üürn oluşturuyoruz.
        //SQl serverden ya da Oracle geliyor gibi ürünler. Datamız olmadığı için böyle yaptık
        public InMemoryCarDal()
        {
            _car = new List<Car> { 
                new Car{BrandId=1, ColorId=1, DailyPrice=45, Id=1, ModelYear=1998, Description="aaa"},
                new Car{BrandId=2, ColorId=2, DailyPrice=55, Id=2, ModelYear=1996, Description="bbbb"},
                new Car{BrandId=3, ColorId=3, DailyPrice=26, Id=3, ModelYear=2000, Description="ccccc"}

            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {

            //LINQ kullanımı
            //Tek bir eleman bulmaya yarar
            //Ürünleri tek tek dolaşırken takma isim alır p dedik bizde
            Car carToDelete = _car.SingleOrDefault(p=>p.Id==car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _car.Where(p => p.BrandId ==brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(p =>p.Id==car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
