### Example 1: List AzureFrontDoor endpoints under the profile
```powershell
Get-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6
```

```output
Location Name   ResourceGroupName
-------- ----   -----------------
Global   end001 testps-rg-da16jm
Global   end002 testps-rg-da16jm
```

List AzureFrontDoor endpoints under the profile


### Example 2: Get an AzureFrontDoor endpoint under the profile
```powershell
Get-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001
```

```output
Location Name   ResourceGroupName
-------- ----   -----------------
Global   end001 testps-rg-da16jm
```

Get an AzureFrontDoor endpoint under the profile


### Example 2: Get an AzureFrontDoor endpoint under the profile via identity
```powershell
New-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end011 -Location Global -EnabledState Enabled 
| Get-AzFrontDoorCdnEndpoint
```

```output
Location Name   ResourceGroupName
-------- ----   -----------------
Global   end011 testps-rg-da16jm
```

Get an AzureFrontDoor endpoint under the profile via identity