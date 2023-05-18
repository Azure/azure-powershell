if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkSecurityPerimeterLink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkSecurityPerimeterLink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkSecurityPerimeterLink' {
    It 'Delete' {
        {
            Remove-AzNetworkSecurityPerimeterLink -Name $env.tmpLinkDelete3 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp8
        
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $Obj = Get-AzNetworkSecurityPerimeterLink -Name $env.tmpLinkDelete4 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp10

            Remove-AzNetworkSecurityPerimeterLink -InputObject $Obj

        } | Should -Not -Throw
    }
}
