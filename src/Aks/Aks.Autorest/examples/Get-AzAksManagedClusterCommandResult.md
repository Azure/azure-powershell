### Example 1: Get the results of a command which has been run on the Managed Cluster.
```powershell
Get-AzAksManagedClusterCommandResult -ResourceGroupName mygroup -ResourceName mycluster -CommandId '706de66629b14267b4962cf015122c12'
```

```output
ExitCode          : 0
FinishedAt        : 3/31/2023 9:14:40 AM
Id                : 706de66629b14267b4962cf015122c12
Log               : NAME                              STATUS   ROLES   AGE   VERSION
                    aks-default-40136599-vmss000000   Ready    agent   68m   v1.24.9
                    aks-pool2-22198594-vmss000000     Ready    agent   65m   v1.24.9

ProvisioningState : Succeeded
Reason            :
StartedAt         : 3/31/2023 9:14:38 AM
```


