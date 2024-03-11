if(($null -eq $TestName) -or ($TestName -contains 'New-AzSupportFileAndUpload'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSupportFileAndUpload.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSupportFileAndUpload' {
    It 'CreateExpanded' {
        $testFilePath = Join-Path $PSScriptRoot files test.txt
        $file = New-AzSupportFileAndUpload -WorkspaceName $env.FileWorkspaceNameSubscription -FilePath $testFilePath -SubscriptionId $env.SubscriptionId
        $file.Name | Should -Be "test.txt"
    }
}
