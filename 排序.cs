using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 自定义排序需要继承IComparable接口，实现对应函数
 * 返回值的含义：
 * 小于0：放在传入对象的左边
 * 等于0：保持当前位置不变
 * 大于0：放入传入对象的右边
*/

namespace ConsoleApp1 {
    
    // 方式1：通过接口排序
    class Node: IComparable<Node> {
        public int num = default(int);

        public int CompareTo(ConsoleApp1.Node other) {
            if(this.num >= other.num) {
                return 1;
            }
            else {
                return -1;
            }
        }
    }

    // 方式2：通过委托排序
    class Node2  {
        public int num = default(int);

        
    }

    class Program {

        static void Main(string[] args) {
            List<Node> ls = new List<Node>();
            ls.Add(new Node() { num = 3 });
            ls.Add(new Node() { num = 5 });
            ls.Add(new Node() { num = 8 });
            ls.Add(new Node() { num = 1 });
            ls.Add(new Node() { num = 0 });
            ls.Add(new Node() { num = 2 });
            ls.Add(new Node() { num = 4 });
            ls.Sort(); // 会将Node转换为IComparable接口对象，然后参与排序算法
            foreach(var e in ls) {
                Console.WriteLine(e.num);
            }

            List<Node2> ls2 = new List<Node2> {
                new Node2() { num = 3 },
                new Node2() { num = 5 },
                new Node2() { num = 8 },
                new Node2() { num = 1 },
                new Node2() { num = 0 },
                new Node2() { num = 2 },
                new Node2() { num = 4 }
            };
            //ls2.Sort((a,b)=> { // 规则一样，升序（b为原点）
            //    if (a.num >= b.num) {
            //        return 1;
            //    }
            //    else {
            //        return -1;
            //    }
            //});
            // 或者借由三目，一句代码：
            ls2.Sort((a, b) => { return a.num > b.num ? 1 : -1; });
            foreach (var e in ls2) {
                Console.WriteLine(e.num);
            }
        }
    }
}


