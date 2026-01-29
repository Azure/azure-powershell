if(($null -eq $TestName) -or ($TestName -contains 'Add-AzCdnEdgeActionAttachment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzCdnEdgeActionAttachment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Add-AzCdnEdgeActionAttachment' {
    It 'AddExpanded' {
        $resourceGroupName = $env.ResourceGroupName
        $edgeActionName = "eanew" 
        $version = "v1"

        New-AzCdnEdgeAction -ResourceGroupName $resourceGroupName -EdgeActionName $edgeActionName -SkuName "Standard" -SkuTier "Standard" -Location "global"

        New-AzCdnEdgeActionVersion -ResourceGroupName $resourceGroupName -EdgeActionName $edgeActionName -Version $version -DeploymentType "zip" -IsDefaultVersion $false -Location "global"

        Add-AzCdnEdgeActionAttachment -ResourceGroupName $resourceGroupName -EdgeActionName $edgeActionName -AttachedResourceId "97b45a70-afbe-49a6-ac4b-176a45e2b24f/resourceGroups/Synthetics-AFD-NorwayEast/providers/Microsoft.Cdn/profiles/easyntheticsppenorwayeast/ruleSets/eaRuleSet/rules/EdgeAction" 
        # Remove-AzCdnEdgeActionAttachment -ResourceGroupName $resourceGroupName -EdgeActionName $edgeActionName -AttachedResourceId "97b45a70-afbe-49a6-ac4b-176a45e2b24f/resourceGroups/Synthetics-AFD-NorwayEast/providers/Microsoft.Cdn/profiles/easyntheticsppenorwayeast/ruleSets/eaRuleSet/rules/EdgeAction"
    }

    It 'AddViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Add' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
