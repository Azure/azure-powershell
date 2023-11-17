### Example 1: Create an AzureFrontDoor profile under the resource group
```powershell
New-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 -SkuName Standard_AzureFrontDoor -Location Global
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Create an AzureFrontDoor profile under the resource group