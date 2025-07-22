if(($null -eq $TestName) -or ($TestName -contains 'Start-AzEventHubNamespaceFailOver'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzEventHubNamespaceFailOver.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzEventHubNamespaceFailOver' {
    It 'SetExpanded' {
        # Failover geo-Dr namespace
        $eventhubNamespace = Start-AzEventHubNamespaceFailOver -ResourceGroupName $env.resourceGroup -Name $env.namespaceV12 -PrimaryLocation eastus2euap
        $eventhubNamespace = Get-AzEventHubNamespace -ResourceGroupName $env.resourceGroup -Name $env.namespaceV12 
        $eventHubNamespace.GeoDataReplicationLocation.Count | Should -Be 2
    }

    It 'SetViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
