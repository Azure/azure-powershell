if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWebAppTriggeredWebJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppTriggeredWebJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWebAppTriggeredWebJob' {
    It 'List' {
        $jobList = Get-AzWebAppTriggeredWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp
        $jobList.Count | Should -Be 2
    }

    It 'Get' {
        $job = Get-AzWebAppTriggeredWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.triggeredJob01
        $job.Name | Should -Be "$($env.webApp)/$($env.triggeredJob01)"
    }

    It 'GetViaIdentity' {
        $job = Get-AzWebAppTriggeredWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.triggeredJob01
        $job = Get-AzWebAppTriggeredWebJob -InputObject $job
        
        $job.Name | Should -Be "$($env.webApp)/$($env.triggeredJob01)"
    }
}
