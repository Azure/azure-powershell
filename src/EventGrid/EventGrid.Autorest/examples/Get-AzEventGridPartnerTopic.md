### Example 1: Get properties of a partner topic.
```powershell
Get-AzEventGridPartnerTopic
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   default azps_test_group_eventgrid
```

Get properties of a partner topic.

### Example 2: Get properties of a partner topic.
```powershell
Get-AzEventGridPartnerTopic -ResourceGroupName azps_test_group_eventgrid
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   default azps_test_group_eventgrid
```

Get properties of a partner topic.

### Example 3: Get properties of a partner topic.
```powershell
Get-AzEventGridPartnerTopic -Name default -ResourceGroupName azps_test_group_eventgrid
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   default azps_test_group_eventgrid
```

Get properties of a partner topic.