### Example 1: Create a new ADDomainService
```powershell
$replicaSet = New-AzADDomainServiceReplicaSetObject -Location westus -SubnetId /subscriptions/********-****-****-****-**********/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/default
New-AzADDomainService -Name youriADdomain -ResourceGroupName youriAddomain -DomainName youriAddomain.com -ReplicaSet $replicaSet
```

```output
Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Create a new ADDomainService


