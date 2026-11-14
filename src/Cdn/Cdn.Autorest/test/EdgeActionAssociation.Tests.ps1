if (($null -eq $TestName) -or ($TestName -contains 'EdgeActionAssociation')) {
    . (Join-Path $PSScriptRoot 'loadEnv.ps1')
    $TestRecordingFile = Join-Path $PSScriptRoot 'EdgeActionAssociation.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'EdgeActionAssociation' {
    BeforeAll {
        if (-not $env.EdgeActionResourceId) {
            throw 'Configure EdgeActionResourceId with an existing EdgeAction before recording.'
        }
        $script:ruleSetName = 'azpsEdgeActionAssociation'
        $script:ruleName = 'edgeActionAssociation'
        New-AzFrontDoorCdnRuleSet -Name $script:ruleSetName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnRuleSet -Name $script:ruleSetName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'Creates a rule referencing the existing EdgeAction' {
        $action = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.EdgeAction]::new()
        $action.ParameterTypeName = 'DeliveryRuleEdgeActionParameters'
        $action.ParameterInvocationPoint = 'ClientRequest'
        $action.ReferenceId = $env.EdgeActionResourceId
        $rule = New-AzFrontDoorCdnRule -Name $script:ruleName -RuleSetName $script:ruleSetName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Order 1 -Action @($action)
        $rule.Action[0].Name | Should -Be 'EdgeAction'
        $rule.Action[0].ReferenceId | Should -Be $env.EdgeActionResourceId
    }

    It 'Updates the association without modifying the EdgeAction resource' {
        $action = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.EdgeAction]::new()
        $action.ParameterTypeName = 'DeliveryRuleEdgeActionParameters'
        $action.ParameterInvocationPoint = 'ClientResponse'
        $action.ReferenceId = $env.EdgeActionResourceId
        Update-AzFrontDoorCdnRule -Name $script:ruleName -RuleSetName $script:ruleSetName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Action @($action) | Out-Null
        $rule = Get-AzFrontDoorCdnRule -Name $script:ruleName -RuleSetName $script:ruleSetName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $rule.Action[0].ParameterInvocationPoint | Should -Be 'ClientResponse'
        $rule.Action[0].ReferenceId | Should -Be $env.EdgeActionResourceId
    }
}
