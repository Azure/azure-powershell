if(($null -eq $TestName) -or ($TestName -contains 'New-AzMonitorHealthModel'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMonitorHealthModel.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMonitorHealthModel' {
    It 'CreateExpanded' {
        {
            $result = New-AzMonitorHealthModel -Name $env.HealthModelCreateName -ResourceGroupName $env.ResourceGroupName -Location $env.Location -EnableSystemAssignedIdentity -Tag @{ scenario = 'create' }
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.HealthModelCreateName
            $result.Location | Should -Be $env.Location
        } | Should -Not -Throw
    }

    $createViaJsonCases = @(
        @{ CaseName = 'CreateViaJsonString'; UseJsonFile = $false }
        @{ CaseName = 'CreateViaJsonFilePath'; UseJsonFile = $true }
    )

    # These input checks reuse recorded responses rather than creating another resource.
    It '<CaseName>' -TestCases $createViaJsonCases -Skip:($TestMode -ne 'playback') {
        param($CaseName, $UseJsonFile)

        $payloadObject = @{
            location = $env.Location
            identity = @{
                type = 'SystemAssigned'
            }
            tags = @{
                scenario = 'create'
            }
        }
        $jsonPayload = $payloadObject | ConvertTo-Json -Depth 5

        $replay = [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.PipelineMock]::new($TestRecordingFile)
        $replay.SetPlayback()
        $replay.PushDescription('New-AzMonitorHealthModel')
        $replay.PushScenario('CreateExpanded')
        $replay.ForceResponseHeaders['Retry-After'] = '0'

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

        $createParameters = @{
            Name = $env.HealthModelCreateName
            ResourceGroupName = $env.ResourceGroupName
            ErrorAction = 'Stop'
            HttpPipelinePrepend = @($replay, $capture)
        }

        if ($UseJsonFile) {
            $jsonFilePath = Join-Path $TestDrive 'health model create payload.json'
            [System.IO.File]::WriteAllText($jsonFilePath, $jsonPayload, [System.Text.UTF8Encoding]::new($false))
            $createParameters['JsonFilePath'] = $jsonFilePath
        } else {
            $createParameters['JsonString'] = $jsonPayload
        }

        $result = New-AzMonitorHealthModel @createParameters
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.HealthModelCreateName
        $result.Location | Should -Be $env.Location

        $capturedRequests.Count | Should -Be 3
        (@($capturedRequests | ForEach-Object { $_.Method }) -join ',') | Should -Be 'PUT,GET,GET'

        $resourceUri = "https://management.azure.com/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.CloudHealth/healthmodels/$($env.HealthModelCreateName)?api-version=2026-09-01-preview"
        $capturedRequests[0].RequestUri | Should -Be $resourceUri
        $capturedRequests[1].RequestUri | Should -Match '/providers/Microsoft.CloudHealth/locations/.+/operationStatuses/.+\?api-version=2026-09-01-preview'
        $capturedRequests[2].RequestUri | Should -Be $resourceUri

        $putRequest = @($capturedRequests | Where-Object { $_.Method -eq 'PUT' })
        $putRequest.Count | Should -Be 1
        $putRequest[0].ContentType | Should -Match '^application/json'
        $putRequestBody = $putRequest[0].Content | ConvertFrom-Json
        $putRequestBody.PSObject.Properties.Name | Should -Contain 'location'
        $putRequestBody.PSObject.Properties.Name | Should -Contain 'identity'
        $putRequestBody.PSObject.Properties.Name | Should -Contain 'tags'
        $putRequestBody.PSObject.Properties.Name | Should -Not -Contain 'properties'
        $putRequestBody.PSObject.Properties.Name | Should -Not -Contain 'enableSystemAssignedIdentity'
        $putRequestBody.PSObject.Properties.Name | Should -Not -Contain 'tag'
        $putRequestBody.location | Should -Be $env.Location
        $putRequestBody.identity.GetType().Name | Should -Be 'PSCustomObject'
        $putRequestBody.identity.type | Should -Be 'SystemAssigned'
        $putRequestBody.identity.PSObject.Properties.Name | Should -Contain 'type'
        $putRequestBody.tags.scenario | Should -Be 'create'
    }

}
