### Example 1: Create NotificationSetting for AzADDomain
```powershell
PS C:\> New-AzADDomainServiceNotificationSettingObject -AdditionalRecipient test@microsoft.com -NotifyDcAdmin Enabled -NotifyGlobalAdmin Enabled

AdditionalRecipient  NotifyDcAdmin NotifyGlobalAdmin
-------------------  ------------- -----------------
{test@microsoft.com} Enabled       Enabled
```

Create NotificationSetting for AzADDomain

