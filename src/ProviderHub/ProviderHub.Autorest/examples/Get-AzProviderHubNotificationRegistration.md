### Example 1: List all the notification registration by ProviderNamespace.
```powershell
PS C:\> Get-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso"

Name
----
notificationRegistrationTest1
notificationRegistrationTest2
```

List all the notification registration in the provider namespace.

### Example 2: Get the notification registration by name.
```powershell
PS C:\> Get-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso" -Name "notificationRegistrationTest"

Name
----
notificationRegistrationTest
```

Get the notification registration by name.
