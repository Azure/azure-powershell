### Example 1: Asynchronously updates a partner destination with the specified parameters.
```powershell
Update-AzEventGridPartnerDestination -Name azps-destin -ResourceGroupName azps_test_group_eventgrid -Tag @{"123"="abc"} -DefaultProfile "test default"
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
eastus   azps-destin azps_test_group_eventgrid
```

Asynchronously updates a partner destination with the specified parameters.