### Example 1: Update credentials for a namespace
```powershell
Update-AzDeviceRegistryCredentials -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -Tag @{environment="production"}
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
default eastus   my-resource-group
```

Updates the credentials resource for the specified Device Registry namespace.

{{ Add description here }}

