Describe 'EdgeAction.Unit' {
    function Invoke-EdgeActionOfflineCmdlet {
        param(
            [string]$Command,
            [hashtable]$Parameters,
            [System.Net.HttpStatusCode]$Status = [System.Net.HttpStatusCode]::OK
        )

        $responseStatus = $Status
        $requests = [System.Collections.Generic.List[object]]::new()
        $step = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.SendAsyncStep] {
            param($request, $callback)
            $callback.Token.ThrowIfCancellationRequested()
            $body = if ($request.Content) { $request.Content.ReadAsStringAsync().GetAwaiter().GetResult() }
            $requests.Add(@{ Method = $request.Method.Method; Uri = $request.RequestUri; Body = $body })
            $response = [System.Net.Http.HttpResponseMessage]::new($responseStatus)
            $response.Headers.RetryAfter = [System.Net.Http.Headers.RetryConditionHeaderValue]::new([TimeSpan]::Zero)
            $response.Content = [System.Net.Http.StringContent]::new(
                '{"properties":{"provisioningState":"Succeeded"}}', [System.Text.Encoding]::UTF8, 'application/json')
            if ($responseStatus -eq [System.Net.HttpStatusCode]::Accepted) {
                $response.Headers.Location = $request.RequestUri
            }
            $response.RequestMessage = $request
            return [System.Threading.Tasks.Task]::FromResult[System.Net.Http.HttpResponseMessage]($response)
        }
        $output = @(& $Command @Parameters -HttpPipelinePrepend $step -Confirm:$false `
                -WarningVariable warningMessages -WarningAction SilentlyContinue -ErrorAction Stop)
        return @{ Requests = $requests; Output = $output; Warnings = @($warningMessages) }
    }

    function Invoke-EdgeActionOfflineRequest {
        param(
            [string]$Operation,
            [string]$Form,
            [string]$Identity,
            [switch]$LongRunning,
            [switch]$AsyncOnly,
            [switch]$CaptureResult,
            [ValidateSet('Succeeded', 'Failed')]
            [string]$PollingState = 'Succeeded'
        )

        $isLongRunning = $LongRunning.IsPresent
        $requests = [System.Collections.Generic.List[object]]::new()
        $send = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.SendAsync] {
            param($request, $callback)
            $callback.Token.ThrowIfCancellationRequested()
            $body = if ($request.Content) { $request.Content.ReadAsStringAsync().GetAwaiter().GetResult() }
            $requests.Add(@{ Method = $request.Method.Method; Uri = $request.RequestUri; Body = $body })
            $status = if ($isLongRunning -and $requests.Count -eq 1) {
                [System.Net.HttpStatusCode]::Accepted
            } elseif ($Operation -match 'Delete$|SwapDefault$' -and -not $isLongRunning) {
                [System.Net.HttpStatusCode]::NoContent
            } else {
                [System.Net.HttpStatusCode]::OK
            }
            $response = [System.Net.Http.HttpResponseMessage]::new($status)
            $json = '{"name":"offline","value":[],"properties":{"provisioningState":"Succeeded","isDefaultVersion":"True"}}'
            if ($AsyncOnly -and $requests.Count -gt 1 -and $request.RequestUri.AbsolutePath -eq '/operationStatuses/offline') {
                $json = '{"status":"' + $PollingState + '","error":{"code":"OfflineFailure","message":"offline failure"}}'
            }
            $response.Content = [System.Net.Http.StringContent]::new($json, [System.Text.Encoding]::UTF8, 'application/json')
            $response.Headers.RetryAfter = [System.Net.Http.Headers.RetryConditionHeaderValue]::new([TimeSpan]::Zero)
            if ($AsyncOnly) {
                if ($requests.Count -eq 1) {
                    $null = $response.Headers.TryAddWithoutValidation('Azure-AsyncOperation',
                        'https://management.azure.com/operationStatuses/offline?api-version=2026-10-01')
                }
            } else {
                $response.Headers.Location = $request.RequestUri
            }
            $response.RequestMessage = $request
            return [System.Threading.Tasks.Task]::FromResult[System.Net.Http.HttpResponseMessage]($response)
        }
        $terminal = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.SendAsyncTerminalFactory]::new($send)
        $listener = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.EventListener]::new()
        $client = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Cdn]::new()
        $suffix = switch ($Form) {
            'Identity' { 'ViaIdentity' }
            'Json' { 'ViaJsonString' }
            default { '' }
        }
        $method = $client.GetType().GetMethod("${Operation}${suffix}WithResult")
        if (-not $method) { $method = $client.GetType().GetMethod("${Operation}${suffix}") }
        if (-not $method) { throw "Missing client method for $Operation ($Form)." }
        $arguments = foreach ($parameter in $method.GetParameters()) {
            switch ($parameter.Name) {
                'subscriptionId' { '00000000-0000-0000-0000-000000000000' }
                'viaIdentity' { $Identity }
                'jsonString' { '{"ignored":true}' }
                'body' {
                    $typeName = $parameter.ParameterType.FullName -replace '\.I([^.]*)$', '.$1'
                    $model = [System.Activator]::CreateInstance($client.GetType().Assembly.GetType($typeName, $true))
                    if ($model.PSObject.Properties['ProvisioningState']) { $model.ProvisioningState = 'Succeeded' }
                    if ($model.PSObject.Properties['AttachedResourceId']) {
                        $model.AttachedResourceId = '/subscriptions/offline/resourceGroups/offline/providers/Microsoft.Cdn/profiles/offline'
                    }
                    ,$model
                }
                'eventListener' { ,$listener }
                'sender' { ,$terminal }
                { $_ -in 'onOk', 'onNoContent' } {
                    [System.Func[System.Net.Http.HttpResponseMessage, System.Threading.Tasks.Task]] {
                        param($response)
                        if (-not $response.IsSuccessStatusCode) { throw 'Unexpected failure response.' }
                        return [System.Threading.Tasks.Task]::CompletedTask
                    }
                }
                'onDefault' {
                    [System.Func[System.Net.Http.HttpResponseMessage,
                        System.Threading.Tasks.Task[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IErrorResponse],
                        System.Threading.Tasks.Task]] {
                        param($response, $errorBody)
                        throw "Unexpected HTTP status $($response.StatusCode): $($errorBody.GetAwaiter().GetResult())"
                    }
                }
                default {
                    if ($parameter.HasDefaultValue) { $parameter.DefaultValue }
                    elseif ($parameter.ParameterType -eq [string]) { 'offline' }
                    else { throw "Unexpected parameter $($parameter.Name) in $($method.Name)." }
                }
            }
        }
        $task = $method.Invoke($client, [object[]]$arguments)
        $result = $task.GetAwaiter().GetResult()
        if ($CaptureResult) { return @{ Requests = $requests; Value = $result } }
        return ,$requests
    }

    $subscription = '/subscriptions/00000000-0000-0000-0000-000000000000'
    $group = "$subscription/resourceGroups/offline"
    $action = "$group/providers/Microsoft.Cdn/edgeActions/offline"
    $version = "$action/versions/offline"
    $filter = "$action/executionFilters/offline"
    $operations = @(
        @{ Operation = 'EdgeActionsListBySubscription'; Method = 'GET'; Identity = $subscription; Path = "$subscription/providers/Microsoft.Cdn/edgeActions" }
        @{ Operation = 'EdgeActionsListByResourceGroup'; Method = 'GET'; Identity = $group; Path = "$group/providers/Microsoft.Cdn/edgeActions" }
        @{ Operation = 'EdgeActionsGet'; Method = 'GET'; Identity = $action; Path = $action }
        @{ Operation = 'EdgeActionsCreate'; Method = 'PUT'; Identity = $action; Path = $action; HasBody = $true }
        @{ Operation = 'EdgeActionsUpdate'; Method = 'PATCH'; Identity = $action; Path = $action; HasBody = $true }
        @{ Operation = 'EdgeActionsDelete'; Method = 'DELETE'; Identity = $action; Path = $action }
        @{ Operation = 'EdgeActionExecutionFiltersListByEdgeAction'; Method = 'GET'; Identity = $action; Path = "$action/executionFilters" }
        @{ Operation = 'EdgeActionExecutionFiltersGet'; Method = 'GET'; Identity = $filter; Path = $filter }
        @{ Operation = 'EdgeActionExecutionFiltersCreate'; Method = 'PUT'; Identity = $filter; Path = $filter; HasBody = $true }
        @{ Operation = 'EdgeActionExecutionFiltersUpdate'; Method = 'PATCH'; Identity = $filter; Path = $filter; HasBody = $true }
        @{ Operation = 'EdgeActionExecutionFiltersDelete'; Method = 'DELETE'; Identity = $filter; Path = $filter }
        @{ Operation = 'EdgeActionVersionsListByEdgeAction'; Method = 'GET'; Identity = $action; Path = "$action/versions" }
        @{ Operation = 'EdgeActionVersionsGet'; Method = 'GET'; Identity = $version; Path = $version }
        @{ Operation = 'EdgeActionVersionsCreate'; Method = 'PUT'; Identity = $version; Path = $version; HasBody = $true }
        @{ Operation = 'EdgeActionVersionsUpdate'; Method = 'PATCH'; Identity = $version; Path = $version; HasBody = $true }
        @{ Operation = 'EdgeActionVersionsDelete'; Method = 'DELETE'; Identity = $version; Path = $version }
        @{ Operation = 'EdgeActionVersionsDeployVersionCode'; Method = 'POST'; Identity = $version; Path = "$version/deployVersionCode"; HasBody = $true }
        @{ Operation = 'EdgeActionVersionsGetVersionCode'; Method = 'POST'; Identity = $version; Path = "$version/getVersionCode"; HasBody = $true }
        @{ Operation = 'EdgeActionVersionsSwapDefault'; Method = 'POST'; Identity = $version; Path = "$version/swapDefault" }
        @{ Operation = 'EdgeActionsAddAttachment'; Method = 'POST'; Identity = $action; Path = "$action/addAttachment"; HasBody = $true; Legacy = $true }
        @{ Operation = 'EdgeActionsDeleteAttachment'; Method = 'POST'; Identity = $action; Path = "$action/deleteAttachment"; HasBody = $true; Legacy = $true }
    )
    $cases = foreach ($operation in $operations) {
        $forms = @('Named', 'Identity')
        if ($operation.HasBody) { $forms += 'Json' }
        foreach ($form in $forms) {
            $case = @{} + $operation
            if ($operation.Operation -match 'ListBy') { $case.Identity = $operation.Path }
            $case.Form = $form
            $case.ApiVersion = if ($operation.Legacy) { '2024-07-22-preview' } else { '2026-10-01' }
            $case
        }
    }

    It 'Uses the correct contract for <Operation> (<Form>)' -TestCases $cases {
        param($Operation, $Method, $Identity, $Path, $HasBody, $Legacy, $Form, $ApiVersion)
        $requests = Invoke-EdgeActionOfflineRequest -Operation $Operation -Form $Form -Identity $Identity
        $requests.Count | Should BeGreaterThan 0
        $requests[0].Method | Should Be $Method
        $requests[0].Uri.AbsolutePath | Should Be $Path
        foreach ($request in $requests) {
            $request.Uri.Query | Should Be "?api-version=$ApiVersion"
        }
        if ($Operation -eq 'EdgeActionVersionsGetVersionCode' -or -not $HasBody) {
            $requests[0].Body | Should BeNullOrEmpty
        } else {
            $requests[0].Body | Should Not BeNullOrEmpty
            if ($Form -ne 'Json' -and -not $Legacy) {
                $requests[0].Body | Should Not Match '"provisioningState"'
            }
        }
        if ($Legacy -and $Form -ne 'Json') {
            ($requests[0].Body | ConvertFrom-Json).attachedResourceId | Should Match '/profiles/offline$'
        }
    }

    It 'Retains provisioningState in <Model> output but not typed requests' -TestCases @(
        @{ Model = 'EdgeAction' }
        @{ Model = 'EdgeActionVersion' }
        @{ Model = 'EdgeActionExecutionFilter' }
    ) {
        param($Model)
        $type = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Cdn].Assembly.GetType(
            "Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.$Model", $true)
        $modelObject = [System.Activator]::CreateInstance($type)
        $modelObject.ProvisioningState = 'Succeeded'
        ($modelObject.ToJsonString() | ConvertFrom-Json).properties.provisioningState | Should Be 'Succeeded'
        $mode = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.SerializationMode]::IncludeCreate -bor
            [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.SerializationMode]::IncludeUpdate
        $modelObject.ToJson($null, $mode).ToString() | Should Not Match '"provisioningState"'
    }

    It 'Polls swapDefault through Location for <Form> requests' -TestCases @(
        @{ Form = 'Named' }
        @{ Form = 'Identity' }
    ) {
        param($Form)
        $requests = Invoke-EdgeActionOfflineRequest -Operation EdgeActionVersionsSwapDefault `
            -Form $Form -Identity $version -LongRunning
        $requests.Count | Should BeGreaterThan 1
        $requests[0].Method | Should Be 'POST'
        foreach ($request in @($requests | Select-Object -Skip 1)) {
            $request.Method | Should Be 'GET'
            $request.Uri.AbsolutePath | Should Be "$version/swapDefault"
            $request.Uri.Query | Should Be '?api-version=2026-10-01'
            $request.Body | Should BeNullOrEmpty
        }
    }

    It 'Completes swapDefault using only Azure-AsyncOperation for <Form> requests' -TestCases @(
        @{ Form = 'Named' }
        @{ Form = 'Identity' }
    ) {
        param($Form)
        $requests = Invoke-EdgeActionOfflineRequest -Operation EdgeActionVersionsSwapDefault `
            -Form $Form -Identity $version -LongRunning -AsyncOnly
        $requests.Count | Should Be 2
        $requests[0].Method | Should Be 'POST'
        $requests[1].Method | Should Be 'GET'
        $requests[1].Uri.AbsolutePath | Should Be '/operationStatuses/offline'
        $requests[1].Body | Should BeNullOrEmpty
    }

    It 'Surfaces a failed swapDefault operation instead of returning success' {
        {
            Invoke-EdgeActionOfflineRequest -Operation EdgeActionVersionsSwapDefault `
                -Form Named -Identity $version -LongRunning -AsyncOnly -PollingState Failed
        } | Should Throw
    }

    It 'Completes <Operation> without retrieving a deleted resource' -TestCases @(
        @{ Operation = 'EdgeActionsDelete'; Identity = $action }
        @{ Operation = 'EdgeActionVersionsDelete'; Identity = $version }
        @{ Operation = 'EdgeActionExecutionFiltersDelete'; Identity = $filter }
    ) {
        param($Operation, $Identity)
        $requests = Invoke-EdgeActionOfflineRequest -Operation $Operation `
            -Form Named -Identity $Identity -LongRunning -AsyncOnly
        $requests.Count | Should Be 2
        $requests[0].Method | Should Be 'DELETE'
        $requests[1].Uri.AbsolutePath | Should Be '/operationStatuses/offline'
    }

    It 'Returns the deployed version resource (LongRunning=<LongRunning>)' -TestCases @(
        @{ LongRunning = $false }
        @{ LongRunning = $true }
    ) {
        param($LongRunning)
        $result = Invoke-EdgeActionOfflineRequest -Operation EdgeActionVersionsDeployVersionCode `
            -Form Named -Identity $version -LongRunning:$LongRunning -AsyncOnly:$LongRunning -CaptureResult
        $result.Value.Name | Should Be 'offline'
        $result.Value.ProvisioningState | Should Be 'Succeeded'
        $result.Value.IsDefaultVersion | Should Be 'True'
        $result.Requests[0].Method | Should Be 'POST'
        $result.Requests[0].Uri.AbsolutePath | Should Be "$version/deployVersionCode"
        if ($LongRunning) {
            $result.Requests.Count | Should Be 3
            $result.Requests[1].Uri.AbsolutePath | Should Be '/operationStatuses/offline'
            $result.Requests[2].Method | Should Be 'GET'
            $result.Requests[2].Uri.AbsolutePath | Should Be $version
            $result.Requests[2].Body | Should BeNullOrEmpty
        } else {
            $result.Requests.Count | Should Be 1
        }
    }

    It 'Retrieves the resource result of <Operation> without Location' -TestCases @(
        @{ Operation = 'EdgeActionsCreate'; Identity = $action }
        @{ Operation = 'EdgeActionsUpdate'; Identity = $action }
        @{ Operation = 'EdgeActionVersionsCreate'; Identity = $version }
        @{ Operation = 'EdgeActionVersionsUpdate'; Identity = $version }
        @{ Operation = 'EdgeActionExecutionFiltersCreate'; Identity = $filter }
        @{ Operation = 'EdgeActionExecutionFiltersUpdate'; Identity = $filter }
    ) {
        param($Operation, $Identity)
        $result = Invoke-EdgeActionOfflineRequest -Operation $Operation `
            -Form Named -Identity $Identity -LongRunning -AsyncOnly -CaptureResult
        $result.Value.Name | Should Be 'offline'
        $result.Value.ProvisioningState | Should Be 'Succeeded'
        $result.Requests.Count | Should Be 3
        $result.Requests[1].Uri.AbsolutePath | Should Be '/operationStatuses/offline'
        $result.Requests[2].Method | Should Be 'GET'
        $result.Requests[2].Uri.AbsolutePath | Should Be $Identity
        $result.Requests[2].Body | Should BeNullOrEmpty
    }

    It 'Preserves legacy code body parameter sets' {
        $command = Get-Command Get-AzCdnEdgeActionVersionCode
        foreach ($name in @('Body', 'JsonString', 'JsonFilePath')) {
            $command.Parameters.ContainsKey($name) | Should Be $true
        }
        foreach ($set in @('Get', 'GetViaIdentity', 'GetViaJsonString', 'GetViaJsonFilePath',
                'GetViaIdentityExpanded', 'GetExpanded')) {
            $command.ParameterSets.Name | Should Contain $set
        }
        foreach ($name in @('New-AzCdnEdgeAction', 'New-AzCdnEdgeActionVersion', 'New-AzCdnEdgeActionExecutionFilter')) {
            (Get-Command $name).Parameters.ContainsKey('ProvisioningState') | Should Be $true
        }
    }

    It 'Exposes swapDefault identity, long-running and ShouldProcess parameters' {
        $command = Get-Command Switch-AzCdnEdgeActionVersionDefault
        foreach ($name in @('EdgeActionName', 'Version', 'InputObject', 'EdgeActionInputObject',
                'NoWait', 'PassThru', 'WhatIf', 'Confirm')) {
            $command.Parameters.ContainsKey($name) | Should Be $true
        }
        $command.ParameterSets.Count | Should Be 3
    }

    It 'Does not submit swapDefault when WhatIf is specified' {
        $output = Switch-AzCdnEdgeActionVersionDefault -SubscriptionId '00000000-0000-0000-0000-000000000000' `
            -ResourceGroupName offline -EdgeActionName offline -Version offline -WhatIf -ErrorAction Stop
        $output | Should BeNullOrEmpty
    }

    $swapCases = foreach ($form in @('Named', 'Identity', 'ParentIdentity')) {
        foreach ($noWait in @($false, $true)) {
            @{ Form = $form; NoWait = $noWait }
        }
    }
    It 'Invokes swapDefault with <Form> binding (NoWait=<NoWait>) without Azure access' -TestCases $swapCases {
        param($Form, $NoWait)
        $parameters = @{ PassThru = $true }
        switch ($Form) {
            'Named' {
                $parameters.SubscriptionId = '00000000-0000-0000-0000-000000000000'
                $parameters.ResourceGroupName = 'offline'
                $parameters.EdgeActionName = 'offline'
                $parameters.Version = 'offline'
            }
            'Identity' { $parameters.InputObject = @{ Id = $version } }
            'ParentIdentity' {
                $parameters.EdgeActionInputObject = @{ Id = $action }
                $parameters.Version = 'offline'
            }
        }
        $status = [System.Net.HttpStatusCode]::NoContent
        if ($NoWait) {
            $parameters.NoWait = $true
            $status = [System.Net.HttpStatusCode]::Accepted
        }
        $result = Invoke-EdgeActionOfflineCmdlet -Command Switch-AzCdnEdgeActionVersionDefault `
            -Parameters $parameters -Status $status
        $result.Requests.Count | Should Be 1
        $result.Requests[0].Method | Should Be 'POST'
        $result.Requests[0].Uri.AbsolutePath | Should Be "$version/swapDefault"
        $result.Requests[0].Uri.Query | Should Be '?api-version=2026-10-01'
        $result.Requests[0].Body | Should BeNullOrEmpty
        $result.Warnings | Should BeNullOrEmpty
        $result.Output.Count | Should Be 1
        if ($NoWait) {
            $result.Output[0].GetType().Name | Should Match '^AsyncOperationResponse'
        } else {
            $result.Output[0] | Should Be $true
        }
    }

    It 'Warns and omits legacy ProvisioningState for <Command>' -TestCases @(
        @{ Command = 'New-AzCdnEdgeAction'; Extra = @{ Name = 'offline'; SkuName = 'Standard'; SkuTier = 'Standard' } }
        @{ Command = 'New-AzCdnEdgeActionVersion'; Extra = @{ EdgeActionName = 'offline'; Version = 'offline' } }
        @{ Command = 'New-AzCdnEdgeActionExecutionFilter'; Extra = @{ EdgeActionName = 'offline'; ExecutionFilter = 'offline' } }
    ) {
        param($Command, $Extra)
        $parameters = @{
            SubscriptionId = '00000000-0000-0000-0000-000000000000'
            ResourceGroupName = 'offline'
            Location = 'global'
            ProvisioningState = 'Succeeded'
        } + $Extra
        $result = Invoke-EdgeActionOfflineCmdlet -Command $Command -Parameters $parameters
        $result.Requests.Count | Should Be 3
        $result.Requests[0].Method | Should Be 'PUT'
        $result.Requests[0].Uri.Query | Should Be '?api-version=2026-10-01'
        $result.Requests[0].Body | Should Not Match '"provisioningState"'
        foreach ($request in @($result.Requests | Select-Object -Skip 1)) {
            $request.Method | Should Be 'GET'
            $request.Uri | Should Be $result.Requests[0].Uri
            $request.Body | Should BeNullOrEmpty
        }
        $result.Warnings.Count | Should Be 1
        "$($result.Warnings[0])" | Should Match 'server-managed.*ignored.*2026-10-01'
    }

    It 'Warns but sends no legacy <BodyParameter> in getVersionCode requests' -TestCases @(
        @{ BodyParameter = 'Body' }
        @{ BodyParameter = 'JsonString' }
        @{ BodyParameter = 'JsonFilePath' }
    ) {
        param($BodyParameter)
        $parameters = @{
            SubscriptionId = '00000000-0000-0000-0000-000000000000'
            ResourceGroupName = 'offline'
            EdgeActionName = 'offline'
            Version = 'offline'
        }
        switch ($BodyParameter) {
            'Body' { $parameters.Body = [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Any]::new() }
            'JsonString' { $parameters.JsonString = '{"ignored":true}' }
            'JsonFilePath' {
                $parameters.JsonFilePath = Join-Path $TestDrive 'legacy-code-body.json'
                Set-Content -LiteralPath $parameters.JsonFilePath -Value '{"ignored":true}'
            }
        }
        $result = Invoke-EdgeActionOfflineCmdlet -Command Get-AzCdnEdgeActionVersionCode -Parameters $parameters
        $result.Requests.Count | Should Be 1
        $result.Requests[0].Method | Should Be 'POST'
        $result.Requests[0].Uri.AbsolutePath | Should Be "$version/getVersionCode"
        $result.Requests[0].Uri.Query | Should Be '?api-version=2026-10-01'
        $result.Requests[0].Body | Should BeNullOrEmpty
        $result.Warnings.Count | Should Be 1
        "$($result.Warnings[0])" | Should Match 'retained for compatibility.*not sent.*2026-10-01'
    }

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
