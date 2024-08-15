if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspaceDataVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspaceDataVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspaceDataVersion' {
    It 'CreateExpanded' {
        { 
            New-AzMLWorkspaceDataVersion -ResourceGroupName $env.TestGroupName -WorkspaceName $env.mainWorkspace -Name iris-data -Version 2 -DataType 'uri_file' -DataUri "https://azuremlexamples.blob.core.windows.net/datasets/iris.csv" 
            # Remove Method not supported
            # Remove-AzMLWorkspaceDataVersion -ResourceGroupName $env.TestGroupName -WorkspaceName $env.mainWorkspace -Name iris-data -Version 2
        } | Should -Not -Throw
    }
}
