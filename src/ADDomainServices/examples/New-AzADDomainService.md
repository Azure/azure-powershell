### Example 1: Create new ADDomainService
```powershell
PS C:\> $replicaSet = New-AzADDomainServiceReplicaSetObject -Location westus -SubnetId /subscriptions/********-****-****-****-**********/resourceGroups/yishitest/providers/Microsoft.Network/virtualNetworks/aadds-vnet/subnets/default
New-AzADDomainService -name youriADdomain -ResourceGroupName youriAddomain -DomainName youriAddomain.com -ReplicaSet $replicaSet -debug

Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Create new ADDomainService


