if(($null -eq $TestName) -or ($TestName -contains 'Get-AzImageBuilderTrigger'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzImageBuilderTrigger.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzImageBuilderTrigger' {
    It 'List' {
        {
            $trigger = Get-AzImageBuilderTrigger -ImageTemplateName $env.templateName -ResourceGroupName $env.rg
            $trigger.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $trigger = Get-AzImageBuilderTrigger -ImageTemplateName $env.templateName -ResourceGroupName $env.rg -Name $env.newTempTriggerName1
            $trigger.Name | Should -Be $env.newTempTriggerName1
        } | Should -Not -Throw
    }
}
