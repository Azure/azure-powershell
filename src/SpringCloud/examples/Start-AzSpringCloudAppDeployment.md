### Example 1: Start Spring Cloud Service by name.
```powershell
Start-AzSpringCloud -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default
```

Start Spring Cloud Service by name.

### Example 2: Start Spring Cloud Service from pipe.
```powershell
Get-AzSpringCloudAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default | Start-AzSpringCloud
```

Start Spring Cloud Service from pipe.
