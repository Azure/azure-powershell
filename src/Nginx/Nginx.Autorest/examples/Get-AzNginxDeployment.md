### Example 1: Get a NGINX deployment with name
```powershell
Get-AzNginxDeployment -Name nginx-test -ResourceGroupName nginx-test-rg
```

```output
Location      Name
--------      ----
westcentralus nginx-test
```

This command gets a NGINX deployment in a resource group.

### Example 2: List all NGINX deployments in a subscription
```powershell
Get-AzNginxDeployment
```

```output
Location      Name
--------      ----
westcentralus nginx-test
westcentralus nginx-test1
eastus2       nginx-test2

```

This command lists all NGINX deployments in a subscription.

### Example 3: List all NGINX deployments in a resource group
```powershell
Get-AzNginxDeployment -ResourceGroupName nginx-test-rg
```

```output
Location      Name
--------      ----
westcentralus nginx-test
westcentralus nginx-test1
```

This command lists all NGINX deployments in a resource group.
