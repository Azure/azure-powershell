if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityPerimeterAccessRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkSecurityPerimeterAccessRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkSecurityPerimeterAccessRule' {
    It 'List' {
        { 
            Get-AzNetworkSecurityPerimeterAccessRule -ProfileName $env.tmpProfile1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1
        } | Should -Not -Throw
    }

    It 'Get' {
        { 

            Get-AzNetworkSecurityPerimeterAccessRule -Name $env.tmpAccessRule1 -ProfileName $env.tmpProfile1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1
        
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { 
        
        $GETObj = Get-AzNetworkSecurityPerimeterAccessRule -Name $env.tmpAccessRule1 -ProfileName $env.tmpProfile1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1
        $GETObjViaIdentity = Get-AzNetworkSecurityPerimeterAccessRule -InputObject $GETObj

        $GETObj.Name | Should -Be $GETObjViaIdentity.Name
        } | Should -Not -Throw
    }
}
