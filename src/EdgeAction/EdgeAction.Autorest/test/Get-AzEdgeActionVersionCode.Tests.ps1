if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEdgeActionVersionCode'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEdgeActionVersionCode.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEdgeActionVersionCode' {
    BeforeAll {
        $script:resourceGroupName = "powershelltests"
        $script:edgeActionName = "eagetcode02"
        $script:version = "v1"
        $script:testFilePath = Join-Path $PSScriptRoot 'test_handler.js'
        
        # Create edge action and version for testing
        New-AzEdgeAction -ResourceGroupName $script:resourceGroupName `
            -Name $script:edgeActionName `
            -SkuName "Standard" `
            -SkuTier "Standard" `
            -Location "global"
        
        New-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version `
            -DeploymentType "file" `
            -IsDefaultVersion $true `
            -Location "global"
        
        # Deploy code to the version - Deploy is an LRO that waits for completion
        Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version `
            -FilePath $script:testFilePath
        
        # Verify deployment completed successfully before trying to get code
        $versionStatus = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version
        
        if ($versionStatus.ProvisioningState -ne "Succeeded" -or $versionStatus.ValidationStatus -ne "Succeeded") {
            throw "Deploy did not complete successfully. ProvisioningState: $($versionStatus.ProvisioningState), ValidationStatus: $($versionStatus.ValidationStatus)"
        }
    }

    AfterAll {
        # Clean up test edge action
        Remove-AzEdgeAction -ResourceGroupName $script:resourceGroupName `
            -Name $script:edgeActionName -ErrorAction SilentlyContinue
    }

    It 'Get' {
        # Test getting version code - this downloads the deployed code as base64-encoded ZIP
        $result = Get-AzEdgeActionVersionCode -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version
        
        $result | Should -Not -BeNullOrEmpty
        
        # Verify we got base64-encoded content
        $result.Content | Should -Not -BeNullOrEmpty
        
        # Verify it's valid base64 (should decode without error)
        { [System.Convert]::FromBase64String($result.Content) } | Should -Not -Throw
        
        # Verify the decoded content has reasonable size (ZIP file should be > 0 bytes)
        $bytes = [System.Convert]::FromBase64String($result.Content)
        $bytes.Length | Should -BeGreaterThan 0
    }

    It 'GetAndSave' {
        # Test getting version code and saving to file
        $outputDir = Join-Path $PSScriptRoot 'output'
        
        # Clean up output directory if it exists
        if (Test-Path $outputDir) {
            Remove-Item -Path $outputDir -Recurse -Force
        }
        
        $result = Get-AzEdgeActionVersionCode -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version `
            -OutputPath $outputDir
        
        $result | Should -Not -BeNullOrEmpty
        $result.Message | Should -Be "Version code saved successfully"
        $result.FilePath | Should -Not -BeNullOrEmpty
        
        # Verify file was created
        Test-Path $result.FilePath | Should -Be $true
        
        # Verify the file has content (should be a ZIP file)
        $fileInfo = Get-Item $result.FilePath
        $fileInfo.Length | Should -BeGreaterThan 0
        
        # Clean up
        if (Test-Path $outputDir) {
            Remove-Item -Path $outputDir -Recurse -Force
        }
    }

    It 'GetViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
