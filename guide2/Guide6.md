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

