using System;
using System.Threading;
using System.Timers;
/// <summary>
/// 事件的完整声明格式
/// </summary>
namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Action();
            customer.PayTheBill();
        }
    }

    // 以下依次访问级别一致
    public class OrderEventArgs : EventArgs { // 默认继承自EventArgs
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    public class Customer {
        private OrderEventHandler orderEventHandler;
        public event OrderEventHandler Order {
            add {
                this.orderEventHandler += value;
            }
            remove {
                this.orderEventHandler -= value;
            }

        }

        public double Bill { get; set; }
        public void PayTheBill() {
            Console.WriteLine("I will pay ${0}.", this.Bill);
        }
        public void WalkIn() {
            Console.WriteLine("Walk into the restaurant.");
        }
        public void SitDown() {
            Console.WriteLine("Sit Down.");
        }
        public void Think() {
            for(int i=0; i<5; ++i) {
                Console.WriteLine("Let me think...");
                Thread.Sleep(100);
            }
            if(orderEventHandler != null) {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "Kongpao Chicken";
                e.Size = "large";
                this.orderEventHandler.Invoke(this, e);
            }
        }

        public void Action() {
            Console.ReadLine();
            this.WalkIn();
            this.SitDown();
            this.Think();
        }
    }

    class Waiter {
        public void Action(Customer customer, OrderEventArgs e) {
            Console.WriteLine("I will serve you the dish - {0}.", e.DishName);
            double price = 10;
            switch (e.Size) {
                case "small":
                    price *= 0.5;
                    break;
                case "large":
                    price *= 1.5;
                    break;
                default:
                    break;
            }
            customer.Bill += price;
        }
    }
}

// 使用现成的
//namespace ConsoleApp1 {
//    class Program {
//        static void Main(string[] args) {
//            Timer timer = new Timer();
//            Boy boy = new Boy();
//            Girl girl = new Girl();
//            timer.Elapsed += boy.Action;
//            timer.Elapsed += Girl.Sing;
//            timer.Interval = 500;
//            timer.Start();
//            Console.ReadLine();
//        }
//    }

//    class Boy {
//        internal void Action(object sender, ElapsedEventArgs e) {
//            Console.WriteLine("Play!");
//        }
//    }

//    class Girl {
//        internal static void Sing(object sender, ElapsedEventArgs e) {
//            Console.WriteLine("Sing~");
//        }
//    }
//}