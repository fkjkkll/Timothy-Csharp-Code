using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace InterfaceIsolation
{
    class Program
    {
        static void Main(string[] args)
        {
            // ============================= 自己实现反射 ==============================
            {
                ITank tank = new HeavyTank();
                // === 以下不用静态类型
                var t = tank.GetType(); // get type info
                object o = Activator.CreateInstance(t);
                MethodInfo fireMi = t.GetMethod("Fire");
                MethodInfo runMi = t.GetMethod("Run");
                fireMi.Invoke(o, null);
                runMi.Invoke(o, null);
                Console.WriteLine("\n\n");
            }
            // ============================= 采用封装好的注射1 ==============================
            {
                // === 一次性注册
                var sc = new ServiceCollection(); // 容器
                sc.AddScoped(typeof(ITank), typeof(HeavyTank)); // 接口 和 实现该接口的类
                var sp = sc.BuildServiceProvider();
                // === 范围内都可以使用(因为AddScoped)
                ITank tank = sp.GetService<ITank>();
                tank.Fire();
                tank.Run();
                Console.WriteLine("\n\n");
            }
            // ============================= 采用封装好的注射2 ==============================
            {
                // === 一次性注册
                var sc = new ServiceCollection(); // 容器
                sc.AddScoped(typeof(IVehicle), typeof(LightTank)); // 接口 和 实现该接口的类
                sc.AddScoped(typeof(IVehicle), typeof(Car)); // 接口 和 实现该接口的类
                sc.AddScoped<Driver>();
                var sp = sc.BuildServiceProvider();
                // === 范围内都可以使用(因为AddScoped)
                var driver = sp.GetService<Driver>();
                driver.Drive();
                Console.WriteLine("\n\n");
            }
        }
    }

    class Driver
    {
        private IVehicle _vehicle;
        public Driver(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Drive()
        {
            _vehicle.Run();
        }
    }

    interface IVehicle
    {
        void Run();
    }

    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is running...");
        }
    }

    class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is running...");
        }
    }


    interface IWeapon
    {
        void Fire();
    }



    interface ITank : IVehicle, IWeapon // 把握一个度 不要过犹不及
    {
    }


    class LightTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!");
        }

        public void Run()
        {
            Console.WriteLine("Ka! Ka! Ka! ...");
        }
    }

    class Medium : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka!! Ka!! Ka!! ...");
        }
    }

    class HeavyTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka!!! Ka!!! Ka!!! ...");
        }
    }
}
