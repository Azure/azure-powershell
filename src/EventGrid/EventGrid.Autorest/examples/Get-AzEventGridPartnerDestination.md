### Example 1: List properties of partner destination.
```powershell
Get-AzEventGridPartnerDestination
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
eastus   azps-destin azps_test_group_eventgrid
```

List properties of partner destination.

### Example 2: List properties of partner destination.
```powershell
Get-AzEventGridPartnerDestination -ResourceGroupName azps_test_group_eventgrid
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
eastus   azps-destin azps_test_group_eventgrid
```

List properties of partner destination.

### Example 3: Get properties of a partner destination.
```powershell
Get-AzEventGridPartnerDestination -ResourceGroupName azps_test_group_eventgrid -Name azps-destin
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
eastus   azps-destin azps_test_group_eventgrid
```

Get properties of a partner destination.