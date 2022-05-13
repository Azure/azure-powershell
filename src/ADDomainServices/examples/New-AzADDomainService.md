### Example 1: Create new ADDomainService
```powershell
PS C:\> $replicaSet = New-AzADDomainServiceReplicaSetObject -Location westus -SubnetId /subscriptions/********-****-****-****-**********/resourceGroups/yishitest/providers/Microsoft.Network/virtualNetworks/aadds-vnet/subnets/default
New-AzADDomainService -name youriADdomain -ResourceGroupName youriAddomain -DomainName youriAddomain.com -ReplicaSet $replicaSet -debug

Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Create new ADDomainService

### Example 2: Create new ADDomainService with certificate 
```powershell
# Variables
$replicaSet = New-AzADDomainServiceReplicaSet -Location westus -SubnetId /subscriptions/********-****-****-****-**********/resourceGroups/yishitest/providers/Microsoft.Network/virtualNetworks/aadds-vnet/subnets/default\
$certificateBytes = get-content "certificate.pfx" -AsByteStream
$base64String = [System.Convert]::ToBase64String($certificateBytes) 
$ldaps_pfx_pass = "MyStrongPassword"
New-AzADDomainService -name youriADdomain -ResourceGroupName youriAddomain -DomainName youriAddomain.com -ReplicaSet $replicaSet -LdapSettingLdaps Enabled -LdapSettingPfxCertificate $base64String -LdapSettingPfxCertificatePassword $($ldaps_pfx_pass | ConvertTo-SecureString -Force -AsPlainText)
```

```output
Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Create new ADDomainService with certificate
