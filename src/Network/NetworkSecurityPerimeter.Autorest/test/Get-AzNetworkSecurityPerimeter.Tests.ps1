if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityPerimeter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkSecurityPerimeter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkSecurityPerimeter' {
    It 'List' {
        { Get-AzNetworkSecurityPerimeter -ResourceGroupName $env.rgname } | Should -Not -Throw
    }

    It 'List1' -Skip {
        { Get-AzNetworkSecurityPerimeter} | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzNetworkSecurityPerimeter -Name $env.tmpNsp1 -ResourceGroupName $env.rgname } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { 
        
        $GETObj = Get-AzNetworkSecurityPerimeter -Name $env.tmpNsp1 -ResourceGroupName $env.rgname
        $GETObjViaIdentity = Get-AzNetworkSecurityPerimeter -InputObject $GETObj

        $GETObj.Name | Should -Be $GETObjViaIdentity.Name
        
        } | Should -Not -Throw
    }
}
