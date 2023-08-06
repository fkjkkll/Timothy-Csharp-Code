using System;
using System.Threading;
using System.Timers;
/// <summary>
/// 事件的简略声明格式
/// </summary>
namespace ConsoleApp3 {
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

    //public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);
    // 可以直接使用.Net平台准备好的EventHandler就行了

    public class Customer {
        public event EventHandler Order; // 委托类型字段被语法糖包裹

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
            for (int i = 0; i < 5; ++i) {
                Console.WriteLine("Let me think...");
                Thread.Sleep(100);
            }
            OnOrder("Kongpao Chicken", "large");
            
        }
        // protected防止“借刀杀人”
        protected void OnOrder(string name, string size) {
            if (Order != null) {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = name;
                e.Size = size;
                this.Order.Invoke(this, e);
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
        public void Action(Object sender, EventArgs eventArgs) {
            Customer customer = sender as Customer;
            OrderEventArgs e = eventArgs as OrderEventArgs;
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