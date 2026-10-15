Describe 'AuthPolicy.Unit' {
    It 'Exports authentication policy CRUD and object helpers' {
        foreach ($name in @('Get-AzFrontDoorCdnAuthPolicy', 'New-AzFrontDoorCdnAuthPolicy',
                'Update-AzFrontDoorCdnAuthPolicy', 'Remove-AzFrontDoorCdnAuthPolicy',
                'New-AzFrontDoorCdnAuthPolicyEntraIdConfigObject',
                'New-AzFrontDoorCdnAuthPolicyAssociationObject')) {
            (Get-Command $name -Module Az.Cdn -ErrorAction Stop).Name | Should Be $name
        }
        foreach ($name in @('New-AzFrontDoorCdnAuthPolicy', 'Update-AzFrontDoorCdnAuthPolicy')) {
            foreach ($parameter in @('AuthConfig', 'Association', 'Action', 'ForwardTokenToOrigin')) {
                (Get-Command $name).Parameters.ContainsKey($parameter) | Should Be $true
            }
        }
    }

    It 'Serializes Entra ID configuration and preserves its discriminator on round-trip' {
        $config = New-AzFrontDoorCdnAuthPolicyEntraIdConfigObject -Issuer 'https://issuer.example/v2.0' `
            -Audience 'api://first', 'api://second' -AuthLocation Header -AuthLocationSelector Authorization
        $json = $config.ToJsonString() | ConvertFrom-Json
        $json.identityProvider | Should Be 'EntraID'
        $json.issuer | Should Be 'https://issuer.example/v2.0'
        $json.audiences.Count | Should Be 2
        $json.audiences[1] | Should Be 'api://second'
        $json.authLocation | Should Be 'Header'
        $json.authLocationSelector | Should Be 'Authorization'
        $policy = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.AuthPolicy]::new()
        $policy.AuthConfig = @($config)
        $roundTrip = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.AuthPolicy]::FromJsonString($policy.ToJsonString())
        ($roundTrip.AuthConfig[0] -is [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.AuthPolicyEntraIDConfig]) | Should Be $true
        $roundTrip.AuthConfig[0].Audience[1] | Should Be 'api://second'
    }

    It 'Serializes profile-level and domain/route associations without losing explicit false' {
        $profileAssociation = New-AzFrontDoorCdnAuthPolicyAssociationObject -IsProfileLevel $true
        ($profileAssociation.ToJsonString() | ConvertFrom-Json).isProfileLevel | Should Be $true
        $association = New-AzFrontDoorCdnAuthPolicyAssociationObject -IsProfileLevel:$false `
            -Domain @{ Id = '/profiles/offline/customDomains/domain' } `
            -Route @{ Id = '/profiles/offline/afdEndpoints/endpoint/routes/route' }
        $json = $association.ToJsonString() | ConvertFrom-Json
        $json.PSObject.Properties.Name -contains 'isProfileLevel' | Should Be $true
        $json.isProfileLevel | Should Be $false
        $json.domains[0].id | Should Be '/profiles/offline/customDomains/domain'
        $json.routes[0].id | Should Be '/profiles/offline/afdEndpoints/endpoint/routes/route'
        $omitted = New-AzFrontDoorCdnAuthPolicyAssociationObject
        ($omitted.ToJsonString() | ConvertFrom-Json).PSObject.Properties.Name -contains 'isProfileLevel' | Should Be $false
    }

    It 'Does not reset omitted properties in a partial update' {
        $update = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.AuthPolicyUpdateParameters]::new()
        $update.Action = 'Log'
        $json = $update.ToJsonString() | ConvertFrom-Json
        $json.properties.action | Should Be 'Log'
        foreach ($name in @('authConfigs', 'associations', 'forwardTokenToOrigin')) {
            $json.properties.PSObject.Properties.Name -contains $name | Should Be $false
        }
        $update.ForwardTokenToOrigin = $false
        $json = $update.ToJsonString() | ConvertFrom-Json
        $json.properties.PSObject.Properties.Name -contains 'forwardTokenToOrigin' | Should Be $true
        $json.properties.forwardTokenToOrigin | Should Be $false
    }

    It 'Uses the September contract for <Operation> with status <Status>' -TestCases @(
        @{ Operation = 'Create'; Method = 'PUT'; Status = 200 },
        @{ Operation = 'Create'; Method = 'PUT'; Status = 201 },
        @{ Operation = 'Create'; Method = 'PUT'; Status = 202 },
        @{ Operation = 'Update'; Method = 'PATCH'; Status = 200 },
        @{ Operation = 'Update'; Method = 'PATCH'; Status = 202 },
        @{ Operation = 'Get'; Method = 'GET'; Status = 200 },
        @{ Operation = 'List'; Method = 'GET'; Status = 200 },
        @{ Operation = 'Delete'; Method = 'DELETE'; Status = 200 },
        @{ Operation = 'Delete'; Method = 'DELETE'; Status = 204 },
        @{ Operation = 'Delete'; Method = 'DELETE'; Status = 202 }
    ) {
        param($Operation, $Method, $Status)
        $requests = [System.Collections.Generic.List[object]]::new()
        $policyJson = '{"id":"/subscriptions/offline/resourceGroups/offline/providers/Microsoft.Cdn/profiles/profile/authPolicies/policy","name":"policy","properties":{"authConfigs":[{"identityProvider":"EntraID","issuer":"https://issuer.example/v2.0","audiences":["api://first"],"authLocation":"Header","authLocationSelector":"Authorization"}],"associations":{"isProfileLevel":true},"action":"Block","forwardTokenToOrigin":false,"provisioningState":"Succeeded"}}'
        $send = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.SendAsync] {
            param($request, $callback)
            $callback.Token.ThrowIfCancellationRequested()
            if ($requests.Count -ge 6) { throw 'Unexpected authentication policy polling loop.' }
            $body = if ($request.Content) { $request.Content.ReadAsStringAsync().GetAwaiter().GetResult() }
            $requests.Add(@{ Method = $request.Method.Method; Uri = $request.RequestUri; Body = $body })
            $code = if ($requests.Count -eq 1) { $Status } else { 200 }
            $response = [System.Net.Http.HttpResponseMessage]::new([System.Net.HttpStatusCode]$code)
            $response.RequestMessage = $request
            if ($code -eq 202) {
                $pollUri = if ($Operation -eq 'Delete') {
                    'https://management.azure.com/subscriptions/offline/providers/Microsoft.Cdn/operationresults/offline?api-version=2026-09-01-preview'
                } else { $request.RequestUri.AbsoluteUri }
                $header = if ($Operation -eq 'Delete') { 'Azure-AsyncOperation' } else { 'Location' }
                $null = $response.Headers.TryAddWithoutValidation($header, $pollUri)
                $null = $response.Headers.TryAddWithoutValidation('Retry-After', '0')
            } elseif ($Operation -eq 'Delete' -and $requests.Count -gt 1) {
                $response.Content = [System.Net.Http.StringContent]::new('{"status":"Succeeded"}')
            } elseif ($Operation -ne 'Delete') {
                $responseJson = if ($Operation -eq 'List') { '{"value":[' + $policyJson + ']}' } else { $policyJson }
                $response.Content = [System.Net.Http.StringContent]::new($responseJson, [System.Text.Encoding]::UTF8, 'application/json')
            }
            return [System.Threading.Tasks.Task]::FromResult[System.Net.Http.HttpResponseMessage]($response)
        }
        $terminal = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.SendAsyncTerminalFactory]::new($send)
        $listener = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.EventListener]::new()
        $client = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Cdn]::new()
        if ($Operation -eq 'Create') {
            $policy = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.AuthPolicy]::FromJsonString($policyJson)
            $task = $client.AuthPoliciesCreateWithResult('offline', 'offline', 'profile', 'policy', $policy, $listener, $terminal)
        } elseif ($Operation -eq 'Update') {
            $policy = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.AuthPolicyUpdateParameters]::new()
            $policy.Action = 'Log'
            $policy.ForwardTokenToOrigin = $false
            $task = $client.AuthPoliciesUpdateWithResult('offline', 'offline', 'profile', 'policy', $policy, $listener, $terminal)
        } elseif ($Operation -eq 'Get') {
            $task = $client.AuthPoliciesGetWithResult('offline', 'offline', 'profile', 'policy', $listener, $terminal)
        } elseif ($Operation -eq 'List') {
            $task = $client.AuthPoliciesListByProfileWithResult('offline', 'offline', 'profile', $listener, $terminal)
        } else {
            $onSuccess = [System.Func[System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task]] {
                param($response)
                if (-not $response.IsSuccessStatusCode) { throw "Unexpected delete status: $($response.StatusCode)" }
                return [System.Threading.Tasks.Task]::CompletedTask
            }
            $onError = [System.Func[System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IErrorResponse], System.Threading.Tasks.Task]] {
                param($response, $errorBody)
                $serviceError = $errorBody.GetAwaiter().GetResult()
                throw "Unexpected delete failure: $($response.StatusCode), $($serviceError.Message)"
            }
            $task = $client.AuthPoliciesDelete('offline', 'offline', 'profile', 'policy', $onSuccess, $onSuccess, $onError, $listener, $terminal)
        }
        $result = $task.GetAwaiter().GetResult()
        $requests.Count | Should BeGreaterThan 0
        $requests[0].Method | Should Be $Method
        $expectedPath = '/subscriptions/offline/resourceGroups/offline/providers/Microsoft.Cdn/profiles/profile/authPolicies'
        if ($Operation -ne 'List') { $expectedPath += '/policy' }
        $requests[0].Uri.AbsolutePath | Should Be $expectedPath
        foreach ($request in $requests) {
            $request.Uri.Query | Should Match 'api-version=2026-09-01-preview'
        }
        if ($Status -eq 202) {
            $requests.Count | Should BeGreaterThan 1
            $requests[1].Method | Should Be 'GET'
        }
        if ($Operation -in @('Create', 'Update')) {
            $payload = $requests[0].Body | ConvertFrom-Json
            $payload.properties.forwardTokenToOrigin | Should Be $false
            foreach ($name in @('id', 'name', 'type')) {
                $payload.PSObject.Properties.Name -contains $name | Should Be $false
            }
            $payload.properties.PSObject.Properties.Name -contains 'provisioningState' | Should Be $false
            if ($Operation -eq 'Create') {
                $payload.properties.authConfigs[0].identityProvider | Should Be 'EntraID'
                $payload.properties.authConfigs[0].audiences[0] | Should Be 'api://first'
                $payload.properties.associations.isProfileLevel | Should Be $true
                $payload.properties.action | Should Be 'Block'
            } else {
                $payload.properties.action | Should Be 'Log'
                $payload.properties.PSObject.Properties.Name -contains 'authConfigs' | Should Be $false
                $payload.properties.PSObject.Properties.Name -contains 'associations' | Should Be $false
            }
        }
        if ($Operation -eq 'List') {
            $result.Value.Count | Should Be 1
            $result = $result.Value[0]
        }
        if ($Operation -ne 'Delete') {
            $result.Name | Should Be 'policy'
            ($result.AuthConfig[0] -is [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.AuthPolicyEntraIDConfig]) | Should Be $true
            $result.AuthConfig[0].Issuer | Should Be 'https://issuer.example/v2.0'
            $result.ForwardTokenToOrigin | Should Be $false
        }
    }

    It 'Propagates service errors instead of returning an empty policy' {
        $send = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.SendAsync] {
            param($request, $callback)
            $callback.Token.ThrowIfCancellationRequested()
            $response = [System.Net.Http.HttpResponseMessage]::new([System.Net.HttpStatusCode]::BadRequest)
            $response.RequestMessage = $request
            $response.Content = [System.Net.Http.StringContent]::new('{"error":{"code":"InvalidAuthPolicy","message":"Invalid issuer."}}')
            return [System.Threading.Tasks.Task]::FromResult[System.Net.Http.HttpResponseMessage]($response)
        }
        $terminal = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.SendAsyncTerminalFactory]::new($send)
        $listener = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.EventListener]::new()
        $client = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Cdn]::new()
        { $client.AuthPoliciesGetWithResult('offline', 'offline', 'profile', 'policy', $listener, $terminal).GetAwaiter().GetResult() } |
            Should Throw 'Invalid issuer'
    }
}
