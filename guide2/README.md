# Minecraft启动器制作教程

**本教程只适用于JAVA版**

更新日期`2024-9-9`

## 目录

- [前言](#前言)
  - [工具说明](#工具说明)
- [游戏文件](Guide1.md/#游戏文件)
  - [游戏元数据](Guide1.md/#游戏元数据)
  - [游戏版本元数据](Guide1.md/#游戏版本元数据)
  - [资源文件](Guide1.md/#资源文件)
  - [文件储存结构](Guide1.md/#文件储存结构)
- [登录与启动](Guide2.md/#登录与启动)
  - [OAuth登录新账户](Guide2.md/#OAuth登录新账户)
  - [OAuth刷新密钥](Guide2.md/#OAuth刷新密钥)
  - [第三方登录](Guide2.md/#第三方登录)
  - [游戏启动](Guide2.md/#游戏启动)
- [模组加载器](Guide3.md/#模组加载器)
  - [Forge元数据获取](Guide3.md/#Forge元数据获取)
  - [ForgeV1解析运行库](Guide3.md/#ForgeV1解析运行库)
  - [ForgeV2解析运行库](Guide3.md/#ForgeV2解析运行库)
  - [Forge旧版启动](Guide3.md/#Forge旧版启动)
  - [Forge新版启动](Guide3.md/#Forge新版启动)
  - [Fabric获取与启动](Guide3.md/#Fabric获取与启动)
  - [NeoForge地址](Guide3.md/#NeoForge地址)
  - [Quilt地址](Guide3.md/#Quilt地址)
- [模组文件解析](Guide4.md/#模组文件解析)
  - [Forge旧版](Guide3.md/#Forge旧版)
  - [Forge新版](Guide3.md/#Forge新版)
  - [NeoForge旧版](Guide3.md/#NeoForge旧版)
  - [NeoForge新版](Guide3.md/#NeoForge新版)
  - [ForgeCore模组](Guide3.md/#ForgeCore模组)
  - [Forgelowcodeloader模组](Guide3.md/#Forgelowcodeloader模组)
  - [Fabric模组](Guide3.md/#Fabric模组)
  - [Quilt模组](Guide3.md/#Quilt模组)
- [NBT标签读取](Guide5.md/#NBT标签读取)
- [其他资源读取](Guide6.md/#NBT标签读取)
- [玩家皮肤获取](Guide7.md/#NBT标签读取)
- [CurseForge资源获取](Guide8.md/#NBT标签读取)
- [Modrinth资源获取](Guide9.md/#NBT标签读取)

## 前言

本教授是由Coloryr编写的关于[Minecraft](https://minecraft.net/)JAVA版本的启动器教程  
教程适用于JAVA8开始的游戏版本，及1.7.10以上的版本  
参考资料基本都来源于https://minecraft.wiki/

在编写启动器之前，你需要掌握以下知识
- 掌握一门编程语言
- 理解HTTP Web请求
- 理解Json的写法与数据解析
- 了解Java的启动方式
- 了解什么是文件
- 有自己的思考能力，能够自己解决问题

**我在这里不推荐任何一个新手去编写启动器**  
因为难度非常大，并且需要花费非常多的时间，只适合有能力，有闲时的人去这么做  
如果你没有任何知识，一定要去做一个启动器，那么可以先去学习编程语言，了解编程思想，再来看本教程  
**本教程不附带任何源码**  
本教程只做文字及图表说明，实际代码需要你自己去完成  

### 工具说明

本教程大部分地方都是用了[Postman](https://www.postman.com/)工具发起请求
