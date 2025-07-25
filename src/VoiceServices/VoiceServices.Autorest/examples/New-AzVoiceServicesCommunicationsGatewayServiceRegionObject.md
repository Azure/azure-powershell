### Example 1: Create an in-memory object for ServiceRegionProperties
```powershell
$region = @()
$region += New-AzVoiceServicesCommunicationsGatewayServiceRegionObject -Name useast -PrimaryRegionOperatorAddress '198.51.100.1'
$region += New-AzVoiceServicesCommunicationsGatewayServiceRegionObject -Name useast2 -PrimaryRegionOperatorAddress '198.51.100.2'

New-AzVoiceServicesCommunicationsGateway -ResourceGroupName 'vtest-communication-rg' -Name vsc-gateway-pwsh01 -Location 'westcentralus' -Codec 'PCMA' -E911Type 'Standard' -Platform 'OperatorConnect' -ServiceLocation $region
```

```output
Location      Name               SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----               -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus vsc-gateway-pwsh01 12/7/2022 7:09:45 AM v-diya@microsoft.com User                    12/7/2022 7:09:45 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

Create an in-memory object for ServiceRegionProperties and assign to ServiceLocation parameter of the New-AzVoiceServicesCommunicationsGateway.
