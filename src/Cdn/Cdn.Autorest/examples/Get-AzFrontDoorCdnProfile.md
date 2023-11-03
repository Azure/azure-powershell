### Example 1: List AzureFrontDoor profiles under the subscription
```powershell
Get-AzFrontDoorCdnProfile
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
Global   fdp-a345e9 frontdoor testps-rg-da16jm
Global   fdp-t0jfb9 frontdoor testps-rg-zvt8sy
```

List AzureFrontDoor profiles under the subscription


### Example 2: List AzureFrontDoor profiles under the resource group
```powershell
Get-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
Global   fdp-a345e9 frontdoor testps-rg-da16jm
```

List AzureFrontDoor profiles under the resource group


### Example 3: Get an AzureFrontDoor profile under the resource group
```powershell
Get-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```
Get an AzureFrontDoor profile under the resource group


### Example 4: Get an AzureFrontDoor profile under the resource group via identity
```powershell
New-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q7 -SkuName Standard_AzureFrontDoor -Location Global | Get-AzFrontDoorCdnProfile
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q7 frontdoor testps-rg-da16jm
```
Get an AzureFrontDoor profile under the resource group via identity