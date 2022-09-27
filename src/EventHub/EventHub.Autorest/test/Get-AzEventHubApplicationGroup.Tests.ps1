if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEventHubApplicationGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEventHubApplicationGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEventHubApplicationGroup' {
    It 'List' {
        $listOfAppGroups = Get-AzEventHubApplicationGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfAppGroups.Count | Should -Be 1
    }

    It 'Get' {
        $appGroup = Get-AzEventHubApplicationGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.appGroup
        $appGroup.Name | Should -Be $env.appGroup
        $appGroup.Policy.Count | Should -Be 1
        $appGroup.Policy[0].Name | Should -Be "t1"
        $appGroup.IsEnabled | Should -Be $true
    }

    It 'GetViaIdentity' {
        $appGroup = Get-AzEventHubApplicationGroup -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.appGroup

        $appGroup = Get-AzEventHubApplicationGroup -InputObject $appGroup

        $appGroup.Name | Should -Be $env.appGroup
        $appGroup.Policy.Count | Should -Be 1
        $appGroup.Policy[0].Name | Should -Be "t1"
        $appGroup.IsEnabled | Should -Be $true

        $appGroup = Get-AzEventHubApplicationGroup -InputObject $appGroup.Id

        $appGroup.Name | Should -Be $env.appGroup
        $appGroup.Policy.Count | Should -Be 1
        $appGroup.Policy[0].Name | Should -Be "t1"
        $appGroup.IsEnabled | Should -Be $true
    }
}
