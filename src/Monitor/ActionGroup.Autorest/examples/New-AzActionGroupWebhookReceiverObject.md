### Example 1: create action group webhook receiver with aad auth
```powershell
New-AzActionGroupWebhookReceiverObject -Name "sample webhook" -ServiceUri "http://www.example.com/webhook1" -IdentifierUri "http://someidentifier/d7811ba3-7996-4a93-99b6-6b2f3f355f8a" -ObjectId "d3bb868c-fe44-452c-aa26-769a6538c808" -TenantId 68a4459a-ccb8-493c-b9da-dd30457d1b84 -UseAadAuth $true -UseCommonAlertSchema $true
```

```output
IdentifierUri        : http://someidentifier/d7811ba3-7996-4a93-99b6-6b2f3f355f8a
Name                 : sample webhook
ObjectId             : d3bb868c-fe44-452c-aa26-769a6538c808
ServiceUri           : http://www.example.com/webhook1
TenantId             : 68a4459a-ccb8-493c-b9da-dd30457d1b84
UseAadAuth           : True
UseCommonAlertSchema : True
```

This command creates action group webhook receiver object.

### Example 2: create minimum action group webhook receiver
```powershell
New-AzActionGroupWebhookReceiverObject -Name "sample webhook" -ServiceUri "http://www.example.com/webhook2"                                                        
```

```output
IdentifierUri        : 
Name                 : sample webhook
ObjectId             : 
ServiceUri           : http://www.example.com/webhook2
TenantId             : 
UseAadAuth           : 
UseCommonAlertSchema : 
```

This command creates action group email receiver object.

