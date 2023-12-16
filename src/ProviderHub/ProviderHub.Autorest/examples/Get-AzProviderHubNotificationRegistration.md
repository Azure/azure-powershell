### Example 1: List all the notification registration by ProviderNamespace.
```powershell
Get-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso"
```

```output
Name
----
notificationRegistrationTest1
notificationRegistrationTest2
```

List all the notification registration in the provider namespace.

### Example 2: Get the notification registration by name.
```powershell
Get-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso" -Name "notificationRegistrationTest"
```

```output
Name
----
notificationRegistrationTest
```

Get the notification registration by name.
