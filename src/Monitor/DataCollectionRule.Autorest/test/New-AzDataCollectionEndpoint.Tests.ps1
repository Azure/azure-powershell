if(($null -eq $TestName) -or ($TestName -contains 'New-AzDataCollectionEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataCollectionEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDataCollectionEndpoint' {
    It 'CreateExpanded' -skip {
        {
            # Skip
            New-AzDataCollectionEndpoint -Name $env.testCollectionEndpoint -ResourceGroupName $env.resourceGroup -Location $env.Location -NetworkAclsPublicNetworkAccess Enabled
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        {
            # Skip
            New-AzDataCollectionEndpoint -Name $env.testCollectionEndpoint -ResourceGroupName $env.resourceGroup2 -JsonFilePath (Join-Path $PSScriptRoot '.\jsonfile\endpointTest1.json')
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
