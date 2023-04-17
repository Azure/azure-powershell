if(($null -eq $TestName) -or ($TestName -contains 'Update-AzContainerRegistry'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzContainerRegistry.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzContainerRegistry' {
    It 'UpdateExpanded' {
        $network1 = New-AzContainerRegistryIPRuleObject -IPAddressOrRange 192.159.0.31 -Action 'Forbidden'
        $network2 = New-AzContainerRegistryIPRuleObject -IPAddressOrRange 192.158.0.31 -Action 'Forbidden'
        $networkSet = @($network1, $network2)
        { Update-AzContainerRegistry -RegistryName $env.rstr1 -sku 'Premium' -ResourceGroupName $env.resourceGroup -NetworkRuleSetIPRule $networkSet} | Should -Not -Throw
    }

    It 'UpdateViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
