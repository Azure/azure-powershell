# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------
# These are synthetic HTTP contract tests, not recordings of the stable service.
Describe 'StableApi' {
    BeforeEach {
        $script:requests = [System.Collections.Generic.List[object]]::new()
        $script:subscriptionId = '00000000-0000-0000-0000-000000000000'
        $script:resourceId = "/subscriptions/$script:subscriptionId/resourceGroups/rg/providers/Microsoft.Cdn/edgeActions/action"
    }

    function New-StableApiParameters {
        param(
            [System.Net.HttpStatusCode]$StatusCode = 'OK',
            [string]$Body = '{"name":"action","location":"global","properties":{"provisioningState":"Succeeded"}}'
        )

        # The playback marker satisfies the login guard; the outermost responder never calls the network.
        $marker = [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.PipelineMock]::new(
            (Join-Path $TestDrive 'unused-recording.json'))
        $marker.SetPlayback()
        $requests = $script:requests
        $responder = [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.SendAsyncStep]{
            param($request, $callback, $next)
            $content = $null
            if ($request.Content) {
                $content = $request.Content.ReadAsStringAsync().GetAwaiter().GetResult()
            }
            $requests.Add([pscustomobject]@{
                Method = $request.Method.Method
                Uri = $request.RequestUri.AbsoluteUri
                Body = $content
            })
            if ($requests.Count -gt 4) {
                throw 'Unexpected additional polling request in the synthetic response pipeline.'
            }
            $response = [System.Net.Http.HttpResponseMessage]::new($StatusCode)
            $response.RequestMessage = $request
            $response.Headers.Add('Retry-After', '0')
            if ($StatusCode -eq [System.Net.HttpStatusCode]::Accepted) {
                $response.Headers.Location = $request.RequestUri
                if ($request.Method -eq [System.Net.Http.HttpMethod]::Get) {
                    $response.StatusCode = [System.Net.HttpStatusCode]::OK
                    $response.Content = [System.Net.Http.StringContent]::new('{}', [System.Text.Encoding]::UTF8, 'application/json')
                }
            }
            if ($Body) {
                $response.Content = [System.Net.Http.StringContent]::new($Body, [System.Text.Encoding]::UTF8, 'application/json')
            }
            [System.Threading.Tasks.Task]::FromResult($response)
        }.GetNewClosure()

        @{
            SubscriptionId = $script:subscriptionId
            ResourceGroupName = 'rg'
            HttpPipelinePrepend = @($marker, $responder)
            ErrorAction = 'Stop'
        }
    }

    It 'uses the stable API for <Command>' -TestCases @(
        @{ Command = 'Get-AzEdgeAction'; Method = 'GET'; Path = ''; Arguments = @{ Name = 'action' } }
        @{ Command = 'Get-AzEdgeActionVersion'; Method = 'GET'; Path = '/versions/v1'; Arguments = @{ EdgeActionName = 'action'; Version = 'v1' } }
        @{ Command = 'Get-AzEdgeActionExecutionFilter'; Method = 'GET'; Path = '/executionFilters/filter'; Arguments = @{ EdgeActionName = 'action'; ExecutionFilter = 'filter' } }
        @{ Command = 'New-AzEdgeAction'; Method = 'PUT'; Path = ''; Arguments = @{ Name = 'action'; Location = 'global'; SkuName = 'Standard'; SkuTier = 'Standard' } }
        @{ Command = 'New-AzEdgeActionVersion'; Method = 'PUT'; Path = '/versions/v1'; Arguments = @{ EdgeActionName = 'action'; Version = 'v1'; Location = 'global'; DeploymentType = 'file'; IsDefaultVersion = 'False' } }
        @{ Command = 'New-AzEdgeActionExecutionFilter'; Method = 'PUT'; Path = '/executionFilters/filter'; Arguments = @{ EdgeActionName = 'action'; ExecutionFilter = 'filter'; Location = 'global' } }
    ) {
        param($Command, $Method, $Path, $Arguments)
        $parameters = New-StableApiParameters
        & $Command @parameters @Arguments | Should -Not -BeNullOrEmpty
        $expectedCount = if ($Method -eq 'PUT') { 3 } else { 1 }
        $script:requests.Count | Should -Be $expectedCount
        $script:requests[0].Method | Should -Be $Method
        foreach ($request in $script:requests) {
            $request.Uri | Should -Be "https://management.azure.com$script:resourceId${Path}?api-version=2026-10-01"
        }
        if ($Method -eq 'PUT') {
            ($script:requests.Method -join ',') | Should -Be 'PUT,GET,GET'
        }
    }

    It 'serializes a tags-only Edge Action PATCH without SKU or properties' {
        $parameters = New-StableApiParameters
        Update-AzEdgeAction @parameters -Name action -Tag @{ Environment = 'Test' } | Out-Null
        $script:requests.Count | Should -Be 1
        $script:requests[0].Method | Should -Be 'PATCH'
        $script:requests[0].Uri | Should -Be "https://management.azure.com$script:resourceId`?api-version=2026-10-01"
        $body = $script:requests[0].Body | ConvertFrom-Json
        $body.tags.Environment | Should -Be 'Test'
        $body.PSObject.Properties.Name | Should -Not -Contain 'sku'
        $body.PSObject.Properties.Name | Should -Not -Contain 'properties'
    }

    It 'serializes the expanded execution filter update properties' {
        $parameters = New-StableApiParameters
        Update-AzEdgeActionExecutionFilter @parameters -EdgeActionName action -ExecutionFilter filter `
            -VersionId "$script:resourceId/versions/v1" -ExecutionFilterIdentifierHeaderName 'x-filter' `
            -ExecutionFilterIdentifierHeaderValue 'test' -Tag @{ Environment = 'Test' } | Out-Null
        $script:requests.Count | Should -Be 1
        $script:requests[0].Method | Should -Be 'PATCH'
        $script:requests[0].Uri | Should -Be "https://management.azure.com$script:resourceId/executionFilters/filter?api-version=2026-10-01"
        $body = $script:requests[0].Body | ConvertFrom-Json
        $body.properties.versionId | Should -Be "$script:resourceId/versions/v1"
        $body.properties.executionFilterIdentifierHeaderName | Should -Be 'x-filter'
        $body.properties.executionFilterIdentifierHeaderValue | Should -Be 'test'
        $body.tags.Environment | Should -Be 'Test'
    }

    It 'serializes the version validation values without inferring a mutation' {
        $parameters = New-StableApiParameters
        Update-AzEdgeActionVersion @parameters -EdgeActionName action -Version v1 `
            -DeploymentType file -IsDefaultVersion False | Out-Null
        $script:requests.Count | Should -Be 1
        $script:requests[0].Method | Should -Be 'PATCH'
        $script:requests[0].Uri | Should -Be "https://management.azure.com$script:resourceId/versions/v1?api-version=2026-10-01"
        $body = $script:requests[0].Body | ConvertFrom-Json
        $body.properties.deploymentType | Should -Be 'file'
        $body.properties.isDefaultVersion | Should -Be 'False'
    }

    $deleteCases = foreach ($status in @('OK', 'Accepted', 'NoContent')) {
        @{ Command = 'Remove-AzEdgeAction'; Status = $status; Path = ''; Arguments = @{ Name = 'action' } }
        @{ Command = 'Remove-AzEdgeActionVersion'; Status = $status; Path = '/versions/v1'; Arguments = @{ EdgeActionName = 'action'; Version = 'v1' } }
        @{ Command = 'Remove-AzEdgeActionExecutionFilter'; Status = $status; Path = '/executionFilters/filter'; Arguments = @{ EdgeActionName = 'action'; ExecutionFilter = 'filter' } }
    }
    It 'accepts DELETE <Status> for <Command>' -TestCases $deleteCases {
        param($Command, $Status, $Path, $Arguments)
        $parameters = New-StableApiParameters -StatusCode $Status -Body ''
        & $Command @parameters @Arguments -Confirm:$false -PassThru | Should -BeTrue
        $expectedCount = if ($Status -eq 'Accepted') { 2 } else { 1 }
        $script:requests.Count | Should -Be $expectedCount
        $script:requests[0].Method | Should -Be 'DELETE'
        foreach ($request in $script:requests) {
            $request.Uri | Should -Be "https://management.azure.com$script:resourceId${Path}?api-version=2026-10-01"
        }
        if ($Status -eq 'Accepted') {
            $script:requests[1].Method | Should -Be 'GET'
        }
    }

    It 'surfaces a DELETE service error' {
        $parameters = New-StableApiParameters -StatusCode BadRequest -Body '{"error":{"code":"InvalidRequest","message":"Rejected request"}}'
        { Remove-AzEdgeAction @parameters -Name action -Confirm:$false } | Should -Throw 'Rejected request'
        $script:requests.Count | Should -Be 1
    }

    It 'preserves the version-code POST route and decoded file output' {
        $parameters = New-StableApiParameters -Body '{"name":"v1","content":"aGVsbG8="}'
        $result = Get-AzEdgeActionVersionCode @parameters -EdgeActionName action -Version v1 -OutputPath $TestDrive
        $script:requests.Count | Should -Be 1
        $script:requests[0].Method | Should -Be 'POST'
        $script:requests[0].Uri | Should -Be "https://management.azure.com$script:resourceId/versions/v1/getVersionCode?api-version=2026-10-01"
        [System.Text.Encoding]::UTF8.GetString([System.IO.File]::ReadAllBytes($result.FilePath)) | Should -Be 'hello'
    }

    It 'preserves the swap-default POST route' {
        $parameters = New-StableApiParameters
        Switch-AzEdgeActionVersionDefault @parameters -EdgeActionName action -Version v1 -Confirm:$false | Out-Null
        $script:requests.Count | Should -Be 1
        $script:requests[0].Method | Should -Be 'POST'
        $script:requests[0].Uri | Should -Be "https://management.azure.com$script:resourceId/versions/v1/swapDefault?api-version=2026-10-01"
    }

    It 'preserves file deployment encoding and version code name' {
        $file = Join-Path $TestDrive 'action.js'
        [System.IO.File]::WriteAllText($file, 'export default {};', [System.Text.UTF8Encoding]::new($false))
        $parameters = New-StableApiParameters
        Deploy-AzEdgeActionVersionCode @parameters -EdgeActionName action -Version v1 -FilePath $file -Confirm:$false | Out-Null
        $script:requests.Count | Should -Be 1
        $script:requests[0].Method | Should -Be 'POST'
        $script:requests[0].Uri | Should -Be "https://management.azure.com$script:resourceId/versions/v1/deployVersionCode?api-version=2026-10-01"
        $body = $script:requests[0].Body | ConvertFrom-Json
        $body.name | Should -Be 'v1'
        [System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String($body.content)) | Should -Be 'export default {};'
    }
}
