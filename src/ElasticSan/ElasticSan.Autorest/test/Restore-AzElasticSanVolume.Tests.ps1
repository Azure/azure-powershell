# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

# A C# responder can run on the job's worker thread without a PowerShell runspace.
# It intercepts every request, so no Azure login, live resource, or recording is needed.
if (-not ('ElasticSan.RestoreTestResponder' -as [type])) {
    $references = @([Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.SendAsyncStep].Assembly.Location)
    $referenceDirectory = Join-Path $PSHOME 'ref'
    if (Test-Path $referenceDirectory) {
        $references += (Get-ChildItem $referenceDirectory -Filter '*.dll').FullName
    } else {
        $references += [System.Net.Http.HttpRequestMessage].Assembly.Location
    }
    Add-Type -ReferencedAssemblies $references -TypeDefinition @'
namespace ElasticSan
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime;

    public class RestoreTestResponder
    {
        public string ExpectedPath { get; set; }
        public bool LongRunning { get; set; }
        private int requestCount;
        public int RequestCount { get { return requestCount; } }
        public SendAsyncStep Step { get { return Respond; } }

        private Task<HttpResponseMessage> Respond(HttpRequestMessage request, IEventListener callback, ISendAsync next)
        {
            var requestNumber = Interlocked.Increment(ref requestCount);
            var polling = LongRunning && requestNumber > 1;
            if (requestNumber > (LongRunning ? 4 : 1) ||
                request.Method != (polling ? HttpMethod.Get : HttpMethod.Post) ||
                request.RequestUri.AbsolutePath != (polling ? ExpectedPath + "/operations/restore" : ExpectedPath) ||
                request.RequestUri.Query != "?api-version=2026-05-01-preview")
            {
                throw new InvalidOperationException("Unexpected restore request: " + request.Method + " " + request.RequestUri);
            }
            if (LongRunning && requestNumber <= 2)
            {
                var accepted = new HttpResponseMessage(HttpStatusCode.Accepted);
                accepted.Headers.Location = new Uri(request.RequestUri.GetLeftPart(UriPartial.Authority) +
                    ExpectedPath + "/operations/restore?api-version=2026-05-01-preview");
                accepted.Headers.TryAddWithoutValidation("Retry-After", "0");
                accepted.Content = new StringContent("{}", Encoding.UTF8, "application/json");
                return Task.FromResult(accepted);
            }
            if (LongRunning && requestNumber == 3)
            {
                // Require a separate GET to retrieve the final volume.
                var completed = new HttpResponseMessage(HttpStatusCode.OK);
                completed.Content = new StringContent("{\"status\":\"Succeeded\"}", Encoding.UTF8, "application/json");
                return Task.FromResult(completed);
            }
            var volumeId = ExpectedPath.Substring(0, ExpectedPath.Length - "/restore".Length);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(
                "{\"id\":\"" + volumeId + "\",\"name\":\"volume\",\"type\":\"Microsoft.ElasticSan/elasticSans/volumegroups/volumes\"," +
                "\"properties\":{\"sizeGiB\":100,\"provisioningState\":\"Succeeded\"}}",
                Encoding.UTF8, "application/json");
            return Task.FromResult(response);
        }
    }
}
'@
}

Describe 'Restore-AzElasticSanVolume' {
    $subscriptionId = '00000000-0000-0000-0000-000000000000'
    $sanId = "/subscriptions/$subscriptionId/resourceGroups/rg/providers/Microsoft.ElasticSan/elasticSans/san"
    $groupId = "$sanId/volumegroups/group"
    $volumeId = "$groupId/volumes/volume"
    $cases = foreach ($variant in @('Restore', 'RestoreViaIdentityVolumegroup', 'RestoreViaIdentityElasticSan', 'RestoreViaIdentity', 'RestoreViaIdentityComponents')) {
        foreach ($longRunning in @($false, $true)) {
            @{ Variant = $variant; AsJob = $false; LongRunning = $longRunning }
            @{ Variant = $variant; AsJob = $true; LongRunning = $longRunning }
        }
    }

    It '<Variant> AsJob=<AsJob> LongRunning=<LongRunning> sends the restore request and returns the volume' -TestCases $cases {
        param($Variant, $AsJob, $LongRunning)

        $responder = [ElasticSan.RestoreTestResponder]::new()
        $responder.ExpectedPath = "$volumeId/restore"
        $responder.LongRunning = $LongRunning
        # The playback mock satisfies the proxy's authentication gate but must never
        # read a recording: the responder is the outermost step and answers directly.
        $mock = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.PipelineMock]::new(
            (Join-Path $TestDrive 'unused-restore-recording.json')
        )
        $mock.SetPlayback()
        $parameters = @{
            HttpPipelinePrepend = @($mock, $responder.Step)
            Confirm = $false
            ErrorAction = 'Stop'
        }
        switch ($Variant) {
            'Restore' {
                $parameters.SubscriptionId = $subscriptionId
                $parameters.ResourceGroupName = 'rg'
                $parameters.ElasticSanName = 'san'
                $parameters.VolumeGroupName = 'group'
                $parameters.Name = 'volume'
            }
            'RestoreViaIdentityVolumegroup' {
                $parameters.VolumegroupInputObject = @{ Id = $groupId }
                $parameters.Name = 'volume'
            }
            'RestoreViaIdentityElasticSan' {
                $parameters.ElasticSanInputObject = @{ Id = $sanId }
                $parameters.VolumeGroupName = 'group'
                $parameters.Name = 'volume'
            }
            'RestoreViaIdentity' {
                $parameters.InputObject = @{ Id = $volumeId }
            }
            'RestoreViaIdentityComponents' {
                $parameters.InputObject = @{
                    SubscriptionId = $subscriptionId
                    ResourceGroupName = 'rg'
                    ElasticSanName = 'san'
                    VolumeGroupName = 'group'
                    VolumeName = 'volume'
                }
            }
        }

        if ($AsJob) {
            $job = Restore-AzElasticSanVolume @parameters -AsJob
            try {
                $completed = Wait-Job -Job $job -Timeout 30 -ErrorAction Stop
                $completed | Should -Not -BeNullOrEmpty
                $volume = @(Receive-Job -Job $job -ErrorAction Stop)
                $job.State | Should -Be 'Completed'
            } finally {
                Remove-Job -Job $job -Force -ErrorAction Stop
            }
        } else {
            $volume = @(Restore-AzElasticSanVolume @parameters)
        }
        $expectedRequestCount = if ($LongRunning) { 4 } else { 1 }
        $responder.RequestCount | Should -Be $expectedRequestCount
        $volume.Count | Should -Be 1
        $volume[0].Id | Should -Be $volumeId
        $volume[0].Name | Should -Be 'volume'
        $volume[0].SizeGiB | Should -Be 100
        $volume[0].ProvisioningState | Should -Be 'Succeeded'
    }
}
