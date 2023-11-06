if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDnsDnssecConfig'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsDnssecConfig.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDnsDnssecConfig' {
    It 'Delete' {          
        # SETUP
        New-AzDnsDnssecConfig -ResourceGroupName $env.ResourceGroup -ZoneName $env.ZoneName3

        # TEST
        { Remove-AzDnsDnssecConfig -ResourceGroupName $env.ResourceGroup -ZoneName $env.ZoneName3 } | Should -Not -Throw

        # VERIFY
        { Get-AzDnsDnssecConfig -ResourceGroupName $env.ResourceGroup -ZoneName $env.ZoneName3 } | Should -Throw
    }
}
