if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkSecurityPerimeterProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkSecurityPerimeterProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkSecurityPerimeterProfile' {
    It 'Delete' {
        {
        
        Remove-AzNetworkSecurityPerimeterProfile -Name $env.tmpProfileDelete1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNspDelBase1
        
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
        
            $profileObj = Get-AzNetworkSecurityPerimeterProfile -Name $env.tmpProfileDelete2 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNspDelBase1 

            Remove-AzNetworkSecurityPerimeterProfile -InputObject $profileObj

        } | Should -Not -Throw
    }
}
        