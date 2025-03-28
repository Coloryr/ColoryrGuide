namespace ConsoleApp1;

internal class Program   //这是一个类
{
    const int b = 0; //声明一个常量b类型为int，值为0
    int a; //声明一个变量a类型为int

    /// <summary>
    /// 主函数
    /// </summary>
    /// <param name="args">程序输入内容</param>
    static void Main(string[] args)
    {
        /*
        往控制台输入内容
        */
        Console.WriteLine("Hello, World!");  //输出Hello world

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

        int a1 = 011;
    }
}