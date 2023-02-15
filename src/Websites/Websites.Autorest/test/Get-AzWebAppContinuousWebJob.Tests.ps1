if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWebAppContinuousWebJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebAppContinuousWebJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWebAppContinuousWebJob' {
    It 'List' {
        $jobList = Get-AzWebAppContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp
        $jobList.Count | Should -Be 2
    }

    It 'Get' {
        $job = Get-AzWebAppContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.continuousJob01
        $job.Name | Should -Be "$($env.webApp)/$($env.continuousJob01)"
    }

    It 'GetViaIdentity' {
        $job = Get-AzWebAppContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.continuousJob01
        $job = Get-AzWebAppContinuousWebJob -InputObject $job
        
        $job.Name | Should -Be "$($env.webApp)/$($env.continuousJob01)"
    }
}
