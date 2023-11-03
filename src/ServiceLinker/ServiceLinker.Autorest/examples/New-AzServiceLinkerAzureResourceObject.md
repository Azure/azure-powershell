### Example 1: Create an target resource object for azure resource
```powershell
New-AzServiceLinkerAzureResourceObject -Id /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/servicelinker-test-group/providers/Microsoft.KeyVault/vaults/servicelinker-test-kv -ConnectAsKubernetesCsiDriver 1
```

```output
Id
--
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/servicelinker-test-… 

```

Create an AzureResourceObject as the param of `-TargetService`
