if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDnsDnssecConfig'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsDnssecConfig.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDnsDnssecConfig' {
    It 'Get' {
        try {            
            # SETUP
            New-AzDnsZone -ResourceGroupName $env.ResourceGroup -Name $env.ZoneName1 -Location $env.Location
            New-AzDnsDnssecConfig -ResourceGroupName $env.ResourceGroup -ZoneName $env.ZoneName1

            # TEST
            $config = Get-AzDnsDnssecConfig -ResourceGroupName $env.ResourceGroup -ZoneName $env.ZoneName1
            $config.SigningKey.Count | Should -Be 2    
        }
        finally {
            Remove-AzDnsZone -ResourceGroupName $env.ResourceGroup -Name $env.ZoneName1
        }
    }
}
