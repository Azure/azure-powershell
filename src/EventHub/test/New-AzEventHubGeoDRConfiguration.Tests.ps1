if(($null -eq $TestName) -or ($TestName -contains 'New-AzEventHubGeoDRConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEventHubGeoDRConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEventHubGeoDRConfiguration' {
    It 'CreateExpanded' -skip {
        $drConfig = New-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -PartnerNamespace $env.secondaryNamespaceResourceId
        $drConfig.ResourceGroupName | $env.resourceGroup
        $drConfig.Name | $env.alias
        $drConfig.PartnerNamespace | $env.secondaryNamespaceResourceId
        $drConfig.Role | "Primary"

        while($drConfig -ne "Succeeded"){
            $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
            Wait-Seconds 10
        }

        $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
        $drConfig.ResourceGroupName | $env.resourceGroup
        $drConfig.Name | $env.alias
        $drConfig.PartnerNamespace | $env.primaryNamespaceResourceId
        $drConfig.Role | "Secondary"
    }
}
