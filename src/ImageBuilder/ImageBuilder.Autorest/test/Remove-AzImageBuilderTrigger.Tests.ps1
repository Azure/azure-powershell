if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzImageBuilderTrigger'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzImageBuilderTrigger.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzImageBuilderTrigger' {
    It 'Delete' {
        {
            Remove-AzImageBuilderTrigger -ImageTemplateName $env.templateName -ResourceGroupName $env.rg -Name $env.newTempTriggerName2
        } | Should -Not -Throw
    }
}
