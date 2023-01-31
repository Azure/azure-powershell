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
    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' {
        $a = New-AzContainerRegistryIPRuleObject -IPAddressOrRange 192.159.0.31 -Action 'Forbidden'
        $b = New-AzContainerRegistryIPRuleObject -IPAddressOrRange 192.158.0.31 -Action 'Forbidden'
        $c = @($a, $b)
        { Update-AzContainerRegistry   -RegistryName $env.rstr1 -sku 'Premium' -ResourceGroupName $env.resourceGroup -NetworkRuleSetIPRule $c} | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
