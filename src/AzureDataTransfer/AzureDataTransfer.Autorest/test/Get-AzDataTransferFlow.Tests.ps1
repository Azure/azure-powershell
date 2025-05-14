if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDataTransferFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataTransferFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDataTransferFlow' {
    It 'List' {
        {
            $flows = Get-AzDataTransferFlow -ConnectionName $env:ConnectionName -ResourceGroupName $env:ResourceGroupName
            $flows.Count | Should -BeGreaterThan 0
            $flows | ForEach-Object {
                $_.Connection | Should -Be $env:ConnectionName
                $_.ResourceGroupName | Should -Be $env:ResourceGroupName
            }
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $flow = Get-AzDataTransferFlow -ConnectionName $env:ConnectionName -ResourceGroupName $env:ResourceGroupName -Name $env:FlowName
            $flow | Should -Not -BeNullOrEmpty
            $flow.Name | Should -Be $env:FlowName
            $flow.Connection | Should -Be $env:ConnectionName
            $flow.ResourceGroupName | Should -Be $env:ResourceGroupName
        } | Should -Not -Throw
    }

    It 'GetViaIdentityConnection' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
