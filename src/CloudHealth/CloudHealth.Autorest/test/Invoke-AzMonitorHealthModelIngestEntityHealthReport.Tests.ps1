if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzMonitorHealthModelIngestEntityHealthReport'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzMonitorHealthModelIngestEntityHealthReport.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzMonitorHealthModelIngestEntityHealthReport' {
    It 'IngestExpanded' {
        {
            $result = Invoke-AzMonitorHealthModelIngestEntityHealthReport -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -EntityName $env.EntityName -SignalName $env.SignalDefinitionName -HealthState Healthy -Value 88.8 -ExpiresInMinute 60 -PassThru -ErrorAction Stop
            $result | Should -BeTrue
        } | Should -Not -Throw
    }

    $ingestViaJsonCases = @(
        @{ CaseName = 'IngestViaJsonString'; UseJsonFile = $false }
        @{ CaseName = 'IngestViaJsonFilePath'; UseJsonFile = $true }
    )

    # These input checks reuse recorded responses rather than submitting another report.
    It '<CaseName>' -TestCases $ingestViaJsonCases -Skip:($TestMode -ne 'playback') {
        param($CaseName, $UseJsonFile)

        $payloadObject = @{
            signalName = $env.SignalDefinitionName
            healthState = 'Healthy'
            value = 88.8
            expiresInMinutes = 60
        }
        $jsonPayload = $payloadObject | ConvertTo-Json -Depth 5

        $replay = [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.PipelineMock]::new($TestRecordingFile)
        $replay.SetPlayback()
        $replay.PushDescription('Invoke-AzMonitorHealthModelIngestEntityHealthReport')
        $replay.PushScenario('IngestExpanded')

        $capturedRequests = [System.Collections.Generic.List[object]]::new()
        $capture = [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.SendAsyncStep]{
            param($request, $callback, $next)
            $content = $null
            $contentType = $null
            if ($request.Content) {
                $content = $request.Content.ReadAsStringAsync().GetAwaiter().GetResult()
                $contentType = $request.Content.Headers.ContentType.ToString()
            }

            $capturedRequests.Add([pscustomobject]@{
                Method = $request.Method.Method
                RequestUri = $request.RequestUri.AbsoluteUri
                ContentType = $contentType
                Content = $content
            }) | Out-Null

            return $next.SendAsync($request, $callback)
        }.GetNewClosure()

        $ingestParameters = @{
            HealthModelName = $env.HealthModelName
            ResourceGroupName = $env.ResourceGroupName
            EntityName = $env.EntityName
            PassThru = $true
            ErrorAction = 'Stop'
            HttpPipelinePrepend = @($replay, $capture)
        }

        if ($UseJsonFile) {
            $jsonFilePath = Join-Path $TestDrive 'health report ingest payload.json'
            [System.IO.File]::WriteAllText($jsonFilePath, $jsonPayload, [System.Text.UTF8Encoding]::new($false))
            $ingestParameters['JsonFilePath'] = $jsonFilePath
        } else {
            $ingestParameters['JsonString'] = $jsonPayload
        }

        $result = Invoke-AzMonitorHealthModelIngestEntityHealthReport @ingestParameters
        $result | Should -BeTrue
        $result.GetType().Name | Should -Be 'Boolean'

        $capturedRequests.Count | Should -Be 1
        (@($capturedRequests | ForEach-Object { $_.Method }) -join ',') | Should -Be 'POST'

        $ingestUri = "https://management.azure.com/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.CloudHealth/healthmodels/$($env.HealthModelName)/entities/$($env.EntityName)/ingestHealthReport?api-version=2026-09-01-preview"
        $capturedRequests[0].RequestUri | Should -Be $ingestUri
        $capturedRequests[0].ContentType | Should -Match '^application/json'

        $postRequestBody = $capturedRequests[0].Content | ConvertFrom-Json
        $postRequestBody.PSObject.Properties.Name | Should -Contain 'signalName'
        $postRequestBody.PSObject.Properties.Name | Should -Contain 'healthState'
        $postRequestBody.PSObject.Properties.Name | Should -Contain 'value'
        $postRequestBody.PSObject.Properties.Name | Should -Contain 'expiresInMinutes'
        $postRequestBody.PSObject.Properties.Name | Should -Not -Contain 'expiresInMinute'
        $postRequestBody.PSObject.Properties.Name | Should -Not -Contain 'evaluationRules'
        $postRequestBody.PSObject.Properties.Name | Should -Not -Contain 'additionalContext'
        $postRequestBody.PSObject.Properties.Name | Should -Not -Contain 'properties'
        $postRequestBody.signalName | Should -Be $env.SignalDefinitionName
        $postRequestBody.healthState | Should -Be 'Healthy'
        $postRequestBody.value | Should -Be 88.8
        ($postRequestBody.value -is [double] -or $postRequestBody.value -is [decimal]) | Should -BeTrue
        $postRequestBody.expiresInMinutes | Should -Be 60
        ($postRequestBody.expiresInMinutes -is [int] -or $postRequestBody.expiresInMinutes -is [long]) | Should -BeTrue
    }

    It 'IngestViaIdentityHealthmodelExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IngestViaIdentityHealthmodel' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Ingest' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IngestViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IngestViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
