if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityPerimeterProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkSecurityPerimeterProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkSecurityPerimeterProfile' {
    It 'List' {
        { 
        
         Get-AzNetworkSecurityPerimeterProfile -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1
        
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
        
        Get-AzNetworkSecurityPerimeterProfile -Name $env.tmpProfile1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1
        
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { 
        
        $GETObj = Get-AzNetworkSecurityPerimeterProfile -Name $env.tmpProfile1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1
        $GETObjViaIdentity = Get-AzNetworkSecurityPerimeterProfile -InputObject $GETObj
        $GETObj.Name | Should -Be $GETObjViaIdentity.Name

        } | Should -Not -Throw
    }
}
