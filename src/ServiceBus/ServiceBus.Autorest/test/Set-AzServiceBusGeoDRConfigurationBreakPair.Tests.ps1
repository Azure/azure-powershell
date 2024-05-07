if(($null -eq $TestName) -or ($TestName -contains 'Set-AzServiceBusGeoDRConfigurationBreakPair'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzServiceBusGeoDRConfigurationBreakPair.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzServiceBusGeoDRConfigurationBreakPair' {
    It 'Break' -skip:$($env.secondaryLocation -eq '') {
        Set-AzServiceBusGeoDRConfigurationBreakPair -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace -Name $env.alias
        
        while($drConfig.ProvisioningState -ne "Succeeded"){
            $drConfig = Get-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
            if ($TestMode -ne 'playback') {
                Start-Sleep 10
            }
        }

        $drConfig.Name | Should -Be $env.alias
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.PartnerNamespace | Should -Be ""
        $drConfig.Role | Should -Be "PrimaryNotReplicating"

        $drConfig = New-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace -PartnerNamespace $env.secondaryNamespaceResourceId
        
        while($drConfig.ProvisioningState -ne "Succeeded"){
            $drConfig = Get-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
            if ($TestMode -ne 'playback') {
                Start-Sleep 10
            }
        }
    }

    It 'BreakViaIdentity' -skip:$($env.secondaryLocation -eq '') {
        $drConfig = Get-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace

        Set-AzServiceBusGeoDRConfigurationBreakPair -InputObject $drConfig
        
        do{
            $drConfig = Get-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
            if ($TestMode -ne 'playback') {
                Start-Sleep 10
            }
        } while($drConfig.ProvisioningState -ne "Succeeded")

        $drConfig.Name | Should -Be $env.alias
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.PartnerNamespace | Should -Be ""
        $drConfig.Role | Should -Be "PrimaryNotReplicating"

        $drConfig = New-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace -PartnerNamespace $env.secondaryNamespaceResourceId
        
        while($drConfig.ProvisioningState -ne "Succeeded"){
            $drConfig = Get-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
            if ($TestMode -ne 'playback') {
                Start-Sleep 10
            }
        }
    }
}
