### Example 1: Create AvailabilitySetListItem object in memory
```powershell
New-AzScVmmAvailabilitySetListItemObject -Name "test-avset" -Id "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/availabilitySets/test-avset"
```

```output
Id                                                                                                                                         Name
--                                                                                                                                         ----
/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/availabilitySets/test-avset        test-avset
```

Create AvailabilitySetListItem object in memory. Used in Update-AzScVmmVM for AvailabilitySet[].
