### Example 1: Operation to update an exiting Deployment
```powershell
Update-AzSpringAppDeployment -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -AppName tools -Name default
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/1 3:41:45    *********@microsoft.com User                    2022/7/1 3:49:11         **********@microso…
```

Operation to update an exiting Deployment.

### Example 2: Operation to update an exiting Deployment by pipeline
```powershell
Get-AzSpringAppDeployment -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -AppName tools -Name default | Update-AzSpringAppDeployment
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/1 3:41:45    *********@microsoft.com User                    2022/7/1 3:49:11         **********@microso…
```

Operation to update an exiting Deployment by pipeline.

