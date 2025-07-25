if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspaceCodeVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspaceCodeVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspaceCodeVersion' { #Moved
    It 'CreateExpanded' -Skip {
        {
            New-AzMLWorkspaceCodeVersion -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name 'test01' -Version 1 -CodeUri "https://mlworkspacekee7404291888.blob.core.windows.net/azureml-blobstore-179c53d8-ae09-4516-ac03-85af16e8848c/LocalUpload/a8da6e3978c9f8b1cb03501595a9142f/src"
            Remove-AzMLWorkspaceCodeVersion -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name 'test01' -Version 1
        } | Should -Not -Throw
    }
}
