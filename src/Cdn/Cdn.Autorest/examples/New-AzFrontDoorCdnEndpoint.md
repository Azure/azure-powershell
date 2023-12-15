### Example 1: Create an AzureFrontDoor endpoint under the AzureFrontDoor profile
```powershell
New-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -Location Global -EnabledState Enabled
```

```output
Location Name   ResourceGroupName
-------- ----   -----------------
Global   end001 testps-rg-da16jm
```

Create an AzureFrontDoor endpoint under the AzureFrontDoor profile