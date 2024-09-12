## 玩家皮肤获取

需要取到玩家的皮肤，需要先知道玩家的UUID

可以通过Http请求得到数据
```
GET https://api.mojang.com/users/profiles/minecraft/{name}
```
得到结果
```json
{
    "id": "cced95f30a844377b8c18e60cf1b3fea",
    "name": "Color_yr"
}
```
此时这个id就是玩家的uuid，后面皮肤的请求通过这个uuid
```
https://sessionserver.mojang.com/session/minecraft/profile/{uuid}
```
得到结果
```json
{
    "id": "cced95f30a844377b8c18e60cf1b3fea",
    "name": "Color_yr",
    "properties": [
        {
            "name": "textures",
            "value": "ewogICJ0aW1lc3RhbXAiIDogMTcyNjAyNjM4MjcyOCwKICAicHJvZmlsZUlkIiA6ICJjY2VkOTVmMzBhODQ0Mzc3YjhjMThlNjBjZjFiM2ZlYSIsCiAgInByb2ZpbGVOYW1lIiA6ICJDb2xvcl95ciIsCiAgInRleHR1cmVzIiA6IHsKICAgICJTS0lOIiA6IHsKICAgICAgInVybCIgOiAiaHR0cDovL3RleHR1cmVzLm1pbmVjcmFmdC5uZXQvdGV4dHVyZS9iZTliNGI2NWM4MWM0N2NkYTZlZmZlMTczYTkwYWJjMzI4NjRlNGIxNDdkMzdhN2EzODU0Mjg3MzkzYzQ4YmVjIiwKICAgICAgIm1ldGFkYXRhIiA6IHsKICAgICAgICAibW9kZWwiIDogInNsaW0iCiAgICAgIH0KICAgIH0sCiAgICAiQ0FQRSIgOiB7CiAgICAgICJ1cmwiIDogImh0dHA6Ly90ZXh0dXJlcy5taW5lY3JhZnQubmV0L3RleHR1cmUvY2Q5ZDgyYWIxN2ZkOTIwMjJkYmQ0YTg2Y2RlNGMzODJhNzU0MGUxMTdmYWU3YjlhMjg1MzY1ODUwNWE4MDYyNSIKICAgIH0KICB9Cn0="
        }
    ],
    "profileActions": []
}
```
然后其中的`properties`中的`textures`，里面有玩家的皮肤和披风数据  
对`value`中的BASE64进行解码，得到  
```json
{
  "timestamp" : 1726026382728,
  "profileId" : "cced95f30a844377b8c18e60cf1b3fea",
  "profileName" : "Color_yr",
  "textures" : {
    "SKIN" : {
      "url" : "http://textures.minecraft.net/texture/be9b4b65c81c47cda6effe173a90abc32864e4b147d37a7a3854287393c48bec",
      "metadata" : {
        "model" : "slim"
      }
    },
    "CAPE" : {
      "url" : "http://textures.minecraft.net/texture/cd9d82ab17fd92022dbd4a86cde4c382a7540e117fae7b9a2853658505a80625"
    }
  }
}
```
此时就拿到了玩家披风和皮肤的图片下载地址