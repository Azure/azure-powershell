### Example 1: List Transform by Media Name.
```powershell
Get-AzMediaTransform -AccountName azpsms -ResourceGroupName azps_test_group
```

```output
Name             ResourceGroupName
----             -----------------
azpsms-transform azps_test_group
```

List Transform by Media Name.

### Example 2: Get a Transform by Transform Name.
```powershell
Get-AzMediaTransform -AccountName azpsms -ResourceGroupName azps_test_group -Name azpsms-transform
```

```output
Name             ResourceGroupName
----             -----------------
azpsms-transform azps_test_group
```

Get a Transform by Transform Name.