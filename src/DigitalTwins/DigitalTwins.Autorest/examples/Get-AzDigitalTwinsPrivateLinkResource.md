### Example 1: Get the specified private link resource for the given Digital Twin.
```powershell
Get-AzDigitalTwinsPrivateLinkResource -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance
```

```output
GroupId Name ResourceGroupName
------- ---- -----------------
API     API  azps_test_group
```

Get the specified private link resource for the given Digital Twin.

### Example 2: Get the specified private link resource for the given Digital Twin.
```powershell
Get-AzDigitalTwinsPrivateLinkResource -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -ResourceId API
```

```output
GroupId Name ResourceGroupName
------- ---- -----------------
API     API  azps_test_group
```

Get the specified private link resource for the given Digital Twin.