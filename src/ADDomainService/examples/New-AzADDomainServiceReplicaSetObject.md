### Example 1: Create ReplicaSet for AzADDomain
```powershell
PS C:\> New-AzADDomainServiceReplicaSetObject -Location westus -SubnetId /subscriptions/********-****-****-****-**********/resourceGroups/youritest/providers/Microsoft.Network/virtualNetworks/aadds-vnet/subnets/default

$NewAdDomain = New-AzADDomainServiceReplicaSetObject -Location westus -SubnetId /subscriptions/********-****-****-****-**********/resourceGroups/yishitest/providers/Microsoft.Network/virtualNetworks/aadds-vnet/subnets/default
```

Create ReplicaSet for AzADDomain


