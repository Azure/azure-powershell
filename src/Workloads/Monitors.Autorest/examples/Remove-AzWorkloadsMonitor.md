### Example 1: Delete a specific AMS 
```powershell
Remove-AzWorkloadsMonitor -Name suha-050423-ams7 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c
```

```output
EndTime Name                                                                                                  PercentComplete Resour
                                                                                                                              ceGrou
                                                                                                                              pName
------- ----                                                                                                  --------------- ------
        2a2acaca-6dbb-4531-859e-5cc8bf6d66a0*223F4A00A95CA88C8A59BF9C0FAD97B67B40E41D4AF631069741A1BF6DDA8BFB
```

Delete a specific AMS

### Example 2: Delete a specific AMS by Id
```powershell
Remove-AzWorkloadsMonitor -InputObject "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.Workloads/monitors/suha-050423-ams7"
```

```output
EndTime Name                                                                                                  PercentComplete Resour
                                                                                                                              ceGrou
                                                                                                                              pName
------- ----                                                                                                  --------------- ------
        2a2acaca-6dbb-4531-859e-5cc8bf6d66a0*223F4A00A95CA88C8A59BF9C0FAD97B67B40E41D4AF631069741A1BF6DDA8BFB
```

Delete a specific AMS by Arm Id

