### Example 1: Remove a connected kubernetes
```powershell
PS C:\> Remove-AzConnectedKubernetes -ResourceGroupName connected-aks -Name wyunchi-pwsh-aks3

```

This command removes a connected kubernetes.

### Example 2: Remove a connected kubernetes by object
```powershell
PS C:\> $conAks = Get-AzConnectedKubernetes -ResourceGroupName connected-aks -Name wyunchi-pwsh-aks1
PS C:\> Remove-AzConnectedKubernetes -InputObject $conAks

```

This command removes a connected kubernetes by object.

