### Example 1:
```powershell
PS C:\> New-AzAks -ResourceGroupName group -Name myCluster
```

Create a new managed Kubernetes cluster with default params

### Example 2:
```powershell
PS C:\> $addOn = @{enabled=$true}
PS C:\> $addonProfile = @{additionalProperties=($addOn)}
PS C:\> New-AzAks -ResourceGroupName group -Name myCluster -AddOnProfile $addonProfile
```

Create a new managed Kubernetes cluster with AddOnProfile

