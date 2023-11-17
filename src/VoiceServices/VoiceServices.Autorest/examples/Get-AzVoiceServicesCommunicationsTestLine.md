### Example 1: List all testline under the communications gateway
```powershell
Get-AzVoiceServicesCommunicationsTestLine -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01
```

```output
Location      Name        SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----        -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus testline-01 12/7/2022 7:56:47 AM v-diya@microsoft.com User                    12/7/2022 7:56:47 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

List all testline under the communications gateway.

### Example 2: Get a testline
```powershell
Get-AzVoiceServicesCommunicationsTestLine -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name testline-01
```

```output
Location      Name        SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----        -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus testline-01 12/7/2022 7:56:47 AM v-diya@microsoft.com User                    12/7/2022 7:56:47 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

Get a testline.

### Example 3: Get a testline by pipeline
```powershell
New-AzVoiceServicesCommunicationsTestLine -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name testline-01 -Location westcentralus -Purpose 'Automated' -PhoneNumber "+1-555-1234" | Get-AzVoiceServicesCommunicationsTestLine
```

```output
Location      Name        SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----        -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus testline-01 12/7/2022 7:56:47 AM v-diya@microsoft.com User                    12/7/2022 7:56:47 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

Get a testline by pipeline.