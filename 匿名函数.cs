using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
lambda匿名函数会形成闭包，可能会延长外层函数的变量。
且变量的值是外部变量最终值（无快照机制）
*/

namespace ConsoleApp1 {

    class Node {
        public event Action MyE = null;
        public Node() {
            int value = 10;
            MyE += () => {
                Console.WriteLine(value);
            };
            for(int i=0; i<10; ++i) {
                MyE += () => {
                    Console.WriteLine(i);
                    // 在这里调用会死循环
                };
                MyE?.Invoke(); // 在这里调用会更清晰
            }
            MyE?.Invoke();
        }
    }

    class Program {

        static void Main(string[] args) {
            Node node = new Node(); // 全部输出10
        }
    }
}


