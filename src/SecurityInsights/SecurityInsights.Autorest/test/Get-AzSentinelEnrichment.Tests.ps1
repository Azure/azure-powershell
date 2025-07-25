if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelEnrichment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelEnrichment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelEnrichment' {
    It 'Get_IP'  {
        $IPEnrichment = Get-AzSentinelEnrichment -ResourceGroupName $env.resourceGroupName -IPAddress 8.8.8.8 
        $IPEnrichment.ipAddr | Should -Be '8.8.8.8'
    }

    It 'Get_Domain' {
        $DomainEnrichment = Get-AzSentinelEnrichment -ResourceGroupName $env.resourceGroupName -Domain "google.com"
        $DomainEnrichment.domain | Should -Be 'google.com'
    }
}
