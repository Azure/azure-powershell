if(($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkSecurityPerimeterLoggingConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkSecurityPerimeterLoggingConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkSecurityPerimeterLoggingConfiguration' {
     It 'UpdateExpanded' {
        {

        Update-AzNetworkSecurityPerimeterLoggingConfiguration -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp13 -EnabledLogCategory @('NspPublicOutboundPerimeterRulesAllowed')

        } | Should -Not -Throw
    }

     It 'UpdateViaIdentityExpanded' {
        {

           $GETObj = Get-AzNetworkSecurityPerimeterLoggingConfiguration -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp13

           Update-AzNetworkSecurityPerimeterLoggingConfiguration -InputObject $GETObj -EnabledLogCategory @('NspPublicOutboundResourceRulesAllowed')

        } | Should -Not -Throw
    }
}
