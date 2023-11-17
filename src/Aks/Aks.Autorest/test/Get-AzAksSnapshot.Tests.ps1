if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksSnapshot'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksSnapshot.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksSnapshot' {
    It 'List' {
        $Snapshot = Get-AzAksSnapshot
        $Snapshot.Count | Should -Be 3
        $Snapshot.Name.Contains('snapshot1') | Should -Be $true
        $Snapshot.Name.Contains('snapshot2') | Should -Be $true
        $Snapshot.Name.Contains('snapshot3') | Should -Be $true
    }

    It 'List1' {
        $Snapshot = Get-AzAksSnapshot -ResourceGroupName $env.ResourceGroupName
        $Snapshot.Count | Should -Be 2
        $Snapshot.Name.Contains('snapshot1') | Should -Be $true
        $Snapshot.Name.Contains('snapshot2') | Should -Be $true
    }

    It 'Get' {
        $Snapshot = Get-AzAksSnapshot -ResourceGroupName $env.ResourceGroupName -ResourceName 'snapshot1'
        $Snapshot.Count | Should -Be 1
        $Snapshot.Name.Contains('snapshot1') | Should -Be $true
    }

    It 'GetViaIdentity' {
        $InputObject = @{Id = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/aks-test/providers/Microsoft.ContainerService/snapshots/snapshot1" }
        $Snapshot = Get-AzAksSnapshot -InputObject $InputObject
        $Snapshot.Count | Should -Be 1
        $Snapshot.Name.Contains('snapshot1') | Should -Be $true
    }
}
