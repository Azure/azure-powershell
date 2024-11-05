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

        $updateLinkObj = Update-AzNetworkSecurityPerimeterLoggingConfiguration -Name 'instance' -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp4

        } | Should -Not -Throw
    }
}
