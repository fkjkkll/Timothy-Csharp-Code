using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 协变：和谐的变化，自然的变化
 * 因为 里氏替换原则 父类可以装子类
 * 所以子类变父类 比如string变object 感受是和谐的
 * 
 * 逆变：逆常规的变化，不正常的变化
 * 因为 里氏替换原则 父类可以装子类 但是子类不能装父类
 * 所以父类变子类 比如object变string 感受是不和谐的
 * 
 * 协变和逆变是用来修饰泛型的
 * 协变：out
 * 逆变：in
 * 用于在泛型中，修饰泛型字母的
 * 只有 [泛型接口] 和 [泛型委托] 能使用
*/

namespace ConsoleApp1 {
    // 1, 返回值 和 参数
    // 用out修饰的泛型 只能作为返回值
    delegate T TestOut<out T>();
    // 用in修饰的泛型 只能作为参数
    delegate void TestIn<in T>(T t);

    // 2, 结合里氏替换原则理解
    class Father {

    }
    class Son : Father {

    }

    class Program {

        static void Main(string[] args) {
            // 协变 父类总是能被子类替换
            // 看起来 就是 son->father
            TestOut<Son> os = () => { return new Son(); };
            TestOut<Father> of = os; // 如果委托里面没有 out，则报错
            Father f = of(); // 实际上 返回的 是os里面装的函数 返回的是Son

            // 逆变 父类总是能被子类替换
            TestIn<Father> iF = (value) => { };
            TestIn<Son> iS = iF; // 如果委托里没有 in，则报错
            iS(new Son()); // 调用的实际上 iF
        }
    }
}

// 作用两点：
// 1、out修饰的泛型类型 只能作为返回值类型 in修饰的泛型类型 只能作为参数类型
// 2、遵循里氏替换原则 用out和in修饰的 泛型委托 可以相互装载（有父子关系的泛型）
// 协变：父类泛型委托装子类泛型委托     逆变：子类泛型委托装父类泛型委托

