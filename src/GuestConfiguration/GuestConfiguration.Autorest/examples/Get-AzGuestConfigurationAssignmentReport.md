### Example 1: Get a report by ReportId for a guest configuration assignment
```powershell
Get-AzGuestConfigurationAssignmentReport -GuestConfigurationAssignmentName test-assignment -ResourceGroupName test-rg -VMName test-vm -ReportId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/test-assignment/reports/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
```

Get a report by ReportId for a guest configuration assignment

### Example 2: List reports for a guest configuration assignment
```powershell
Get-AzGuestConfigurationAssignmentReport -GuestConfigurationAssignmentName test-assignment -ResourceGroupName test-rg -VMName test-vm
```

List reports for a guest configuration assignment
