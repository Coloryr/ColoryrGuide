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
- 蓝图\对象
- 变量\属性
- 函数\方法
- 所有内容\成员

在C#中，若创建一个蓝图相当于创建一个类  
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
var car = new Car();
```
此时这个car变量就是一个对象了，里面有`X`、`Y`、`Z`三个属性，`Start`和`Stop`这两个方法

## 静态Static

通常还会见到`static`这种东西写在变量或者函数上
