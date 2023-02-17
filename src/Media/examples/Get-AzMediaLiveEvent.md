### Example 1: List properties of live event by Media Name.
```powershell
Get-AzMediaLiveEvent -AccountName azpsms -ResourceGroupName azps_test_group
```

```output
Location Name         ResourceGroupName
-------- ----         -----------------
East US  azpsms-event azps_test_group
```

List properties of live event by Media Name.

### Example 2: Get properties of a live event by Live Event Name.
```powershell
Get-AzMediaLiveEvent -AccountName azpsms -ResourceGroupName azps_test_group -Name azpsms-event
```

```output
Location Name         ResourceGroupName
-------- ----         -----------------
East US  azpsms-event azps_test_group
```

Get properties of a live event by Live Event Name.