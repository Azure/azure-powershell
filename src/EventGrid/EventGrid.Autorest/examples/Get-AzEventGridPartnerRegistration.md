### Example 1: List partner registration with the specified parameters.
```powershell
Get-AzEventGridPartnerRegistration
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
global   azps-registration azps_test_group_eventgrid
```

List partner registration with the specified parameters.

### Example 2: List partner registration with the specified parameters.
```powershell
Get-AzEventGridPartnerRegistration -ResourceGroupName azps_test_group_eventgrid
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
global   azps-registration azps_test_group_eventgrid
```

List partner registration with the specified parameters.

### Example 3: Gets a partner registration with the specified parameters.
```powershell
Get-AzEventGridPartnerRegistration -ResourceGroupName azps_test_group_eventgrid -Name azps-registration
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
global   azps-registration azps_test_group_eventgrid
```

Gets a partner registration with the specified parameters.