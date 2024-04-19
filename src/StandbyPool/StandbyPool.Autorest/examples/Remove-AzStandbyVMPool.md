### Example 1: Delete a standby virtual machine pool
```powershell
Remove-AzStandbyVMPool `
-SubscriptionId f8da6e30-a9d8-48ab-b05c-3f7fe482e13b `
-ResourceGroupName test-standbypool `
-Name testPool `
-NoWait
```

```output
Target
------
https://management.azure.com/subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/providers/Microsoft.StandbyPool/locations/EASTUS/operationStatuses/dd097fee-99c2-4423-be9a-08ed20bfbf28*9F4DB3114D3D8F7DED8497F0D441BD1016348E645BEF0AF23FFE9753EE918EA8?api-version=2023-12-01-preview&t=638483770276035131&c=MIIHADCCBeig…

```

Above command is deleting a standby virtual machine pool without waiting.
