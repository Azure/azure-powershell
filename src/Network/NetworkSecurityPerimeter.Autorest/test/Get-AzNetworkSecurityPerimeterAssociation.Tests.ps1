if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityPerimeterAssociation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkSecurityPerimeterAssociation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkSecurityPerimeterAssociation' {
    It 'List' {
        { 
        
        
        Get-AzNetworkSecurityPerimeterAssociation -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1

        
        } | Should -Not -Throw
    }

    It 'Get' {
        {
        
        Get-AzNetworkSecurityPerimeterAssociation -Name $env.tmpAssociation1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1
        
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { 
        
        $GETObj = Get-AzNetworkSecurityPerimeterAssociation -Name $env.tmpAssociation1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1
        $GETObjViaIdentity = Get-AzNetworkSecurityPerimeterAssociation -InputObject $GETObj
        $GETObj.Name | Should -Be $GETObjViaIdentity.Name

        } | Should -Not -Throw
    }
}
