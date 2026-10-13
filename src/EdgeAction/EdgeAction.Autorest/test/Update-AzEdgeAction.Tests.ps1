if(($null -eq $TestName) -or ($TestName -contains 'Update-AzEdgeAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzEdgeAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzEdgeAction' {
    BeforeAll { Initialize-EdgeActionTestScenario {
        $script:resourceGroupName = "powershelltests"
        $script:edgeActionName = "eaupdatetag01"
        New-EdgeActionTestResource -ResourceGroupName $script:resourceGroupName -Name $script:edgeActionName
    } }

    AfterAll {
        Complete-EdgeActionTestScenario -ResourceGroupName $script:resourceGroupName -Name $script:edgeActionName
    }

    It 'UpdateExpanded tag replacement and UpdateViaJsonString tag clearing' {
        $parameters = @{ ResourceGroupName = $script:resourceGroupName; Name = $script:edgeActionName }
        $before = Get-AzEdgeAction @parameters
        $null = Update-AzEdgeAction @parameters -Tag @{ Purpose = "initial"; RemoveMe = "initial" }
        $initial = Get-AzEdgeAction @parameters
        $initial.Tag['Purpose'] | Should -Be "initial"
        $initial.Tag['RemoveMe'] | Should -Be "initial"

        $null = Update-AzEdgeAction @parameters -Tag @{ Purpose = "updated" }
        $updated = Get-AzEdgeAction @parameters
        $updated.Tag['Purpose'] | Should -Be "updated"
        $updated.Tag.Count | Should -Be 1
        $updated.Location | Should -Be $before.Location
        $updated.SkuName | Should -Be $before.SkuName
        $updated.SkuTier | Should -Be $before.SkuTier

        # Expanded serialization omits empty objects; JSON preserves the explicit tag-clear request.
        $null = Update-AzEdgeAction @parameters -JsonString '{"tags":{}}'
        $cleared = Get-AzEdgeAction @parameters
        $cleared.Tag.Count | Should -Be 0
        $cleared.Location | Should -Be $before.Location
        $cleared.SkuName | Should -Be $before.SkuName
        $cleared.SkuTier | Should -Be $before.SkuTier
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
