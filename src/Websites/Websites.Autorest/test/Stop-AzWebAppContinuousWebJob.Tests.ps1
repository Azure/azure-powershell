if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzWebAppContinuousWebJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzWebAppContinuousWebJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzWebAppContinuousWebJob' {
    It 'Stop' {
        { Stop-AzWebAppContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.continuousJob01 } | Should -Not -Throw
    }

    It 'StopViaIdentity' {
        $job = Get-AzWebAppContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.continuousJob01
        { Stop-AzWebAppContinuousWebJob -InputObject $job.Id } | Should -Not -Throw
    }
}
