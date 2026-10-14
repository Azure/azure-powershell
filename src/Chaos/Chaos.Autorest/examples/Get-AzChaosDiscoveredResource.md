### Example 1: List all resources discovered for a workspace
```powershell
Get-AzChaosDiscoveredResource -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace
```

```output
Name                Type
----                ----
contoso-vm          Microsoft.Compute/virtualMachines
contoso-aks-cluster Microsoft.ContainerService/managedClusters
```

Lists every resource that the `contoso-workspace` workspace discovered inside its configured scopes.

### Example 2: Get a single discovered resource by name
```powershell
Get-AzChaosDiscoveredResource -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Name contoso-vm
```

```output
Name       Type
----       ----
contoso-vm Microsoft.Compute/virtualMachines
```

Gets a single discovered resource by name from the `contoso-workspace` workspace.
