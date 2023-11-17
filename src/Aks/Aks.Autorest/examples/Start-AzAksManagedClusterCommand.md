### Example 1: Run AKS command
```powershell
Start-AzAksManagedClusterCommand -ResourceGroupName mygroup -ResourceName mycluster -Command "kubectl get nodes"
```

```output
ExitCode          : 0
FinishedAt        : 3/31/2023 8:52:17 AM
Id                : 0a3991475d9744fcbfdc2595b40e517f
Log               : NAME                              STATUS   ROLES   AGE   VERSION
                    aks-default-40136599-vmss000000   Ready    agent   46m   v1.24.9
                    aks-pool2-22198594-vmss000000     Ready    agent   43m   v1.24.9

ProvisioningState : Succeeded
Reason            :
StartedAt         : 3/31/2023 8:52:16 AM
```

AKS will create a pod to run the command. This is primarily useful for private clusters.

### Example 2: Run AKS command via identity 
```powershell
$cluster = Get-AzAksCluster -ResourceGroupName mygroup -Name mycluster
$cluster | Start-AzAksManagedClusterCommand -Command "kubectl get nodes"
```

```output
ExitCode          : 0
FinishedAt        : 3/31/2023 8:54:17 AM
Id                : 0a3991475d9744fcbfdc2595b40e517f
Log               : NAME                              STATUS   ROLES   AGE   VERSION
                    aks-default-40136599-vmss000000   Ready    agent   46m   v1.24.9
                    aks-pool2-22198594-vmss000000     Ready    agent   43m   v1.24.9

ProvisioningState : Succeeded
Reason            :
StartedAt         : 3/31/2023 8:54:16 AM
```


