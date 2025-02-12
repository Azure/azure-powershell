if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspaceDatastore'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspaceDatastore.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspaceDatastore' { #Moved
    It 'CreateExpanded' -skip {
        { 
            $accountKey = New-AzMLWorkspaceDatastoreKeyCredentialObject -Key "xxxxxxxxxxxxxxxxxxxxxxxx"
            $datastoreBlob = New-AzMLWorkspaceDatastoreBlobObject -AccountName 'mlworkspacekee7404291888' -ContainerName "globaldatasets" -Endpoint "core.windows.net" -Protocol "https" -ServiceDataAccessAuthIdentity 'None' -Credentials $accountKey
            New-AzMLWorkspaceDatastore -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name blobdatastore -Datastore $datastoreBlob
            Remove-AzMLWorkspaceDatastore -ResourceGroupName ml-rg-test01 -WorkspaceName mlworkspacekeep -Name blobdatastore
         } | Should -Not -Throw
    }
}
