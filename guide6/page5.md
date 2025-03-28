[上一章](./page4.md)

# 基本运算

在C#中，数据的处理也有加减乘除，同时也有逻辑运算  
运算的程序语句一般是这样写，一般这种称为运算表达式，简称`表达式`
```
变量1 = 操作数1 运算符 操作数2;
```
运算符可以连着使用，意思是
```
变量1 = 操作数1 运算符 操作数2 运算符 操作数3;
```
只要你想可以一直连着使用

## 数学运算

数学运算，故名思意就是对数字进行加减乘除  
进行运算时，会根据数据类型自动处理，例如浮点数会处理小数与整除，整数处理若出现小数则会被去掉  
如果加减乘除后出现了溢出，程序不会提示错误等，因此需要自行判断运算是否会出现溢出  

数学加，加法可以用在任何支持加的地方，甚至是声明变量时
```C#
int a = 0;
int b = 1;
int c = a + b;
```
此时`c`的值就是`a`加上`b`的值

数学减
```C#
int a = 0;
int b = 1;
int c = a - b;
```

数学乘
```C#
int a = 0;
int b = 1;
int c = a * b;
```

数学除
```C#
int a = 20;
int b = 3;
int c = a / b; //c为6
```
**不允许除数为0**

数学余，意思是除之后取余数
```C#
int a = 20;
int b = 3;
int c = a % b; //c为2
```
**不允许除数为0**

自加
```C#
int a = 0;
a++;  //同等与a = a + 1;
++a;  //同等与a = a + 1;
a+=2; //同等与a = a + 2;
```

```C#
int a = 0;
int b = a++; //此时b为0 因为先赋值后自加
a = 0;
int c = ++a; //此时c为1 因为先自加后赋值
```

自减
```C#
int a = 0;
a--;  //同等与a = a - 1;
--a;  //同等与a = a - 1;
a-=2; //同等与a = a + 2;
```

```C#
int a = 1;
int b = a--; //此时b为1 因为先赋值后自减
a = 1;
int c = --a; //此时c为0 因为先自减后赋值
```

自乘
```C#
int a = 0;
a*=2; //同等与a = a * 2;
```

自除
```C#
int a = 0;
a/=2; //同等与a = a / 2;
```

自取余
```C#
int a = 0;
a%=2; //同等与a = a % 2;
```

## 逻辑运算

逻辑运算，及0 1运算，对于类型为`bool`的变量其结果只有`true`与`false`  
对于数字类型的运算，则会对在二进制里面每一位做处理  

取反
```C#
bool a = true;
bool b = !a; //b为false
```

或运算
```C#
bool a = true;
bool b = false; 
bool c = a | b; //c为true
bool d = a || b; //d为true
```
对于数字变量
```C#
int a = 0b0010;
int b = 0b0001;
int c = a | b; //c为0b0011
```
`|`与`||`的区别是，`|`前后都会做判断，而`||`前面不成立了，后面就不继续判断了  
例如
```C#
bool a = true | false
bool b = false | true
```
无论如何都会两个都一起判断  
```C#
bool a = true || false
bool b = false || true
```
判断到第一个true后，就不会去判断第二个false了，在使用的时候需要注意区分

与运算
```C#
bool a = true;
bool b = false; 
bool c = a & b; //c为false
bool d = a && b; //d为false
```
`&`与`&&`的区别跟或运算是一样的  
对于数字变量
```C#
int a = 0b0010;
int b = 0b0011;
int c = a | b; //c为0b0010
```

异或运算
```C#
bool a = true;
bool b = true; 
bool c = a ^ b; //c为false
```
对于数字变量
```C#
int a = 0b0010;
int b = 0b0011;
int c = a ^ b; //c为0b0001
```

逻辑运算也可以自己作为结果存储
```C#
bool a = true;
a&=true;
a|=true;
a^=true;
```

## 数字位移

位移就是在二进制状态下，对所有二进制位进行移动操作  
```C#
int a = 0b1100;
int b = a >> 1; //b为0b0110
int c = a << 2; //c为0b11000;
```
对数字结果来说，左移相当于x2的级数，右移/2的级数  
左移右移在数据处理中，用以拼接数据包等操作居多  

## 运算符优先级

若你的一个表达式里面有很多个运算，则会有计算优先级在里面  
同级运算符遵循从左到右
具体可以参考[这张表格](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/#operator-precedence)  

```C#
int a = 1;
int b = 2;
int c = a + b / 2; //先乘除，后加减
```
如何先算`a + b`，可以加个括号解决
```C#
int a = 1;
int b = 2;
int c = (a + b) / 2; //先乘除，后加减
```

[下一章](./page6.md)