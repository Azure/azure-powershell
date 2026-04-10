### Example 1: Get credentials for a namespace
```powershell
Get-AzDeviceRegistryCredentials -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace"
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
default eastus   my-resource-group
```

Gets the credentials resource for the specified Device Registry namespace.

{{ Add description here }}

