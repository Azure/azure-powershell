$subscription = '00000000-0000-0000-0000-000000000000'
$root = "/subscriptions/$subscription/resourceGroups/test-rg/providers/Microsoft.NetworkSecurity/neuroShields/test-shield"
$child = "$root/protectedResources/test-vm"
$rootParameters = @{ SubscriptionId = $subscription; ResourceGroupName = 'test-rg'; Name = 'test-shield' }
$childParameters = @{ SubscriptionId = $subscription; ResourceGroupName = 'test-rg'; NeuroShieldName = 'test-shield'; ProtectedResourceName = 'test-vm' }
$findingParameters = $childParameters + @{ FindingId = 'test-finding' }
$mitigationParameters = $childParameters + @{ MitigationId = 'test-mitigation' }
$cases = @(
    @{ Operation = 'NeuroShields_Get'; Command = 'Get-AzNetworkSecurityNeuroShield'; Parameters = $rootParameters; Method = 'GET'; Path = $root }
    @{ Operation = 'NeuroShields_CreateOrUpdate'; Command = 'New-AzNetworkSecurityNeuroShield'; Parameters = ($rootParameters + @{ Location = 'westus2'; ResponseMode = 'Manual'; IfMatch = '"test-etag"' }); Method = 'PUT'; Path = $root }
    @{ Operation = 'NeuroShields_Update'; Command = 'Update-AzNetworkSecurityNeuroShield'; Parameters = ($rootParameters + @{ Description = 'Updated'; IfMatch = '"test-etag"' }); Method = 'PATCH'; Path = $root }
    @{ Operation = 'NeuroShields_Delete'; Command = 'Remove-AzNetworkSecurityNeuroShield'; Parameters = $rootParameters; Method = 'DELETE'; Path = $root }
    @{ Operation = 'NeuroShields_ListByResourceGroup'; Command = 'Get-AzNetworkSecurityNeuroShield'; Parameters = @{ SubscriptionId = $subscription; ResourceGroupName = 'test-rg' }; Method = 'GET'; Path = "/subscriptions/$subscription/resourceGroups/test-rg/providers/Microsoft.NetworkSecurity/neuroShields" }
    @{ Operation = 'NeuroShields_ListBySubscription'; Command = 'Get-AzNetworkSecurityNeuroShield'; Parameters = @{ SubscriptionId = $subscription }; Method = 'GET'; Path = "/subscriptions/$subscription/providers/Microsoft.NetworkSecurity/neuroShields" }
    @{ Operation = 'NeuroShieldProtectedResources_Get'; Command = 'Get-AzNetworkSecurityNeuroShieldProtectedResource'; Parameters = $childParameters; Method = 'GET'; Path = $child }
    @{ Operation = 'NeuroShieldProtectedResources_CreateOrUpdate'; Command = 'New-AzNetworkSecurityNeuroShieldProtectedResource'; Parameters = ($childParameters + @{ TargetResourceId = "/subscriptions/$subscription/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm"; TargetIdentityType = 'SystemAssigned'; TargetIdentityPrincipalId = '11111111-1111-1111-1111-111111111111'; TargetIdentityTenantId = '22222222-2222-2222-2222-222222222222'; IfMatch = '"test-etag"' }); Method = 'PUT'; Path = $child }
    @{ Operation = 'NeuroShieldProtectedResources_Delete'; Command = 'Remove-AzNetworkSecurityNeuroShieldProtectedResource'; Parameters = ($childParameters + @{ IfMatch = '"test-etag"' }); Method = 'DELETE'; Path = $child }
    @{ Operation = 'NeuroShieldProtectedResources_List'; Command = 'Get-AzNetworkSecurityNeuroShieldProtectedResource'; Parameters = @{ SubscriptionId = $subscription; ResourceGroupName = 'test-rg'; NeuroShieldName = 'test-shield' }; Method = 'GET'; Path = "$root/protectedResources" }
    @{ Operation = 'NeuroShieldProtectedResources_TriggerInventoryUpload'; Command = 'Invoke-AzNetworkSecurityNeuroShieldProtectedResourceInventoryUpload'; Parameters = $childParameters; Method = 'POST'; Path = "$child/triggerInventoryUpload" }
    @{ Operation = 'NeuroShieldFindings_Get'; Command = 'Get-AzNetworkSecurityNeuroShieldFinding'; Parameters = $findingParameters; Method = 'GET'; Path = "$child/findings/test-finding" }
    @{ Operation = 'NeuroShieldFindings_List'; Command = 'Get-AzNetworkSecurityNeuroShieldFinding'; Parameters = $childParameters; Method = 'GET'; Path = "$child/findings" }
    @{ Operation = 'NeuroShieldFindings_ListByNeuroShield'; Command = 'Get-AzNetworkSecurityNeuroShieldFinding'; Parameters = @{ SubscriptionId = $subscription; ResourceGroupName = 'test-rg'; NeuroShieldName = 'test-shield' }; Method = 'GET'; Path = "$root/findings" }
    @{ Operation = 'NeuroShieldFindings_Mitigate'; Command = 'Invoke-AzNetworkSecurityNeuroShieldFindingMitigation'; Parameters = $findingParameters; Method = 'POST'; Path = "$child/findings/test-finding/mitigate" }
    @{ Operation = 'NeuroShieldFindings_Rollback'; Command = 'Invoke-AzNetworkSecurityNeuroShieldFindingRollback'; Parameters = $findingParameters; Method = 'POST'; Path = "$child/findings/test-finding/rollback" }
    @{ Operation = 'NeuroShieldMitigations_Get'; Command = 'Get-AzNetworkSecurityNeuroShieldMitigation'; Parameters = $mitigationParameters; Method = 'GET'; Path = "$child/mitigations/test-mitigation" }
    @{ Operation = 'NeuroShieldMitigations_List'; Command = 'Get-AzNetworkSecurityNeuroShieldMitigation'; Parameters = $childParameters; Method = 'GET'; Path = "$child/mitigations" }
    @{ Operation = 'NeuroShieldMitigations_ListByNeuroShield'; Command = 'Get-AzNetworkSecurityNeuroShieldMitigation'; Parameters = @{ SubscriptionId = $subscription; ResourceGroupName = 'test-rg'; NeuroShieldName = 'test-shield' }; Method = 'GET'; Path = "$root/mitigations" }
    @{ Operation = 'NeuroShieldMitigations_Execute'; Command = 'Invoke-AzNetworkSecurityNeuroShieldMitigationExecution'; Parameters = $mitigationParameters; Method = 'POST'; Path = "$child/mitigations/test-mitigation/execute" }
    @{ Operation = 'NeuroShieldMitigations_Rollback'; Command = 'Invoke-AzNetworkSecurityNeuroShieldMitigationRollback'; Parameters = $mitigationParameters; Method = 'POST'; Path = "$child/mitigations/test-mitigation/rollback" }
    @{ Operation = 'NeuroShieldSummaries_Get'; Command = 'Get-AzNetworkSecurityNeuroShieldSummary'; Parameters = @{ SubscriptionId = $subscription; ResourceGroupName = 'test-rg'; NeuroShieldName = 'test-shield' }; Method = 'GET'; Path = "$root/summary/default" }
    @{ Operation = 'NeuroShieldSummaries_List'; Command = 'Get-AzNetworkSecurityNeuroShieldSummary'; Parameters = @{ SubscriptionId = $subscription; ResourceGroupName = 'test-rg'; NeuroShieldName = 'test-shield'; Top = 50 }; Method = 'GET'; Path = "$root/summary" }
    @{ Operation = 'NeuroShieldOperationStatuses_Get'; Command = 'Get-AzNetworkSecurityNeuroShieldOperationStatus'; Parameters = @{ SubscriptionId = $subscription; Location = 'westus2'; OperationId = '33333333-3333-3333-3333-333333333333' }; Method = 'GET'; Path = "/subscriptions/$subscription/providers/Microsoft.NetworkSecurity/locations/westus2/neuroShieldOperationStatuses/33333333-3333-3333-3333-333333333333" }
    @{ Operation = 'Operations_List'; Command = 'Get-AzNetworkSecurityOperation'; Parameters = @{}; Method = 'GET'; Path = '/providers/Microsoft.NetworkSecurity/operations' }
)

