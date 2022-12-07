### Example 1: Update a contact
```powershell
Update-AzVoiceServicesCommunicationsContact -ResourceGroupName lucas-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name gateway-01 -Tag @{'key1'='value1'}
```

```output
Location      Name       SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----       -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus gateway-01 12/7/2022 7:47:30 AM v-diya@microsoft.com User                    12/7/2022 8:34:33 AM     v-diya@microsoft.com     User                         lucas-communication-rg 
```

Update a contact.

### Example 2: Update a contact by pipeline
```powershell
Get-AzVoiceServicesCommunicationsContact -ResourceGroupName lucas-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name gateway-01 | Update-AzVoiceServicesCommunicationsContact -Tag @{'key1'='value1'}
```

```output
Location      Name       SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----       -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus gateway-01 12/7/2022 7:47:30 AM v-diya@microsoft.com User                    12/7/2022 8:34:33 AM     v-diya@microsoft.com     User                         lucas-communication-rg 
```

Update a contact by pipeline.