# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

if (-not ('ElasticSan.UpdateIopsTestResponder' -as [type])) {
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

    public class UpdateIopsTestResponder
    {
        public string ExpectedPath { get; set; }
        public string RequestBody { get; private set; }
        private int requestCount;
        public int RequestCount { get { return requestCount; } }
        public SendAsyncStep Step { get { return Respond; } }

        private async Task<HttpResponseMessage> Respond(HttpRequestMessage request, IEventListener callback, ISendAsync next)
        {
            if (Interlocked.Increment(ref requestCount) != 1 ||
                request.Method.Method != "PATCH" ||
                request.RequestUri.AbsolutePath != ExpectedPath ||
                request.RequestUri.Query != "?api-version=2026-05-01-preview")
            {
                throw new InvalidOperationException("Unexpected update request: " + request.Method + " " + request.RequestUri);
            }
            RequestBody = await request.Content.ReadAsStringAsync();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(
                "{\"id\":\"" + ExpectedPath + "\",\"name\":\"san\",\"location\":\"eastus\"," +
                "\"properties\":{\"provisioningState\":\"Succeeded\"}}",
                Encoding.UTF8, "application/json");
            return response;
        }
    }
}
'@
}

Describe 'Update-AzElasticSan IOPS parameter compatibility' {
    $subscriptionId = '00000000-0000-0000-0000-000000000000'
    $sanId = "/subscriptions/$subscriptionId/resourceGroups/rg/providers/Microsoft.ElasticSan/elasticSans/san"
    $cases = foreach ($variant in @('Named', 'Identity', 'IdentityComponents')) {
        foreach ($parameterName in @('TotalIops', 'TotalIop')) {
            foreach ($value in @(0L, 5000000000L)) {
                @{ Variant = $variant; IopsParameter = $parameterName; Iops = $value; AsJob = $false }
            }
        }
    }
    foreach ($parameterName in @('TotalIops', 'TotalIop')) {
        $cases += @{ Variant = 'Named'; IopsParameter = $parameterName; Iops = 100000L; AsJob = $true }
    }

    It '<Variant> <IopsParameter>=<Iops> AsJob=<AsJob> preserves the totalIops wire field' -TestCases $cases {
        param($Variant, $IopsParameter, $Iops, $AsJob)

        $responder = [ElasticSan.UpdateIopsTestResponder]::new()
        $responder.ExpectedPath = $sanId
        $mock = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.PipelineMock]::new(
            (Join-Path $TestDrive 'unused-update-iops-recording.json')
        )
        $mock.SetPlayback()
        $parameters = @{
            TotalMBps = 4000
            TotalSizeTiB = 20
            HttpPipelinePrepend = @($mock, $responder.Step)
            Confirm = $false
            ErrorAction = 'Stop'
        }
        $parameters[$IopsParameter] = $Iops
        switch ($Variant) {
            'Named' {
                $parameters.Name = 'san'
                $parameters.ResourceGroupName = 'rg'
                $parameters.SubscriptionId = $subscriptionId
            }
            'Identity' {
                $parameters.InputObject = @{ Id = $sanId }
            }
            'IdentityComponents' {
                $parameters.InputObject = @{
                    SubscriptionId = $subscriptionId
                    ResourceGroupName = 'rg'
                    ElasticSanName = 'san'
                }
            }
        }

        if ($AsJob) {
            $job = Update-AzElasticSan @parameters -AsJob
            try {
                $completed = Wait-Job -Job $job -Timeout 30 -ErrorAction Stop
                $completed | Should -Not -BeNullOrEmpty
                $san = Receive-Job -Job $job -ErrorAction Stop
                $job.State | Should -Be 'Completed'
            } finally {
                Remove-Job -Job $job -Force -ErrorAction Stop
            }
        } else {
            $san = Update-AzElasticSan @parameters
        }
        $responder.RequestCount | Should -Be 1
        $san.Id | Should -Be $sanId
        $body = $responder.RequestBody | ConvertFrom-Json
        $body.properties.totalIops | Should -Be $Iops
        $body.properties.totalMBps | Should -Be $parameters.TotalMBps
        $body.properties.totalSizeTiB | Should -Be $parameters.TotalSizeTiB
        $body.properties.PSObject.Properties.Name | Should -Contain 'totalIops'
        $body.properties.PSObject.Properties.Name | Should -Not -Contain 'totalIop'
    }

    It 'Exposes TotalIops as the canonical optional Int64 parameter with the legacy alias on every update parameter set' {
        $command = Get-Command Update-AzElasticSan -Module Az.ElasticSan -ErrorAction Stop
        foreach ($parameterSet in $command.ParameterSets) {
            $parameter = $parameterSet.Parameters | Where-Object Name -EQ 'TotalIops'
            $parameter | Should -Not -BeNullOrEmpty
            $parameter.ParameterType | Should -Be ([long])
            $parameter.IsMandatory | Should -Be $false
            $parameter.Aliases | Should -Contain 'TotalIop'
            $parameterSet.Parameters.Name | Should -Not -Contain 'TotalIop'
            $parameterSet.Parameters.Name | Should -Contain 'TotalMBps'
            $parameterSet.Parameters.Name | Should -Contain 'TotalSizeTiB'
        }
    }
}
