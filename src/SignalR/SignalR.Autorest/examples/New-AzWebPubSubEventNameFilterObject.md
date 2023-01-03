### Example 1: Create an event name filter object
```powershell
$filter = New-AzWebPubSubEventNameFilterObject -SystemEvent connected,disconnected -UserEventPattern *
$filter
```

```output
SystemEvent               UserEventPattern
-----------               ----------------
{connected, disconnected} *
```

