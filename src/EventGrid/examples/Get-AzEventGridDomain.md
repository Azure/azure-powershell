### Example 1: List properties of domain.
```powershell
Get-AzEventGridDomain
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
westus2  azps-domain azps_test_group_eventgrid
```

List properties of domain.

### Example 2: List properties of domain.
```powershell
Get-AzEventGridDomain -ResourceGroupName azps_test_group_eventgrid
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
westus2  azps-domain azps_test_group_eventgrid
```

List properties of domain.

### Example 3: Get properties of a domain.
```powershell
Get-AzEventGridDomain -ResourceGroupName azps_test_group_eventgrid -Name azps-domain
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
westus2  azps-domain azps_test_group_eventgrid
```

Get properties of a domain.