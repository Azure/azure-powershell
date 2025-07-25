### Example 1: Update AzADDomainService By ResourceGroupName and Name
```powershell
Update-AzADDomainService -Name youriADdomain -ResourceGroupName youriADdomain -DomainSecuritySettingTlsV1 Disabled
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
Update-AzADDomainService -InputObject $getAzAddomain -DomainSecuritySettingTlsV1 Disabled
```

```output
Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Update AzADDomainService By InputObject
