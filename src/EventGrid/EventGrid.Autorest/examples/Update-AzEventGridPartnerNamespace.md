### Example 1: Asynchronously updates a partner namespace with the specified parameters.
```powershell
Update-AzEventGridPartnerNamespace -Name azps-partnernamespace -ResourceGroupName azps_test_group_eventgrid -Tag @{"abc"="123"} -PassThru
```

```output
True
```

Asynchronously updates a partner namespace with the specified parameters.

### Example 2: Asynchronously updates a partner namespace with the specified parameters.
```powershell
$partnernamespace = Get-AzEventGridPartnerNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-partnernamespace
Update-AzEventGridPartnerNamespace -InputObject $partnernamespace -Tag @{"abc"="123"} -PassThru
```

```output
True
```

Asynchronously updates a partner namespace with the specified parameters.