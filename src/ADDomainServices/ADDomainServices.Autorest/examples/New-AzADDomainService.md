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

### Example 2: Create new ADDomainService with certificate 
```powershell
# Variables
$replicaSet = New-AzADDomainServiceReplicaSet -Location westus -SubnetId /subscriptions/********-****-****-****-**********/resourceGroups/yishitest/providers/Microsoft.Network/virtualNetworks/aadds-vnet/subnets/default\
$certificateBytes = Get-Content "certificate.pfx" -AsByteStream
$base64String = [System.Convert]::ToBase64String($certificateBytes) 
$ldaps_pfx_pass = "MyStrongPassword"

New-AzADDomainService -Name youriADdomain -ResourceGroupName youriAddomain -DomainName youriAddomain.com -ReplicaSet $replicaSet -LdapSettingLdaps Enabled -LdapSettingPfxCertificate $base64String -LdapSettingPfxCertificatePassword $($ldaps_pfx_pass | ConvertTo-SecureString -Force -AsPlainText)
```

```output
Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Create new ADDomainService with certificate


