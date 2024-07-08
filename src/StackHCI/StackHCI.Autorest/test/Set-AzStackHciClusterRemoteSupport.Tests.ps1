if(($null -eq $TestName) -or ($TestName -contains 'Set-AzStackHciClusterRemoteSupport'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzStackHciClusterRemoteSupport.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzStackHciClusterRemoteSupport' {
    It 'ConfigureExpanded' {
        Set-AzStackHciClusterRemoteSupport -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroup -ExpirationTimeStamp "2024-08-01T17:18:19.1234567Z" -RemoteSupportType "Enable"
    }

    It 'Configure' {

        $remoteSupportRequest = @{
            ExpirationTimeStamp = "2024-08-01T17:18:19.1234567Z"
            RemoteSupportType = "Enable"
        }

        Set-AzStackHciClusterRemoteSupport -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroup -RemoteSupportRequest $remoteSupportRequest
    }
}
