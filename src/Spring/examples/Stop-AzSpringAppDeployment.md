### Example 1: Stop Spring Cloud Service by name
```powershell
Stop-AzSpringAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default  
```

Stop Spring Cloud Service by name.

### Example 2: Stop Spring Cloud Service by pipeline
```powershell
Get-AzSpringAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default | Stop-AzSpringAppDeployment
```

Stop Spring Cloud Service by pipeline.