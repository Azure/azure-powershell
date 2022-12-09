### Example 1: List all contacts under the communications gateway
```powershell
Get-AzVoiceServicesCommunicationsContact -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01
```

```output
Location      Name       SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----       -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus gateway-01 12/7/2022 7:47:30 AM v-diya@microsoft.com User                    12/7/2022 7:47:30 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

List all contacts under the communications gateway.

### Example 2: Get a contact
```powershell
Get-AzVoiceServicesCommunicationsContact -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name gateway-01
```

```output
Location      Name       SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----       -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus gateway-01 12/7/2022 7:47:30 AM v-diya@microsoft.com User                    12/7/2022 7:47:30 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

Get a contact.

### Example 3: Get a contact by pipeline
```powershell
New-AzVoiceServicesCommunicationsContact -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name gateway-01 -Location 'westcentralus' -PhoneNumber "+1-555-1234" -FullContactName "John Smith" -Email "johnsmith@example.com" -Role "Network Manager" | Get-AzVoiceServicesCommunicationsContact
```

```output
Location      Name       SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----       -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus gateway-01 12/7/2022 7:47:30 AM v-diya@microsoft.com User                    12/7/2022 7:47:30 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

Get a contact by pipeline.