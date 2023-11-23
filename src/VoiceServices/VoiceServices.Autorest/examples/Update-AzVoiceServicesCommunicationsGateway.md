### Example 1: Update a gateway
```powershell
Update-AzVoiceServicesCommunicationsGateway -ResourceGroupName vtest-communication-rg -Name vsc-gateway-pwsh01 -Tag @{'key1'='value1'}
```

```output
Location      Name               SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----               -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus vsc-gateway-pwsh01 12/7/2022 7:09:45 AM v-diya@microsoft.com User                    12/7/2022 7:09:45 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

Update a gateway.

### Example 2: Update a gateway by pipeline
```powershell
Get-AzVoiceServicesCommunicationsGateway -ResourceGroupName vtest-communication-rg -Name vsc-gateway-pwsh01 | Update-AzVoiceServicesCommunicationsGateway -Tag @{'key1'='value1'}
```

```output
Location      Name               SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----               -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus vsc-gateway-pwsh01 12/7/2022 7:09:45 AM v-diya@microsoft.com User                    12/7/2022 7:09:45 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

Update a gateway by pipeline.