if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkSecurityPerimeterLoggingConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkSecurityPerimeterLoggingConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkSecurityPerimeterLoggingConfiguration' {
    It 'CreateExpanded' {
        { 
            # Logging configs created in nsp 6 & 7 will be deleted in remove logging config tests
            New-AzNetworkSecurityPerimeterLoggingConfiguration  -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp6 -EnabledLogCategory @('NspPublicOutboundResourceRulesAllowed')
            New-AzNetworkSecurityPerimeterLoggingConfiguration  -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp7 -EnabledLogCategory @('NspPublicOutboundResourceRulesAllowed')

        } | Should -Not -Throw
    }
}
