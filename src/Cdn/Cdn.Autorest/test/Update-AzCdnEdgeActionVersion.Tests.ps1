if(($null -eq $TestName) -or ($TestName -contains 'Update-AzCdnEdgeActionVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCdnEdgeActionVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzCdnEdgeActionVersion' {
    It 'UpdateExpanded' -skip {
        $script:EdgeActionName = "eavupdate"
        $script:TestResourceGroup = $env.ResourceGroupName
        
        New-AzCdnEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -SkuName "Standard" -SkuTier "Standard" -Location "global"
        $version = "v1"

        New-AzCdnEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -DeploymentType "zip" -IsDefaultVersion $false 

        Update-AzCdnEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -DeploymentType "file"
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
