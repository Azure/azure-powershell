if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCdnEdgeActionVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCdnEdgeActionVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzCdnEdgeActionVersion' {
    It 'Delete' {
        $script:EdgeActionName = "eavremove"
        $script:Version = "v1"
        $script:TestResourceGroup = $env.ResourceGroupName
        
        # Create test edge action and version for removal test
        New-AzCdnEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -SkuName "Standard" -SkuTier "Standard" -Location "global"
        New-AzCdnEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $script:Version -DeploymentType "file" -IsDefaultVersion $false -Location "global"
        # Test deleting existing edge action version
        { Remove-AzCdnEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $script:Version } | Should -Not -Throw

        try {
            # Clean up edge action (this will also clean up any remaining versions)
            Remove-AzCdnEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -NoWait -ErrorAction SilentlyContinue
        } catch {
            # Ignore cleanup errors
        }
    }
}
