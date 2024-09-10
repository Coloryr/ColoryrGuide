## 游戏文件

在启动游戏之前，我们需要获取游戏文件，Minecraft游戏文件（下面简称文件）由几部分组成  
- 游戏核心(Minecraft.jar)
- 运行库(xxxx-xxx-xxx.jar)
- 资源文件(音乐、音效等文件)

### 游戏元数据
首先需要请求获取版本列表，网址为：`https://launchermeta.mojang.com/mc/game/version_manifest_v2.json`  

```
GET https://launchermeta.mojang.com/mc/game/version_manifest_v2.json
```

得到下面的数据
```json
{
    "latest": {
        "release": "1.20.4",
        "snapshot": "24w09a"
    },
    "versions": [
        {
            "id": "24w09a",
            "type": "snapshot",
            "url": "https://piston-meta.mojang.com/v1/packages/dc6fd93b4a4856000343557281a47c27192cdd3b/24w09a.json",
            "time": "2024-02-28T13:17:23+00:00",
            "releaseTime": "2024-02-28T12:38:12+00:00",
            "sha1": "dc6fd93b4a4856000343557281a47c27192cdd3b",
            "complianceLevel": 1
        },
        ....
    ]
}
```

其中`latest`为最新版号
```json
{
    "latest": {
        "release": "{最新正式版}",
        "snapshot": "{最新预览版}"
    }
}
```

剩下的`versions`为目前所有的游戏版本
```json
{
    "id": "{游戏版本}",
    "type": "{类型}",
    "url": "{元数据地址}",
    "time": "{时间}",
    "releaseTime": "{发布时间}",
    "sha1": "{元数据SHA1}",
    "complianceLevel": 1
}
```

`类型`有快照`snapshot` 正式版`release` 旧测试版`old_beta` 旧内测版`old_alpha`几种，可以通过该字段来区分游戏版本

### 游戏版本元数据
选择一个想要启动的版本，比如`1.20.4`，获取版本元数据

```
GET https://piston-meta.mojang.com/v1/packages/8bcd47def18efee744bd0700e86ab44a96ade21f/1.20.4.json
```

