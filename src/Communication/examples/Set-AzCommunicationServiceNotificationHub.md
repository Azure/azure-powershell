## EXAMPLES

### Example 1: Provide Notification Hub details interactively

```powershell
<<<<<<< HEAD
Set-AzCommunicationServiceNotificationHub -CommunicationServiceName ContosoAcsResource2 -ResourceGroupName ContosoResourceProvider1 -ConnectionString "<notificationhub-connectionstring>" -NotificationHubResourceId "<notificationhub-resourceid>"
=======
PS C:\> Set-AzCommunicationServiceNotificationHub -CommunicationServiceName ContosoAcsResource2 -ResourceGroupName ContosoResourceProvider1 -ConnectionString "<notificationhub-connectionstring>" -NotificationHubResourceId "<notificationhub-resourceid>"
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

A linked notification hub allows a ACS resource to send notifications for certain events.
