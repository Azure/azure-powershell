### Example 1: List AzureFrontDoor origins under the origin group 
```powershell
 Get-AzFrontDoorCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001
```

```output
Name   ResourceGroupName
----   -----------------
ori001 testps-rg-da16jm
ori002 testps-rg-da16jm
```
List AzureFrontDoor origins under the origin group 


### Example 2: Get an AzureFrontDoor origin under the origin group
```powershell
Get-AzFrontDoorCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -OriginName ori001
```

```output
Name   ResourceGroupName
----   -----------------
ori001 testps-rg-da16jm
```

Get an AzureFrontDoor origin under the origin group


