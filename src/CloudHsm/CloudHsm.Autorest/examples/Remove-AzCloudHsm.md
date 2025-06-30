### Example 1: Deletes a Cloud HSM.
```powershell
Remove-AzCloudHsm -Name chsm1 -ResourceGroupName group
```

This command removes the Cloud HSM named chsm1 from the named resource group. If you do not specify the resource group name, the cmdlet searches for the named Cloud HSM to delete in your current subscription.

