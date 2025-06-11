if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDataTransferPipeline'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataTransferPipeline.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDataTransferPipeline' {
    It 'List in Subscription' {
        {
            $pipelines = Get-AzDataTransferPipeline
            $pipelines.Count | Should -BeGreaterThan 0
            $pipelines | ForEach-Object {
                $_.Name | Should -Not -BeNullOrEmpty
            }
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $pipelines = Get-AzDataTransferPipeline -ResourceGroupName $env.ResourceGroupName
            $pipelines.Count | Should -BeGreaterThan 0
            $pipelines | ForEach-Object {
                $_.Name | Should -Not -BeNullOrEmpty
                $_.ResourceGroupName | Should -Be $env.ResourceGroupName
            }
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $pipeline = Get-AzDataTransferPipeline -ResourceGroupName $env.ResourceGroupName -Name $env.PipelineName
            $pipeline | Should -Not -BeNullOrEmpty
            $pipeline.Name | Should -Be $env.PipelineName
            $pipeline.ResourceGroupName | Should -Be $env.ResourceGroupName
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
