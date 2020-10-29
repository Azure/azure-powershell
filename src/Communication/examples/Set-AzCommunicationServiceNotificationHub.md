## EXAMPLES

### Example 1: Provide Notification Hub details interactively

```powershell
PS C:\> Set-AzCommunicationServiceNotificationHub -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
cmdlet Set-AzCommunicationServiceNotificationHub at command pipeline position 1
Supply values for the following parameters:
ConnectionString: Endpoint=sb://contosonotificationhubnamespace.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=CWmzuVInoBjs+zphYwyBdzbNzQHpHZG9sfzF2bFnswg=
ResourceId: /subscriptions/73fc3588-3cef-4302-9e19-2d18b71ce0e5/resourcegroups/ContosoResourceProvider1/providers/Microsoft.NotificationHubs/namespaces/contosonotificationhubnamespace/notificationHubs/contosonotificationhub

/subscriptions/73fc3588-3cef-4302-9e19-2d18b71ce0e5/resourcegroups/ContosoResourceProvider1/providers/Microsoft.NotificationHubs/namespaces/contosonotificationhubnamespace/notificationHubs/contosonotificationhub
```

A linked notification hub allows a ACS resource to send notifications for certain events.
