# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# ----------------------------------------------------------------------------------

# These helpers exercise generated serialization without loadEnv.ps1, recordings, or an Azure
# login. Initialize/Restore must surround the tests so even a missing capture hook fails closed.
function Initialize-DocumentDBRequestTest {
    if (-not ('Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Module' -as [type])) {
        throw 'Import the built Az.DocumentDB module before running the request tests.'
    }

    $module = [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Module]::Instance
    $state = [pscustomobject]@{
        Module = $module
        OnNewRequest = $module.OnNewRequest
        Telemetry = $module.Telemetry
    }

    $module.Telemetry = {}
    $module.OnNewRequest = {
        # The cmdlet prepends its explicit capture after this guard, making capture outermost.
        # Do not call the saved authentication hook or allow a request to reach HttpClient.
        # The fourth OnNewRequest delegate argument installs a prepend step.
        $args[3].Invoke({
            throw 'Network is disabled in DocumentDB request tests: no terminal capture handled the request.'
        })
    }

    $state
}

function Restore-DocumentDBRequestTest {
    param([Parameter(Mandatory)] $State)

    $State.Module.OnNewRequest = $State.OnNewRequest
    $State.Module.Telemetry = $State.Telemetry
}

function New-DocumentDBRequestCapture {
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute(
        'PSUseShouldProcessForStateChangingFunctions', '',
        Justification = 'This test factory only creates an in-memory terminal HTTP responder.')]
    param(
        [Parameter(Mandatory)]
        [ValidateCount(1, 8)]
        [hashtable[]] $Responses
    )

    $requests = [System.Collections.Generic.List[object]]::new()
    $responseQueue = $Responses
    $capture = [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SendAsyncStep]{
        param($request)

        $content = $null
        $contentType = $null
        if ($null -ne $request.Content) {
            $content = $request.Content.ReadAsStringAsync().GetAwaiter().GetResult()
            $contentType = [string]$request.Content.Headers.ContentType
        }

        $index = $requests.Count
        $requests.Add([pscustomobject]@{
            Method = $request.Method.Method
            RequestUri = $request.RequestUri.AbsoluteUri
            ContentType = $contentType
            Content = $content
        })

        if ($index -ge $responseQueue.Count) {
            throw 'Unexpected extra request in the bounded DocumentDB request test.'
        }
        $expected = $responseQueue[$index]
        if ($request.Method.Method -ne $expected.Method) {
            throw "Expected request $index to use $($expected.Method), not $($request.Method.Method)."
        }

        $statusCode = [System.Net.HttpStatusCode]::OK
        if ($expected.ContainsKey('StatusCode')) {
            $statusCode = [System.Net.HttpStatusCode]$expected.StatusCode
        }
        $response = [System.Net.Http.HttpResponseMessage]::new($statusCode)
        $response.RequestMessage = $request
        $response.Headers.RetryAfter = [System.Net.Http.Headers.RetryConditionHeaderValue]::new(
            [System.TimeSpan]::Zero)
        if ($expected.ContainsKey('Body')) {
            $response.Content = [System.Net.Http.StringContent]::new(
                [string]$expected.Body, [System.Text.Encoding]::UTF8, 'application/json')
        }
        else {
            # Unlike .NET Core, Framework leaves synthetic Content null. Real HTTP responses
            # still have an empty content wrapper whose headers the generated client reads.
            $response.Content = [System.Net.Http.ByteArrayContent]::new([byte[]]@())
        }

        # A terminal response, never $next.SendAsync: inspect the real generated request body.
        [System.Threading.Tasks.Task]::FromResult($response)
    }.GetNewClosure()

    # Generated proxies recognize this explicit Playback delegate and do not require a login.
    # The LAST prepend runs FIRST. If ordering changes, the nonexistent recording fails closed.
    $unusedRecording = Join-Path $PSScriptRoot 'DocumentDB.RequestTest.must-not-read.Recording.json'
    $playback = [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.PipelineMock]::new($unusedRecording)
    $playback.SetPlayback()

    [pscustomobject]@{
        Requests = $requests
        Pipeline = @($playback, $capture)
    }
}
