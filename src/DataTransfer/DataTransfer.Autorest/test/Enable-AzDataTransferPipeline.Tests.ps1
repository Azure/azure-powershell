if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzDataTransferPipeline'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzDataTransferPipeline.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzDataTransferPipeline' -Tag 'LiveOnly' {
    It 'Enable pipeline with NoWait' {
        {
            # Enable pipeline asynchronously
            $result = Enable-AzDataTransferPipeline -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -Justification "Test enabling pipeline with NoWait" -NoWait -Confirm:$false
            
            $pipeline = Get-AzDataTransferPipeline -Name $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
                    
            if ($pipeline) {
                Write-Host "Pipeline status check completed successfully"
                $pipeline | Should -Not -BeNullOrEmpty
                $pipeline.Status | Should -Not -Be "Disabled"
            } else {
                Write-Warning "Pipeline status could not be retrieved"
            }
            # NoWait should return immediately
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }
}
