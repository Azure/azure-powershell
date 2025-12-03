### Example 1: Remove credentials from a namespace
```powershell
Remove-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group
```

Removes the credentials resource from the namespace. This operation is destructive and will affect all devices and policies that depend on these credentials. **Warning:** All associated policies must be deleted before credentials can be removed.

### Example 2: Remove credentials with confirmation prompt
```powershell
Remove-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -Confirm
```

```output
Confirm
Are you sure you want to remove credentials from namespace 'my-namespace'? This will affect all associated policies and devices.
[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"): Y
```

Removes the credentials after prompting for user confirmation due to the destructive nature of the operation.

### Example 3: Remove credentials without confirmation
```powershell
Remove-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -Confirm:$false
```

Removes the credentials without prompting for confirmation. Useful for automation scenarios where the consequences are understood.

### Example 4: Remove credentials via identity object
```powershell
$credentialsIdentity = @{
    SubscriptionId = "xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Remove-AzDeviceRegistryCredentials -InputObject $credentialsIdentity -Confirm:$false
```

Removes the credentials using an identity object parameter.

### Example 5: Remove credentials after cleaning up policies
```powershell
# First remove all policies
Get-AzDeviceRegistryPolicy -NamespaceName my-namespace -ResourceGroupName my-resource-group | Remove-AzDeviceRegistryPolicy -Confirm:$false

# Then remove credentials
Remove-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -Confirm:$false
```

Demonstrates the proper cleanup sequence: remove all dependent policies first, then remove the credentials resource.
