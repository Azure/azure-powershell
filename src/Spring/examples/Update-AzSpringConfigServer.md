### Example 1: Update the config server
```powershell
Update-AzSpringConfigServer -ResourceGroupName Spring-gp-junxi -Name Spring-service
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
Get-AzSpringConfigServer -ResourceGroupName Spring-gp-junxi -Name Spring-service | Update-AzSpringConfigServer
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/1 7:22:54    *********@microsoft.com User                    2022/7/1 7:22:54         **********@microso…
```

Update the config server by pipeline.

