if(($null -eq $TestName) -or ($TestName -contains 'Switch-AzEdgeActionVersionDefault'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Switch-AzEdgeActionVersionDefault.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Switch-AzEdgeActionVersionDefault' {
    BeforeAll {
        $script:resourceGroupName = "powershelltests"
        $script:edgeActionName = "easwapdec01"
        $script:version1 = "v1"
        $script:version2 = "v2"
        $script:testFilePath = Join-Path $PSScriptRoot 'test_handler.js'
        
        # Create edge action
        New-AzEdgeAction -ResourceGroupName $script:resourceGroupName `
            -Name $script:edgeActionName `
            -SkuName "Standard" `
            -SkuTier "Standard" `
            -Location "global"
        
        # Create v1 as default version
        New-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version1 `
            -DeploymentType "file" `
            -IsDefaultVersion $true `
            -Location "global"
        
        # Deploy code to v1
        Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version1 `
            -FilePath $script:testFilePath
        
        # Create v2 as non-default version
        New-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version2 `
            -DeploymentType "file" `
            -IsDefaultVersion $false `
            -Location "global"
        
        # Deploy code to v2
        Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version2 `
            -FilePath $script:testFilePath
    }

    AfterAll {
        # Clean up test edge action
        Remove-AzEdgeAction -ResourceGroupName $script:resourceGroupName `
            -Name $script:edgeActionName -ErrorAction SilentlyContinue
    }

    It 'Swap' {
        # Verify initial state: v1 is default, v2 is not
        $v1Before = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version1
        $v2Before = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version2
        
        $v1Before.IsDefaultVersion | Should -Be "True"
        $v2Before.IsDefaultVersion | Should -Be "False"
        
        # Switch default version from v1 to v2
        # Switch is an LRO that waits for completion
        Switch-AzEdgeActionVersionDefault -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version2
        
        # Verify final state: v1 is not default, v2 is default
        $v1After = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version1
        $v2After = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $script:version2
        
        $v1After.IsDefaultVersion | Should -Be "False"
        $v2After.IsDefaultVersion | Should -Be "True"
    }

    It 'SwapViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SwapViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
