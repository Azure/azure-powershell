### Example 1: Remove a policy by name
```powershell
Remove-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group
```

Removes the specified policy from the namespace. This operation is destructive and cannot be undone. Devices using this policy will need to be reassigned to a different policy.

### Example 2: Remove a policy with confirmation prompt
```powershell
Remove-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group -Confirm
```

```output
Confirm
Are you sure you want to remove the policy 'my-policy'?
[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"): Y
```

Removes the policy after prompting for user confirmation.

### Example 3: Remove a policy without confirmation
```powershell
Remove-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group -Confirm:$false
```

Removes the policy without prompting for confirmation. Useful for automation scenarios.

### Example 4: Remove a policy via identity object
```powershell
$policyIdentity = @{
    SubscriptionId = "xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
    CredentialName = "default"
    PolicyName = "my-policy-name"
}
Remove-AzDeviceRegistryPolicy -InputObject $policyIdentity -Confirm:$false
```

Removes a policy object using an identity object parameter.

### Example 5: Remove multiple policies using pipeline
```powershell
Get-AzDeviceRegistryPolicy -NamespaceName my-namespace -ResourceGroupName my-resource-group | Where-Object { $_.Tag.environment -eq "test" } | Remove-AzDeviceRegistryPolicy -Confirm:$false
```

Retrieves all policies with the "test" environment tag and removes them in bulk.
