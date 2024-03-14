if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageActionTask'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageActionTask.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageActionTask' {
    It 'List' {
        {
            $list_sub = Get-AzStorageActionTask
            $list_sub | Should -BeGreaterThan 1
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $task = Get-AzStorageActionTask -Name mytask1 -ResourceGroupName ps1-test
            $task.Name | Should -Be mytask1
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $list_group = Get-AzStorageActionTask -ResourceGroupName ps1-test
            $list_group | Should -BeGreaterThan 1
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
