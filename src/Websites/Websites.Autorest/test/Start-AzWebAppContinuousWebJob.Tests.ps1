if(($null -eq $TestName) -or ($TestName -contains 'Start-AzWebAppContinuousWebJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzWebAppContinuousWebJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzWebAppContinuousWebJob' {
    It 'Start' {
        { Start-AzWebAppContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.continuousJob01 } | Should -Not -Throw
    }

    It 'StartViaIdentity' {
        $job = Get-AzWebAppContinuousWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.continuousJob01
        { Start-AzWebAppContinuousWebJob -InputObject $job.Id } | Should -Not -Throw
    }
}
