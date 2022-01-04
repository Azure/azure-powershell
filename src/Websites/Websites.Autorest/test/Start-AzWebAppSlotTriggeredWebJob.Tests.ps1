if(($null -eq $TestName) -or ($TestName -contains 'Start-AzWebAppSlotTriggeredWebJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzWebAppSlotTriggeredWebJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzWebAppSlotTriggeredWebJob' {
    It 'Start' {
        { Start-AzWebAppSlotTriggeredWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slottriggeredJob03 } | Should -Not -Throw
    }

    It 'StartViaIdentity' {
        $job = Get-AzWebAppSlotTriggeredWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slottriggeredJob03
        { Start-AzWebAppSlotTriggeredWebJob -InputObject $job.Id } | Should -Not -Throw
    }
}
