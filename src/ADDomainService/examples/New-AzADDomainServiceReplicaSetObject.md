### Example 1: Create ReplicaSet for AzADDomain
```powershell
PS C:\> New-AzADDomainServiceReplicaSetObject -Location westus -SubnetId /subscriptions/********-****-****-****-**********/resourceGroups/youritest/providers/Microsoft.Network/virtualNetworks/aadds-vnet/subnets/default

DomainControllerIPAddress ExternalAccessIPAddress HealthLastEvaluated Location ServiceStatus SubnetId
------------------------- ----------------------- ------------------- -------- ------------- --------
                                                                      westus                 /subscriptions/********-****-****-****-**********/resourceGroups/youritest/providers/Microsoft.Network…
```

Create ReplicaSet for AzADDomain


