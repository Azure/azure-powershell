if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCdnEdgeAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCdnEdgeAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzCdnEdgeAction' {
    It 'Delete' {
        $script:EdgeActionName = "earemove"
        $script:TestResourceGroup = $env.ResourceGroupName
        
        # Create test edge action for removal test
        New-AzCdnEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -SkuName "Standard" -SkuTier "Standard" -Location "global"
        # Test deleting existing edge action
        { Remove-AzCdnEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName } | Should -Not -Throw
    }
}