可以得到下面的数据结构
```json
{
    "arguments": {
        "game": [
            "--username",
            "${auth_player_name}",
            ...
            {
                "rules": [
                    {
                        "action": "allow",
                        "features": {
                            "is_quick_play_realms": true
                        }
                    }
                ],
                "value": [
                    "--quickPlayRealms",
                    "${quickPlayRealms}"
                ]
            }
        ],
        "jvm": [
            ...
            {
                "rules": [
                    {
                        "action": "allow",
                        "os": {
                            "arch": "x86"
                        }
                    }
                ],
                "value": "-Xss1M"
            },
            "-Djava.library.path=${natives_directory}",
            "-Djna.tmpdir=${natives_directory}",
            "-Dorg.lwjgl.system.SharedLibraryExtractPath=${natives_directory}",
            "-Dio.netty.native.workdir=${natives_directory}",
            "-Dminecraft.launcher.brand=${launcher_name}",
            "-Dminecraft.launcher.version=${launcher_version}",
            "-cp",
            "${classpath}"
        ]
    },
    "assetIndex": {
        "id": "12",
        "sha1": "518a69b460cb49a5547cea4290d343116a5d2eb8",
        "size": 436400,
        "totalSize": 627004279,
        "url": "https://piston-meta.mojang.com/v1/packages/518a69b460cb49a5547cea4290d343116a5d2eb8/12.json"
    },
    "assets": "12",
    "complianceLevel": 1,
    "downloads": {
        "client": {
            "sha1": "fd19469fed4a4b4c15b2d5133985f0e3e7816a8a",
            "size": 24445539,
            "url": "https://piston-data.mojang.com/v1/objects/fd19469fed4a4b4c15b2d5133985f0e3e7816a8a/client.jar"
        },
        "client_mappings": {
            "sha1": "be76ecc174ea25580bdc9bf335481a5192d9f3b7",
            "size": 8897012,
            "url": "https://piston-data.mojang.com/v1/objects/be76ecc174ea25580bdc9bf335481a5192d9f3b7/client.txt"
        },
        "server": {
            "sha1": "8dd1a28015f51b1803213892b50b7b4fc76e594d",
            "size": 49150256,
            "url": "https://piston-data.mojang.com/v1/objects/8dd1a28015f51b1803213892b50b7b4fc76e594d/server.jar"
        },
        "server_mappings": {
            "sha1": "c1cafe916dd8b58ed1fe0564fc8f786885224e62",
            "size": 6797462,
            "url": "https://piston-data.mojang.com/v1/objects/c1cafe916dd8b58ed1fe0564fc8f786885224e62/server.txt"
        }
    },
    "id": "1.20.4",
    "javaVersion": {
        "component": "java-runtime-gamma",
        "majorVersion": 17
    },
    "libraries": [
        ...
        {
            "downloads": {
                "artifact": {
                    "path": "org/lwjgl/lwjgl-tinyfd/3.3.2/lwjgl-tinyfd-3.3.2-natives-windows-x86.jar",
                    "sha1": "0c1dfa1c438e0262453e7bf625289540e5cbffb2",
                    "size": 111596,
                    "url": "https://libraries.minecraft.net/org/lwjgl/lwjgl-tinyfd/3.3.2/lwjgl-tinyfd-3.3.2-natives-windows-x86.jar"
                }
            },
            "name": "org.lwjgl:lwjgl-tinyfd:3.3.2:natives-windows-x86",
            "rules": [
                {
                    "action": "allow",
                    "os": {
                        "name": "windows"
                    }
                }
            ]
        },
        ...
        {
            "downloads": {
                "artifact": {
                    "path": "org/slf4j/slf4j-api/2.0.7/slf4j-api-2.0.7.jar",
                    "sha1": "41eb7184ea9d556f23e18b5cb99cad1f8581fc00",
                    "size": 63635,
                    "url": "https://libraries.minecraft.net/org/slf4j/slf4j-api/2.0.7/slf4j-api-2.0.7.jar"
                }
            },
            "name": "org.slf4j:slf4j-api:2.0.7"
        }
    ],
    "logging": {
        "client": {
            "argument": "-Dlog4j.configurationFile=${path}",
            "file": {
                "id": "client-1.12.xml",
                "sha1": "bd65e7d2e3c237be76cfbef4c2405033d7f91521",
                "size": 888,
                "url": "https://piston-data.mojang.com/v1/objects/bd65e7d2e3c237be76cfbef4c2405033d7f91521/client-1.12.xml"
            },
            "type": "log4j2-xml"
        }
    },
    "mainClass": "net.minecraft.client.main.Main",
    "minimumLauncherVersion": 21,
    "releaseTime": "2023-12-07T12:56:20+00:00",
    "time": "2023-12-07T12:56:20+00:00",
    "type": "release"
}
```

- arguments 启动参数  
`arguments`为游戏启动时所需的JVM与游戏参数  
`arguments.game`为游戏参数，`arguments.jvm`为JVM参数，其中有些参数是一个`rule`的对象  
```json
{
    "rules": [
        {
            "action": "allow",
            "features": {
                "has_custom_resolution": true
            }
        }
    ],
    "value": [
        "--width",
        "${resolution_width}",
        "--height",
        "${resolution_height}"
    ]
}
```
这表示这是一个平台\可选参数，`rules`为生效所需的条件，`rules.action`是生效的方向，例如`allow`表示条件满足生效，`features`为生效的附加条件，例如`has_custom_resolution`表示需要启用自定义分辨率时添加，`value`为附加的参数    
有些启动参数是必须要添加的，比如
```json
{
    "rules": [
        {
            "action": "allow",
            "os": {
                "name": "osx"
            }
        }
    ],
    "value": [
        "-XstartOnFirstThread"
    ]
}
```
这个表示，在osx系统下，就是mac上启动游戏时，需要添加启动参数`-XstartOnFirstThread`，如果不添加则无法正常启动  
在这些游戏参数中，由`${}`包裹起来的东西，是启动器在启动前需要换掉的内容  

