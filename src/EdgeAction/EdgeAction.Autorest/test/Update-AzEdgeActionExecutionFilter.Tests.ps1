if(($null -eq $TestName) -or ($TestName -contains 'Update-AzEdgeActionExecutionFilter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzEdgeActionExecutionFilter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzEdgeActionExecutionFilter' {
    BeforeAll { Initialize-EdgeActionTestScenario {
        $script:resourceGroupName = $env.ResourceGroupName
        $script:edgeActionName = Get-EdgeActionTestFixtureName 'Update-AzEdgeActionExecutionFilter'
        $script:filterName = "updatefilter"
        $script:versionIds = @{}
        New-EdgeActionTestResource -ResourceGroupName $script:resourceGroupName -Name $script:edgeActionName
        foreach ($version in "v1", "v2") {
            $isDefault = if ($version -eq "v1") { "True" } else { "False" }
            $null = New-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
                -EdgeActionName $script:edgeActionName -Version $version `
                -DeploymentType "file" -IsDefaultVersion $isDefault -Location "global"
            $null = Deploy-AzEdgeActionVersionCode -ResourceGroupName $script:resourceGroupName `
                -EdgeActionName $script:edgeActionName -Version $version `
                -FilePath (Join-Path $PSScriptRoot 'test_handler.js')
            $ready = Get-AzEdgeActionVersion -ResourceGroupName $script:resourceGroupName `
                -EdgeActionName $script:edgeActionName -Version $version
            if ($ready.ProvisioningState -ne "Succeeded" -or $ready.ValidationStatus -ne "Succeeded") {
                throw "Update fixture version deployment did not succeed. ProvisioningState: $($ready.ProvisioningState), ValidationStatus: $($ready.ValidationStatus)"
            }
            if (-not $ready.Id) { throw "Update fixture version has no resource ID." }
            $script:versionIds[$version] = $ready.Id
        }
        $filter = New-AzEdgeActionExecutionFilter -ResourceGroupName $script:resourceGroupName `
            -EdgeActionName $script:edgeActionName -ExecutionFilter $script:filterName `
            -VersionId $script:versionIds["v1"] -Location "global" `
            -ExecutionFilterIdentifierHeaderName "X-Update-Filter" `
            -ExecutionFilterIdentifierHeaderValue "initial" -ErrorAction Stop
        if ($null -eq $filter) {
            throw "Update fixture execution-filter creation returned no resource."
        }
        if ($filter.ProvisioningState -ne "Succeeded") {
            throw "Update fixture execution-filter creation did not succeed. ProvisioningState: $($filter.ProvisioningState)"
        }
        if (-not $filter.Id) { throw "Update fixture execution filter has no resource ID." }
    } }

    AfterAll {
        Complete-EdgeActionTestScenario -ResourceGroupName $script:resourceGroupName -Name $script:edgeActionName
    }

    It 'UpdateExpanded' {
        $parameters = @{
            ResourceGroupName = $script:resourceGroupName
            EdgeActionName = $script:edgeActionName
            ExecutionFilter = $script:filterName
        }
        $null = Update-AzEdgeActionExecutionFilter @parameters -VersionId $script:versionIds["v2"] `
            -ExecutionFilterIdentifierHeaderName "X-Updated-Filter" `
            -ExecutionFilterIdentifierHeaderValue "updated" -Tag @{ Purpose = "updated" }
        $updated = Get-AzEdgeActionExecutionFilter @parameters
        $updated.Name | Should -Be $script:filterName
        $updated.VersionId | Should -Be $script:versionIds["v2"]
        $updated.ExecutionFilterIdentifierHeaderName | Should -Be "X-Updated-Filter"
        $updated.ExecutionFilterIdentifierHeaderValue | Should -Be "updated"
        $updated.Tag['Purpose'] | Should -Be "updated"

        $null = Update-AzEdgeActionExecutionFilter @parameters -ExecutionFilterIdentifierHeaderValue "preserved-tags"
        $preserved = Get-AzEdgeActionExecutionFilter @parameters
        $preserved.VersionId | Should -Be $script:versionIds["v2"]
        $preserved.ExecutionFilterIdentifierHeaderName | Should -Be "X-Updated-Filter"
        $preserved.ExecutionFilterIdentifierHeaderValue | Should -Be "preserved-tags"
        $preserved.Tag['Purpose'] | Should -Be "updated"
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
