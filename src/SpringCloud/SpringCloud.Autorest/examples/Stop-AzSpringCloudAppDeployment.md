### Example 1: Stop Spring Cloud Service by name
```powershell
Stop-AzSpringCloudAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default  
```

Stop Spring Cloud Service by name.

### Example 2: Stop Spring Cloud Service by pipeline
```powershell
Get-AzSpringCloudAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default | Stop-AzSpringCloudAppDeployment
```

Stop Spring Cloud Service by pipeline.
