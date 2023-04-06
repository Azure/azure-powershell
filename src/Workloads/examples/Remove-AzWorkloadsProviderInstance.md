### Example 1: Delete a specific provider from AMS instance
```powershell
Remove-AzWorkloadsProviderInstance -MonitorName suha-160323-ams7 -Name suha-os-1 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c
```

```output
EndTime             Name                                                                                                  PercentComplete ResourceGroupName StartTime           Status
-------             ----                                                                                                  --------------- ----------------- ---------           ------
16-03-2023 11:48:08 034ff381-73dc-4273-8ed2-1ccd852a64a2*6E77053B6B98265D96E60B59AE83132A76A7B1EA2C160941AD1C81EFE679D721                                   16-03-2023 11:48:05 Succeeded
```

Delete a provider from specific AMS Instance

### Example 2: Delete a specific provider from AMS instance by Id
```powershell
Remove-AzWorkloadsProviderInstance -InputObject "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.Workloads/monitors/suha-160323-ams7/providerInstances/suha-os-1"
```

```output
EndTime             Name                                                                                                  PercentComplete ResourceGroupName StartTime           Status
-------             ----                                                                                                  --------------- ----------------- ---------           ------
16-03-2023 11:48:08 034ff381-73dc-4273-8ed2-1ccd852a64a2*6E77053B6B98265D96E60B59AE83132A76A7B1EA2C160941AD1C81EFE679D721                                   16-03-2023 11:48:05 Succeeded
```

Delete a provider from specific AMS Instance by Arm Id

