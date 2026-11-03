# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
if ($TestName -and $TestName -notcontains 'Location response contract') { return }

Describe 'Location response contract' {
    BeforeAll {
        . (Join-Path $PSScriptRoot 'utils.ps1')
    }
    BeforeEach {
        $request = [uri]'https://example.invalid/subscriptions/test/resourceGroups/test/providers/Microsoft.Cdn/edgeActions/test/versions/v1/deployVersionCode?api-version=2026-10-01'
        $location = [uri]'https://example.invalid/final-result?api-version=2026-10-01'
        $validVersion = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":"False","provisioningState":"Succeeded"}}'
        $start = [pscustomobject]@{ Method = 'POST'; Uri = $request; StatusCode = 202; AsyncOperation = $null; Location = $location.AbsoluteUri; Content = '' }
        $monitor = [pscustomobject]@{ Method = 'GET'; Uri = [uri]'https://example.invalid/status'; StatusCode = 200; Content = '{"status":"Succeeded"}' }
        $final = [pscustomobject]@{ Method = 'GET'; Uri = $location; StatusCode = 200; Content = $validVersion }
    }
    It 'checks both a successful monitor and an observed Location result' {
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        Assert-EdgeActionTestAsyncResponses @($start, $monitor, $final)
        Assert-EdgeActionTestLocationResponses @($start, $monitor, $final)
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
    It 'rejects terminal HTTP failure and unfinished Location polling' {
        $final.StatusCode = 404
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw 'returned HTTP 404'
        $final.StatusCode = 202
        $final.Content = ''
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw 'No terminal GET response'
    }
    It 'does not borrow a final response from another mutation' {
        { Assert-EdgeActionTestLocationResponses @($start, $start, $final) } | Should -Throw 'No terminal GET response'
    }
    It 'defers only the swap final payload, retaining its monitor and Location checks' {
        $start.Uri = [uri]($request.AbsoluteUri.Replace('deployVersionCode', 'swapDefault'))
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        Assert-EdgeActionTestAsyncResponses @($start, $monitor, $final)
        Assert-EdgeActionTestLocationResponses @($start, $monitor, $final)
        { Assert-EdgeActionTestLocationResponses @($start, $monitor) } | Should -Throw 'No terminal GET response'
        $monitor.Content = '{"status":"Failed"}'
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor, $final) } | Should -Throw 'requires Succeeded'
    }
    It 'requires successful resource provisioning after completion: <State>' -TestCases @(
        @{ State = 'Provisioning' }
        @{ State = 'Upgrading' }
        @{ State = 'Failed' }
        @{ State = 'Canceled' }
    ) {
        param($State)
        $final.Content = $validVersion.Replace('"Succeeded"', ('"' + $State + '"'))
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw 'provisioningState must be Succeeded'
    }
    It 'flags null validationStatus and allows only this known version-service defect' {
        $final.Content = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":"False","validationStatus":null,"provisioningState":"Succeeded"}}'
        $body = ConvertFrom-Json -InputObject $final.Content
        { Assert-EdgeActionTestJsonProperty $body.properties 'validationStatus' 'string' } | Should -Throw "'validationStatus' must be a JSON string"
        $warnings = @(Assert-EdgeActionTestLocationResponses @($start, $final) 3>&1)
        $warnings.Count | Should -Be 1
        $warnings[0] | Should -BeOfType System.Management.Automation.WarningRecord
        $warnings[0].Message | Should -Match 'Temporary service-contract allowance: EdgeActionVersion.properties.validationStatus is null'
    }
    It 'does not warn for omitted or string validationStatus: <Value>' -TestCases @(
        @{ Value = '' }
        @{ Value = ',"validationStatus":"Succeeded"' }
        @{ Value = ',"validationStatus":"Failed"' }
    ) {
        param($Value)
        $body = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":"False"' + $Value + '}}'
        @(Assert-EdgeActionTestResponseShape $body 'EdgeActionVersion' 3>&1).Count | Should -Be 0
    }
    It 'keeps the validationStatus allowance in ordinary GET and list responses visible' {
        $body = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":"False","validationStatus":null}}'
        $get = [pscustomobject]@{ Method = 'GET'; Uri = [uri]($request.AbsoluteUri.Replace('/deployVersionCode', '')); StatusCode = 200; Content = $body }
        $warnings = @(Assert-EdgeActionTestApiResponses @($get) 3>&1)
        $warnings.Count | Should -Be 1
        $warnings[0] | Should -BeOfType System.Management.Automation.WarningRecord
        $get.Uri = [uri]($request.AbsoluteUri.Replace('/v1/deployVersionCode', ''))
        $get.Content = '{"value":[' + $body + ']}'
        $warnings = @(Assert-EdgeActionTestApiResponses @($get) 3>&1)
        $warnings.Count | Should -Be 1
        $warnings[0] | Should -BeOfType System.Management.Automation.WarningRecord
    }
    It 'checks JSON <Type> without coercing other types' -TestCases @(
        @{ Type = 'string'; Valid = @('"text"', '"False"', '"42"', '"2026-10-01T00:00:00Z"'); Invalid = @('42', 'true', 'false', '{}', '[]') }
        @{ Type = 'object'; Valid = @('{}', '{"nested":[]}'); Invalid = @('"text"', '42', 'true', 'false', '[]') }
        @{ Type = 'array'; Valid = @('[]', '[1]', '["text"]'); Invalid = @('"text"', '42', 'true', 'false', '{}') }
    ) {
        param($Type, $Valid, $Invalid)
        foreach ($json in $Valid) {
            $body = ConvertFrom-Json -InputObject ('{"field":' + $json + '}')
            { Assert-EdgeActionTestJsonProperty $body 'field' $Type -Required } | Should -Not -Throw
        }
        foreach ($json in $Invalid) {
            $body = ConvertFrom-Json -InputObject ('{"field":' + $json + '}')
            { Assert-EdgeActionTestJsonProperty $body 'field' $Type } | Should -Throw "'field' must be a JSON $Type"
        }
    }
    It 'rejects explicit null but permits missing optional <Type> fields' -TestCases @(
        @{ Type = 'string' }
        @{ Type = 'object' }
        @{ Type = 'array' }
    ) {
        param($Type)
        $body = ConvertFrom-Json -InputObject '{"field":null}'
        { Assert-EdgeActionTestJsonProperty $body 'field' $Type } | Should -Throw "'field' must be a JSON $Type"
        { Assert-EdgeActionTestJsonProperty $body 'field' $Type -Required } | Should -Throw "'field' must be a JSON $Type"
        $body = ConvertFrom-Json -InputObject '{}'
        { Assert-EdgeActionTestJsonProperty $body 'field' $Type } | Should -Not -Throw
        { Assert-EdgeActionTestJsonProperty $body 'field' $Type -Required } | Should -Throw "missing required 'field'"
    }
    It 'checks declared final status for <Method>' -TestCases @(
        @{ Method = 'POST'; Code = 201 }
        @{ Method = 'POST'; Code = 204 }
        @{ Method = 'DELETE'; Code = 201 }
    ) {
        param($Method, $Code)
        $start.Method = $Method
        $final.StatusCode = $Code
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw 'expected'
    }
    It 'requires empty delete results for HTTP <Code>' -TestCases @(
        @{ Code = 200 }
        @{ Code = 204 }
    ) {
        param($Code)
        $start.Method = 'DELETE'
        $final.StatusCode = $Code
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw 'must be empty'
        $final.Content = ''
        Assert-EdgeActionTestLocationResponses @($start, $final)
    }
    It 'rejects malformed or wrong-envelope Location payload <Body>' -TestCases @(
        @{ Body = '' }
        @{ Body = 'null' }
        @{ Body = '[]' }
        @{ Body = '[{"location":"global"}]' }
        @{ Body = '{"location":' }
        @{ Body = '{"status":"Succeeded"}' }
        @{ Body = '{"deploymentType":"file","isDefaultVersion":"False"}' }
        @{ Body = '{"Location":"global"}' }
        @{ Body = '{"location":null}' }
        @{ Body = '{"location":true}' }
        @{ Body = '{"location":"global","properties":[]}' }
        @{ Body = '{"location":"global","properties":{"deploymentType":"file"}}' }
        @{ Body = '{"location":"global","properties":{"deploymentType":null,"isDefaultVersion":"False"}}' }
        @{ Body = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":false}}' }
        @{ Body = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":"False","validationStatus":42}}' }
    ) {
        param($Body)
        $final.Content = $Body
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw 'API response'
    }
    It 'checks the parent response rather than requiring version fields' {
        $start.Method = 'PATCH'
        $start.Uri = [uri]($request.AbsoluteUri.Replace('/versions/v1/deployVersionCode', ''))
        $final.Content = '{"location":"global","sku":{"name":"Standard","tier":"Standard"},"properties":{"attachments":[],"provisioningState":"Succeeded"}}'
        Assert-EdgeActionTestLocationResponses @($start, $final)
        $final.Content = $validVersion
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw "missing required 'sku'"
    }
    It 'checks execution-filter and get-code final models' {
        $start.Method = 'PATCH'
        $start.Uri = [uri]($request.AbsoluteUri.Replace('/versions/v1/deployVersionCode', '/executionFilters/f1'))
        $final.Content = '{"location":"global","properties":{"versionId":"/version","executionFilterIdentifierHeaderName":"x-test","executionFilterIdentifierHeaderValue":"test"}}'
        Assert-EdgeActionTestLocationResponses @($start, $final)
        $final.Content = $validVersion
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw "missing required 'versionId'"
        $start.Method = 'POST'
        $start.Uri = [uri]($request.AbsoluteUri.Replace('deployVersionCode', 'getVersionCode'))
        $final.Content = '{"name":"test.zip","content":"encoded"}'
        Assert-EdgeActionTestLocationResponses @($start, $final)
        $final.Content = '{"name":"test.zip","content":null}'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw "'content' must be a JSON string"
    }
    It 'checks nested objects, array items, and tag values' {
        $parent = '{"location":"global","sku":{"name":"Standard","tier":"Standard"},"properties":{"attachments":[{"attachedResourceId":"/route"}]}}'
        Assert-EdgeActionTestResponseShape $parent 'EdgeAction'
        { Assert-EdgeActionTestResponseShape ($parent.Replace('"/route"', 'null')) 'EdgeAction' } | Should -Throw "'attachedResourceId'"
        { Assert-EdgeActionTestResponseShape ($parent.Replace('{"attachedResourceId":"/route"}', 'null')) 'EdgeAction' } | Should -Throw 'attachment must be a JSON object'
        { Assert-EdgeActionTestResponseShape ($parent.Replace('{"name":"Standard","tier":"Standard"}', '{}')) 'EdgeAction' } | Should -Throw "missing required 'name'"
        { Assert-EdgeActionTestResponseShape ($validVersion.Replace('"location":"global"', '"location":"global","tags":{"test":42}')) 'EdgeActionVersion' } | Should -Throw "'test' must be a JSON string"
        { Assert-EdgeActionTestResponseShape ($validVersion.Replace('"location":"global"', '"location":"global","systemData":{"createdBy":true}')) 'EdgeActionVersion' } | Should -Throw "'createdBy' must be a JSON string"
    }
    It 'allows absent optional fields, date strings, and extensible enum strings' {
        Assert-EdgeActionTestResponseShape '{"location":"global"}' 'EdgeActionVersion'
        Assert-EdgeActionTestResponseShape '{"location":"global","properties":{"deploymentType":"future-type","isDefaultVersion":"False","lastPackageUpdateTime":"2026-10-01T00:00:00Z"}}' 'EdgeActionVersion'
    }
    It 'does not extend the validationStatus null allowance to <Field>' -TestCases @(
        @{ Field = 'id'; Body = '{"location":"global","id":null}' }
        @{ Field = 'name'; Body = '{"location":"global","name":null}' }
        @{ Field = 'type'; Body = '{"location":"global","type":null}' }
        @{ Field = 'properties'; Body = '{"location":"global","properties":null}' }
        @{ Field = 'tags'; Body = '{"location":"global","tags":null}' }
        @{ Field = 'systemData'; Body = '{"location":"global","systemData":null}' }
        @{ Field = 'provisioningState'; Body = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":"False","provisioningState":null}}' }
        @{ Field = 'lastPackageUpdateTime'; Body = '{"location":"global","properties":{"deploymentType":"file","isDefaultVersion":"False","lastPackageUpdateTime":null}}' }
    ) {
        param($Field, $Body)
        { Assert-EdgeActionTestResponseShape $Body 'EdgeActionVersion' } | Should -Throw "'$Field' must be a JSON"
    }
    It 'checks list envelopes and every resource item' {
        Assert-EdgeActionTestResponseShape '{"value":[]}' 'EdgeActionVersionListResult'
        Assert-EdgeActionTestResponseShape ('{"value":[' + $validVersion + ']}') 'EdgeActionVersionListResult'
        foreach ($body in '{"value":null}', '{"value":{}}', '{}', '{"value":[null]}', '{"value":[{"location":false}]}', '{"value":[],"nextLink":null}') {
            { Assert-EdgeActionTestResponseShape $body 'EdgeActionVersionListResult' } | Should -Throw 'API response'
        }
    }
    It 'checks ordinary GET and synchronous mutation payloads and status codes' {
        $get = [pscustomobject]@{ Method = 'GET'; Uri = [uri]($request.AbsoluteUri.Replace('/deployVersionCode', '')); StatusCode = 200; Content = $validVersion }
        Assert-EdgeActionTestApiResponses @($get)
        $get.Content = '{}'
        { Assert-EdgeActionTestApiResponses @($get) } | Should -Throw "missing required 'location'"
        $get.StatusCode = 201
        { Assert-EdgeActionTestApiResponses @($get) } | Should -Throw 'expected 200'
        $start.StatusCode = 200
        $start.Content = $validVersion
        Assert-EdgeActionTestApiResponses @($start)
        $start.Content = '{}'
        { Assert-EdgeActionTestApiResponses @($start) } | Should -Throw "missing required 'location'"
    }
    It 'allows intermediate provisioning in initial PUT and ordinary GET responses' {
        $start.Method = 'PUT'
        $start.StatusCode = 201
        $start.Uri = [uri]($request.AbsoluteUri.Replace('/deployVersionCode', ''))
        $start.Content = $validVersion.Replace('Succeeded', 'Provisioning')
        Assert-EdgeActionTestApiResponses @($start)
        $start.Method = 'GET'
        $start.StatusCode = 200
        Assert-EdgeActionTestApiResponses @($start)
    }
    It 'correlates polling separately and resumes schema checks after the final GET' {
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        $start.Location = $request.AbsoluteUri.Replace('/deployVersionCode', '')
        $final.Uri = [uri]$start.Location
        Assert-EdgeActionTestApiResponses @($start, $monitor, $final)
        $later = [pscustomobject]@{ Method = 'GET'; Uri = $final.Uri; StatusCode = 200; Content = '{}' }
        { Assert-EdgeActionTestApiResponses @($start, $monitor, $final, $later) } | Should -Throw "missing required 'location'"
    }
    It 'does not exempt synchronous swap responses' {
        $start.Uri = [uri]($request.AbsoluteUri.Replace('deployVersionCode', 'swapDefault'))
        $start.StatusCode = 204
        $start.Content = $validVersion
        { Assert-EdgeActionTestApiResponses @($start) } | Should -Throw 'must be empty'
        $start.Content = ''
        Assert-EdgeActionTestApiResponses @($start)
        $start.StatusCode = 200
        { Assert-EdgeActionTestApiResponses @($start) } | Should -Throw 'expected 202 or 204'
    }
    It 'leaves expected probe errors outside successful response schema checks' {
        $start.Method = 'GET'
        $start.StatusCode = 404
        $start.Content = '{"error":{"code":"ResourceNotFound"}}'
        Assert-EdgeActionTestApiResponses @($start)
    }
    It 'does not require a Location header or extra GET for PUT' {
        $start.Method = 'PUT'
        $start.StatusCode = 201
        $start.Uri = [uri]($request.AbsoluteUri.Replace('/deployVersionCode', ''))
        $start.Location = ''
        Assert-EdgeActionTestLocationResponses @($start, $monitor)
        $final.Uri = $start.Uri
        Assert-EdgeActionTestLocationResponses @($start, $monitor, $final)
        $final.Content = $validVersion.Replace('Succeeded', 'Provisioning')
        { Assert-EdgeActionTestLocationResponses @($start, $monitor, $final) } | Should -Throw 'provisioningState must be Succeeded'
    }
    It 'rejects payloads on accepted and pending Location 202 responses' {
        $start.Content = '{"status":"Running"}'
        { Assert-EdgeActionTestLocationResponses @($start, $final) } | Should -Throw '202 response must be empty'
        $start.Content = ''
        $pending = [pscustomobject]@{ Method = 'GET'; Uri = $location; StatusCode = 202; Content = '{"status":"Running"}' }
        { Assert-EdgeActionTestLocationResponses @($start, $pending, $final) } | Should -Throw '202 response must be empty'
        $pending.Content = ''
        Assert-EdgeActionTestLocationResponses @($start, $pending, $final)
    }
    It 'allows provider-defined intermediate states and optional async headers' {
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        $pending = [pscustomobject]@{ Method = 'GET'; Uri = $monitor.Uri; StatusCode = 200; Content = '{"status":"Preparing"}' }
        Assert-EdgeActionTestAsyncResponses @($start, $pending, $monitor, $final)
        $start.AsyncOperation = $null
        Assert-EdgeActionTestAsyncResponses @($start, $final)
        Assert-EdgeActionTestLocationResponses @($start, $final)
    }
    It 'rejects malformed async URL <Value>' -TestCases @(
        @{ Value = '' }
        @{ Value = '/status' }
        @{ Value = 'file:///status' }
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
        @{ Body = '{"status":42}' }
        @{ Body = '{"status":{}}' }
        @{ Body = '{"status":[]}' }
        @{ Body = '{"status":null}' }
        @{ Body = '{"status":""}' }
    ) {
        param($Body)
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        $monitor.Content = $Body
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor) } | Should -Throw 'Azure-AsyncOperation'
    }
    It 'defers non-status monitor fields until the next API: <Case>' -TestCases @(
        @{ Case = 'null metadata'; Fields = '"id":null,"name":null,"startTime":null,"endTime":null,"percentComplete":null,"properties":null,"error":null,"operations":null' }
        @{ Case = 'wrong metadata types'; Fields = '"id":[],"name":42,"startTime":true,"endTime":{},"percentComplete":"50","properties":[],"error":false,"operations":{}' }
        @{ Case = 'nonempty error'; Fields = '"error":{"code":"KnownIssue","message":"Deferred"}' }
        @{ Case = 'early properties'; Fields = '"properties":{"result":"present while polling"}' }
        @{ Case = 'out-of-range progress'; Fields = '"percentComplete":101' }
        @{ Case = 'nested operations'; Fields = '"operations":[null,{"status":"Failed"}]' }
    ) {
        param($Case, $Fields)
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        $pending = [pscustomobject]@{ Method = 'GET'; Uri = $monitor.Uri; StatusCode = 200; Content = '{"status":"Running",' + $Fields + '}' }
        $monitor.Content = '{"status":"Succeeded",' + $Fields + '}'
        Assert-EdgeActionTestAsyncResponses @($start, $pending, $monitor, $final)
        Assert-EdgeActionTestApiResponses @($start, $pending, $monitor, $final)
        Assert-EdgeActionTestLocationResponses @($start, $pending, $monitor, $final)
        $final.Content = '{}'
        { Assert-EdgeActionTestLocationResponses @($start, $pending, $monitor, $final) } | Should -Throw "missing required 'location'"
    }
    It 'rejects failed/canceled operations despite a successful Location resource: <State>' -TestCases @(
        @{ State = 'Failed' }
        @{ State = 'Canceled' }
    ) {
        param($State)
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        $monitor.Content = '{"status":"' + $State + '","error":null,"endTime":null}'
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor, $final) } | Should -Throw 'requires Succeeded'
    }
    It 'requires a terminal monitor before accepting the final result' {
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        { Assert-EdgeActionTestAsyncResponses @($start, $final, $monitor) } | Should -Throw 'before Azure-AsyncOperation reached Succeeded'
        $monitor.Content = '{"status":"Running"}'
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor) } | Should -Throw 'No Succeeded terminal response'
    }
    It 'does not borrow a monitor from another mutation or URL' {
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        { Assert-EdgeActionTestAsyncResponses @($start, $start, $monitor) } | Should -Throw 'No Succeeded terminal response'
        $monitor.Uri = [uri]'https://example.invalid/unrelated'
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor) } | Should -Throw 'No Succeeded terminal response'
    }
    It 'rejects status regressions after Succeeded' {
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        $pending = [pscustomobject]@{ Method = 'GET'; Uri = $monitor.Uri; StatusCode = 200; Content = '{"status":"Running"}' }
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor, $pending) } | Should -Throw 'regressed'
    }
    It 'validates PUT monitor flow for both declared initial codes' {
        $start.AsyncOperation = $monitor.Uri.AbsoluteUri
        $start.Method = 'PUT'
        $start.Location = ''
        foreach ($code in 200, 201) {
            $start.StatusCode = $code
            Assert-EdgeActionTestAsyncResponses @($start, $monitor)
        }
        $start.StatusCode = 202
        { Assert-EdgeActionTestAsyncResponses @($start, $monitor) } | Should -Throw 'expected 200 or 201'
    }
    It 'captures raw headers and JSON without replacing the response' {
        $observer = New-EdgeActionTestResponse
        $message = New-Object System.Net.Http.HttpRequestMessage -ArgumentList @([System.Net.Http.HttpMethod]::Post, $request)
        $response = New-Object System.Net.Http.HttpResponseMessage -ArgumentList @([System.Net.HttpStatusCode]::Accepted)
        $response.Headers.Location = $location
        $response.Headers.Add('Azure-AsyncOperation', $monitor.Uri.AbsoluteUri)
        $response.Content = New-Object System.Net.Http.StringContent -ArgumentList @($validVersion)
        try {
            $actual = $observer.Capture($message, [System.Threading.Tasks.Task]::FromResult($response)).GetAwaiter().GetResult()
            [object]::ReferenceEquals($actual, $response) | Should -Be $true
            $observer.Exchanges.Count | Should -Be 1
            $observer.Exchanges[0].Location | Should -Be $location.AbsoluteUri
            $observer.Exchanges[0].AsyncOperation | Should -Be $monitor.Uri.AbsoluteUri
            $observer.Exchanges[0].Content | Should -Be $validVersion
        } finally {
            $response.Dispose()
            $message.Dispose()
        }
    }
}
