Describe 'Private Traffic Manager model contracts' {
    BeforeAll {
        $modulePath = Join-Path $PSScriptRoot '../Az.PrivateTrafficManager.psd1'
        if (-not (Test-Path $modulePath)) {
            $modulePath = Join-Path $PSScriptRoot '../../../../artifacts/Debug/Az.PrivateTrafficManager/PrivateTrafficManager.Autorest/Az.PrivateTrafficManager.psd1'
        }
        Import-Module $modulePath -Force -ErrorAction Stop
    }

    It 'Round-trips probe configuration without the obsolete nested name' {
        $payload = '{"kind":"Probe","properties":{"probeConfig":{"protocol":"HTTPS","port":443,"path":"/health","intervalInSeconds":30,"timeoutInSeconds":10,"toleratedNumberOfFailures":3,"customHeaders":[{"name":"X-Probe","value":"ready"}],"expectedStatusCodeRanges":[{"min":200,"max":299}]}}}'
        $policy = [Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.HealthPolicy]::FromJsonString($payload)
        $policy.GetType().Name | Should -Be 'ProbeHealthPolicy'
        $policy.ProbeConfigProtocol | Should -Be 'HTTPS'
        $policy.ProbeConfigPort | Should -Be 443
        $policy.ProbeConfigPath = '/ready'
        $json = $policy.ToJsonString() | ConvertFrom-Json
        $json.kind | Should -Be 'Probe'
        $json.properties.PSObject.Properties.Name | Should -Not -Contain 'name'
        $json.properties.probeConfig.path | Should -Be '/ready'
        $json.properties.probeConfig.protocol | Should -Be 'HTTPS'
        $json.properties.probeConfig.port | Should -Be 443
        $json.properties.probeConfig.intervalInSeconds | Should -Be 30
        $json.properties.probeConfig.timeoutInSeconds | Should -Be 10
        $json.properties.probeConfig.toleratedNumberOfFailures | Should -Be 3
        $json.properties.probeConfig.customHeaders[0].name | Should -Be 'X-Probe'
        $json.properties.probeConfig.customHeaders[0].value | Should -Be 'ready'
        $json.properties.probeConfig.expectedStatusCodeRanges[0].min | Should -Be 200
        $json.properties.probeConfig.expectedStatusCodeRanges[0].max | Should -Be 299
    }

    It 'Round-trips VNet routing and the current topology mode' {
        $profile = [Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.PrivateTrafficManagerProfile]::FromJsonString('{"location":"global","properties":{"customTopologyMapMode":"Disabled","trafficRoutingMethod":"VNet","dnsConfig":{"recordType":"A","ttl":0}}}')
        $json = $profile.ToJsonString() | ConvertFrom-Json
        $json.properties.customTopologyMapMode | Should -Be 'Disabled'
        $json.properties.trafficRoutingMethod | Should -Be 'VNet'
        $json.properties.dnsConfig.ttl | Should -Be 0
        $json.properties.PSObject.Properties.Name | Should -Not -Contain 'customTopologyMap'
    }

    It 'Round-trips endpoint virtual network assignments' {
        $networkId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/network'
        $endpoint = [Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.Endpoint]::FromJsonString((@{ properties = @{ target = '10.0.0.4'; virtualNetworkIds = @($networkId) } } | ConvertTo-Json -Depth 4))
        $json = $endpoint.ToJsonString() | ConvertFrom-Json
        $json.properties.target | Should -Be '10.0.0.4'
        @($json.properties.virtualNetworkIds).Count | Should -Be 1
        $json.properties.virtualNetworkIds[0] | Should -Be $networkId
    }

    It 'Round-trips the gateway resource reference in a profile association' {
        $gatewayId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/probingGateways/gateway'
        $association = [Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.ProfileProbingGateway]::FromJsonString((@{ properties = @{ probingGatewayId = $gatewayId } } | ConvertTo-Json))
        $json = $association.ToJsonString() | ConvertFrom-Json
        $json.properties.probingGatewayId | Should -Be $gatewayId
    }

    It 'Sends <method> to the profile gateway association for <verb>' -TestCases @(
        @{ verb = 'New'; method = 'PUT'; requestCount = 3 },
        @{ verb = 'Update'; method = 'PATCH'; requestCount = 1 },
        @{ verb = 'Get'; method = 'GET'; requestCount = 1 },
        @{ verb = 'Remove'; method = 'DELETE'; requestCount = 1 }
    ) {
        param($verb, $method, $requestCount)
        $gatewayId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/probingGateways/gateway'
        $requests = [System.Collections.Generic.List[object]]::new()
        $responses = [System.Collections.Generic.List[System.Net.Http.HttpResponseMessage]]::new()
        $payload = @{ name = 'association'; properties = @{ probingGatewayId = $gatewayId; provisioningState = 'Succeeded' } } | ConvertTo-Json
        $pipeline = [Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Runtime.SendAsyncStep] {
            param($request, $callback, $next)
            $body = if ($request.Content) { $request.Content.ReadAsStringAsync().GetAwaiter().GetResult() } else { $null }
            $requests.Add(@{ Method = $request.Method.Method; Uri = $request.RequestUri; Body = $body })
            $status = if ($request.Method.Method -eq 'DELETE') { [System.Net.HttpStatusCode]::NoContent } else { [System.Net.HttpStatusCode]::OK }
            $response = [System.Net.Http.HttpResponseMessage]::new($status)
            $response.Content = [System.Net.Http.StringContent]::new($payload, [System.Text.Encoding]::UTF8, 'application/json')
            $response.Headers.Add('Retry-After', '0')
            $responses.Add($response)
            return [System.Threading.Tasks.Task[System.Net.Http.HttpResponseMessage]]::FromResult($response)
        }.GetNewClosure()
        $module = [Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Module]::Instance
        $onNewRequest = $module.OnNewRequest
        try {
            $module.OnNewRequest = $null
            $parameters = @{
                Name = 'association'
                PrivateTrafficManagerProfileName = 'profile'
                ResourceGroupName = 'test-rg'
                SubscriptionId = '00000000-0000-0000-0000-000000000000'
                HttpPipelinePrepend = $pipeline
                ErrorAction = 'Stop'
            }
            if ($verb -in @('New', 'Update')) {
                $parameters.ProbingGatewayId = $gatewayId
            }
            if ($verb -ne 'Get') {
                $parameters.Confirm = $false
            }
            $result = & "$verb-AzPrivateTrafficManagerProfileProbingGateway" @parameters
            $requests.Count | Should -Be $requestCount
            $requests[0].Method | Should -Be $method
            $requests[0].Uri.PathAndQuery | Should -Be '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/privateTrafficManagerProfiles/profile/probingGateways/association?api-version=2026-10-01-preview'
            if ($verb -in @('New', 'Update')) {
                $body = $requests[0].Body | ConvertFrom-Json
                $body.properties.probingGatewayId | Should -Be $gatewayId
                $body.properties.PSObject.Properties.Name | Should -Not -Contain 'provisioningState'
            }
            if ($verb -ne 'Remove') {
                $result.Name | Should -Be 'association'
                $result.ProbingGatewayId | Should -Be $gatewayId
            }
        }
        finally {
            $module.OnNewRequest = $onNewRequest
            foreach ($response in $responses) {
                $response.Dispose()
            }
        }
    }

    It 'Updates a health policy with GET then PUT while preserving unbound probe fields' {
        $requests = [System.Collections.Generic.List[object]]::new()
        $responses = [System.Collections.Generic.List[System.Net.Http.HttpResponseMessage]]::new()
        $payload = '{"name":"policy","kind":"Probe","properties":{"provisioningState":"Succeeded","probeConfig":{"protocol":"HTTPS","port":443,"path":"/health","intervalInSeconds":30,"timeoutInSeconds":10,"toleratedNumberOfFailures":3,"customHeaders":[{"name":"X-Probe","value":"ready"}],"expectedStatusCodeRanges":[{"min":200,"max":299}]}}}'
        $pipeline = [Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Runtime.SendAsyncStep] {
            param($request, $callback, $next)
            $body = if ($request.Content) { $request.Content.ReadAsStringAsync().GetAwaiter().GetResult() } else { $null }
            $requests.Add(@{ Method = $request.Method.Method; Uri = $request.RequestUri; Body = $body })
            $response = [System.Net.Http.HttpResponseMessage]::new([System.Net.HttpStatusCode]::OK)
            $response.Content = [System.Net.Http.StringContent]::new($payload, [System.Text.Encoding]::UTF8, 'application/json')
            $response.Headers.Add('Retry-After', '0')
            $responses.Add($response)
            return [System.Threading.Tasks.Task[System.Net.Http.HttpResponseMessage]]::FromResult($response)
        }.GetNewClosure()
        $module = [Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Module]::Instance
        $onNewRequest = $module.OnNewRequest
        try {
            $module.OnNewRequest = $null
            $null = Update-AzPrivateTrafficManagerHealthPolicy -Name 'policy' -PrivateTrafficManagerProfileName 'profile' -ResourceGroupName 'test-rg' -SubscriptionId '00000000-0000-0000-0000-000000000000' -ProbeConfigPath '/ready' -HttpPipelinePrepend $pipeline -Confirm:$false -ErrorAction Stop
            $requests.Count | Should -Be 4
            $requests[0].Method | Should -Be 'GET'
            $requests[1].Method | Should -Be 'PUT'
            $requests[2].Method | Should -Be 'GET'
            $requests[3].Method | Should -Be 'GET'
            $requests[0].Uri.PathAndQuery | Should -Be '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/privateTrafficManagerProfiles/profile/healthPolicies/policy?api-version=2026-10-01-preview'
            $requests[1].Uri | Should -Be $requests[0].Uri
            $body = $requests[1].Body | ConvertFrom-Json
            $body.kind | Should -Be 'Probe'
            $body.properties.probeConfig.path | Should -Be '/ready'
            $body.properties.probeConfig.protocol | Should -Be 'HTTPS'
            $body.properties.probeConfig.port | Should -Be 443
            $body.properties.probeConfig.intervalInSeconds | Should -Be 30
            $body.properties.probeConfig.timeoutInSeconds | Should -Be 10
            $body.properties.probeConfig.toleratedNumberOfFailures | Should -Be 3
            $body.properties.probeConfig.customHeaders[0].value | Should -Be 'ready'
            $body.properties.probeConfig.expectedStatusCodeRanges[0].max | Should -Be 299
            $body.properties.PSObject.Properties.Name | Should -Not -Contain 'name'
        }
        finally {
            $module.OnNewRequest = $onNewRequest
            foreach ($response in $responses) {
                $response.Dispose()
            }
        }
    }
}