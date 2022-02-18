# STM32系列单片机开发软件说明

常用的开发软件有[keil](#keil)、[STM32CubeIDE](#STM32CubeIDE)、[VSCode](#VSCode)、[Clion](#Clion)

## [Keil](https://www.keil.com/)
在[官网](https://www.keil.com/demo/eval/arm.htm)下载，安装后即可使用

接下来还需要[安装](https://www.keil.com/dd2/pack/)不同的单片机软件包

## [STM32CubeIDE](https://www.st.com/zh/development-tools/stm32cubeide.html)

和`Keil`一样，这个也是直接安装就能用的，新建工程选择单片机和就能进行编写代码

## [VSCode](https://code.visualstudio.com/)

安装完后还需要装插件[PlatformIO IDE](https://marketplace.visualstudio.com/items?itemName=platformio.platformio-ide)

安装完成后打开`PIO`主页，新建或者使用例程

## [Clion](https://www.jetbrains.com/clion/)

使用`Clion`开发还需要下载安装[STM32CubeMX](https://www.st.com/zh/development-tools/stm32cubemx.html)、[mingw64](https://www.mingw-w64.org/downloads/)、[arm-none-eabi](https://developer.arm.com/tools-and-software/open-source-software/developer-tools/gnu-toolchain/gnu-rm/downloads)

所有都安装完成后，添加`mingw64`和`arm-none-eabi`的`bin`到[环境变量](https://jingyan.baidu.com/article/a17d5285c9b0c48099c8f26a.html)的`path`去

打开Clion新建STM32CubeMX工程即可开始

设置Clion的工具链  
设置C编译器为`安装路径\bin\arm-none-eabi-gcc.exe`  
设置C++编译器为`安装路径\bin\arm-none-eabi-g++.exe`  
调试器为`安装路径\bin\arm-none-eabi-gdb.exe`  

## 在线调试
只有调试工具才能进行在线调试  
例如`ST-Link`、`J-Link`

如果你用`Keil`或者`Stm32CubeIDE`，调试只需要安装驱动即可，如果你使用`VScode`或`Clion`需要安装[openocd](https://gnutoolchains.com/arm-eabi/openocd/)