### Example 1: Create event hub destination object
```powershell
New-AzEventHubDestinationObject -EventHubResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.EventHub/namespaces/amcseastushub -Name testHub
```

```output
EventHubResourceId                                                                                                                 Name
------------------                                                                                                                 ----
/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.EventHub/namespaces/amcseastushub testHub
```

This command creates event hub destination object.

