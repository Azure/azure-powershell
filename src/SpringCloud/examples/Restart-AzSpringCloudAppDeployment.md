### Example 1: Restart Spring Cloud Service by name
```powershell
Restart-AzSpringCloudAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default 
```

Restart Spring Cloud Service by name.

### Example 2: Restart Spring Cloud Service by pipeline
```powershell
Get-AzSpringCloudAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default | Restart-AzSpringCloudAppDeployment
```

Restart Spring Cloud Service by pipeline.
