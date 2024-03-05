### Example 1: Create an in-memory object for ResourceMoveChangeHistory.
```powershell
New-AzEventGridResourceMoveChangeHistoryObject -AzureSubscriptionId "{subId}" -ChangedTimeUtc "2023-12-10T11:06:13.109Z" -ResourceGroupName azps_test_group_eventgrid
```

```output
AzureSubscriptionId ChangedTimeUtc         ResourceGroupName
------------------- --------------         -----------------
{subId}             2023-12-10 07:06:13 PM azps_test_group_eventgrid2
```

Create an in-memory object for ResourceMoveChangeHistory.