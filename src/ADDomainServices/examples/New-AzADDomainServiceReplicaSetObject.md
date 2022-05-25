### Example 1: Create ReplicaSet for AdDomain
```powershell
New-AzADDomainServiceReplicaSetObject -Location westus -SubnetId /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/test-vm/subnets/test-subnets
```

```output
DomainControllerIPAddress ExternalAccessIPAddress HealthLastEvaluated Location ServiceStatus SubnetId
------------------------- ----------------------- ------------------- -------- ------------- --------
                                                                      westus                 /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resource… 
```

Create an in-memory object for ReplicaSet. This object can be used to create or update a domain service.
