## 模组文件解析

游戏模组这里只给出Forge，Fabric的解析，其余的都是类似的内容

模组Jar可以使用zip软件打开查看里面的内容，提取一些关键文件即可解析

Forge的模组分为旧版与新版两种  
Forge的CoreMod需要另外做处理解析

### Forge旧版
Forge旧版的jar里面有一个关键的`json`格式的文件`mcmod.info`，这里面包含了该mod的数据  
一般内容如下
```json
[
{
  "modid": "actuallyadditions",
  "name": "Actually Additions",
  "description": "Do you want Automation? Wireless Transport? Better Machines? A cup o' Coffee? Chests? Better Hoppers? Leaf Blowers? Faster Growth? Plants? Well, Actually Additions has all that and a lot more!",
  "version": "1.12.2-r152",
  "mcversion": "1.12.2",
  "url": "http://github.com/Ellpeck/ActuallyAdditions",
  "updateUrl": "",
  "authorList": [ "Ellpeck" ],
  "credits": "Author: Ellpeck; Textures and Models: BootyToast, GlenthorLP, canitzp",
  "logoFile": "assets/actuallyadditions/textures/logo.png",
  "screenshots": [
  ],
  "parent":"",
  "dependencies": [
  ]
}
]
```
或者
```json
{
  "modListVersion": 2,
  "modList": [{
    "modid": "armorunder",
    "name": "Armor Underwear",
    "description": "Give your armor warming or cooling underwear (a ToughAsNails utility)",
    "version": "1.0.0",
    "mcversion": "1.12.2",
    "url": "https://minecraft.curseforge.com/projects/armor-underwear-mod",
    "updateUrl": "",
    "authorList": ["The_Wabbit"],
    "credits": "Forge, Pig-Ralph and family, Llama Mama, and Polarbear Ned",
    "logoFile": "",
    "screenshots": [],
    "dependencies": ["carrots"]
  }]
}
```
你会发现这两其实差不多，只不过有些时候会多套了一层`list`  
这时候反序列化这个json就能拿到所有关于模组的信息了  

### Forge新版
Forge新版的jar里面有一个关键的`toml`文件`META-INF/mods.toml`，这里面包含了该mod的数据  
一般是这种结构
```toml
modLoader="javafml"
loaderVersion="[46,)"
license="All Rights Reserved"

[[mods]]
modId="adorabuild_structures"
version="2.7.0"
displayName="AdoraBuild: Structures"
displayURL="https://www.curseforge.com/minecraft/mc-mods/adorabuild-structures"
logoFile="logo.png"
authors="Vlad Hatylo, Kate Hatylo"
credits="AdoraBuild"
description="AdoraBuild: Structures adds 100 new structures like houses, castles, temples, hidden treasures, etc. to enhance the world exploration. Generated structures are biome specific and fit perfectly into the environment."

[[dependencies.adorabuild_structures]]
    modId="minecraft"
    mandatory=true
    versionRange="[1.20,1.20.2]"
    ordering="NONE"
    side="BOTH"

[[dependencies.adorabuild_structures]]
    modId="forge"
    mandatory=true
    versionRange="[46,)"
```
`mods`节点是关键数据，里面包含了模组的所有信息

