### Example 1: Asynchronously creates a new partner destination with the specified parameters.
```powershell
New-AzEventGridPartnerDestination -Name azps-destin -ResourceGroupName azps_test_group_eventgrid -Location eastus -Tag @{"1"="a"}
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
eastus   azps-destin azps_test_group_eventgrid
```

Asynchronously creates a new partner destination with the specified parameters.