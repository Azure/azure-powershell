### Example 1: Start Spring Cloud Service by name
```powershell
Start-AzSpringCloudAppDeploymentJfr -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -Name default 
```

Start Spring Cloud Service by name.

### Example 2: Start Spring Cloud Service by pipeline
```powershell
Get-AzSpringCloudAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -Name default | Start-AzSpringCloudAppDeployment
```

Start Spring Cloud Service by pipeline.