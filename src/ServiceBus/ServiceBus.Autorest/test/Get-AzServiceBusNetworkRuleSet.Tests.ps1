if(($null -eq $TestName) -or ($TestName -contains 'Get-AzServiceBusNetworkRuleSet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzServiceBusNetworkRuleSet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzServiceBusNetworkRuleSet' {
    It 'Get'  {
        $networkRuleSet = Get-AzServiceBusNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $networkRuleSet.PublicNetworkAccess | Should -Be "Enabled"
        $networkRuleSet.TrustedServiceAccessEnabled | Should -Be $false
        $networkRuleSet.VirtualNetworkRule.Count | Should -Be 0
        $networkRuleSet.IPRule.Count | Should -Be 0
    }

    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
