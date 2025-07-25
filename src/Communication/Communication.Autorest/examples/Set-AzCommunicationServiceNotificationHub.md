## EXAMPLES

### Example 1: Provide Notification Hub details interactively

```powershell
Set-AzCommunicationServiceNotificationHub -CommunicationServiceName ContosoAcsResource2 -ResourceGroupName ContosoResourceProvider1 -ConnectionString "<notificationhub-connectionstring>" -NotificationHubResourceId "<notificationhub-resourceid>"
```

A linked notification hub allows a ACS resource to send notifications for certain events.
