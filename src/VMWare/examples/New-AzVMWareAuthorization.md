### Example 1: Create autorization
```powershell
PS C:\> New-AzVMwareAuthorization -Name azps-test-auth -PrivateCloudName azps-test-cloud -ResourceGroupName azps-test-group



Name           Type
----           ----
azps-test-auth Microsoft.AVS/privateClouds/authorizations
```

This cmdlet creates authorization `azps-test-auth` under private cloud `azps-test-cloud`