- assetIndex 资源文件元信息  
`assetIndex`为资源元信息，游戏所需的资源文件需要通过这个元信息来获取
```json
{
    "id": "{版本号}",
    "sha1": "{元信息SHA1值}",
    "size": "{文件大小}",
    "totalSize": "{资源文件总大小}",
    "url": "{获取网址}"
},
```
`版本号`在低版本直接叫`1.12.2` 高版本就只有数字` 1 2 3 ...`  
旧一点的版本，比如`1.12.2`，没有`arguments`这个字段，在旧版本中叫`minecraftArguments`  
是一个一长串的游戏参数字符串
```
--username ${auth_player_name} --version ${version_name} --gameDir ${game_directory} --assetsDir ${assets_root} --assetIndex ${assets_index_name} --uuid ${auth_uuid} --accessToken ${auth_access_token} --userType ${user_type} --versionType ${version_type}
```
旧版本的元数据里面只有游戏参数，没有JVM参数，但JVM参数可以使用  
```
-Djava.library.path=${natives_directory}
-cp
${classpath}
```
来代替  
目前已知的参数有
```
auth_player_name: 用户名
version_name: 版本名
game_directory: 游戏路径，就是config等的根目录
assets_root: 资源路径
assets_index_name: 资源名，直接填 assetIndex.id
auth_uuid: 账户UUID
auth_access_token: 账户token
user_type: 账户类型，正版登录为msa
version_type: 版本类型，直接填 type
resolution_width: 游戏窗口宽度
resolution_height: 游戏窗口高度
quickPlayPath: 快速加入保留的日志(1.20新增)
quickPlaySingleplayer: 快速加入存档名字(1.20新增)
quickPlayMultiplayer: 快速加入的服务器(1.20新增)
quickPlayRealms: 快速加入的领域服(1.20新增)
(三种快速加入只能三选一)
natives_directory: native库路径
launcher_name: 启动器名字
launcher_version: 启动器版本
classpath: JVM的ClassPath
```
还没有搞懂的参数
```
auth_xuid: 不知道是啥
```

- downloads 核心下载  
`downloads`为游戏核心下载地址
```json
{
    //客户端地址
    "client": {
        "sha1": "fd19469fed4a4b4c15b2d5133985f0e3e7816a8a",
        "size": 24445539,
        "url": "https://piston-data.mojang.com/v1/objects/fd19469fed4a4b4c15b2d5133985f0e3e7816a8a/client.jar"
    },
    //客户端混淆表
    "client_mappings": {
        "sha1": "be76ecc174ea25580bdc9bf335481a5192d9f3b7",
        "size": 8897012,
        "url": "https://piston-data.mojang.com/v1/objects/be76ecc174ea25580bdc9bf335481a5192d9f3b7/client.txt"
    },
    //服务端地址
    "server": {
        "sha1": "8dd1a28015f51b1803213892b50b7b4fc76e594d",
        "size": 49150256,
        "url": "https://piston-data.mojang.com/v1/objects/8dd1a28015f51b1803213892b50b7b4fc76e594d/server.jar"
    },
    //服务端混淆表
    "server_mappings": {
        "sha1": "c1cafe916dd8b58ed1fe0564fc8f786885224e62",
        "size": 6797462,
        "url": "https://piston-data.mojang.com/v1/objects/c1cafe916dd8b58ed1fe0564fc8f786885224e62/server.txt"
    }
}
```
通过这个网址下载到的jar，就是游戏核心jar  

- javaVersion 所需java版本
`javaVersion.majorVersion`所表示的就是最低要求的JAVA版本号，低于该版本号将无法启动

- libraries 运行库    
游戏启动所需的运行库列表
```json
{
    //下载地址
    "downloads": {
        "artifact": {
            "path": "ca/weblite/java-objc-bridge/1.1/java-objc-bridge-1.1.jar",
            "sha1": "1227f9e0666314f9de41477e3ec277e542ed7f7b",
            "size": 1330045,
            "url": "https://libraries.minecraft.net/ca/weblite/java-objc-bridge/1.1/java-objc-bridge-1.1.jar"
        }
    },
    //文件名字
    "name": "ca.weblite:java-objc-bridge:1.1",
    //是否使用，这个用于区分系统
    "rules": [
        {
            "action": "allow",
            "os": {
                "name": "osx"
            }
        }
    ]
}
```
在旧版本，运行库还有这种格式  
```json
{
    "downloads": {
        //native库
        "classifiers": {
            "natives-linux": {
                "path": "org/lwjgl/lwjgl/lwjgl-platform/2.9.2-nightly-20140822/lwjgl-platform-2.9.2-nightly-20140822-natives-linux.jar",
                "sha1": "d898a33b5d0a6ef3fed3a4ead506566dce6720a5",
                "size": 578539,
                "url": "https://libraries.minecraft.net/org/lwjgl/lwjgl/lwjgl-platform/2.9.2-nightly-20140822/lwjgl-platform-2.9.2-nightly-20140822-natives-linux.jar"
            },
            "natives-osx": {
                "path": "org/lwjgl/lwjgl/lwjgl-platform/2.9.2-nightly-20140822/lwjgl-platform-2.9.2-nightly-20140822-natives-osx.jar",
                "sha1": "79f5ce2fea02e77fe47a3c745219167a542121d7",
                "size": 468116,
                "url": "https://libraries.minecraft.net/org/lwjgl/lwjgl/lwjgl-platform/2.9.2-nightly-20140822/lwjgl-platform-2.9.2-nightly-20140822-natives-osx.jar"
            },
            "natives-windows": {
                "path": "org/lwjgl/lwjgl/lwjgl-platform/2.9.2-nightly-20140822/lwjgl-platform-2.9.2-nightly-20140822-natives-windows.jar",
                "sha1": "78b2a55ce4dc29c6b3ec4df8ca165eba05f9b341",
                "size": 613680,
                "url": "https://libraries.minecraft.net/org/lwjgl/lwjgl/lwjgl-platform/2.9.2-nightly-20140822/lwjgl-platform-2.9.2-nightly-20140822-natives-windows.jar"
            }
        }
    },
    "extract": {
        "exclude": [
            "META-INF/"
        ]
    },
    "name": "org.lwjgl.lwjgl:lwjgl-platform:2.9.2-nightly-20140822",
    "natives": {
        "linux": "natives-linux",
        "osx": "natives-osx",
        "windows": "natives-windows"
    },
    "rules": [
        {
            "action": "allow",
            "os": {
                "name": "osx"
            }
        }
    ]
}
```
这表示下载的jar里面含有`native`库，需要进行jar解压，将jar通过zip解压后，可以得到一个文件目录结构
```
- \
  - liblwjgl.so
  - liblwjgl64.so
  - libopenal.so
  - libopenal64.so
```
这些`native`库都需要解压出来，放在`native`文件夹下面，如果不这样做，游戏将无法启动

