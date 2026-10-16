# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
if ($TestName -and $TestName -notcontains 'Location response contract') { return }

Describe 'Location response contract' {
    BeforeAll {
        . (Join-Path $PSScriptRoot 'utils.ps1')
    }
    BeforeEach {
        $request = [uri]'https://example.invalid/subscriptions/test/resourceGroups/test/providers/Microsoft.Cdn/edgeActions/test/versions/v1/deployVersionCode?api-version=2026-10-01'
        $location = [uri]'https://example.invalid/final-result?api-version=2026-10-01'
        $validVersion = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":"False"}}'
        $start = [pscustomobject]@{ Method = 'POST'; Uri = $request; StatusCode = 202; AsyncOperation = $null; Location = $location.AbsoluteUri; Content = '' }
        $monitor = [pscustomobject]@{
            Method = 'GET'; Uri = [uri]'https://example.invalid/status'; StatusCode = 200
            Location = ''; Content = '{"status":"Succeeded"}'
        }
        $final = [pscustomobject]@{ Method = 'GET'; Uri = $location; StatusCode = 200; Location = ''; Content = $validVersion }
    }
    It 'checks the final Location response after a successful status monitor' {
        { Assert-EdgeActionTestLocationResponses @($start, $monitor, $final) } | Should -Not -Throw
    }
    It 'accepts date-time strings despite PowerShell JSON date conversion' {
        $final.Content = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":"False","lastPackageUpdateTime":"2026-10-14T11:04:40.9021295+00:00"}}'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Not -Throw
    }
    It 'rejects a success envelope instead of the declared resource' {
        $final.Content = '{"status":"Succeeded"}'
        { Assert-EdgeActionTestLocationResponses @($start, $monitor, $final) } | Should -Throw "missing required 'location'"
    }
    It 'does not accept a successful monitor without a Location GET' {
        { Assert-EdgeActionTestLocationResponses @($start, $monitor) } | Should -Throw 'No terminal GET response'
    }
    It 'rejects invalid Location <Value>' -TestCases @(
        @{ Value = '' }
        @{ Value = '/relative/result' }
        @{ Value = 'file:///private/result' }
    ) {
        param($Value)
        $start.Location = $Value
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw 'absolute HTTP(S) Location'
    }
    It 'rejects invalid resource body <Body>' -TestCases @(
        @{ Body = '' }
        @{ Body = '[]' }
        @{ Body = '{broken' }
        @{ Body = '{"location":false}' }
        @{ Body = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":false}}' }
        @{ Body = '{"location":"global","properties":{"deploymentType":"file"}}' }
    ) {
        param($Body)
        $final.Content = $Body
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw 'Location final response'
    }
    It 'rejects a terminal HTTP error even if its body resembles a resource' {
        $final.StatusCode = 404
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw 'returned HTTP 404'
    }
    It 'allows intermediate Location 202 responses but requires the final resource' {
        $pending = [pscustomobject]@{ Method = 'GET'; Uri = $location; StatusCode = 202; Location = ''; Content = '' }
        { Assert-EdgeActionTestLocationResponses @($start, $pending, $final) } | Should -Not -Throw
        { Assert-EdgeActionTestLocationResponses @($start, $pending) } | Should -Throw 'No terminal GET response'
    }
    It 'does not use another operation to supply a missing final response' {
        { Assert-EdgeActionTestLocationResponses @($start, $start, $final) } | Should -Throw 'No terminal GET response'
    }
    It 'validates the VersionCode schema rather than an EdgeActionVersion resource' {
        $start.Uri = [uri]($request.AbsoluteUri.Replace('deployVersionCode', 'getVersionCode'))
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw "missing required 'name'"
        $final.Content = '{"name":"handler.js","content":"export default {}"}'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Not -Throw
        $final.Content = '{"name":"handler.js","content":{}}'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw "'content' must be a JSON string"
    }
    It 'checks required parent SKU and execution-filter fields' {
        $start.Method = 'PATCH'
        $start.Uri = [uri]'https://example.invalid/providers/Microsoft.Cdn/edgeActions/test'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw "missing required 'sku'"
        $final.Content = '{"location":"global","sku":{"name":"Standard","tier":"Standard"},"properties":{"attachments":[]}}'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Not -Throw
        $start.Uri = [uri]'https://example.invalid/providers/Microsoft.Cdn/edgeActions/test/executionFilters/filter'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw "missing required 'versionId'"
        $final.Content = '{"location":"global","properties":{"versionId":"version-id","executionFilterIdentifierHeaderName":"X-Test","executionFilterIdentifierHeaderValue":"test"}}'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Not -Throw
    }
    It 'checks the documented empty swap and delete responses' {
        $start.Uri = [uri]($request.AbsoluteUri.Replace('deployVersionCode', 'swapDefault'))
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw 'expected 204'
        $final.StatusCode = 204
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw 'must be empty'
        $final.Content = ''
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Not -Throw
        $start.Method = 'DELETE'
        $start.Uri = [uri]'https://example.invalid/providers/Microsoft.Cdn/edgeActions/test'
        $final.StatusCode = 200
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Not -Throw
    }
    It 'does not impose Location final-state semantics on PUT' {
        $start.Method = 'PUT'
        $start.StatusCode = 201
        $start.Uri = [uri]($request.AbsoluteUri.Replace('/deployVersionCode', ''))
        $start.Location = ''
        { Assert-EdgeActionTestLocationResponses @($start, $monitor) } | Should -Not -Throw
    }
    It 'requires a successful final provisioning state when supplied: <State>' -TestCases @(
        @{ State = 'Provisioning' }
        @{ State = 'Upgrading' }
        @{ State = 'Failed' }
        @{ State = 'Canceled' }
    ) {
        param($State)
        $final.Content = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":"False","provisioningState":"' + $State + '"}}'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw 'provisioningState must be Succeeded'
    }
    It 'accepts Succeeded and rejects explicitly null provisioning state' {
        $final.Content = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":"False","provisioningState":"Succeeded"}}'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Not -Throw
        $final.Content = $final.Content.Replace('"Succeeded"', 'null')
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw "'provisioningState' must be a JSON string"
    }
    It 'checks observed PUT Location resources without requiring an extra GET' {
        $start.Method = 'PUT'
        $start.StatusCode = 201
        $start.Uri = [uri]($request.AbsoluteUri.Replace('/deployVersionCode', ''))
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Not -Throw
        { Assert-EdgeActionTestLocationResponses @($start, $monitor) } | Should -Not -Throw
        $final.Content = '{"status":"Succeeded"}'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw "missing required 'location'"
        $start.Location = ''
        { Assert-EdgeActionTestLocationResponses @($start, $monitor) } | Should -Not -Throw
        $final.Uri = $start.Uri
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw "missing required 'location'"
    }
    It 'rejects a present null validationStatus instead of omitting the optional string' {
        $final.Content = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":"False","validationStatus":null}}'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw "'validationStatus' must be a JSON string"
    }
    It 'rejects payloads on accepted and pending Location 202 responses' {
        $start.Content = '{"status":"Running"}'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw '202 response must be empty'
        $start.Content = ''
        $pending = [pscustomobject]@{ Method = 'GET'; Uri = $location; StatusCode = 202; Content = '{"status":"Running"}' }
        { Assert-EdgeActionTestLocationResponses @($start, $pending, $final) } | Should -Throw '202 response must be empty'
    }
    It 'validates both monitor and resource success with provider-defined intermediate states' {
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        $pending = [pscustomobject]@{ Method = 'GET'; Uri = $monitor.Uri; StatusCode = 200; Content = '{"status":"Preparing"}' }
        {
            Assert-EdgeActionTestAsyncResponses @($start, $pending, $monitor, $final)
            Assert-EdgeActionTestLocationResponses @($start, $pending, $monitor, $final)
        } | Should -Not -Throw
    }
    It 'supports Location-only polling when the optional async header is absent' {
        {
            Assert-EdgeActionTestAsyncResponses @($start, $final)
            Assert-EdgeActionTestLocationResponses @($start, $final)
        } | Should -Not -Throw
    }
    It 'rejects malformed async URL <Value>' -TestCases @(
        @{ Value = '' }
        @{ Value = '/status' }
        @{ Value = 'file:///status' }
        @{ Value = ' ' }
    ) {
        param($Value)
        $start.AsyncOperation = $Value
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor) } | Should -Throw 'absolute HTTP(S)'
    }
    It 'requires monitor HTTP 200, not <Code>' -TestCases @(
        @{ Code = 201 }
        @{ Code = 202 }
        @{ Code = 204 }
        @{ Code = 404 }
        @{ Code = 500 }
    ) {
        param($Code)
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        $monitor.StatusCode = $Code
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor) } | Should -Throw 'expected 200'
    }
    It 'rejects malformed monitor status body <Body>' -TestCases @(
        @{ Body = '' }
        @{ Body = '[]' }
        @{ Body = '{broken' }
        @{ Body = '{"properties":{"provisioningState":"Succeeded"}}' }
        @{ Body = '{"Status":"Succeeded"}' }
        @{ Body = '{"status":true}' }
        @{ Body = '{"status":null}' }
        @{ Body = '{"status":""}' }
    ) {
        param($Body)
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        $monitor.Content = $Body
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor) } | Should -Throw 'Azure-AsyncOperation'
    }
    It 'rejects failed or canceled operations despite a successful Location resource: <State>' -TestCases @(
        @{ State = 'Failed' }
        @{ State = 'Canceled' }
    ) {
        param($State)
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        $monitor.Content = '{"status":"' + $State + '","error":{"code":"Test","message":"Test"}}'
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor, $final) } | Should -Throw 'requires Succeeded'
    }
    It 'requires a terminal monitor before accepting the final result' {
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        { Assert-EdgeActionTestAsyncResponses @($start, $final, $monitor) } | Should -Throw 'before Azure-AsyncOperation reached Succeeded'
        $monitor.Content = '{"status":"Running"}'
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor) } | Should -Throw 'No Succeeded terminal response'
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor, $final) } | Should -Throw 'before Azure-AsyncOperation reached Succeeded'
    }
    It 'does not borrow a monitor from another mutation or another URL' {
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        { Assert-EdgeActionTestAsyncResponses @($start, $start, $monitor) } | Should -Throw 'No Succeeded terminal response'
        $monitor.Uri = [uri]'https://example.invalid/unrelated'
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor) } | Should -Throw 'No Succeeded terminal response'
    }
    It 'rejects regressions and contradictory monitor payloads' {
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        $pending = [pscustomobject]@{ Method = 'GET'; Uri = $monitor.Uri; StatusCode = 200; Content = '{"status":"Running"}' }
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor, $pending) } | Should -Throw 'regressed'
        $monitor.Content = '{"status":"Succeeded","error":{"code":"Test","message":"Test"}}'
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor) } | Should -Throw 'error in a non-failed'
        $monitor.Content = '{"status":"Running","properties":{}}'
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor) } | Should -Throw 'only be returned with Succeeded'
    }
    It 'validates PUT monitor flow for both declared initial codes without requiring Location' {
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        $start.Method = 'PUT'
        $start.Location = ''
        foreach ($code in 200, 201) {
            $start.StatusCode = $code
            { Assert-EdgeActionTestAsyncResponses @($start, $monitor) } | Should -Not -Throw
        }
        $start.StatusCode = 202
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor) } | Should -Throw 'expected 200 or 201'
    }
    It 'captures raw headers and JSON without replacing the HTTP response' {
        $observer = New-EdgeActionTestResponse
        $message = New-Object System.Net.Http.HttpRequestMessage -ArgumentList @([System.Net.Http.HttpMethod]::Post, $request)
        $response = New-Object System.Net.Http.HttpResponseMessage -ArgumentList @([System.Net.HttpStatusCode]::Accepted)
        $response.Headers.Location = $location
        $response.Headers.Add('Azure-AsyncOperation', $monitor.Uri.AbsoluteUri)
        $response.Content = New-Object System.Net.Http.StringContent -ArgumentList @($validVersion)
        try {
            $pending = [System.Threading.Tasks.Task]::FromResult($response)
            $actual = $observer.Capture($message, $pending).GetAwaiter().GetResult()
            [object]::ReferenceEquals($actual, $response) | Should -Be $true
            $observer.Exchanges.Count | Should -Be 1
            $observer.Exchanges[0].Location | Should -Be $location.AbsoluteUri
            $observer.Exchanges[0].AsyncOperation | Should -Be $monitor.Uri.AbsoluteUri
            $observer.Exchanges[0].Content | Should -Be $validVersion
            $observer.Exchanges[0].Uri | Should -Be $request
        } finally {
            $response.Dispose()
            $message.Dispose()
        }
    }
}
