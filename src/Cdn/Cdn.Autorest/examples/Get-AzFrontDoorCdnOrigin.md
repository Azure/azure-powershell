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


### Example 3: Get an AzureFrontDoor origin under the origin group via identity
```powershell
New-AzFrontDoorCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -OriginName ori001 -OriginHostHeader en.wikipedia.org -HostName en.wikipedia.org -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000 | Get-AzFrontDoorCdnOrigin
```

```output
Name   ResourceGroupName
----   -----------------
ori001 testps-rg-da16jm
```

Get an AzureFrontDoor origin under the origin group via identity
