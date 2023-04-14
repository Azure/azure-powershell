### Example 1: Create an AzureFrontDoor origin under the AzureFrontDoor origin group
```powershell
 New-AzFrontDoorCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -OriginName ori001 -OriginHostHeader en.wikipedia.org -HostName en.wikipedia.org -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000
```

```output
Name   ResourceGroupName
----   -----------------
ori001 testps-rg-da16jm
```

Create an AzureFrontDoor origin under the AzureFrontDoor origin group