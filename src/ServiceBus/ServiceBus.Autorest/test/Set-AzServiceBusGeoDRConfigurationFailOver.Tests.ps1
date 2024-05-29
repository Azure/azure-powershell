if(($null -eq $TestName) -or ($TestName -contains 'Set-AzServiceBusGeoDRConfigurationFailOver'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzServiceBusGeoDRConfigurationFailOver.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzServiceBusGeoDRConfigurationFailOver' {
    It 'Fail' -skip:$($env.secondaryLocation -eq '')  {
        Set-AzServiceBusGeoDRConfigurationFailOver -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace -Name $env.alias
        
        while($drConfig.ProvisioningState -ne "Succeeded"){
            $drConfig = Get-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
            if ($TestMode -ne 'playback') {
                Start-Sleep 10
            }
        }

        $drConfig.Name | Should -Be $env.alias
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.PartnerNamespace | Should -Be ""
        $drConfig.Role | Should -Be "PrimaryNotReplicating"

        $drConfig = Remove-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
        if ($TestMode -ne 'playback') {
                Start-Sleep 180
        }
        $drConfig = New-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace -PartnerNamespace $env.secondaryNamespaceResourceId
        
        while($drConfig.ProvisioningState -ne "Succeeded"){
            $drConfig = Get-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
            if ($TestMode -ne 'playback') {
                Start-Sleep 10
            }
        }
    }
    It 'FailViaIdentity' -skip:$($env.secondaryLocation -eq '') {
        $drConfig = Get-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
        
        Set-AzServiceBusGeoDRConfigurationFailOver -InputObject $drConfig
        
        do {
            $drConfig = Get-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
            if ($TestMode -ne 'playback') {
                Start-Sleep 10
            }
        } while($drConfig.ProvisioningState -ne "Succeeded")

        $drConfig.Name | Should -Be $env.alias
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.PartnerNamespace | Should -Be ""
        $drConfig.Role | Should -Be "PrimaryNotReplicating"

        $drConfig = Remove-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
        
        if ($TestMode -ne 'playback') {
                Start-Sleep 180
        }

        { Get-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace -ErrorAction Stop } | Should -Throw
    }
}
