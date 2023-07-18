### Example 1: Create a new Application Gateway for Containers resource
```powershell
New-AzAlb -Name test-alb -ResourceGroupName test-rg -Location NorthCentralUS
```

```output
Name      ResourceGroupName Location       ProvisioningState
----      ----------------- --------       -----------------
test-alb  test-rg           NorthCentralUS Succeeded
```

This command creates a new Application Gateway for Containers resource.
