if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWebAppSlotTriggeredWebJobHistory'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppSlotTriggeredWebJobHistory.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWebAppSlotTriggeredWebJobHistory' {
    It 'List' {
        { Get-AzWebAppSlotTriggeredWebJobHistory -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slottriggeredJob03 } | Should -Not -Throw
    }

    It 'Get' {
        $jobs = Get-AzWebAppSlotTriggeredWebJobHistory -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slottriggeredJob03
        { Get-AzWebAppSlotTriggeredWebJobHistory -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slottriggeredJob03 -Id $jobs[0].Id.Split('/')[-1] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        $jobs = Get-AzWebAppSlotTriggeredWebJobHistory -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -SlotName $env.slot -Name $env.slottriggeredJob03
        { Get-AzWebAppSlotTriggeredWebJobHistory -InputObject $jobs[0].Id } | Should -Not -Throw
    }
}
