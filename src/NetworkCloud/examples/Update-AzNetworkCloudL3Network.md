### Example 1: Update tags for L3 network
```powershell
Update-AzNetworkCloudL3Network -ResourceGroupName resourceGroupName -Name l3networkName   -Tag @{'tag'="tagUpdated"}
```

Update tags associated with the provided layer 3 (L3)