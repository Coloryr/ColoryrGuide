[上一章](./page6.md)

# 其他结构类型

常用的还有`枚举(enum)`，`结构体(struct)`，`记录(record)`，元组类型

## 枚举

有些时候，我们需要用一些数字来代表一些内容  
例如数字0代表星期日，1代表星期一，2代表星期二等等  
写的时候有可能还会记得数字几代表什么意思，但是时间长了有可能会忘记  
因此可以使用`枚举`来替换掉这个数字，直接用单词记录  
常见的枚举写法有
```C#
public enum Week
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}
```
还有
```C#
public enum Week
{
    Sunday = 0,
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6
}
```
又或者
```C#
public enum DataType
{
    Command0 = 0x01,
    Command1 = 0x02,
    Data0 = 0x11,
    Data1 = 0x12
}
```
也就是说，其实枚举跟数字有一些联系，可以将枚举的值直接转换为数字，也可以将数字直接转换为枚举  
```C#
var week = Week.Sunday;  //定义一个类型为Week枚举的变量week，其值为Sunday
var weeknum = (int)week;  //定义一个类型为int的变量weeknum，其值为Sunday对应的数值，也就是0
```

## 结构体

[上一章](./page8.md)