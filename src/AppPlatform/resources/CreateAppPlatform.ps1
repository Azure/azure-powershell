$ResourceGroupName = 'wyunchi-app-platform'
$ServiceName = 'pwsh-app-platform'
$GatewayAppName = 'gateway'
$GatewayJarPath = 'C:\Users\yunwang\source\repos\azure-powershell-generation-db\src\piggymetrics\gateway\target\gateway.jar'
$AuthAppName = 'auth-service'
$AuthJarPath = 'C:\Users\yunwang\source\repos\azure-powershell-generation-db\src\piggymetrics\auth-service\target\auth-service.jar'
$AccountAppName = 'account-service'
$AccountJarPath = 'C:\Users\yunwang\source\repos\azure-powershell-generation-db\src\piggymetrics\account-service\target\account-service.jar'

New-AzResourceGroup -ResourceGroupName $ResourceGroupName -Location eastus
New-AzAppPlatformService -ResourceGroupName $ResourceGroupName -name $ServiceName -Location eastus

New-AzappPlatformApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -Name $GatewayAppName -ActiveDeploymentName default
New-AzappPlatformDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $GatewayAppName -DeploymentName default -DeploymentSettingCpu 1 -DeploymentSettingInstanceCount 1 -DeploymentSettingMemoryInGb 1 -SourceRelativePath '<default>'
Update-azappplatformapp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $GatewayAppName -ActiveDeploymentName default -Public
Deploy-AzAppPlatformApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $GatewayAppName -JarPath $GatewayJarPath

New-AzappPlatformApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -Name $AuthAppName -ActiveDeploymentName default
New-AzappPlatformDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AuthAppName -DeploymentName default -DeploymentSettingCpu 1 -DeploymentSettingInstanceCount 1 -DeploymentSettingMemoryInGb 1 -SourceRelativePath '<default>'
Update-azappplatformapp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AuthAppName -ActiveDeploymentName default
Deploy-AzAppPlatformApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AuthAppName -JarPath $AuthJarPath

New-AzappPlatformApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -Name $AccountAppName -ActiveDeploymentName default
New-AzappPlatformDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AccountAppName -DeploymentName default -DeploymentSettingCpu 1 -DeploymentSettingInstanceCount 1 -DeploymentSettingMemoryInGb 1 -SourceRelativePath '<default>'
Update-AzappPlatformapp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AccountAppName -ActiveDeploymentName default
Deploy-AzAppPlatformApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AccountAppName -JarPath $AccountJarPath