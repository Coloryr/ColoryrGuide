[上一章](./page3.md)

# 数据与变量

C#程序在运行的过程中，处理数据处理，还有数据存储，现有数据才能进行操作  
在上一章的代码中，主函数的参数有个`string[] arg`这个表示类型为`string`数组的变量`arg`  
其中这个`arg`就是一个用于数据存储的盒子，你可以往里面读取或者写入数据  

## 数据类型

在存储数据之前，我们需要先知道需要存什么数据  
在C#语言中，默认会提供一些数据类型，这与[编程入门](../guide4/README.md#数据类型)里面的数据类型类似但更具体  
- byte/sbyte 1字节整型，其中的sbyte表示有符号  
- ushort/short 2字节整型，其中的ushort表示无符号  
- uint/int 4字节整型，其中的uint表示无符号  
- ulong/long 8字节整型，其中的ulong表示无符号  
- float 4字节浮点型
- double 8字节浮点型
- bool 布尔类型，只有true与false
- char 字符，一般2字节
- string 字符串，可以储存多个字符组合起来的东西
- unint/nint 指针，一般8字节
- 各种类object 是的类也算类型，通常以object为基底
- null 空，就是啥也没有

例如前面的`Console`，其实也是一种类型  
字符串一般是类似`"123"`，而字符一般是类似`'a'`

## 变量与常量

有了数据类型，我们就可以开始将数据按照某个形式存储了，你可以选择存在`变量`或者`常量`里面  
`变量`故名思意，就是一个内容可以变化的盒子，但变化只能变化值，不能变化类型  
而`常量`就是类型跟内容都不能变化的盒子  

变量与常量在使用前需要声明，例如
```c#
namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        const int b = 0; //声明一个常量b类型为int，值为0
        int a; //声明一个变量a类型为int
    }
}
```
声明的位置可以不在函数内，在类里面也可以  
```C#
namespace ConsoleApp1;

internal class Program
{
    const int b = 0; //声明一个常量b类型为int，值为0
    int a; //声明一个变量a类型为int

    static void Main(string[] args)
    {
        
    }
}
```
但是不能在命名空间里面声明  
常量在声明的同时，需要给它赋予一个初始值，否则会产生错误  

在一些地方，声明变量时有可能为了方便会使用`var`来表示变量，类型编译器会自动判断  
```C#
var a = 1; //声明一个类型为int的变量a
var b = true; //声明一个类型为bool的变量b
var c = 1.0f; //声明一个类型为float的变量c
//var d; //错误，无法知道类型
```

## 赋值

常量与变量的赋值，很简单，`左边`等于`右边`，左边为变量或者常量，右边为需要给的值
```
左边 = 右边;
```

```C#
namespace ConsoleApp1;

internal class Program
{
    const int b = 0; //声明一个常量b类型为int，值为0
    int a; //声明一个变量a类型为int

    static void Main(string[] args)
    {
        a = 1; //给变量a赋值1
        //b = 0; //不允许，常量不允许赋值
        a = b; //给变量a赋值常量b的值，也就是0
        a = a; //给变量a赋值a的值，也就是不变
    }
}
```
注意：变量在使用前，需要先有个值，例如
```C#
namespace ConsoleApp1;

internal class Program
{
    int a; //声明一个变量a类型为int
    int b; //声明一个变量b类型为int

    static void Main(string[] args)
    {
        //a = b; //给变量a赋值变量b的值，但是错误，因为b没有默认值
    }
}
```
```C#
namespace ConsoleApp1;

internal class Program
{
    int a; //声明一个变量a类型为int
    int b = 0; //声明一个变量b类型为int，默认值0

    static void Main(string[] args)
    {
        a = b; //给变量a赋值变量b的值，为0
    }
}
```
变量在赋值的时候，只能赋值同类型，或者低级类型  
如果非要赋值，需要使用强制转换操作
```C#
int a; //声明一个变量a类型为int
int b = 0; //声明一个变量b类型为int，默认值0
long c = 1; //声明一个变量b类型为long，默认值1
float d; //声明一个变量d类型为float
double e = 3; //声明一个变量e类型为double，默认值3
byte f = 2; //声明一个变量f类型为byte，默认值2

a = b; //给变量a赋值变量b的值，为0
//a = c; //给变量a赋值变量c的值，不允许，因为long长度比int大，不是低级类型
a = f; //给变量a赋值变量f的值，为2
d = b; //给变量d赋值变量b的值，为0
//d = e; //给变量d赋值变量e的值，不允许，因为double长度比float大，不是低级类型

d = (float)e; //给变量d赋值变量e的值，强制转换为d类型
```
总的来说，就是大的给不了小的，小的可以给大的，若需要给小的，需要进行强制转换，但转换会丢失数据  
例如`doubel->int`会丢失小数部分，只保留整数部分  
`int->byte`会丢失大于byte的部分，也就是范围小了会截取  

给变量赋值，可以选择输入的进制
```C#
int a = 89; //给变量a赋值10进制的值89
int b = 0x55; //给变量b赋值16进制的值0x55=85
int c = 0b11;  //给变量c赋值2进制的值0b11=3
```

## 可空类型

C#中还有一种类型叫做可空类型，意识是里面的数据有可能为null，其声明方式为`类型?`
```C#
int? a = null; //声明一个int可空变量a，初始数据为null
double? b = 1.0; //声明一个double可空变量b，初始数据为1.0
string? c = "123"; //
```
使用可空类型一般用于你不确定数据是否存在的情况下，不存在直接给`null`就可以了  
注意：`int`与`int?`不是一个东西，操作方式会有区别，请使用时需要注意  

[下一章](./page5.md)