### Example 1: Updates a partner registration with the specified parameters.
```powershell
Update-AzEventGridPartnerRegistration -Name azps-registration -ResourceGroupName azps_test_group_eventgrid -Tag @{"abc"="123"} -PassThru
```

```output
True
```

Updates a partner registration with the specified parameters.

### Example 2: Updates a partner registration with the specified parameters.
```powershell
$partnerregistration = Get-AzEventGridPartnerRegistration -ResourceGroupName azps_test_group_eventgrid -Name azps-registration
Update-AzEventGridPartnerRegistration -InputObject $partnerregistration -Tag @{"abc"="123"} -PassThru
```

```output
True
```

Updates a partner registration with the specified parameters.