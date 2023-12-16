if(($null -eq $TestName) -or ($TestName -contains 'Update-AzImageBuilderTemplate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzImageBuilderTemplate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzImageBuilderTemplate' {
    It 'UpdateExpanded' {
        {
            $template = Update-AzImageBuilderTemplate -Name $env.newTemplateName3 -ResourceGroupName $env.rg -Tag @{"123"="abc"}
            $template = Get-AzImageBuilderTemplate -Name $env.newTemplateName3 -ResourceGroupName $env.rg
            $template.Tag["123"] | Should -be "abc"
        } | Should -Not -Throw
    }
}
