using System;
using System.Collections;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            var fan = new DeskFan(new PowerSupply());
            Console.WriteLine(fan.Work());
            
        }
    }

    public interface IPowerSupply
    {
        int GetPower();
    }

    public class PowerSupply: IPowerSupply
    {
        public int GetPower()
        {
            return 123;
        }
    }

    public class DeskFan
    {
        private IPowerSupply _ps;
        public DeskFan(IPowerSupply ps)
        {
            _ps = ps;
        }

        public string Work()
        {
            int power = _ps.GetPower();
            if(power <= 0)
            {
                return "Won't work.";
            }
            else if(power < 100)
            {
                return "Slow.";
            }
            else if(power < 200)
            {
                return "Work fine.";
            }
            else
            {
                return "Warning!";
            }
        }
    }
}


// 依赖反转的直接应用和受益者：单元测试


// 强耦合不好的代码
//namespace Interface
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var fan = new DeskFan(new PowerSupply());
//            Console.WriteLine(fan.Work());

//        }
//    }

//    class PowerSupply
//    {
//        public int GetPower()
//        {
//            return 210;
//        }
//    }

//    class DeskFan
//    {
//        private PowerSupply _ps;
//        public DeskFan(PowerSupply ps)
//        {
//            _ps = ps;
//        }

//        public string Work()
//        {
//            int power = _ps.GetPower();
//            if (power <= 0)
//            {
//                return "Won't work.";
//            }
//            else if (power < 100)
//            {
//                return "Slow.";
//            }
//            else if (power < 200)
//            {
//                return "Work fine.";
//            }
//            else
//            {
//                return "Warning!";
//            }
//        }
//    }
//}