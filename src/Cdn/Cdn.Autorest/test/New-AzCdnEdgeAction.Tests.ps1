if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnEdgeAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnEdgeAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnEdgeAction' {
    It 'CreateExpanded' {
        # Test creating edge action with expanded parameters
        $resourceGroupName = $env.ResourceGroupName
        $edgeActionName = "eanew" 

        {
            New-AzCdnEdgeAction -ResourceGroupName $resourceGroupName -EdgeActionName $edgeActionName -SkuName "Standard" -SkuTier "Standard" -Location "global"
        } | Should -Not -Throw
        
    }

    It 'CreateViaJsonFilePath' -skip {
    }

    It 'CreateViaJsonString' -skip {
    }
}
