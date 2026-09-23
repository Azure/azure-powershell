### Example 1: Update an association between a ARC machine and guest configuration
```powershell
Update-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName test-assignment -ResourceGroupName test-rg -MachineName test-machine -GuestConfigurationName test-config -GuestConfigurationVersion "1.0.0.3" -GuestConfigurationContentUri "https://thisisfake/package" -GuestConfigurationContentHash "123contenthash"
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment test-rg
```

This command updates an association between a ARC machine and guest configuration.