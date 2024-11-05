if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkSecurityPerimeterLoggingConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkSecurityPerimeterLoggingConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkSecurityPerimeterLoggingConfiguration' {
    It 'Delete' {
        {            
            Remove-AzNetworkSecurityPerimeterLoggingConfiguration -Name $env.tmpLoggingConfigurationName -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp9

        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
            $configGet = Get-AzNetworkSecurityPerimeterLoggingConfiguration -Name $env.tmpLoggingConfigurationName -ResourceGroupName $env.rgname  -SecurityPerimeterName $env.tmpNsp9
    
            Remove-AzNetworkSecurityPerimeterLinkReference -InputObject $configGet

        } | Should -Not -Throw
    }
}
