if(($null -eq $TestName) -or ($TestName -contains 'Update-AzEdgeActionVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzEdgeActionVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzEdgeActionVersion' {
    BeforeAll { Initialize-EdgeActionTestScenario {
        $script:resourceGroupName = "powershelltests"
        $script:edgeActionName = "eaupdatever01"
        $script:version = "v1"
        New-EdgeActionTestResource -ResourceGroupName $script:resourceGroupName -Name $script:edgeActionName
        $null = New-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName -Version $script:version `
            -DeploymentType "file" -IsDefaultVersion "True" -Location "global"
    } }

    AfterAll {
        Complete-EdgeActionTestScenario -ResourceGroupName $script:resourceGroupName -Name $script:edgeActionName
    }

    It 'UpdateExpanded' {
        $parameters = @{
            ResourceGroupName = $script:resourceGroupName
            EdgeActionName = $script:edgeActionName
            Version = $script:version
        }
        $before = Get-AzEdgeActionVersion @parameters
        $before.IsDefaultVersion | Should -Be "True"

        # PATCH changes tags, not the default version; default changes belong to swapDefault.
        $null = Update-AzEdgeActionVersion @parameters -Tag @{ Purpose = "updated" }
        $updated = Get-AzEdgeActionVersion @parameters
        $updated.Name | Should -Be $script:version
        $updated.Tag['Purpose'] | Should -Be "updated"
        $updated.IsDefaultVersion | Should -Be $before.IsDefaultVersion
        $updated.DeploymentType | Should -Be $before.DeploymentType
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityEdgeActionExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
