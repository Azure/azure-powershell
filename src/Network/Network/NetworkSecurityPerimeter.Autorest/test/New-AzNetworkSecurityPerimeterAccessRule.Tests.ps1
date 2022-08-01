if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkSecurityPerimeterAccessRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkSecurityPerimeterAccessRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkSecurityPerimeterAccessRule' {
    It 'CreateExpanded' {
        { 
        
        New-AzNetworkSecurityPerimeterAccessRule -Name $env.accessRule1 -ProfileName $env.tmpProfile2 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp1 -AddressPrefix '10.10.0.0/16' -Direction 'Inbound' -Location $env.location
        
        } | Should -Not -Throw
    }
}
