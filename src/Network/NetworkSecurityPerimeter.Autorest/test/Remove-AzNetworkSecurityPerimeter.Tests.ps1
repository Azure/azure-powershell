if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkSecurityPerimeter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkSecurityPerimeter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkSecurityPerimeter' {
    It 'Delete' {
        { 
        
        Remove-AzNetworkSecurityPerimeter -Name $env.tmpNspDelete1 -ResourceGroupName $env.rgname
        
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 

        $nspObj = Get-AzNetworkSecurityPerimeter -Name $env.tmpNspDelete2 -ResourceGroupName $env.rgname
        Remove-AzNetworkSecurityPerimeter -InputObject $nspObj
        
        } | Should -Not -Throw
    }
}
