### Example 1: Create a test line for the communications gateway
```powershell
New-AzVoiceServicesCommunicationsTestLine -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name testline-01 -Location westcentralus -Purpose 'Automated' -PhoneNumber "+1-555-1234"
```

```output
Location      Name        SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----        -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus testline-01 12/7/2022 7:56:47 AM v-diya@microsoft.com User                    12/7/2022 7:56:47 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

Create a test line for the communications gateway.