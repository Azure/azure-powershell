if(($null -eq $TestName) -or ($TestName -contains 'Start-AzWebAppSlotContinuousWebJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzWebAppSlotContinuousWebJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzWebAppSlotContinuousWebJob' {
    It 'Start' {
        { Start-AzWebAppSlotContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slotcontinuousJob03 } | Should -Not -Throw
    }

    It 'StartViaIdentity' {
        $job = Get-AzWebAppSlotContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot  -Name $env.slotcontinuousJob04
        { Start-AzWebAppSlotContinuousWebJob -InputObject $job.Id } | Should -Not -Throw
    }
}
