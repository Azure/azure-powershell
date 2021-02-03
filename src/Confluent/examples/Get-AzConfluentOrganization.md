### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzConfluentOrganization

Location      Name                     Type
--------      ----                     ----
westus2       RegionTestWestUS2        Microsoft.Confluent/organizations
westus2       RohitWUS2                Microsoft.Confluent/organizations
westus2       Rohit-Secret             Microsoft.Confluent/organizations
westus2       Rohit-Secret-2           Microsoft.Confluent/organizations
westus2       Rohit-Secret-WUS2-0      Microsoft.Confluent/organizations
westus2       RohitWus200              Microsoft.Confluent/organizations
westus2       RohitWUS300              Microsoft.Confluent/organizations
westus2       WestUS2-SSOTest          Microsoft.Confluent/organizations
westus2       dri-01-02-postman-stable Microsoft.Confluent/organizations
westus2       dri-02-02                Microsoft.Confluent/organizations
westcentralus RohitWCUS88              Microsoft.Confluent/organizations
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzConfluentOrganization -ResourceGroupName lucas-rg-test

{{ Add output here }}
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> Get-AzConfluentOrganization -ResourceGroupName lucas-rg-test -Name confluentorg-01-portal

Location Name                   Type
-------- ----                   ----
eastus   confluentorg-01-portal Microsoft.Confluent/organizations
```

{{ Add description here }}

### Example 4: {{ Add title here }}
```powershell
PS C:\> Get-AzConfluentOrganization -ResourceGroupName lucas-rg-test -Name confluentorg-01-portal | Get-AzConfluentOrganization

Location Name                   Type
-------- ----                   ----
eastus   confluentorg-01-portal Microsoft.Confluent/organizations
```

{{ Add description here }}


