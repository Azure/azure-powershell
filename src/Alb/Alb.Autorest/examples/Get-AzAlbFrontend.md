### Example 1: Get a specified Application Gateway for Containers frontend resource
```powershell
Get-AzAlbFrontend -Name test-frontend -AlbName test-alb -ResourceGroupName test-rg
```

```output
Name          ResourceGroupName Location       Fqdn                                                ProvisioningState
----          ----------------- --------       ----                                                -----------------
test-frontend test-rg           northcentralus c70d8be2a2d358417f901f8264d4bc32.fz54.alb.azure.com Succeeded
```

This command shows a specific Application Gateway for Containers frontend resource.

### Example 2: List frontends for a given Application Gateway for Containers resource
```powershell
Get-AzAlbFrontend -AlbName test-alb -ResourceGroupName test-rg
```

```output
Name           ResourceGroupName Location       Fqdn                                                ProvisioningState
----           ----------------- --------       ----                                                -----------------
test-frontend2 test-rg           northcentralus e853d603ee81f4af13e83a6df300045d.fz85.alb.azure.com Succeeded
test-frontend  test-rg           northcentralus c70d8be2a2d358417f901f8264d4bc32.fz54.alb.azure.com Succeeded
```

This command lists all Application Gateway for Containers frontend resources belonging to a specific Application Gateway for Containers resource.
