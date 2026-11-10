if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzStorageMoverReconcileJobDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzStorageMoverReconcileJobDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'StorageMoverScenarioPipeline RequestContract' -Tag @('PythonParity', 'Offline') {
    It 'Validate<Scenario>RequestBody' -TestCases @(
        @{ Scenario = 'BodylessGet'; Method = 'GET'; Actual = $null; Recorded = $null; Mismatch = $false },
        @{ Scenario = 'EquivalentJson'; Method = 'PATCH'; Actual = '{"isActive":false,"frequency":"Hourly"}'; Recorded = '{"frequency":"Hourly","isActive":false}'; Mismatch = $false },
        @{ Scenario = 'ChangedJson'; Method = 'PATCH'; Actual = '{"isActive":false}'; Recorded = '{"isActive":true}'; Mismatch = $true }
    ) {
        param($Method, $Actual, $Recorded, $Mismatch)
        $request = [System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::new($Method), 'https://management.azure.com/request')
        $recordedRequest = [System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::new($Method), $request.RequestUri)
        if ($null -ne $Actual) {
            $request.Content = [System.Net.Http.StringContent]::new($Actual)
        }
        if ($null -ne $Recorded) {
            $recordedRequest.Content = [System.Net.Http.StringContent]::new($Recorded)
        }
        $response = [System.Net.Http.HttpResponseMessage]::new(200)
        $response.RequestMessage = $recordedRequest
        $recorder = [pscustomobject]@{ Response = $response }
        $recorder | Add-Member -MemberType ScriptMethod -Name SendAsync -Value {
            param($request, $callback, $next)
            [System.Threading.Tasks.Task[System.Net.Http.HttpResponseMessage]]::FromResult($this.Response)
        }
        $pipeline = New-StorageMoverScenarioPipeline -Recorder $recorder -Mode playback
        try {
            if ($Mismatch) {
                { $pipeline.Invoke($request, $null, $null) } | Should -Throw 'Playback request body differs'
            } else {
                $pipeline.Invoke($request, $null, $null).GetAwaiter().GetResult() | Should -Be $response
            }
        } finally {
            $request.Dispose()
            $response.Dispose()
            $recordedRequest.Dispose()
        }
    }
}

Describe 'Invoke-AzStorageMoverReconcileJobDefinition' -Tag @('PythonParity', 'Offline') {
    It 'Reconcile using <ParameterSet>' -TestCases @(
        @{ ParameterSet = 'Reconcile' },
        @{ ParameterSet = 'ReconcileViaIdentityStorageMover' },
        @{ ParameterSet = 'ReconcileViaIdentityProject' },
        @{ ParameterSet = 'ReconcileViaIdentity' }
    ) {
        param($ParameterSet)
        $moverId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/rg/providers/Microsoft.StorageMover/storageMovers/mover"
        $projectId = "$moverId/projects/project"
        $jobId = "$projectId/jobDefinitions/job"
        $runId = "$jobId/jobRuns/run"
        $parameters = @{}
        switch ($ParameterSet) {
            'Reconcile' {
                $parameters = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = 'rg'; StorageMoverName = 'mover'; ProjectName = 'project'; JobDefinitionName = 'job' }
            }
            'ReconcileViaIdentityStorageMover' {
                $parameters = @{ StorageMoverInputObject = @{ Id = $moverId }; ProjectName = 'project'; JobDefinitionName = 'job' }
            }
            'ReconcileViaIdentityProject' {
                $parameters = @{ ProjectInputObject = @{ Id = $projectId }; JobDefinitionName = 'job' }
            }
            'ReconcileViaIdentity' {
                $parameters = @{ InputObject = @{ Id = $jobId } }
            }
        }
        $capture = Invoke-StorageMoverTestRequest -Response @{ jobRunResourceId = $runId } -Command {
            param($pipeline)
            Invoke-AzStorageMoverReconcileJobDefinition @parameters -HttpPipelinePrepend $pipeline
        }
        $capture.Requests.Count | Should -Be 1
        $capture.Requests[0].Method | Should -Be 'POST'
        $capture.Requests[0].Uri.AbsolutePath | Should -Be "$jobId/reconcileJob"
        $capture.Requests[0].Uri.Query | Should -Be '?api-version=2026-05-01'
        $capture.Requests[0].Content | Should -BeNullOrEmpty
        $capture.Result.JobRunResourceId1 | Should -Be $runId
    }

    It 'PropagatesReconcileServiceErrors' {
        {
            Invoke-StorageMoverTestRequest -StatusCode 400 -Response @{
                error = @{ code = 'InvalidRequestPropertyValue'; message = 'Reconciliation rejected' }
            } -Command {
                param($pipeline)
                Invoke-AzStorageMoverReconcileJobDefinition -SubscriptionId $env.SubscriptionId -ResourceGroupName 'rg' -StorageMoverName 'mover' -ProjectName 'project' -JobDefinitionName 'job' -HttpPipelinePrepend $pipeline -ErrorAction Stop
            }
        } | Should -Throw 'Reconciliation rejected'
    }
}
