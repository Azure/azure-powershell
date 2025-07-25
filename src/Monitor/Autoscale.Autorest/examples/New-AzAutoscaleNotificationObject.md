### Example 1: Create web hook notification object
```powershell
$webhook1=New-AzAutoscaleWebhookNotificationObject -Property @{} -ServiceUri "http://myservice.com"
New-AzAutoscaleNotificationObject -EmailCustomEmail "gu@ms.com" -EmailSendToSubscriptionAdministrator $true -EmailSendToSubscriptionCoAdministrator $true -Webhook $webhook1
```

Create web hook notification object

