# STM32之VSCode+Cmake+Ninja+GCC+Stm32CubeMX+Debug

首先安装[cmake](https://cmake.org/)，[gcc](https://developer.arm.com/tools-and-software/open-source-software/developer-tools/gnu-toolchain/gnu-rm/downloads)，[ninja](https://ninja-build.org/)，[MinGW](https://gnutoolchains.com/mingw64/)，[openocd](https://openocd.sourceforge.io/)

[VSCode](https://code.visualstudio.com/)，[Stm32CubeMX](https://www.st.com/en/development-tools/stm32cubemx.html)

VSCode与Stm32CubeMX的初始化有大量教程，这里不再说明

只用展开文件，然后添加进运行环境  
![](/pic/pic1.png)

在控制台输入测试  
![](/pic/pic2.png)  
![](/pic/pic3.png)

如果都能找到说明正常

安装VScode扩展
- [Cmake](https://marketplace.visualstudio.com/items?itemName=twxs.cmake)
- [CMake Language Support](https://marketplace.visualstudio.com/items?itemName=josetr.cmake-language-support-vscode)
- [CMake Tools](https://marketplace.visualstudio.com/items?itemName=ms-vscode.cmake-tools)
- [C/C++](https://marketplace.visualstudio.com/items?itemName=ms-vscode.cpptools)
- [Cortex-Debug](https://marketplace.visualstudio.com/items?itemName=marus25.cortex-debug)
- [Cortex-Debug: Device Support Pack - STM32H7](https://marketplace.visualstudio.com/items?itemName=jeandudey.cortex-debug-dp-stm32h7)
- [SVD Viewer](https://marketplace.visualstudio.com/items?itemName=cortex-debug.svd-viewer)

Cortex-Debug需要安装对应芯片的扩展包，我用的是H7所以安装H7的扩展包

语法高亮可以自行选择

使用Stm32CubeMX生成一个项目  
![](/pic/pic4.png)
![](/pic/pic5.png)  
这里演示使用STM32H743并启用了rtos和fatfs

代码生成选项
![](/pic/pic6.png)  

生成代码之后的文件夹  
![](/pic/pic7.png)  

使用VSCode打开此文件夹，新建一个`CMakeLists.txt`
内容大致为
```CMake
set(CMAKE_SYSTEM_NAME Generic)
set(CMAKE_SYSTEM_VERSION 1)
cmake_minimum_required(VERSION 3.18)

# specify cross-compilers and tools
set(CMAKE_C_COMPILER arm-none-eabi-gcc)
set(CMAKE_CXX_COMPILER arm-none-eabi-g++)
set(CMAKE_ASM_COMPILER  arm-none-eabi-gcc)
set(CMAKE_AR arm-none-eabi-ar)
set(CMAKE_OBJCOPY arm-none-eabi-objcopy)
set(CMAKE_OBJDUMP arm-none-eabi-objdump)
set(SIZE arm-none-eabi-size)
set(CMAKE_TRY_COMPILE_TARGET_TYPE STATIC_LIBRARY)

# project settings
project(//TODO C CXX ASM)
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_C_STANDARD 11)

#Uncomment for hardware floating point
#add_compile_definitions(ARM_MATH_CM4;ARM_MATH_MATRIX_CHECK;ARM_MATH_ROUNDING)
#add_compile_options(-mfloat-abi=hard -mfpu=fpv4-sp-d16)
#add_link_options(-mfloat-abi=hard -mfpu=fpv4-sp-d16)

#Uncomment for software floating point
#add_compile_options(-mfloat-abi=soft)

add_compile_options(-mcpu=cortex-m4 -mthumb -mthumb-interwork)
add_compile_options(-ffunction-sections -fdata-sections -fno-common -fmessage-length=0)

# uncomment to mitigate c++17 absolute addresses warnings
#set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -Wno-register")

# Enable assembler files preprocessing
add_compile_options($<$<COMPILE_LANGUAGE:ASM>:-x$<SEMICOLON>assembler-with-cpp>)

if ("${CMAKE_BUILD_TYPE}" STREQUAL "Release")
    message(STATUS "Maximum optimization for speed")
    add_compile_options(-Ofast)
elseif ("${CMAKE_BUILD_TYPE}" STREQUAL "RelWithDebInfo")
    message(STATUS "Maximum optimization for speed, debug info included")
    add_compile_options(-Ofast -g)
elseif ("${CMAKE_BUILD_TYPE}" STREQUAL "MinSizeRel")
    message(STATUS "Maximum optimization for size")
    add_compile_options(-Os)
else ()
    message(STATUS "Minimal optimization, debug info included")
    add_compile_options(-Og -g)
endif ()

include_directories(
    //TODO
)

add_definitions(
    //TODO
)

file(GLOB_RECURSE SOURCES
    //TODO
)

set(LINKER_SCRIPT ${CMAKE_SOURCE_DIR}/
    //TODO
.ld)

add_link_options(-Wl,-gc-sections,--print-memory-usage,-Map=${PROJECT_BINARY_DIR}/${PROJECT_NAME}.map)
add_link_options(-mcpu=cortex-m4 -mthumb -mthumb-interwork)
add_link_options(-T ${LINKER_SCRIPT})

add_executable(${PROJECT_NAME}.elf ${SOURCES} ${LINKER_SCRIPT})

set(HEX_FILE ${PROJECT_BINARY_DIR}/${PROJECT_NAME}.hex)
set(BIN_FILE ${PROJECT_BINARY_DIR}/${PROJECT_NAME}.bin)

add_custom_command(TARGET ${PROJECT_NAME}.elf POST_BUILD
        COMMAND ${CMAKE_OBJCOPY} -Oihex $<TARGET_FILE:${PROJECT_NAME}.elf> ${HEX_FILE}
        COMMAND ${CMAKE_OBJCOPY} -Obinary $<TARGET_FILE:${PROJECT_NAME}.elf> ${BIN_FILE}
        COMMENT "Building ${HEX_FILE}
Building ${BIN_FILE}")

```

然后打开`.cproject`  
对照修改`CMakeLists.txt`

1. 项目名字
```CMake
project(//TODO C CXX ASM)
```
中的`//TODO`修改为项目名字，例如
```CMake
project(mcu1 C CXX ASM)
```

2. 浮点处理器（不需要的可以跳过）
```CMake
#Uncomment for hardware floating point
#add_compile_definitions(ARM_MATH_CM4;ARM_MATH_MATRIX_CHECK;ARM_MATH_ROUNDING)
#add_compile_options(-mfloat-abi=hard -mfpu=fpv4-sp-d16)
#add_link_options(-mfloat-abi=hard -mfpu=fpv4-sp-d16)

#Uncomment for software floating point
#add_compile_options(-mfloat-abi=soft)
```

如果使用软件浮点
```CMake
#Uncomment for hardware floating point
#add_compile_definitions(ARM_MATH_CM4;ARM_MATH_MATRIX_CHECK;ARM_MATH_ROUNDING)
#add_compile_options(-mfloat-abi=hard -mfpu=fpv4-sp-d16)
#add_link_options(-mfloat-abi=hard -mfpu=fpv4-sp-d16)

#Uncomment for software floating point
add_compile_options(-mfloat-abi=soft)
```

如果使用硬件浮点
```CMake
#Uncomment for hardware floating point
add_compile_definitions(ARM_MATH_CM4;ARM_MATH_MATRIX_CHECK;ARM_MATH_ROUNDING)
add_compile_options(-mfloat-abi=hard -mfpu=fpv4-sp-d16)
add_link_options(-mfloat-abi=hard -mfpu=fpv4-sp-d16)

#Uncomment for software floating point
#add_compile_options(-mfloat-abi=soft)
```

3. CPU内核
```CMake
add_compile_options(-mcpu=cortex-m4 -mthumb -mthumb-interwork)
add_compile_options(-ffunction-sections -fdata-sections -fno-common -fmessage-length=0)

...

add_link_options(-Wl,-gc-sections,--print-memory-usage,-Map=${PROJECT_BINARY_DIR}/${PROJECT_NAME}.map)
add_link_options(-mcpu=cortex-m4 -mthumb -mthumb-interwork)
add_link_options(-T ${LINKER_SCRIPT})
```
其中的`-mcpu=`要修改为你的单片机内核
- H7:cortex-m7
- F4:cortex-m4
- F1:cortex-m3

4. 全局定义
```CMake
add_definitions(
    //TODO
)
```

在`.cproject`中查找`definedSymbols`  
![](/pic/pic8.png)  
其中的`value`就是要添加的东西  
修改后为(要记得前面加上`-D`)
```CMake
add_definitions(-DDEBUG -DUSE_FULL_LL_DRIVER -DUSE_HAL_DRIVER -DSTM32H743xx)
```

5. 代码文件
```CMake
file(GLOB_RECURSE SOURCES
    //TODO
)
```

在`.cproject`中查找`sourceEntries`  
![](/pic/pic9.png)  
其中的`Name`就是要添加的东西  
修改后为
```CMake
file(GLOB_RECURSE SOURCES "Core/*.*" "FATFS/*.*" "Middlewares/*.*" "Drivers/*.*")
```

6. 头文件路径
```CMake
include_directories(
    //TODO
)
```

在`.cproject`中查找`includePath`  
![](/pic/pic10.png)  
其中的`Value`就是要添加的东西  
修改后为(前面的`../`去掉)
```CMake
include_directories(Core/Inc FATFS/Target FATFS/App Drivers/STM32H7xx_HAL_Driver/Inc Drivers/STM32H7xx_HAL_Driver/Inc/Legacy Middlewares/Third_Party/FreeRTOS/Source/include Middlewares/Third_Party/FreeRTOS/Source/CMSIS_RTOS_V2 Middlewares/Third_Party/FreeRTOS/Source/portable/GCC/ARM_CM4F Middlewares/Third_Party/FatFs/src Drivers/CMSIS/Device/ST/STM32H7xx/Include Drivers/CMSIS/Include)
```

7. LD文件
```CMake
set(LINKER_SCRIPT ${CMAKE_SOURCE_DIR}/
    //TODO
.ld)
```

在根目录下有两个`.ld`文件，选择`FLASH`的那个
```CMake
set(LINKER_SCRIPT ${CMAKE_SOURCE_DIR}/STM32H743VITx_FLASH.ld)
```

修改完成后的`CMakeLists.txt`
```CMake
set(CMAKE_SYSTEM_NAME Generic)
set(CMAKE_SYSTEM_VERSION 1)
cmake_minimum_required(VERSION 3.18)

# specify cross-compilers and tools
set(CMAKE_C_COMPILER arm-none-eabi-gcc)
set(CMAKE_CXX_COMPILER arm-none-eabi-g++)
set(CMAKE_ASM_COMPILER  arm-none-eabi-gcc)
set(CMAKE_AR arm-none-eabi-ar)
set(CMAKE_OBJCOPY arm-none-eabi-objcopy)
set(CMAKE_OBJDUMP arm-none-eabi-objdump)
set(SIZE arm-none-eabi-size)
set(CMAKE_TRY_COMPILE_TARGET_TYPE STATIC_LIBRARY)

# project settings
project(mcu_test1 C CXX ASM)
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_C_STANDARD 11)

#Uncomment for hardware floating point
add_compile_definitions(ARM_MATH_CM4;ARM_MATH_MATRIX_CHECK;ARM_MATH_ROUNDING)
add_compile_options(-mfloat-abi=hard -mfpu=fpv4-sp-d16)
add_link_options(-mfloat-abi=hard -mfpu=fpv4-sp-d16)

#Uncomment for software floating point
#add_compile_options(-mfloat-abi=soft)

add_compile_options(-mcpu=cortex-m7 -mthumb -mthumb-interwork)
add_compile_options(-ffunction-sections -fdata-sections -fno-common -fmessage-length=0)

# uncomment to mitigate c++17 absolute addresses warnings
#set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -Wno-register")

# Enable assembler files preprocessing
add_compile_options($<$<COMPILE_LANGUAGE:ASM>:-x$<SEMICOLON>assembler-with-cpp>)

if ("${CMAKE_BUILD_TYPE}" STREQUAL "Release")
    message(STATUS "Maximum optimization for speed")
    add_compile_options(-Ofast)
elseif ("${CMAKE_BUILD_TYPE}" STREQUAL "RelWithDebInfo")
    message(STATUS "Maximum optimization for speed, debug info included")
    add_compile_options(-Ofast -g)
elseif ("${CMAKE_BUILD_TYPE}" STREQUAL "MinSizeRel")
    message(STATUS "Maximum optimization for size")
    add_compile_options(-Os)
else ()
    message(STATUS "Minimal optimization, debug info included")
    add_compile_options(-Og -g)
endif ()

include_directories(Core/Inc FATFS/Target FATFS/App Drivers/STM32H7xx_HAL_Driver/Inc Drivers/STM32H7xx_HAL_Driver/Inc/Legacy Middlewares/Third_Party/FreeRTOS/Source/include Middlewares/Third_Party/FreeRTOS/Source/CMSIS_RTOS_V2 Middlewares/Third_Party/FreeRTOS/Source/portable/GCC/ARM_CM4F Middlewares/Third_Party/FatFs/src Drivers/CMSIS/Device/ST/STM32H7xx/Include Drivers/CMSIS/Include)

add_definitions(-DDEBUG -DUSE_FULL_LL_DRIVER -DUSE_HAL_DRIVER -DSTM32H743xx)

file(GLOB_RECURSE SOURCES "Core/*.*" "FATFS/*.*" "Middlewares/*.*" "Drivers/*.*")

set(LINKER_SCRIPT ${CMAKE_SOURCE_DIR}/STM32H743VITx_FLASH.ld)

add_link_options(-Wl,-gc-sections,--print-memory-usage,-Map=${PROJECT_BINARY_DIR}/${PROJECT_NAME}.map)
add_link_options(-mcpu=cortex-m7 -mthumb -mthumb-interwork)
add_link_options(-T ${LINKER_SCRIPT})

add_executable(${PROJECT_NAME}.elf ${SOURCES} ${LINKER_SCRIPT})

set(HEX_FILE ${PROJECT_BINARY_DIR}/${PROJECT_NAME}.hex)
set(BIN_FILE ${PROJECT_BINARY_DIR}/${PROJECT_NAME}.bin)

add_custom_command(TARGET ${PROJECT_NAME}.elf POST_BUILD
        COMMAND ${CMAKE_OBJCOPY} -Oihex $<TARGET_FILE:${PROJECT_NAME}.elf> ${HEX_FILE}
        COMMAND ${CMAKE_OBJCOPY} -Obinary $<TARGET_FILE:${PROJECT_NAME}.elf> ${BIN_FILE}
        COMMENT "Building ${HEX_FILE}
Building ${BIN_FILE}")
```

点击VSCode的左下角Cmake，或者重新打开VSCode  
选择Gcc工具链  
![](/pic/pic11.png)  
`GCC 10.3.1 arm-none-eabi`

CMake会自动加载，出现这步则加载完成
![](/pic/pic12.png)  

点击`build`编译
![](/pic/pic13.png)  
正常来说会使用`ninja`来编译并链接

工程创建和构建到此完成，下面是调试

打开VSCode的调试界面，点击`创建 launch.json文件`
![](/pic/pic14.png)  
选择`C++ GBD`

点击`显示所有自动调试配置`->`添加配置`
![](/pic/pic15.png)  

找到`cortex-debug`  
![](/pic/pic16.png)  
选择你的调试器类型

修改`executable`的`.elf`路径
```
"executable": "./build/mcu_test1.elf",
```

按下F5就能debug了

# 其他

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
