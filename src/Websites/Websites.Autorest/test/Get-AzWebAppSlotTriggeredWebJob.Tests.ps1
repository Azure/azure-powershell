if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWebAppSlotTriggeredWebJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppSlotTriggeredWebJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWebAppSlotTriggeredWebJob' {
    It 'List' {
        $jobList = Get-AzWebAppSlotTriggeredWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot
        $jobList.Count | Should -Be 2
    }

    It 'Get' {
        $job = Get-AzWebAppSlotTriggeredWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slottriggeredJob03
        $job.Name | Should -Be "$($env.webApp)/$($env.slot)/$($env.slottriggeredJob03)"
    }

    It 'GetViaIdentity' {
        $job = Get-AzWebAppSlotTriggeredWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slottriggeredJob03
        $job = Get-AzWebAppSlotTriggeredWebJob -InputObject $job
        
        $job.Name | Should -Be "$($env.webApp)/$($env.slot)/$($env.slottriggeredJob03)"
    }
}