### NeoForge旧版
这个跟[Forge新版](#Forge新版)一样，同样的结构，同样的文件名

### NeoForge新版
这个跟[Forge新版](#Forge新版)一样，同样的结构，但是文件名改成了`META-INF/neoforge.mods.toml`，内容也有所不同  
例如
```toml
# There are several mandatory fields (#mandatory), and many more that are optional (#optional).
# The overall format is standard TOML format, v0.5.0.
# Note that there are a couple of TOML lists in this file.
# Find more information on toml format here:  https://github.com/toml-lang/toml

# The name of the mod loader type to load - for regular FML @Mod mods it should be javafml
modLoader="javafml" #mandatory

# A version range to match for said mod loader - for regular FML @Mod it will be the minecraft version (without the 1.)
loaderVersion="[4,)" #mandatory

# A URL to refer people to when problems occur with this mod
issueTrackerURL="https://github.com/mezz/JustEnoughItems/issues?q=is%3Aissue" #optional

# License
license="The MIT License (MIT)"

# A file name (in the root of the mod JAR) containing a logo for display
#logoFile="examplemod.png" #optional

# A text field displayed in the mod UI
#credits="Thanks for this example mod goes to Java" #optional

# A list of mods - how many allowed here is determined by the individual mod loader
[[mods]] #mandatory

# The modid of the mod
modId="jei" #mandatory

# The version number of the mod
version="19.17.0.193" #mandatory

# A display name for the mod
displayName="Just Enough Items" #mandatory

# A URL for the "homepage" for this mod, displayed in the mod UI
displayURL="https://www.curseforge.com/minecraft/mc-mods/jei" #optional

# A URL to query for updates for this mod. See the JSON update specification <here>
#updateJSONURL="" #optional

# A text field displayed in the mod UI
# credits="" #optional

# A text field displayed in the mod UI
authors="mezz" #optional

# The description text for the mod (multi line!) (#mandatory)
description='''
JEI is an item and recipe viewing mod for Minecraft, built from the ground up for stability and performance.
'''

# A dependency - use the . to indicate dependency for a specific modid. Dependencies are optional.
[[dependencies.jei]]
    modId="neoforge" #mandatory
    type="required" #mandatory
    versionRange="[21.0.118-beta,)" #mandatory
    # An ordering relationship for the dependency - BEFORE or AFTER required if the relationship is not mandatory
    ordering="NONE"
    # Side this dependency is applied on - BOTH, CLIENT or SERVER
    side="BOTH"

[[dependencies.jei]]
    modId="minecraft" #mandatory
    type="required" #mandatory
    versionRange="[1.21, 1.21.1)" #mandatory
    # An ordering relationship for the dependency - BEFORE or AFTER required if the relationship is not mandatory
    ordering="NONE"
    # Side this dependency is applied on - BOTH, CLIENT or SERVER
    side="BOTH"

[modproperties.jei]
    catalogueImageIcon="jei-icon.png"

```

### ForgeCore模组
这类模组不存在`modid.info`文件，只能通过下面几种方式进行判断  
方式1  
查找文件`META-INF/services/cpw.mods.modlauncher.api.ITransformationService`  
或者文件`META-INF/services/net.minecraftforge.forgespi.language.IModLanguageProvider`  
若其中一个存在，则为Core Mod，模组信息只能通过`META-INF/MANIFEST.MF`来获取  

方式2  
查找文件`META-INF/fml_cache_annotation.json`  
若存在，读取这个json，然后寻找节点`acceptedMinecraftVersions`，这里面就有模组信息

方式3  
通过JAVA反射来获取模组信息，相当于自己做一套Forge系统来读取模组信息（跳过吧）

### Forgelowcodeloader模组
在新版中，还有一种模组叫做lowcodeloader，其内容为  
```toml
modLoader = 'lowcodefml'
loaderVersion = '[40,)'
license = 'LicenseRef-All-Rights-Reserved'
showAsResourcePack = false
mods = [
	{ modId = 'mr_dungeons_andtaverns', version = '3.0.3.f', displayName = 'Dungeons and Taverns', description = 'A Structure Datapack adding dungeons, taverns and other structures to find while you explore the world.', logoFile = 'dungeons-and-taverns_pack.png', updateJSONURL = 'https://api.modrinth.com/updates/tpehi7ww/forge_updates.json', credits = 'Generated by Modrinth', authors = 'NovaWostra, Walls', displayURL = 'https://modrinth.com/datapack/dungeons-and-taverns' },
]
issueTrackerURL = 'https://github.com/NovaWostra/Dungeons-and-Taverns/issues'
```
这是一种数据包当作模组的加载方式，其内容跟新版Forge模组大差不差

### Fabric模组
Fabric的模组通过读取`fabric.mod.json`文件来获取信息  
例如
```json
{
  "schemaVersion": 1,
  "id": "armorstandarms",
  "version": "1.0.1",

  "name": "Armor Stand Armrs",
  "description": "Use the command /trigger armorstandarms to add arms to armor stands.",
  "authors": [
    "GamerPotion", "Rav115"
  ],
  "contact": {
    "homepage": "https://www.gamerpotion.net/2024/06/armor-stand-arms.html"
  },

  "license": "All Rights Reserved",
  "icon": "assets/armorstandarms/icon.png",
    "depends": {
    "fabricloader": ">=0.14.6",
    "fabric": ">=0.53.0",
    "minecraft": ">=1.19",
    "java": ">=17"
  }
}
```
有些模组还会使用JarinJar来打包依赖或者其他模组  
此时还需要读取jar里面的`META-INF\jars`目录下的所有jar，这里可能会包含其他模组  
例如
```
fabric-api-0.103.0+1.21.1.jar \
  - META-INF \
    - jars \
      - fabric-api-base-0.103.0.jar
      - fabric-api-lookup-api-v1-0.103.0.jar
      - fabric-biome-api-v1-0.103.0.jar
      ...
```
然后你再打开`fabric-api-base-0.103.0.jar`，会发现这其实又是一个fabric模组  
因此fabric的一个模组会有套娃的可能

## Quilt模组
跟Fabric类似，文件名改成了`quilt.mod.json`，且内容结构也进行了修改  
例如
```json
{
  "schema_version": 1,
  "quilt_loader": {
    "group": "com.emmacypress",
    "id": "quilt_loading_screen",
    "provides": [
      "quilt-loading-screen"
    ],
    "version": "6.1.0+1.20.1",
    "metadata": {
      "name": "Quilt Loading Screen",
      "description": "Makes the Minecraft loading screen have QuiltMC patches",
      "contributors": {
        "hibi": "Owner",
        "triphora": "Previous Maintainer",
        "darkerbit": "Original Author"
      },
      "contact": {
        "homepage": "https://modrinth.com/mod/quilt-loading-screen",
        "issues": "https://github.com/hibiii/quilt_loading_screen/issues",
        "sources": "https://github.com/hibiii/quilt_loading_screen"
      },
      "license": "MIT",
      "icon": "assets/quilt_loading_screen/icon.png"
    },
    "intermediate_mappings": "net.fabricmc:intermediary",
    "entrypoints": {
      "client_init": "com.emmacypress.quilt_loading_screen.QLSClientInit",
      "modmenu": "com.emmacypress.quilt_loading_screen.ModMenuInteg"
    },
    "depends": [
      "minecraft",
      "quilt_loader",
      "quilt_resource_loader",
      {
        "id": "midnightlib",
        "version": "\u003e\u003d1.1.0",
        "reason": "Config library"
      },
      {
        "id": "modmenu",
        "reason": "For actually configuring stuff",
        "optional": true
      }
    ],
    "jars": [
      "META-INF/jars/midnightlib-1.4.1-fabric.jar"
    ]
  },
  "mixin": "quilt_loading_screen.mixins.json",
  "minecraft": {
    "environment": "client"
  },
  "modmenu": {
    "links": {
      "modmenu.modrinth": "https://modrinth.com/mod/quilt-loading-screen"
    }
  }
}
```