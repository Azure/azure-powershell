if(($null -eq $TestName) -or ($TestName -contains 'New-AzRelayKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRelayKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRelayKey' {
    It 'RegenerateExpanded' {
        {
            New-AzRelayKey -ResourceGroupName $env.resourceGroupName  -Namespace $env.namespaceName01  -Name $env.authRuleName01  -RegenerateKey 'PrimaryKey'
            Get-AzRelayKey -ResourceGroupName $env.resourceGroupName  -Namespace $env.namespaceName01  -Name $env.authRuleName01 
        } | Should -Not -Throw
    }

    It 'RegenerateExpanded1' {
        {
            New-AzRelayKey -ResourceGroupName $env.resourceGroupName  -Namespace $env.namespaceName01  -HybridConnection $env.hybridConnectionName01  -Name $env.authRuleName01  -RegenerateKey 'PrimaryKey'
            Get-AzRelayKey -ResourceGroupName $env.resourceGroupName  -Namespace $env.namespaceName01  -HybridConnection $env.hybridConnectionName01  -Name $env.authRuleName01  
        } | Should -Not -Throw
    }

    It 'RegenerateExpanded2' {
        {
            New-AzRelayKey -ResourceGroupName $env.resourceGroupName  -Namespace $env.namespaceName01  -WcfRelay $env.wcfRelayName01  -Name $env.authRuleName01  -RegenerateKey 'PrimaryKey'
            Get-AzRelayKey -ResourceGroupName $env.resourceGroupName  -Namespace $env.namespaceName01  -WcfRelay $env.wcfRelayName01  -Name $env.authRuleName01 
        } | Should -Not -Throw
    }
}
