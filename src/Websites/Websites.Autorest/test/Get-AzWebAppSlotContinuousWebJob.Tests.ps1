if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWebAppSlotContinuousWebJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppSlotContinuousWebJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWebAppSlotContinuousWebJob' {
    It 'List' {
        $jobList = Get-AzWebAppSlotContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot
        $jobList.Count | Should -Be 2
    }

    It 'Get' {
        $job = Get-AzWebAppSlotContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slotcontinuousJob03
        $job.Name | Should -Be "$($env.webApp)/$($env.slot)/$($env.slotcontinuousJob03)"
    }

    It 'GetViaIdentity' {
        $job = Get-AzWebAppSlotContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slotcontinuousJob03
        $job = Get-AzWebAppSlotContinuousWebJob -InputObject $job
        $job.Name | Should -Be "$($env.webApp)/$($env.slot)/$($env.slotcontinuousJob03)"
    }
}
