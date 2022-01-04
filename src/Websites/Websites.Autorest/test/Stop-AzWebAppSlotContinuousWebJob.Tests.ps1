if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzWebAppSlotContinuousWebJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzWebAppSlotContinuousWebJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzWebAppSlotContinuousWebJob' {
    It 'Stop' {
        { Stop-AzWebAppSlotContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slotcontinuousJob03 } | Should -Not -Throw
    }

    It 'StopViaIdentity' {
        $job = Get-AzWebAppSlotContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot  -Name $env.slotcontinuousJob04
        { Stop-AzWebAppSlotContinuousWebJob -InputObject $job.Id } | Should -Not -Throw
    }
}
