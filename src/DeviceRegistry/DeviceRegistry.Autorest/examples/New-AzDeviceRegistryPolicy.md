### Example 1: Create a policy for a namespace
```powershell
New-AzDeviceRegistryPolicy -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -Name "my-policy" -Location "eastus"
```

```output
Name      Location ResourceGroupName
----      -------- -----------------
my-policy eastus   my-resource-group
```

Creates a new policy in the specified Device Registry namespace.

{{ Add description here }}

