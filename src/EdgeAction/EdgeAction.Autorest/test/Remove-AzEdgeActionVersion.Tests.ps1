if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEdgeActionVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEdgeActionVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEdgeActionVersion' {
    BeforeAll { Initialize-EdgeActionTestScenario {
        $script:resourceGroupName = "powershelltests"
        $script:edgeActionName = "eadelverdec01"
        
        # Create edge action for testing
        New-EdgeActionTestResource -ResourceGroupName $script:resourceGroupName -Name $script:edgeActionName
    } }

    AfterAll {
        # Clean up test edge action
        Complete-EdgeActionTestScenario -ResourceGroupName $script:resourceGroupName -Name $script:edgeActionName
    }

    It 'Delete' {
        # Test deleting version
        $version = "vdelete"
        
        # Create version to delete
        New-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $version `
            -DeploymentType "file" `
            -IsDefaultVersion $false `
            -Location "global"
        
        # Delete the version
        { Remove-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName `
            -Version $version } | Should -Not -Throw
        
        $remaining = Invoke-EdgeActionTestCommand 'Get-AzEdgeActionVersion' @{
            ResourceGroupName = $script:resourceGroupName
            EdgeActionName = $script:edgeActionName; Version = $version
        } "version '$version' under '$($script:edgeActionName)'" -AllowNotFound
        $remaining.NotFound | Should -Be $true
    }

    It 'DeleteViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
