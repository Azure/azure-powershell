if(($null -eq $TestName) -or ($TestName -contains 'New-AzElasticMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzElasticMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzElasticMonitor' {
    It 'CreateExpanded' {
        $elastic = New-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName03 -Location $env.location -Sku $env.sku -UserInfoEmailAddress $env.userEmail
        $elastic.ProvisioningState | Should -Be 'Succeeded'
    }
}
