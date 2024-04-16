### Example 1: Delete a standby container pool
```powershell
Remove-AzStandbyContainerGroupPool `
-SubscriptionId f8da6e30-a9d8-48ab-b05c-3f7fe482e13b `
-Name testPool `
-ResourceGroupName test-standbypool `
-NoWait
```

```output
Target
------
https://management.azure.com/subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/providers/Microsoft.StandbyPool/locations/EASTUS/operationStatuses/551356ac-5eb6-45f7-b6b6-14df83ba036e*85A187C07F40830FA4E50DCF44CFFD9DE9CC801E92CB2EBC4992086870FC7F91?api-version=2023-12-01-preview&t=638483731215571130&c=MIIHADCCBeig…
```

Above command is deleting a standby container pool without waiting.
