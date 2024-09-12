## 其他资源读取

这里说明 材质包 数据包的读取方式

### 材质包解析
材质包里面基本只需要读取`pack.mcmeta`即可，这里面有所有的信息  
示例
```json
{
  "pack": {
    "pack_format": 3,
    "description": "RLHats"
  }
}
```
`description`中可能会带有彩色字的符号  
`pack.png`就是这个材质包的图片了

### 光影包解析
光影包里面基本需要读取`lang/en_US.lang`，然后读取项目`option`，就能取得光影包的名字  
但是这个名字极其难获取，有可能不存在，因此需要做很多判断

### 数据包解析
数据包是放在存档里面的`datapacks`文件夹  
里面的格式跟`材质包`大差不差

数据包是否启用，可以查看`level.dat`中的
```
Data -> DataPacks
```
里面有两个列表`Enabled`和`Disabled`  
这里面是禁用和启用的数据包列表