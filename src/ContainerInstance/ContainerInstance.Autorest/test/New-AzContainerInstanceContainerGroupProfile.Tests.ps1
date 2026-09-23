if(($null -eq $TestName) -or ($TestName -contains 'New-AzContainerInstanceContainerGroupProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzContainerInstanceContainerGroupProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}
 
Describe 'New-AzContainerInstanceContainerGroupProfile' {
    It 'Creates a container group profile using latest standard hello world image and requests a public IP address with opening ports' {
        $port1 = New-AzContainerInstancePortObject -Port $env.port1 -Protocol TCP
        $port2 = New-AzContainerInstancePortObject -Port $env.port2 -Protocol TCP
        $container = New-AzContainerInstanceObject -Name $env.containerInstanceName -Image $env.image -RequestCpu 1 -RequestMemoryInGb 1.5 -Port @($port1, $port2)
        $containerGroupProfile = New-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name $env.containerGroupProfileName1 -Location $env.location -Container $container -OsType $env.osType -RestartPolicy $env.restartPolicy -IpAddressType Public
 
        $containerGroupProfile | Should -Not -Be $null
        $containerGroupProfile.Name | Should -Be $env.containerGroupProfileName1
        $containerGroupProfile.Location | Should -Be $env.location
       
        $containerGroupProfile.Container | Should -Not -Be $null
        $containerGroupProfile.Container.Count | Should -Be 1
        $containerGroupProfile.Container[0].Name | Should -Be $env.containerInstanceName
        $containerGroupProfile.Container[0].Image | Should -Be $env.image
        $containerGroupProfile.Container[0].RequestCpu | Should -Be 1
        $containerGroupProfile.Container[0].RequestMemoryInGb | Should -Be 1.5
 
        $containerGroupProfile.OSType | Should -Be $env.osType
        $containerGroupProfile.RestartPolicy | Should -Be $env.restartPolicy
        $containerGroupProfile.IPAddressType | Should -Be "Public"
 
        $containerGroupProfile.Revision | Should -Be 1
    }
 
    It 'Creates a container group profile and runs a custom script inside the container.' {
        $env1 = New-AzContainerInstanceEnvironmentVariableObject -Name "env1" -Value "value1"
        $env2 = New-AzContainerInstanceEnvironmentVariableObject -Name "env2" -SecureValue (ConvertTo-SecureString -String "value2" -AsPlainText -Force)
        $container = New-AzContainerInstanceObject -Name $env.containerInstanceName -Image alpine -RequestCpu 1 -RequestMemoryInGb 1.5 -Command "echo hello" -EnvironmentVariable @($env1, $env2)
        $containerGroupProfile = New-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name $env.containerGroupProfileName2 -Location $env.location -Container $container -OsType Linux
       
        $containerGroupProfile.Container[0].Command.Count | Should -Be 1
        $containerGroupProfile.Container[0].Command[0] | Should -Be "echo hello"
 
        $containerGroupProfile.Container[0].EnvironmentVariable.Count | Should -Be 2
        $containerGroupProfile.Container[0].EnvironmentVariable[0].Name | Should -Be "env1"
        $containerGroupProfile.Container[0].EnvironmentVariable[0].Value | Should -Be "value1"
        $containerGroupProfile.Container[0].EnvironmentVariable[1].Name | Should -Be "env2"
    }
 
    It 'Creates a container group profile with Spot Priority using latest standard hello world image' {
        $container = New-AzContainerInstanceObject -Name $env.containerInstanceName -Image $env.image -RequestCpu 1 -RequestMemoryInGb 1.5
        $containerGroupProfile = New-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name $env.spotPriorityContainerGroupProfileName -Location $env.location -Container $container -OsType $env.osType -RestartPolicy $env.restartPolicy -Priority $env.spotPriority
 
        $containerGroupProfile | Should -Not -Be $null
        $containerGroupProfile.Name | Should -Be $env.spotPriorityContainerGroupProfileName
        $containerGroupProfile.Location | Should -Be $env.location
       
        $containerGroupProfile.Container | Should -Not -Be $null
        $containerGroupProfile.Container.Count | Should -Be 1
        $containerGroupProfile.Container[0].Name | Should -Be $env.containerInstanceName
        $containerGroupProfile.Container[0].Image | Should -Be $env.image
        $containerGroupProfile.Container[0].RequestCpu | Should -Be 1
        $containerGroupProfile.Container[0].RequestMemoryInGb | Should -Be 1.5
 
        $containerGroupProfile.OSType | Should -Be $env.osType
        $containerGroupProfile.RestartPolicy | Should -Be $env.restartPolicy
        $containerGroupProfile.Priority | Should -Be $env.spotPriority
    }
 
    It 'Creates a container group profile with Confidential Sku using latest standard hello world image' {
        $container = New-AzContainerInstanceObject -Name $env.containerInstanceName -Image $env.image -RequestCpu 1 -RequestMemoryInGb 1.5
        $containerGroupProfile = New-AzContainerInstanceContainerGroupProfile -ResourceGroupName $env.resourceGroupName -Name $env.confidentialContainerGroupProfileName -Location $env.location -Container $container -OsType $env.osType -Sku $env.confidentialSku -ConfidentialComputePropertyCcePolicy $env.confidentialComputePropertyCcePolicy
 
        $containerGroupProfile | Should -Not -Be $null
        $containerGroupProfile.Name | Should -Be $env.confidentialContainerGroupProfileName
        $containerGroupProfile.Location | Should -Be $env.location
       
        $containerGroupProfile.Container | Should -Not -Be $null
        $containerGroupProfile.Container.Count | Should -Be 1
        $containerGroupProfile.Container[0].Name | Should -Be $env.containerInstanceName
        $containerGroupProfile.Container[0].Image | Should -Be $env.image
        $containerGroupProfile.Container[0].RequestCpu | Should -Be 1
        $containerGroupProfile.Container[0].RequestMemoryInGb | Should -Be 1.5
 
        $containerGroupProfile.OSType | Should -Be $env.osType
        $containerGroupProfile.Sku | Should -Be $env.confidentialSku
        $containerGroupProfile.ConfidentialComputePropertyCcePolicy | Should -Not -Be $null
    }
}