if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkSecurityPerimeterProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkSecurityPerimeterProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkSecurityPerimeterProfile' {
    It 'CreateExpanded' {
        { 

            New-AzNetworkSecurityPerimeterProfile -Name $env.profile1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1 
        
        } | Should -Not -Throw
    }
}
