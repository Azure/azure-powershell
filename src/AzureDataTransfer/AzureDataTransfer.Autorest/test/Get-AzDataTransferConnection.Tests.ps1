if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDataTransferConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataTransferConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDataTransferConnection' {
    It 'List' {
        {
            $connections = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName
            $connections.Count | Should -BeGreaterThan 0
            $connections | ForEach-Object {
                $_.ResourceGroupName | Should -Be $env.ResourceGroupName
            }
        } | Should -Not -Throw
    }

    It 'List in Subscription' {
        {
            $connections = Get-AzDataTransferConnection
            $connections.Count | Should -BeGreaterThan 0
            $connections | ForEach-Object {
                $_.Name | Should -Not -BeNullOrEmpty
            }
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $connection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $env.ConnectionLinked
            $connection | Should -Not -BeNullOrEmpty
            $connection.Name | Should -Be $env.ConnectionLinked
            $connection.ResourceGroupName | Should -Be $env.ResourceGroupName
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
