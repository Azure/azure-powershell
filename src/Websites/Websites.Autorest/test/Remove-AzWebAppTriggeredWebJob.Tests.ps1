if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzWebAppTriggeredWebJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWebAppTriggeredWebJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzWebAppTriggeredWebJob' {
    It 'Delete' {
        { Remove-AzWebAppTriggeredWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.triggeredJob01 } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $job = Get-AzWebAppTriggeredWebJob -ResourceGroupName $env.webJobResourceGroup -AppName $env.webApp -Name $env.triggeredJob02
        { Remove-AzWebAppTriggeredWebJob -InputObject $job.Id } | Should -Not -Throw
    }
}
