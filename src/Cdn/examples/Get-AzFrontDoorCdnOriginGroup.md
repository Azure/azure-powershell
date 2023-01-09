### Example 1: List AzureFrontDoor origin groups under the profile
```powershell
Get-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
org002 testps-rg-da16jm
```

List AzureFrontDoor origin groups under the profile



### Example 2: Get an AzureFrontDoor origin group under the profile
```powershell
Get-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```
Get an AzureFrontDoor origin group under the profile

