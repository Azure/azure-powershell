if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspace' {
    It 'List1' {
        {
            $listsub = Get-AzMLWorkspace
            $listsub.Count | Should -BeGreaterOrEqual 2
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $ws = Get-AzMLWorkspace -ResourceGroupName $env.TestGroupName -Name $env.mainWorkspace
            $ws.Name | Should -Be $env.mainWorkspace
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $listgroup = Get-AzMLWorkspace -ResourceGroupName $env.TestGroupName
            $listgroup.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }
}
