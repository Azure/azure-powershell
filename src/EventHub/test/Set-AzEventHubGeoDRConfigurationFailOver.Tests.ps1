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
        Set-AzEventHubGeoDRConfigurationFailOver -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.alias
        
        while($drConfig -ne "Succeeded"){
            $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
            Wait-Seconds 10
        }

        $drConfig.Name | Should -Be $env.alias
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.PartnerNamespace | Should -Be ""
        $drConfig.Role | Should -Be "Primary"

        $drConfig = New-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -PartnerNamespace $env.secondaryNamespaceResourceId
        
        while($drConfig -ne "Succeeded"){
            $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
            Wait-Seconds 10
        }
    }
    It 'FailViaIdentity' {
        Set-AzEventHubGeoDRConfigurationFailOver -InputObject $drConfig -Name $env.alias
        
        while($drConfig -ne "Succeeded"){
            $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
            Wait-Seconds 10
        }

        $drConfig.Name | Should -Be $env.alias
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.PartnerNamespace | Should -Be ""
        $drConfig.Role | Should -Be "Primary"

        $drConfig = New-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -PartnerNamespace $env.secondaryNamespaceResourceId
        
        while($drConfig -ne "Succeeded"){
            $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
            Wait-Seconds 10
        }
    }
}
