### Example 1: Create event hub direct destination object
```powershell
New-AzEventHubDirectDestinationObject -EventHubResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.EventHub/namespaces/amcseastushub -Name testHubDirect
```

```output
EventHubResourceId                                                                                                                 Name
------------------                                                                                                                 ----
/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.EventHub/namespaces/amcseastushub testHubDirect
```

This command creates event hub direct destination object.

