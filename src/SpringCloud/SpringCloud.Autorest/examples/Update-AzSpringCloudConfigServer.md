### Example 1: Update the config server
```powershell
Update-AzSpringCloudConfigServer -ResourceGroupName SpringCloud-gp-junxi -Name springcloud-service
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/1 7:22:54    *********@microsoft.com User                    2022/7/1 7:22:54         **********@microso…
```

Update the config server.

### Example 2: Update the config server by pipeline
```powershell
Get-AzSpringCloudConfigServer -ResourceGroupName SpringCloud-gp-junxi -Name springcloud-service | Update-AzSpringCloudConfigServer
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/1 7:22:54    *********@microsoft.com User                    2022/7/1 7:22:54         **********@microso…
```

Update the config server by pipeline.

