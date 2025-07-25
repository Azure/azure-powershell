### Example 1: Create a new Application Gateway for Containers frontend resource
```powershell
New-AzAlbFrontend -Name alb-frontend -AlbName test-alb -ResourceGroupName test-rg -Location NorthCentralUS
```

```output
Name         ResourceGroupName Location       Fqdn                                                ProvisioningState
----         ----------------- --------       ----                                                -----------------
alb-frontend test-rg           northcentralus d11eeb0c9547bed828e7ae249c424c55.fz05.alb.azure.com Succeeded
```

This command creates a new Application Gateway for Containers frontend resource.
