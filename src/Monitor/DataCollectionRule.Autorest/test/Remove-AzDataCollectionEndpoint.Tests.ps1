if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDataCollectionEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDataCollectionEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDataCollectionEndpoint' {
    It 'Delete' {
        {
            Remove-AzDataCollectionEndpoint -Name $env.testCollectionEndpoint2 -ResourceGroupName $env.resourceGroup2
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $endpoint = New-AzDataCollectionEndpoint -Name $env.testCollectionEndpoint2 -ResourceGroupName $env.resourceGroup2 -Location $env.Location -NetworkAclsPublicNetworkAccess Enabled
            Remove-AzDataCollectionEndpoint -InputObject $endpoint
        } | Should -Not -Throw
    }
}
