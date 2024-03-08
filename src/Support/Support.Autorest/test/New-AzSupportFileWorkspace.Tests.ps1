if(($null -eq $TestName) -or ($TestName -contains 'New-AzSupportFileWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSupportFileWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSupportFileWorkspace' {
    It 'Create' {
        $fileWorkspaceName = $env.FileWorkspaceNameSubscriptionForCreate
        $fileWorkspace = New-AzSupportFileWorkspace -Name $fileWorkspaceName -SubscriptionId $env.SubscriptionId
        $fileWorkspace.Name | Should -Be $fileWorkspaceName
    }
}
