$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzContainerGroup.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzContainerGroup' {
    It 'Creates a container group using latest nginx image and requests a public IP address with opening ports' {
        $port1 = New-AzContainerInstancePortObject -Port $env.port1 -Protocol TCP
        $port2 = New-AzContainerInstancePortObject -Port $env.port2 -Protocol TCP
        $container = New-AzContainerInstanceObject -Name $env.containerInstanceName -Image $env.image -RequestCpu 1 -RequestMemoryInGb 1.5 -Port @($port1, $port2)
        $containerGroup = New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.containerGroupName1 -Location $env.location -Container $container -OsType $env.osType -RestartPolicy $env.restartPolicy -IpAddressType Public

        $containerGroup | Should -Not -Be $null
        $containerGroup.Name | Should -Be $env.containerGroupName1
        $containerGroup.Location | Should -Be $env.location
        
        $containerGroup.Container | Should -Not -Be $null
        $containerGroup.Container.Count | Should -Be 1
        $containerGroup.Container[0].Name | Should -Be $env.containerInstanceName
        $containerGroup.Container[0].Image | Should -Be $env.image
        $containerGroup.Container[0].RequestCpu | Should -Be 1
        $containerGroup.Container[0].RequestMemoryInGb | Should -Be 1.5

        $containerGroup.OSType | Should -Be $env.osType
        $containerGroup.RestartPolicy | Should -Be $env.restartPolicy
        $containerGroup.IPAddressType | Should -Be "Public"
    }

    It 'Creates a container group and runs a custom script inside the container.' {
        $env1 = New-AzContainerInstanceEnvironmentVariableObject -Name "env1" -Value "value1"
        $env2 = New-AzContainerInstanceEnvironmentVariableObject -Name "env2" -SecureValue (ConvertTo-SecureString -String "value2" -AsPlainText -Force)
        $container = New-AzContainerInstanceObject -Name $env.containerInstanceName -Image alpine -RequestCpu 1 -RequestMemoryInGb 1.5 -Command "echo hello" -EnvironmentVariable @($env1, $env2)
        $containerGroup = New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.containerGroupName2 -Location $env.location -Container $container -OsType Linux
        
        $containerGroup.Container[0].Command.Count | Should -Be 1
        $containerGroup.Container[0].Command[0] | Should -Be "echo hello"

        $containerGroup.Container[0].EnvironmentVariable.Count | Should -Be 2
        $containerGroup.Container[0].EnvironmentVariable[0].Name | Should -Be "env1"
        $containerGroup.Container[0].EnvironmentVariable[0].Value | Should -Be "value1"
        $containerGroup.Container[0].EnvironmentVariable[1].Name | Should -Be "env2"
        $containerGroup.Container[0].EnvironmentVariable[1].SecureValue | Should -Be "value2"
    }

    It 'Creates a container group using a nginx image in Azure Container Registry.' -skip {
        $container = New-AzContainerInstanceObject -Name $env.containerInstanceName -Image myacr.azurecr.io/nginx:latest
        $imageRegistryCredential = New-AzContainerGroupImageRegistryCredentialObject -Server "myserver.com" -Username "username" -Password (ConvertTo-SecureString "PlainTextPassword" -AsPlainText -Force) 
        $containerGroup = New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.containerGroupName3 -Location $env.location -Container $container -ImageRegistryCredential $imageRegistryCredential
    }

    It 'Creates a container group that mounts Azure File volume.' -skip {
        $volume = New-AzContainerGroupVolumeObject -Name "myvolume" -AzureFileShareName "myshare" -AzureFileStorageAccountName "username" -AzureFileStorageAccountKey (ConvertTo-SecureString "PlainTextPassword" -AsPlainText -Force)
        $container = New-AzContainerInstanceObject -Name $env.containerInstanceName -Image alpine
        $containerGroup = New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.containerGroupName4 -Location $env.location -Container $container -Volume $volume
    }

    It 'creates a container group with system assigned and user assigned identity.' -skip {
        $container = New-AzContainerInstanceObject -Name $env.containerInstanceName -Image nginx 
        $containerGroup = New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.containerGroupName5 -Location $env.location -Container $container -IdentityType "SystemAssigned, UserAssigned" -IdentityUserAssignedIdentity /subscriptions/<subscriptionId>/resourceGroups/<resourceGroup>/providers/Microsoft.ManagedIdentity/userAssignedIdentities/<UserIdentityName>
    }
}
