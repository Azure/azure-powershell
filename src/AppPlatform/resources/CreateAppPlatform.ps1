$ResourceGroupName = 'wyunchi-app-platform'
$ServiceName = 'pwsh-app-platform-1'
$GatewayAppName = 'gateway'
$GatewayJarPath = 'C:\Users\yunwang\source\repos\azure-powershell-generation-db\src\piggymetrics\gateway\target\gateway.jar'
$AuthAppName = 'auth-service'
$AuthJarPath = 'C:\Users\yunwang\source\repos\azure-powershell-generation-db\src\piggymetrics\auth-service\target\auth-service.jar'
$AccountAppName = 'account-service'
$AccountJarPath = 'C:\Users\yunwang\source\repos\azure-powershell-generation-db\src\piggymetrics\account-service\target\account-service.jar'

# New-AzResourceGroup -ResourceGroupName $ResourceGroupName -Location eastus
# New-AzSpringCloudService -ResourceGroupName $ResourceGroupName -name $ServiceName -Location eastus

# New-AzSpringCloudApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -Name $GatewayAppName
New-AzSpringCloudDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $GatewayAppName -Name default -Cpu 1 -InstanceCount 1 -MemoryInGb 1 -SourceRelativePath '<default>' -SourceType Jar
Update-AzSpringCloudApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $GatewayAppName -ActiveDeploymentName default -Public
Deploy-AzSpringCloudApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $GatewayAppName -JarPath $GatewayJarPath

New-AzSpringCloudApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -Name $AuthAppName
New-AzSpringCloudDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AuthAppName -Name default -Cpu 1 -InstanceCount 1 -MemoryInGb 1 -SourceRelativePath '<default>' -SourceType Jar
Update-AzSpringCloudApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AuthAppName -ActiveDeploymentName default
Deploy-AzSpringCloudApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AuthAppName -JarPath $AuthJarPath

New-AzSpringCloudApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -Name $AccountAppName
New-AzSpringCloudDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AccountAppName -Name default -Cpu 1 -InstanceCount 1 -MemoryInGb 1 -SourceRelativePath '<default>' -SourceType Jar
Update-AzSpringCloudApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AccountAppName -ActiveDeploymentName default
Deploy-AzSpringCloudApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AccountAppName -JarPath $AccountJarPath