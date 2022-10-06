# ESP32之VSCode+ESP-IDF

首先安装esp-idf

[Windows快速方法](https://docs.espressif.com/projects/esp-idf/zh_CN/latest/esp32/get-started/windows-setup.html)

```
$ git clone https://github.com/espressif/esp-idf.git
```

设置环境变量
IDF_PATH

![](/pic/pic17.png)

cd到esp-idf目录

设置工具
```
./install.bat
```

这期间会下载esp需要的所有东西，需要外网

如果提示
```
E:\workload\esp\esp-idf>install.bat

Error: The following tools are not installed in your environment.

  python


Please use the Windows Tool installer for setting up your environment.
Download link: https://dl.espressif.com/dl/esp-idf/
For more details please visit our website: https://docs.espressif.com/projects/esp-idf/en/latest/esp32/get-started/windows-setup.html
```

则需要以下步骤

[安装python3](https://www.python.org/downloads/)
将python环境变量加入到Path中

![](/pic/pic18.png)

重启cmd窗口
再次输入
```
./install.bat
```

出现下面日志则表示安装完成
```
E:\workload\esp\esp-idf>install.bat
Installing ESP-IDF tools
Current system platform: win64
Selected targets are: esp32c2, esp32, esp32h2, esp32c6, esp32c3, esp32s3, esp32s2
Installing tools: xtensa-esp-elf-gdb, riscv32-esp-elf-gdb, xtensa-esp32-elf, xtensa-esp32s2-elf, xtensa-esp32s3-elf, riscv32-esp-elf, esp32ulp-elf, cmake, openocd-esp32, ninja, idf-exe, ccache, dfu-util, esp-rom-elfs
Skipping xtensa-esp-elf-gdb@11.2_20220823 (already installed)
Skipping riscv32-esp-elf-gdb@11.2_20220823 (already installed)
Skipping xtensa-esp32-elf@esp-2022r1-11.2.0 (already installed)
Skipping xtensa-esp32s2-elf@esp-2022r1-11.2.0 (already installed)
Skipping xtensa-esp32s3-elf@esp-2022r1-11.2.0 (already installed)
Skipping riscv32-esp-elf@esp-2022r1-11.2.0 (already installed)
Skipping esp32ulp-elf@2.35_20220830 (already installed)
Skipping cmake@3.24.0 (already installed)
Skipping openocd-esp32@v0.11.0-esp32-20220706 (already installed)
Skipping ninja@1.10.2 (already installed)
Skipping idf-exe@1.0.3 (already installed)
Skipping ccache@4.6.2 (already installed)
Skipping dfu-util@0.9 (already installed)
Installing esp-rom-elfs@20220823
Downloading https://github.com/espressif/esp-rom-elfs/releases/download/20220823/esp-rom-elfs-20220823.tar.gz
Destination: C:\Users\40206\.espressif\dist\esp-rom-elfs-20220823.tar.gz.tmp
Done
Extracting C:\Users\40206\.espressif\dist\esp-rom-elfs-20220823.tar.gz to C:\Users\40206\.espressif\tools\esp-rom-elfs\20220823
Setting up Python environment
Python 3.8.7
pip 20.3.3 from C:\Users\40206\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages\pip (python 3.8)
Upgrading pip and setuptools...
Requirement already satisfied: pip in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (22.2.2)
Requirement already satisfied: setuptools in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (65.4.0)
Collecting setuptools
  Downloading setuptools-65.4.1-py3-none-any.whl (1.2 MB)
     |████████████████████████████████| 1.2 MB 384 kB/s
Installing collected packages: setuptools
  Attempting uninstall: setuptools
    Found existing installation: setuptools 65.4.0
    Uninstalling setuptools-65.4.0:
      Successfully uninstalled setuptools-65.4.0
Successfully installed setuptools-65.4.1
Downloading https://dl.espressif.com/dl/esp-idf/espidf.constraints.v5.1.txt
Destination: C:\Users\40206\.espressif\espidf.constraints.v5.1.txt.tmp
Done
Installing Python packages
 Constraint file: C:\Users\40206\.espressif\espidf.constraints.v5.1.txt
 Requirement files:
  - E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt
Looking in indexes: https://pypi.org/simple, https://dl.espressif.com/pypi
Requirement already satisfied: setuptools in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from -r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 3)) (65.4.1)
Requirement already satisfied: click in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from -r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 4)) (8.1.3)
Requirement already satisfied: pyserial in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from -r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 5)) (3.5)
Requirement already satisfied: cryptography in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from -r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 6)) (38.0.1)
Requirement already satisfied: pyparsing in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from -r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 7)) (3.0.9)
Requirement already satisfied: pyelftools in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from -r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 8)) (0.29)
Requirement already satisfied: idf-component-manager in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from -r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 9)) (1.1.4)
Requirement already satisfied: esp-coredump in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from -r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 10)) (1.3)
Requirement already satisfied: esptool in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from -r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 11)) (4.3)
Requirement already satisfied: kconfiglib in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from -r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 14)) (14.1.0)
Requirement already satisfied: windows-curses in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from -r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 15)) (2.3.0)
Requirement already satisfied: freertos_gdb in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from -r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 18)) (1.0.1)
Requirement already satisfied: colorama in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from click->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 4)) (0.4.5)
Requirement already satisfied: cffi>=1.12 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from cryptography->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 6)) (1.15.1)
Requirement already satisfied: pycparser in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from cffi>=1.12->cryptography->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 6)) (2.21)
Collecting esp-coredump
  Downloading https://dl.espressif.com/pypi/esp-coredump/esp_coredump-1.4-py3-none-any.whl (33 kB)
Requirement already satisfied: pygdbmi>=0.9.0.2 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from esp-coredump->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 10)) (0.9.0.2)
Requirement already satisfied: construct~=2.10 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from esp-coredump->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 10)) (2.10.68)
Requirement already satisfied: bitstring>=3.1.6 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from esptool->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 11)) (3.1.9)
Requirement already satisfied: reedsolo<=1.5.4,>=1.5.3 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from esptool->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 11)) (1.5.4)
Requirement already satisfied: ecdsa>=0.16.0 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from esptool->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 11)) (0.18.0)
Requirement already satisfied: six>=1.9.0 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from ecdsa>=0.16.0->esptool->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 11)) (1.16.0)
Requirement already satisfied: requests-toolbelt in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from idf-component-manager->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 9)) (0.9.1)
Requirement already satisfied: schema in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from idf-component-manager->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 9)) (0.7.5)
Requirement already satisfied: contextlib2>0.6.0 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from idf-component-manager->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 9)) (21.6.0)
Requirement already satisfied: requests<3 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from idf-component-manager->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 9)) (2.28.1)
Requirement already satisfied: tqdm<5 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from idf-component-manager->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 9)) (4.64.1)
Requirement already satisfied: pyyaml>5.2 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from idf-component-manager->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 9)) (6.0)
Requirement already satisfied: future in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from idf-component-manager->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 9)) (0.18.2)
Requirement already satisfied: idna<4,>=2.5 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from requests<3->idf-component-manager->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 9)) (3.3)
Requirement already satisfied: urllib3<1.27,>=1.21.1 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from requests<3->idf-component-manager->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 9)) (1.26.12)
Requirement already satisfied: certifi>=2017.4.17 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from requests<3->idf-component-manager->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 9)) (2022.6.15)
Requirement already satisfied: charset-normalizer<3,>=2 in e:\workload\.espressif\python_env\idf5.1_py3.8_env\lib\site-packages (from requests<3->idf-component-manager->-r E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt (line 9)) (2.1.1)
Installing collected packages: esp-coredump
  Attempting uninstall: esp-coredump
    Found existing installation: esp-coredump 1.3
    Uninstalling esp-coredump-1.3:
      Successfully uninstalled esp-coredump-1.3
Successfully installed esp-coredump-1.4
All done! You can now run:
   export.bat

```


[参考](https://docs.espressif.com/projects/esp-idf/zh_CN/latest/esp32/get-started/linux-macos-setup.html#get-started-set-up-tools)

## esp-idf更新（如果需要）

```
git pull
git submodule update --init --recursive
```

## 编译项目

首先拷贝一份模板

在esp-idf的目录下打开cmd输入
```
E:\workload\esp\esp-idf>export.bat
Checking Python compatibility
Setting IDF_PATH: E:\workload\esp\esp-idf

Adding ESP-IDF tools to PATH...
Not using an unsupported version of tool cmake found in PATH: 3.24.2.
Not using an unsupported version of tool openocd-esp32 found in PATH: 0.11.0.
Not using an unsupported version of tool ninja found in PATH: 1.11.1.
    C:\Users\40206\.espressif\tools\xtensa-esp-elf-gdb\11.2_20220823\xtensa-esp-elf-gdb\bin
    C:\Users\40206\.espressif\tools\riscv32-esp-elf-gdb\11.2_20220823\riscv32-esp-elf-gdb\bin
    C:\Users\40206\.espressif\tools\xtensa-esp32-elf\esp-2022r1-11.2.0\xtensa-esp32-elf\bin
    C:\Users\40206\.espressif\tools\xtensa-esp32s2-elf\esp-2022r1-11.2.0\xtensa-esp32s2-elf\bin
    C:\Users\40206\.espressif\tools\xtensa-esp32s3-elf\esp-2022r1-11.2.0\xtensa-esp32s3-elf\bin
    C:\Users\40206\.espressif\tools\riscv32-esp-elf\esp-2022r1-11.2.0\riscv32-esp-elf\bin
    C:\Users\40206\.espressif\tools\esp32ulp-elf\2.35_20220830\esp32ulp-elf\bin
    C:\Users\40206\.espressif\tools\cmake\3.24.0\bin
    C:\Users\40206\.espressif\tools\openocd-esp32\v0.11.0-esp32-20220706\openocd-esp32\bin
    C:\Users\40206\.espressif\tools\ninja\1.10.2\
    C:\Users\40206\.espressif\tools\idf-exe\1.0.3\
    C:\Users\40206\.espressif\tools\ccache\4.6.2\ccache-4.6.2-windows-x86_64
    C:\Users\40206\.espressif\tools\dfu-util\0.9\dfu-util-0.9-win64
    C:\Users\40206\.espressif\python_env\idf5.1_py3.8_env\Scripts
    E:\workload\esp\esp-idf\tools

Checking if Python packages are up to date...
Skipping the download of C:\Users\40206\.espressif\espidf.constraints.v5.1.txt because it was downloaded recently.
Constraint file: C:\Users\40206\.espressif\espidf.constraints.v5.1.txt
Requirement files:
 - E:\workload\esp\esp-idf\tools\requirements\requirements.core.txt
Python being checked: C:\Users\40206\.espressif\python_env\idf5.1_py3.8_env\Scripts\python.exe
Python requirements are satisfied.

Detected installed tools that are not currently used by active ESP-IDF version.
For removing esp32s2ulp-elf use command 'python.exe E:\workload\esp\esp-idf\tools\idf_tools.py uninstall'
For free up even more space, remove installation packages of those tools. Use option 'python.exe E:\workload\esp\esp-idf\tools\idf_tools.py uninstall --remove-archives'.


Done! You can now compile ESP-IDF projects.
Go to the project directory and run:

  idf.py build


```

然后CD到代码目录，输入
```
idf.py build
```

此时，代码目录会出现一个build文件夹

## VSCode配置

- [C/C++](https://marketplace.visualstudio.com/items?itemName=ms-vscode.cpptools)

使用VSCode打开代码目录即可

配置`.vscode\c_cpp_properties.json`项目
```json
{
    "configurations": [
        {
            "name": "ESP-IDF",
            "compilerPath": "C:\\Users\\40206\\.espressif\\tools\\xtensa-esp32-elf\\esp-2022r1-11.2.0\\xtensa-esp32-elf\\bin\\xtensa-esp32-elf-gcc.exe",
            "cStandard": "c11",
            "cppStandard": "c++17",
            "includePath": [
                "${IDF_PATH}/components/**",
                "${workspaceFolder}/**"
            ],
            "browse": {
                "path": [
                    "${IDF_PATH}/components",
                    "${workspaceFolder}"
                ],
                "limitSymbolsToIncludedHeaders": false
            },
            "compileCommands": "${workspaceFolder}/build/compile_commands.json"
        }
    ],
    "version": 4
}
```

其中的`compilerPath`需要根据你的esp32芯片进行修改

![](/pic/pic19.png)

自动补全啥的都会生效，但是VsCode内不能编译，只能在cmd内
```
idf.py build
```