[上一章](./page6.md)

# 函数

程序中，编写逻辑代码都需要写在函数里面，也就是说函数是一个必须要使用的东西  
而函数是一个对重复功能的包装，多用函数可以最大程度的整理你写的代码  

## 函数声明

函数在使用前需要声明，一般声明是这样写  
```
范围修饰符 返回类型 函数名(传入参数)
{

}
```
例如
```C#
public void Test1() //声明一个公共 无返回值 无输入值 函数名为Test1的函数
{

}

private void Test2(int a) //声明一个私有 无返回值 输入值只有一个类型为int的值 函数名为Test2的函数
{

}

int Test3() //声明一个私有 返回值为类型int的值 无输入值 函数名为Test3的函数
{

}

public int Test4(bool a, int b) //声明一个公共 返回值为类型int的值 输入值只有两个 函数名为Test4的函数
{

}
```

以上是常见的函数声明方式，还有几种比较常见的特殊
```C#
public int GetData() => 1; //声明一个公共 返回值为类型int的值 无输入值 函数名为GetData的函数 其内容是返回1

public bool TryGetData(int len, out string str) //声明一个公共 返回值为类型bool的值 输入值为int，输出string 函数名为TryGetData的函数
{

}

public bool TrySetData(int len, ref string str) //声明一个公共 返回值为类型bool的值 输入值为int，输出string 函数名为TryGetData的函数
{

}
```

如果函数的输入参数里面有个`out`则表示这个输入参数变成了输出参数，会返回函数的值  
如果函数的输入参数里面有个`ref`则表示这个输入参数变成了借用参数，这里的值，若被函数修改了，则也会修改传入的参数给传入的变量  

**若函数需要返回值，则一定需要返回一个值，若不返回数据则会无法编译通过**

## 函数的调用

调用一个函数，可以有集中形式  
```
函数名();
函数名(传入参数);
var 变量 = 函数名();
var 变量 = 函数名(传入参数);
```

在代码中来看是这样的
```C#
public void Test1()
{

}

private void Test2(int a)
{

}
```

[下一章](./page7.md)