- logging 日志附加选项  
`logging`用于在JVM参数附加防止`log4j`的[0day漏洞](https://nvd.nist.gov/vuln/detail/CVE-2021-44228)，可以不用  

### 资源文件
从上面游戏版本元数据中，请求资源文件的元数据
```
GET https://piston-meta.mojang.com/v1/packages/518a69b460cb49a5547cea4290d343116a5d2eb8/12.json
```

得到下面数据结构（很长很长）
```json
{
    "objects": {
        "icons/icon_128x128.png": {
            "hash": "b62ca8ec10d07e6bf5ac8dae0c8c1d2e6a1e3356",
            "size": 9101
        },
        "icons/icon_16x16.png": {
            "hash": "5ff04807c356f1beed0b86ccf659b44b9983e3fa",
            "size": 781
        },
        "icons/icon_256x256.png": {
            "hash": "8030dd9dc315c0381d52c4782ea36c6baf6e8135",
            "size": 19642
        },
        "icons/icon_32x32.png": {
            "hash": "af96f55a90eaf11b327f1b5f8834a051027dc506",
            "size": 2063
        },
        ...
    }
}
```

这一堆列表就是资源文件了，取其中一个来看
```json
{
    //名字
    "icons/icon_128x128.png": {
        //哈希值
        "hash": "b62ca8ec10d07e6bf5ac8dae0c8c1d2e6a1e3356",
        //大小
        "size": 9101
    },
}
```
它的下载地址为
```
https://resources.download.minecraft.net/b6/b62ca8ec10d07e6bf5ac8dae0c8c1d2e6a1e3356
```

### 文件储存结构
知道文件从哪里获取之后，就需要找个地方存起来
  
- 元数据
我推荐是本地存一份，然后启动前请求一次，检测SHA1值，然后判断有无版本更新  
资源文件的元数据需要存起来
- 游戏核心  
游戏核心丢那里都行我习惯放在`/libraries/net/minecraft/client/client-xxx.jar`
- 运行库  
运行库的放置也是可以随便放，但是我更喜欢按结构来放  
比如，一个运行库的名字为`ca.weblite:java-objc-bridge:1.1`  
那么我会放在`/libraries/ca/weblite/java-objc-bridge/1.1/java-objc-bridge-1.1.jar`
- 资源文件  
资源文件需要有点讲究的放，一般资源文件都是以下结构
```
- assets \
  - indexes \
    - 1.12.json
    - 12.json
  - objects \
    - 00 \
      - 000c82756fd54e40cb236199f2b479629d0aca2f
      ...
    - 0a \
      - 0a0bc1ffa05ac5ff00eb2b1bb9093818a35b85b9
    ...
  - skin \
    - 00 \
      - xxxxxx
      ...
    - 01 \
      - xxxxx
```
也就是分为三类，然后取SHA1前两位做一个文件夹，然后再以文件名为SHA1值储存

到此所有游戏文件就获取结束了