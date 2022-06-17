### Example 1: Get All ADDomainService By default
```powershell
Get-AzADDomainService
```

```output
Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Get All ADDomainService By default

### Example 2: Get ADDomainService By ResourceGroup and name
```powershell
Get-AzADDomainService -Name youriADdomain -ResourceGroupName youriADdomain
```

```output
Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Get ADDomainService By ResourceGroup and name

### Example 3: Get all ADDomainService By ResourceGroup
```powershell
Get-AzADDomainService -ResourceGroupName youriADdomain
```

```output
Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Get all ADDomainService By ResourceGroup

### Example 4: Get ADDomainService By InputObject
```powershell
$getAzAddomain = Get-AzADDomainService -Name youriADdomain -ResourceGroupName youriADdomain
Get-AzADDomainService -InputObject $getAzAddomain
```

```output
Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Get ADDomainService By InputObject