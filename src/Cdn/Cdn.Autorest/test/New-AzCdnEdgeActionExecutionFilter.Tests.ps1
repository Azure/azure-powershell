if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnEdgeActionExecutionFilter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnEdgeActionExecutionFilter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnEdgeActionExecutionFilter' {
    It 'CreateExpanded' {
        # Test creating edge action with expanded parameters
        $resourceGroupName = $env.ResourceGroupName
        $edgeActionName = "eaefnew" 

        $result = New-AzCdnEdgeAction -ResourceGroupName $resourceGroupName -EdgeActionName $edgeActionName -SkuName "Standard" -SkuTier "Standard" -Location "global"
            
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $edgeActionName
        $result.ResourceGroupName | Should -Be $resourceGroupName        
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
