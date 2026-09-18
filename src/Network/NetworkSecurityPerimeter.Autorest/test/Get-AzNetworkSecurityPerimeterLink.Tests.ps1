if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityPerimeterLink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkSecurityPerimeterLink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkSecurityPerimeterLink' {
    It 'List' {
        {          
            Get-AzNetworkSecurityPerimeterLink -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp2
        } | Should -Not -Throw
    }

    It 'Get' {
        {
                    Get-AzNetworkSecurityPerimeterLink -Name $env.tmpLink1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp2
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $GETObj = Get-AzNetworkSecurityPerimeterLink -Name $env.tmpLink1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp2
            $GETObjViaIdentity = Get-AzNetworkSecurityPerimeterLink -InputObject $GETObj
            $GETObj.Name | Should -Be $GETObjViaIdentity.Name
        } | Should -Not -Throw
    }
}
