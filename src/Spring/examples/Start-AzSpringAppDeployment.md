### Example 1: Start Spring Cloud Service by name
```powershell
Start-AzSpringAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default 
```

Start Spring Cloud Service by name.

### Example 2: Start Spring Cloud Service by pipeline
```powershell
Get-AzSpringAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default | Start-AzSpringAppDeployment
```

Start Spring Cloud Service by pipeline.
