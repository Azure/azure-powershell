### Example 1: List all the notification registration by ProviderNamespace.
```powershell
<<<<<<< HEAD
Get-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso"
```

```output
=======
PS C:\> Get-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name
----
notificationRegistrationTest1
notificationRegistrationTest2
```

List all the notification registration in the provider namespace.

### Example 2: Get the notification registration by name.
```powershell
<<<<<<< HEAD
Get-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso" -Name "notificationRegistrationTest"
```

```output
=======
PS C:\> Get-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso" -Name "notificationRegistrationTest"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name
----
notificationRegistrationTest
```

Get the notification registration by name.
