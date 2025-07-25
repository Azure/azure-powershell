### Example 1: Create or update the Nginx deployment
```powershell
New-AzNginxDeployment -Name nginx-test -ResourceGroupName nginx-test-rg -Location westcentralus -NetworkProfile $networkProfile -SkuName preview_Monthly_gmz7xq9ge3py
```

```output
Location      Name
--------      ----
westcentralus nginx-test
```

This command creates or updates the Nginx deployment.
