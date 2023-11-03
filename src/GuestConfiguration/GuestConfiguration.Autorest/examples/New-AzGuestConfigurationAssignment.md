### Example 1: Create an association between a VM and guest configuration

```powershell
New-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName test-assignment -ResourceGroupName test-rg -VMName test-vm -GuestConfigurationName test-config -GuestConfigurationVersion "1.0.0.3" -GuestConfigurationContentUri "https://thisisfake/package" -GuestConfigurationContentHash "123contenthash"
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment test-rg
```

Create an association between a VM and guest configuration

### Example 2: Create an association between a ARC machine and guest configuration
```powershell
New-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName test-assignment -ResourceGroupName test-rg -MachineName test-machine -GuestConfigurationName test-config -GuestConfigurationVersion "1.0.0.3" -GuestConfigurationContentUri "https://thisisfake/package" -GuestConfigurationContentHash "123contenthash"
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment test-rg
```

Create an association between a ARC machine and guest configuration
