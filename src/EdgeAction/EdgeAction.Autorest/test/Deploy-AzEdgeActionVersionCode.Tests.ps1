if(($null -eq $TestName) -or ($TestName -contains 'Deploy-AzEdgeActionVersionCode'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Deploy-AzEdgeActionVersionCode.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Deploy-AzEdgeActionVersionCode' {
    BeforeAll {
        $script:EdgeActionName = "eapt" + (New-Guid).ToString().Substring(0, 8)
        $script:TestResourceGroup = $env.ResourceGroupName
        $script:TestFilePath = Join-Path $PSScriptRoot 'test_handler.js'
    }

    AfterAll {
        # Clean up test resources
        Remove-AzEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -ErrorAction SilentlyContinue
    }

    It 'DeployFromJavaScriptFile-FileType' {
        # Create test edge action first (required for version creation)
        New-AzEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -SkuName "Standard" -SkuTier "Standard" -Location "global"
        
        # Test creating edge action version
        $version = "v1"
        New-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -DeploymentType "file" -IsDefaultVersion $false -Location "global"
        
        # Test deploy with JavaScript file using 'file' deployment type
        # Deploy is an LRO - the cmdlet automatically waits for completion
        $result = Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -FilePath $script:TestFilePath -DeploymentType "file"
        
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $version
        
        # Verify deployment completed successfully  
        $versionStatus = Get-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version
        $versionStatus.ProvisioningState | Should -Be "Succeeded"
        $versionStatus.ValidationStatus | Should -Be "Succeeded"
        
        # Clean up version
        Remove-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version
    }

    It 'DeployFromJavaScriptFile-ZipType' {
        # Test creating edge action version for zip deployment
        $version = "v2"
        New-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -DeploymentType "zip" -IsDefaultVersion $false -Location "global"
        
        # Test deploy with JavaScript file using 'zip' deployment type (auto-zips)
        # Deploy is an LRO - AutoRest SDK automatically waits for completion
        $result = Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -FilePath $script:TestFilePath -DeploymentType "zip"
        
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $version
        
        # Verify deployment completed successfully
        $versionStatus = Get-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version
        $versionStatus.ProvisioningState | Should -Be "Succeeded"
        $versionStatus.ValidationStatus | Should -Be "Succeeded"
        
        # Clean up version
        Remove-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version
    }

    It 'DeployFromJavaScriptFile-AutoDetect' {
        # Test auto-detection of deployment type for .js file
        $version = "v3"
        New-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -DeploymentType "file" -IsDefaultVersion $false -Location "global"
        
        # Test deploy without specifying deployment type (should auto-detect as 'file' for .js)
        # Deploy is an LRO - AutoRest SDK automatically waits for completion
        $result = Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -FilePath $script:TestFilePath
        
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $version
        
        # Verify deployment completed successfully
        $versionStatus = Get-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version
        $versionStatus.ProvisioningState | Should -Be "Succeeded"
        $versionStatus.ValidationStatus | Should -Be "Succeeded"
        
        # Clean up version
        Remove-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version
    }

    It 'DeployFromZipFile' {
        # Test deployment with pre-zipped file
        $version = "v4"
        New-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -DeploymentType "zip" -IsDefaultVersion $false -Location "global"
        
        # Create a temporary zip file
        $tempZip = Join-Path $env:TEMP "test_edge_action_$(New-Guid).zip"
        Compress-Archive -Path $script:TestFilePath -DestinationPath $tempZip -Force
        
        try {
            # Test deploy with zip file (auto-detects)
            # Deploy is an LRO - AutoRest SDK automatically waits for completion
            $result = Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -FilePath $tempZip
            
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $version
            
            # Verify deployment completed successfully
            $versionStatus = Get-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version
            $versionStatus.ProvisioningState | Should -Be "Succeeded"
            $versionStatus.ValidationStatus | Should -Be "Succeeded"
        }
        finally {
            # Clean up temp file
            Remove-Item -Path $tempZip -ErrorAction SilentlyContinue
            # Clean up version
            Remove-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version
        }
    }

    It 'DeployWithCustomName' {
        # Test deployment with custom deployment name
        $version = "v5"
        $customName = "customdeploymentname"  # Must be alphanumeric only
        New-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -DeploymentType "file" -IsDefaultVersion $false -Location "global"
        
        # Test deploy with custom name
        # Deploy is an LRO - AutoRest SDK automatically waits for completion
        $result = Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -FilePath $script:TestFilePath -Name $customName
        
        $result | Should -Not -BeNullOrEmpty
        
        # Verify deployment completed successfully
        $versionStatus = Get-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version
        $versionStatus.ProvisioningState | Should -Be "Succeeded"
        $versionStatus.ValidationStatus | Should -Be "Succeeded"
        
        # Clean up version
        Remove-AzEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version
    }

    It 'DeployViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeployViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeployExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Deploy' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeployViaIdentityEdgeActionExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeployViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeployViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeployViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
