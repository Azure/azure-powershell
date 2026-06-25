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
        $edgeActionResourceGroupName = 'testps-rg-edgeaction-permanent'
        $edgeActionName = 'eaattachperm'
        $ruleSetName = 'rseaattach'
        $ruleName = 'ruleeaattach'

        New-AzFrontDoorCdnRuleSet -ResourceGroupName $resourceGroupName -ProfileName $env.FrontDoorCdnProfileName -RuleSetName $ruleSetName | Out-Null
        $condition = New-AzFrontDoorCdnRuleRequestUriConditionObject -Name 'RequestUri' -ParameterOperator 'Any'
        $action = New-AzFrontDoorCdnRuleUrlRedirectActionObject -Name 'UrlRedirect' -ParameterRedirectType 'Moved' -ParameterDestinationProtocol 'MatchRequest'
        $rule = New-AzFrontDoorCdnRule -ResourceGroupName $resourceGroupName -ProfileName $env.FrontDoorCdnProfileName -RuleSetName $ruleSetName -Name $ruleName -Action @($action) -Condition @($condition)

        Add-AzCdnEdgeActionAttachment -ResourceGroupName $edgeActionResourceGroupName -EdgeActionName $edgeActionName -AttachedResourceId $rule.Id
        Remove-AzCdnEdgeActionAttachment -ResourceGroupName $edgeActionResourceGroupName -EdgeActionName $edgeActionName -AttachedResourceId $rule.Id
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
