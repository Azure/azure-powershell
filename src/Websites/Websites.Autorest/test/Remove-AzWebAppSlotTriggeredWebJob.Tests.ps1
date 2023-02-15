if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzWebAppSlotTriggeredWebJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWebAppSlotTriggeredWebJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzWebAppSlotTriggeredWebJob' {
    It 'Delete' {
        { Remove-AzWebAppSlotTriggeredWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slottriggeredJob03 } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $job = Get-AzWebAppSlotTriggeredWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slottriggeredJob04
        { Remove-AzWebAppSlotTriggeredWebJob -InputObject $job.Id } | Should -Not -Throw
    }
}
