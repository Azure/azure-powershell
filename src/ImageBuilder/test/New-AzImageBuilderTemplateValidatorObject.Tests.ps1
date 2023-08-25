if(($null -eq $TestName) -or ($TestName -contains 'New-AzImageBuilderTemplateValidatorObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzImageBuilderTemplateValidatorObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzImageBuilderTemplateValidatorObject' {
    It 'PowerShellValidator' {
        {
            $validator = New-AzImageBuilderTemplateValidatorObject -PowerShellValidator -Name PowerShellValidator -ScriptUri "https://example.com/path/to/script.sh"
            $validator.Name | Should -Be "PowerShellValidator"
        } | Should -Not -Throw
    }

    It 'ShellValidator' {
        {
            $validator = New-AzImageBuilderTemplateValidatorObject -ShellValidator -Name ShellValidator -ScriptUri "https://example.com/path/to/script.sh"
            $validator.Name | Should -Be "ShellValidator"
        } | Should -Not -Throw
    }
}
