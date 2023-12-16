if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelMetadata'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelMetadata.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelMetadata' {
    It 'List'  {
       $metadatas = Get-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
       $metadatas.Count | Should -BeGreaterorEqual 1 
    }

    It 'Get' {
        $metadata = Get-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $env.metadataName
        $metadata.Name | Should -Be $env.metadataName
    }

    It 'GetViaIdentity' {
        $metadata = Get-AzSentinelMetadata -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -name $env.metadataName
        $metadataViaIdentity = Get-AzSentinelMetadata -InputObject $metadata
        $metadataViaIdentity.Name | Should -Be $env.metadataName
    }
}
