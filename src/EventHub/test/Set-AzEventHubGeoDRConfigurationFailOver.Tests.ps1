if(($null -eq $TestName) -or ($TestName -contains 'Set-AzEventHubGeoDRConfigurationFailOver'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzEventHubGeoDRConfigurationFailOver.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzEventHubGeoDRConfigurationFailOver' {
    It 'Fail' {
        Set-AzEventHubGeoDRConfigurationFailOver -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace -Name $env.alias
        
        while($drConfig.ProvisioningState -ne "Succeeded"){
            $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
            Start-Sleep 10
        }

        $drConfig.Name | Should -Be $env.alias
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.PartnerNamespace | Should -Be ""
        $drConfig.Role | Should -Be "Primary"

        $drConfig = Remove-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
        Start-Sleep 180
        Remove-AzEventHub -Name eh1 -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
        $drConfig = New-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace -PartnerNamespace $env.secondaryNamespaceResourceId
        
        while($drConfig.ProvisioningState -ne "Succeeded"){
            $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
            Start-Sleep 10
        }
    }
    It 'FailViaIdentity' {
        Set-AzEventHubGeoDRConfigurationFailOver -InputObject $drConfig
        
        while($drConfig.ProvisioningState -ne "Succeeded"){
            $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
            Start-Sleep 10
        }

        $drConfig.Name | Should -Be $env.alias
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.PartnerNamespace | Should -Be ""
        $drConfig.Role | Should -Be "Primary"

        $drConfig = Remove-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
        
        Start-Sleep 180

        { Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace } | Should -Throw
    }
}
