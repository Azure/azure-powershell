### Example 1: Restart Spring Cloud Service by name
```powershell
Restart-AzSpringAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default 
```

Restart Spring Cloud Service by name.

### Example 2: Restart Spring Cloud Service by pipeline
```powershell
Get-AzSpringAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default | Restart-AzSpringAppDeployment
```

Restart Spring Cloud Service by pipeline.
