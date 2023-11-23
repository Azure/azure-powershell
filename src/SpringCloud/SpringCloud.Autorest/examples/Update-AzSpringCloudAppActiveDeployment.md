### Example 1: Set existing Deployment under the app as active
```powershell
Update-AzSpringCloudAppActiveDeployment -ResourceGroupName springcloudrg -ServiceName standardspring-demo -Name demo -DeploymentName 'green'
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/1 3:41:45    *********@microsoft.com User                    2022/7/1 3:49:11         **********@microso…
```

Set existing Deployment under the app as active.

### Example 2: Set existing Deployment under the app as active by pipeline
```powershell
Get-AzSpringCloudApp -ResourceGroupName springcloudrg -ServiceName standardspring-demo -Name demo | Update-AzSpringCloudAppActiveDeployment -DeploymentName 'green'
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/1 3:41:45    *********@microsoft.com User                    2022/7/1 3:49:11         **********@microso…
```

Set existing Deployment under the app as active by pipeline.

