using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {   //Global değişken oluşturuldu. Veri erişimini newleyerek çağıramam çünkü
        //soyut nesneyle iletişim kuracağız
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;      }


        //ürünleri listele
        public List<Car> GetAll()
        {
            //iş kodlarını geçiyorsa veri erişimini çağırmak gerek
            return _carDal.GetAll();

        }
    }
}
