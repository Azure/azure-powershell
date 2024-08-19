if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEventHubNamespaceV2'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEventHubNamespaceV2.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEventHubNamespaceV2' {
    It 'List' {
        $listOfNamespaces = Get-AzEventHubNamespaceV2
        $listOfNamespaces.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $namespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespace
        $namespace.Name | Should -Be $env.namespace
    }

    It 'List1' {
        $listOfNamespaces = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup
        $listOfNamespaces.Count | Should -BeGreaterOrEqual 2
    }

    It 'GetViaIdentity' {
        $namespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespace
        $namespace = Get-AzEventHubNamespaceV2 -InputObject $namespace
        $namespace.Name | Should -Be $env.namespace
    }
}
