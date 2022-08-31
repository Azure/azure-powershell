if(($null -eq $TestName) -or ($TestName -contains 'New-AzEventHubApplicationGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEventHubApplicationGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEventHubApplicationGroup' {
    It 'CreateExpanded' -skip {
        $t1 = New-AzEventHubThrottlingPolicyConfig -Name t1 -MetricId IncomingMessages -RateLimitThreshold 10000
        $t2 = New-AzEventHubThrottlingPolicyConfig -Name t2 -MetricId OutgoingBytes -RateLimitThreshold 20000
        $appGroup = New-AzEventHubApplicationGroup -Name appGroup -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -ClientAppGroupIdentifier SASKeyName=a -Policy $t1, $t2
        $appGroup.Name | Should -Be "appGroup"
        $appGroup.ResourceGroupName | Should -Be $env.ResourceGroupName
        $appGroup.ClientAppGroupIdentifier | Should -Be "SASKeyName=a"
        $appGroup.Policy.Count | Should -Be 2
    }
}
