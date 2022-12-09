### Example 1: Create a contact for the communications gateway
```powershell
New-AzVoiceServicesCommunicationsContact -ResourceGroupName vtest-communication-rg -CommunicationsGatewayName vsc-gateway-pwsh01 -Name contact-01 -Location 'westcentralus' -PhoneNumber "+1-555-1234" -FullContactName "John Smith" -Email "johnsmith@example.com" -Role "Network Manager"
```

```output
Location      Name       SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      RetryAfter
--------      ----       -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------      ----------
westcentralus contact-01 12/7/2022 7:47:30 AM v-diya@microsoft.com User                    12/7/2022 7:47:30 AM     v-diya@microsoft.com     User                         vtest-communication-rg 
```

Create a contact for the communications gateway.