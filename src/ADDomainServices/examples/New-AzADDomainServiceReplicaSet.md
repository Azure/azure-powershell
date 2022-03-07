### Example 1: Create ReplicaSet for AdDomain
```powershell
New-AzADDomainServiceReplicaSet -Location eastus -SubnetId /subscriptions/**********-****-****-****-****-**********/resourceGroups/youriADDomain-rg-test/providers/Microsoft.Network/virtualNetworks/yourinttest/subnets/default
```

```output
DomainControllerIPAddress ExternalAccessIPAddress HealthLastEvaluated Location ServiceStatus SubnetId
------------------------- ----------------------- ------------------- -------- ------------- --------
                                                                      eastus                 /subscriptions/********-****-****-****-**********/resourceGroups/youriADDomain-rg-test/providers/M…
```

Create ReplicaSet for AdDomain


