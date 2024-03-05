### Example 1: Activate a newly created partner topic.
```powershell
Enable-AzEventGridPartnerTopic -Name default -ResourceGroupName azps_test_group_eventgrid
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   default azps_test_group_eventgrid
```

Activate a newly created partner topic.

### Example 2: Activate a newly created partner topic.
```powershell
Get-AzEventGridPartnerTopic -Name default -ResourceGroupName azps_test_group_eventgrid | Enable-AzEventGridPartnerTopic
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   default azps_test_group_eventgrid
```

Activate a newly created partner topic.