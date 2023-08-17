### Example 1: Update an AzureFrontDoor endpoint under the profile
```powershell
Update-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -EnabledState Disabled
```

```output
Location Name   ResourceGroupName
-------- ----   -----------------
Global   end001 testps-rg-da16jm
```

Update an AzureFrontDoor endpoint under the profile


### Example 2: Update an AzureFrontDoor endpoint under the profile via identity
```powershell
Get-AzFrontDoorCdnEndpoint  -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end011 | Update-AzFrontDoorCdnEndpoint -EnabledState Disabled
```

```output
Location Name   ResourceGroupName
-------- ----   -----------------
Global   end011 testps-rg-da16jm
```

Update an AzureFrontDoor endpoint under the profile via identity

