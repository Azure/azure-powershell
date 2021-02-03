### Example 1: {{ Add title here }}
```powershell
PS C:\> pdate-AzConfluentOrganization -ResourceGroupName lucas-rg-test -Name confluentorg-02-pwsh -Tag @{"key01" = "value01"}

Location Name                 Type
-------- ----                 ----
eastus   confluentorg-02-pwsh Microsoft.Confluent/organizations
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzConfluentOrganization -ResourceGroupName lucas-rg-test -Name confluentorg-02-pwsh | Update-AzConfluentOrganization -Tag @{"key01" = "value01"; "key02"="value02"}

Location Name                 Type
-------- ----                 ----
eastus   confluentorg-02-pwsh Microsoft.Confluent/organizations
```

{{ Add description here }}