function Invoke-NetworkSecurityTransportTest {
    param([Parameter(Mandatory)][string] $CmdletName)

    $commandCases = @($cases | Where-Object Command -EQ $CmdletName)
    if (-not $commandCases.Count) { throw "No HTTP-contract cases found for $CmdletName." }

    Describe $CmdletName {
        BeforeEach {
            $script:networkSecurityRequests = [System.Collections.Generic.List[object]]::new()
            $script:networkSecurityResponses = [System.Collections.Generic.Queue[object]]::new()
            $script:networkSecurityResponses.Enqueue(@{ Status = 200; Body = '{"value":[],"properties":{"provisioningState":"Succeeded"},"status":"Succeeded"}' })
            $script:networkSecurityOffline = [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Runtime.PipelineMock]::new((Join-Path $TestDrive 'unused.json'))
            $script:networkSecurityOffline.SetPlayback()
            # The generated proxy recognizes playback for offline authentication; the outer hook supplies unit-test responses.
            $script:networkSecurityTransport = [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Runtime.SendAsyncStep] {
                param($request, $callback, $next)
                $headers = @{}
                foreach ($header in $request.Headers) { $headers[$header.Key] = $header.Value -join ',' }
                $body = if ($request.Content) { $request.Content.ReadAsStringAsync().GetAwaiter().GetResult() } else { $null }
                $script:networkSecurityRequests.Add(@{ Method = $request.Method.Method; Uri = $request.RequestUri; Body = $body; Headers = $headers })
                $mockResponse = $script:networkSecurityResponses.Dequeue()
                $response = [System.Net.Http.HttpResponseMessage]::new($mockResponse.Status)
                $response.RequestMessage = $request
                $response.Content = [System.Net.Http.StringContent]::new($mockResponse.Body, [System.Text.Encoding]::UTF8, 'application/json')
                return [System.Threading.Tasks.Task]::FromResult($response)
            }
        }

        It 'routes <Operation> through <Command>' -TestCases $commandCases {
            param($Operation, $Command, $Parameters, $Method, $Path)
            $arguments = $Parameters.Clone()
            if ((Get-Command $Command).Parameters.ContainsKey('Confirm')) { $arguments.Confirm = $false }
            if ((Get-Command $Command).Parameters.ContainsKey('NoWait')) { $arguments.NoWait = $true }
            & $Command @arguments -HttpPipelinePrepend @($script:networkSecurityOffline, $script:networkSecurityTransport) -ErrorAction Stop | Out-Null
            $script:networkSecurityRequests.Count | Should -Be 1
            $request = $script:networkSecurityRequests[0]
            $request.Method | Should -Be $Method
            $request.Uri.AbsolutePath | Should -Be $Path
            $request.Uri.Query | Should -Match 'api-version=2026-10-01-preview'
            if ($Parameters.ContainsKey('IfMatch')) { $request.Headers['If-Match'] | Should -Be '"test-etag"' }
            if ($Operation -eq 'NeuroShields_Update') {
                $body = $request.Body | ConvertFrom-Json
                $body.properties.description | Should -Be 'Updated'
                $body.properties.PSObject.Properties.Name | Should -Not -Contain 'responseMode'
                $body.properties.PSObject.Properties.Name | Should -Not -Contain 'severityThreshold'
                $body.PSObject.Properties.Name | Should -Not -Contain 'tags'
            }
            if ($Operation -eq 'NeuroShieldProtectedResources_CreateOrUpdate') {
                $body = $request.Body | ConvertFrom-Json
                $body.properties.targetIdentity.type | Should -Be 'SystemAssigned'
                $body.properties.targetIdentity.principalId | Should -Be $Parameters.TargetIdentityPrincipalId
                $body.properties.targetIdentity.tenantId | Should -Be $Parameters.TargetIdentityTenantId
                $body.properties.targetResourceId | Should -Be $Parameters.TargetResourceId
            }
        }

        if ($CmdletName -eq 'Get-AzNetworkSecurityOperation') {
            It 'follows operation catalog nextLink and returns both pages' {
                $script:networkSecurityResponses.Clear()
                $script:networkSecurityResponses.Enqueue(@{ Status = 200; Body = '{"value":[{"name":"first/read"}],"nextLink":"https://management.azure.com/providers/Microsoft.NetworkSecurity/operations?api-version=2026-10-01-preview&$skiptoken=next"}' })
                $script:networkSecurityResponses.Enqueue(@{ Status = 200; Body = '{"value":[{"name":"second/read"}]}' })
                $items = @(Get-AzNetworkSecurityOperation -HttpPipelinePrepend @($script:networkSecurityOffline, $script:networkSecurityTransport) -ErrorAction Stop)
                $items.Name | Should -Be @('first/read', 'second/read')
                $script:networkSecurityRequests.Count | Should -Be 2
                $script:networkSecurityRequests[1].Uri.Query | Should -Match '\$skiptoken=next'
            }

            It 'surfaces operation catalog service errors' {
                $script:networkSecurityResponses.Clear()
                $script:networkSecurityResponses.Enqueue(@{ Status = 400; Body = '{"error":{"code":"InvalidRequest","message":"Catalog request rejected"}}' })
                { Get-AzNetworkSecurityOperation -HttpPipelinePrepend @($script:networkSecurityOffline, $script:networkSecurityTransport) -ErrorAction Stop } | Should -Throw 'Catalog request rejected'
            }
        }
    }
}
