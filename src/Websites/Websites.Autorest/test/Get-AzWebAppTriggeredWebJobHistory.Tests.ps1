if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWebAppTriggeredWebJobHistory'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppTriggeredWebJobHistory.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWebAppTriggeredWebJobHistory' {
    It 'List' {
        { Get-AzWebAppTriggeredWebJobHistory -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.triggeredJob01 } | Should -Not -Throw
    }

    It 'Get' {
        $jobs = Get-AzWebAppTriggeredWebJobHistory -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.triggeredJob01
        { Get-AzWebAppTriggeredWebJobHistory -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.triggeredJob01 -Id $jobs[0].Id.Split('/')[-1] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        $jobs = Get-AzWebAppTriggeredWebJobHistory -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.triggeredJob01
        { Get-AzWebAppTriggeredWebJobHistory -InputObject $jobs[0].Id } | Should -Not -Throw
    }
}
