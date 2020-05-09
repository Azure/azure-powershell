# New-AzResourceGroup -ResourceGroupName wyunchi-app-platform -Location eastus
New-AzAppPlatformService -ResourceGroupName wyunchi-app-platform -name pwsh-app-platform -Location eastus

New-AzappPlatformApp -ResourceGroupName wyunchi-app-platform -ServiceName pwsh-app-platform -Name gateway -ActiveDeploymentName default
New-AzappPlatformDeployment -ResourceGroupName wyunchi-app-platform -ServiceName pwsh-app-platform -AppName gateway -DeploymentName default -DeploymentSettingCpu 1 -DeploymentSettingInstanceCount 1 -DeploymentSettingMemoryInGb 1 -SourceRelativePath '<default>'
Update-azappplatformapp -ResourceGroupName wyunchi-app-platform -ServiceName pwsh-app-platform -AppName gateway -ActiveDeploymentName default -Public
Deploy-AzAppPlatformApp -ResourceGroupName wyunchi-app-platform -ServiceName pwsh-app-platform -AppName gateway -JarPath C:\Users\yunwang\source\repos\azure-powershell-generation-db\src\piggymetrics\gateway\target\gateway.jar

New-AzappPlatformApp -ResourceGroupName wyunchi-app-platform -ServiceName pwsh-app-platform -Name auth-service -ActiveDeploymentName default
New-AzappPlatformDeployment -ResourceGroupName wyunchi-app-platform -ServiceName pwsh-app-platform -AppName auth-service -DeploymentName default -DeploymentSettingCpu 1 -DeploymentSettingInstanceCount 1 -DeploymentSettingMemoryInGb 1 -SourceRelativePath '<default>'
Update-azappplatformapp -ResourceGroupName wyunchi-app-platform -ServiceName pwsh-app-platform -AppName auth-service -ActiveDeploymentName default
Deploy-AzAppPlatformApp -ResourceGroupName wyunchi-app-platform -ServiceName pwsh-app-platform -AppName auth-service -JarPath C:\Users\yunwang\source\repos\azure-powershell-generation-db\src\piggymetrics\auth-service\target\auth-service.jar

New-AzappPlatformApp -ResourceGroupName wyunchi-app-platform -ServiceName pwsh-app-platform -Name account-service -ActiveDeploymentName default
New-AzappPlatformDeployment -ResourceGroupName wyunchi-app-platform -ServiceName pwsh-app-platform -AppName account-service -DeploymentName default -DeploymentSettingCpu 1 -DeploymentSettingInstanceCount 1 -DeploymentSettingMemoryInGb 1 -SourceRelativePath '<default>'
Update-AzappPlatformapp -ResourceGroupName wyunchi-app-platform -ServiceName pwsh-app-platform -AppName account-service -ActiveDeploymentName default
Deploy-AzAppPlatformApp -ResourceGroupName wyunchi-app-platform -ServiceName pwsh-app-platform -AppName account-service -JarPath C:\Users\yunwang\source\repos\azure-powershell-generation-db\src\piggymetrics\account-service\target\account-service.jar