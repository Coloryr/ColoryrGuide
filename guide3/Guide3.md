# Cmake+Gcc+Vscode

1. 安装软件

- [Vscode](https://code.visualstudio.com/)
- [Cmake](https://cmake.org/)
- [mingw64](https://www.mingw-w64.org/)

Cmake和mingw64只需要解压出来放在一个文件夹下即可  
![Alt text](/pic/pic22.png)

2. 添加环境变量

将`cmake/bin` 和 `mingw64/bin` 添加至`Path`环境变量  
![Alt text](/pic/pic23.png)

3. 打开Vscode安装插件

[C/C++ Extension Pack](https://marketplace.visualstudio.com/items?itemName=ms-vscode.cpptools-extension-pack)  
![Alt text](/pic/pic24.png)

4. 新建工程

创建一个空白文件夹，用Vscode打开  
![Alt text](/pic/pic25.png)

按下`F1`，输入`Cmake`，选择`Cmake 快速入门`  
![Alt text](/pic/pic26.png)

选择`Gcc`  
![Alt text](/pic/pic27.png)  
如果没有，尝试选择`[Scan for kits]`，让Vscode自动扫描  
若还是没有，检查Path中是否有`mingw64/bin`  
然后重启Vscode或者重启电脑

到这一步按下`Esc`取消选择  
![Alt text](/pic/pic28.png)  

这一步输入工程名，按下回车键确认  
![Alt text](/pic/pic29.png)  

工程类型，选择C或者C++  
![Alt text](/pic/pic30.png)  

选择`Excutable`可执行文件  
![Alt text](/pic/pic31.png)  

工程会自动创建  
![Alt text](/pic/pic32.png)  

5. 编译与运行

在Vscode的底部工具栏，有按钮  
![Alt text](/pic/pic33.png)  

若没有，选择左边的  
![Alt text](/pic/pic34.png)  

也可以实现编译与运行

## 注意

1. 无法编译问题

若程序运行中，则无法正常编译，需要关闭程序才行，可以在控制台中按下`Ctrl`+ `C`或者点击按钮
![Alt text](/pic/pic35.png) 
都可以关闭程序

2. .c文件不编译问题

添加了新的.c文件后，需要在CmakeList.txt中添加  
![Alt text](/pic/pic36.png) 

3. 头文件查找路径
```
include_directories(${TARGET_NAME}
./xxxxx)
```
