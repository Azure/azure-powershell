### Example 1: Remove a cloud service

```powershell
<<<<<<< HEAD
Remove-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"
=======
Remove-AzCloudService -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS"
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command removes the cloud service named ContosoCS that belongs to the resource group named ContosOrg.
