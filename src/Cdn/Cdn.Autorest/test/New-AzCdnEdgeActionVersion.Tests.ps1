if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnEdgeActionVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnEdgeActionVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnEdgeActionVersion' {
    BeforeAll {
        $script:EdgeActionName = "eav" + (Get-Random -Maximum 99999)
        $script:TestResourceGroup = $env.ResourceGroupName
        
        # Create test edge action first (required for version creation)
        New-AzCdnEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -SkuName "Standard" -SkuTier "Standard" -Location "global"
    }

    It 'CreateExpanded' {
        # Test creating edge action version with expanded parameters
        $version = "v1"
        
        # Now we can create version on existing EdgeAction
        {
            New-AzCdnEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -DeploymentType "file" -IsDefaultVersion $false -Location "global"
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
    }

    It 'CreateViaJsonString' -skip {
    }
}
