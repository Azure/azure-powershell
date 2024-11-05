if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityPerimeterLoggingConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkSecurityPerimeterLoggingConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkSecurityPerimeterLoggingConfiguration' {
    It 'Get' {
        {
                    Get-AzNetworkSecurityPerimeterLoggingConfiguration -Name $env.tmpLoggingConfigurationName -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp2
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $GETObj = Get-AzNetworkSecurityPerimeterLoggingConfiguration -Name $env.tmpLoggingConfigurationName -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp2
            $GETObjViaIdentity = Get-AzNetworkSecurityPerimeterLoggingConfiguration -InputObject $GETObj
            $GETObj.Name | Should -Be $GETObjViaIdentity.Name
        } | Should -Not -Throw
    }
}
