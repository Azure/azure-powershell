Describe 'Cdn completion metadata' {
    It 'Preserves existing CDN completion values on <Model>.<Property>' -TestCases @(
        @{ Model = 'IDeliveryRuleEdgeActionParameters'; Property = 'InvocationPoint'; Values = @(
                'clientRequest', 'originRequest', 'originResponse', 'clientResponse',
                'ClientRequest', 'OriginRequest', 'ClientResponse') }
        @{ Model = 'ICdnWebApplicationFirewallPolicy'; Property = 'ProvisioningState'; Values = @(
                'Succeeded', 'Failed', 'Canceled', 'Provisioning', 'Upgrading') }
        @{ Model = 'ICdnWebApplicationFirewallPolicyProperties'; Property = 'ProvisioningState'; Values = @(
                'Succeeded', 'Failed', 'Canceled', 'Provisioning', 'Upgrading') }
    ) {
        param($Model, $Property, $Values)
        $type = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Cdn].Assembly.GetType(
            "Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.$Model", $true)
        $completer = $type.GetProperty($Property).GetCustomAttributes($false) |
            Where-Object { $_ -is [Microsoft.Azure.PowerShell.Cmdlets.Cdn.PSArgumentCompleterAttribute] }
        $actual = @($completer.ScriptBlock.Invoke('', '', '', $null, @{}) | ForEach-Object CompletionText)
        foreach ($value in $Values) {
            ($actual -ccontains $value) | Should Be $true
        }
        $actual.Count | Should Be $Values.Count
    }
}
