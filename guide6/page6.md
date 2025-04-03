[上一章](./page6.md)

# 面向对象编程

什么是面向对象，很简单，就是用蓝图造物品，具体的定义可以参考[菜鸟教程](https://www.runoob.com/cplusplus/cpp-classes-objects.html)  
这里说一下我自己的理解，面向对象的本质就是万物皆英文的`obj`中文的`对象`  
所有操作都是以`obj`为最小单位，通过使用`obj`里面的内容或者读取`obj`里面的信息来实现自己的程序  

在使用面向对象使用前，需要制造一个蓝图，然后用这个蓝图重复制造物品  
- 蓝图就是`类`
- 制造出来的东西叫`对象`
- 制造过程叫做`实例化`

在`obj`里面，通常会有一些东西，这些东西在蓝图里面有另外的名称，但是本质是一样的  
- 蓝图=>对象
- 变量=>属性
- 函数=>方法
- 所有内容=>成员

在C#中，若创建一个蓝图相当于创建一个类  
常见写法为
```C#
class 类名
{
    属性类型 属性;
    ...

    函数返回类型 方法名()
    {

    }
    ...

    其他内容;
}
```
然后实例化常见写法为，其中这个`new`就代表了实例化操作
```C#
var 变量 = new 类名();
```

例如我需要创建一辆车的蓝图，需要有长宽高的变量，启动和关闭的函数，这个类可以这样写
```C#
class Car
{
    public int X;  //表示长
    public int Y;  //表示宽
    public int Z;  //表示高

    public void Start()  //启动
    {

    }

    public void Stop()  //关闭
    {

    }
}
```
然后使用蓝图造车
```C#
var car = new Car();  //实例化一个对象，并作为一个变量car
```
此时这个`car`变量就是一个类型为`Car`的对象了，里面有`X`、`Y`、`Z`三个属性，`Start`和`Stop`这两个方法

为什么需要弄这个实例化？很简单，为了可以重复造多个实例来储存不同的内容  
例如你有多辆车，每辆车的属性跟方法一样，只是他们内容不一样  
因此就不需要重复写这个蓝图，只需要使用这个蓝图造类型一样，内容不一样的车即可  
```C#
var car1 = new Car(); //实例化一个对象，并作为一个变量car1
var car2 = new Car(); //实例化一个对象，并作为一个变量car2
//此时car1跟car2是两辆不一样的车
```

## 访问类里面的内容

创建完一张蓝图，并且实例化之后，就可以访问里面的内容了  
常见的访问方法为
```
变量名.成员名字    //访问变量/属性
变量名.成员名字()  //访问方法
```

例如需要给车设置属性，并调用方法
```C#
var car = new Car();  //实例化一个对象car
car.X = 1;            //给X属性赋值1
car.Y = car.X;        //给Y属性赋值X属性的值
car.Start();          //调用Start这个方法
```

访问过程中，如果是从外面访问，只能调用`public`的成员，也就是有`访问范围`，修改成员的访问范围，可以参考前面的`访问修饰符`  

## 静态Static

通常还会见到`static`这种东西写在类、变量或者函数上，表示该类、变量或者函数为静态  
静态的意思就是，不需要实例化就能直接调用  
也就是说，静态相当于已经实例化了一个实例，然后调用的时候使用这个实例，且会共享使用一个实例  

```C#
Car.Start(); //直接调用类Car的函数Start，不需要
var car = new Car();
car.Stop();  //调用类Car的函数Stop，需要先实例化一个实例  

class Car
{
    public int X;  //表示长
    public int Y;  //表示宽
    public int Z;  //表示高

    public static void Start()  //启动
    {

    }

    public void Stop()  //关闭
    {

    }
}
```

## 构造函数

如果你希望，在实例化的时候需要指定初始参数，则可以使用构造函数  
常见的构造函数写法  
```C#
class 类名
{
    访问修饰符 类名()
    {

    }

    访问修饰符 类名(输入参数)
    {

    }
}
```

例如
```C#
class Car
{
    public int X;  //表示长
    public int Y;  //表示宽
    public int Z;  //表示高

    public Car(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}
```

当定义了构造函数后，实例化需要严格按照构造函数实现  
```C#
//var car = new Car();   错误，构造参数不符合
var car = new Car(1, 2, 1);  //实例化一个对象car，同时传入构造参数
```

构造函数也可以重载，例如
```C#
class Car
{
    public int X;  //表示长
    public int Y;  //表示宽
    public int Z;  //表示高

    public Car()
    {

    }

    public Car(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}
```
此时实例化对象可以写成  
```C#
var car1 = new Car();
var car2 = new Car(1, 2, 1);
```

## 构造时赋值

如果你想只需要`x`和`y`给初始值，可以将构造函数修改为只有x和y的输入参数，或者使用下面的实例化方法  
```C#
var car1 = new Car()
{
    X = 1,
    Y = 2
};
```
这表示，先实例化Car，然后再给X和Y的属性赋值，执行下面代码  
```C#
class Car
{
    public int X;  //表示长
    public int Y;  //表示宽
    public int Z;  //表示高

    public Car()
    {
        Console.WriteLine("X is:" + X);
        Console.WriteLine("Y is:" + Y);
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var car = new Car()
        {
            X = 1,
            Y = 2
        };
    }
}
```
你会发现输出是
```
Hello, World!
X is:0
Y is:0
```
但如果你需要先赋值再实例化，就只能通过构造函数传入了  
```C#
class Car
{
    public int X;  //表示长
    public int Y;  //表示宽
    public int Z;  //表示高

    public Car(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;

        Console.WriteLine("X is:" + X);
        Console.WriteLine("Y is:" + Y);
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var car = new Car(1, 2, 3)
        {
            X = 4,
            Y = 5
        };
    }
}
```
此时输出为
```
Hello, World!
X is:1
Y is:2
```

## 设置器与获取器

在类里面，其实`public int X;`严格来讲并不是一个属性，而是一个成员变量，C#中属性的真正写法是  
```C#
访问修饰符 变量类型 变量名 { 访问器; }
```
例如
```C#
public int X { get; set; }
```
其中里面的`get;`与`set;`叫做`Getter`与`Setter`  
这样做可以保证`X`这个是属性，相当于两个函数
```C#
public int GetX()
{
    return X;
}
public void SetX(int value)
{
    X = value;
}
```
这种是一个标准属性写法，只不过C#相对于其他语言做了简化  

如果你的属性只读，可以这样写
```C#
public int X { get; }
```
当你确定了X的值，可以简化为
```C#
public int X => 1;
```
或者需要外部可以访问，但是只能内部设置，可以这样写
```C#
public int X { get; private set; }
```