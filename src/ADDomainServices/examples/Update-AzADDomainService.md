### Example 1: Update AzADDomainService By ResourceGroupName and Name
```powershell
$ADDomainSetting = New-AzADDomainServiceDomainSecuritySettingObject -TlsV1 Disabled
Update-AzADDomainService -Name youriADdomain -ResourceGroupName youriADdomain -DomainSecuritySetting $ADDomainSetting
```

```output
Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Update AzADDomainService By ResourceGroupName and Name

### Example 2: Update AzADDomainService By InputObject
```powershell
$getAzAddomain = Get-AzADDomainService -Name youriADdomain -ResourceGroupName youriADdomain
$ADDomainSetting = New-AzADDomainServiceDomainSecuritySettingObject -TlsV1 Disabled
Update-AzADDomainService -InputObject $getAzAddomain -DomainSecuritySetting $ADDomainSetting
```

```output
Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Update AzADDomainService By InputObject
