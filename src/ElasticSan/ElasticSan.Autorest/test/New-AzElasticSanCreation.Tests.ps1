# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

if (-not ('ElasticSan.CreationTestResponder' -as [type])) {
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

    public class CreationTestResponder
    {
        public string ExpectedPath { get; set; }
        public bool Pending { get; set; }
        public string RequestBody { get; private set; }
        private int requestCount;
        public int RequestCount { get { return requestCount; } }
        public SendAsyncStep Step { get { return Respond; } }

        private async Task<HttpResponseMessage> Respond(HttpRequestMessage request, IEventListener callback, ISendAsync next)
        {
            var requestNumber = Interlocked.Increment(ref requestCount);
            if (requestNumber > 3 ||
                request.Method != (requestNumber == 1 ? HttpMethod.Put : HttpMethod.Get) ||
                request.RequestUri.AbsolutePath != ExpectedPath ||
                request.RequestUri.Query != "?api-version=2026-05-01-preview")
            {
                throw new InvalidOperationException("Unexpected creation request: " + request.Method + " " + request.RequestUri);
            }
            if (requestNumber == 1)
            {
                RequestBody = await request.Content.ReadAsStringAsync();
            }
            var response = new HttpResponseMessage(Pending ? HttpStatusCode.Accepted : HttpStatusCode.OK);
            response.RequestMessage = request;
            response.Headers.Location = request.RequestUri;
            response.Headers.TryAddWithoutValidation("Retry-After", "0");
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

Describe 'New-AzElasticSan creation forwarding' {
    $subscriptionId = '00000000-0000-0000-0000-000000000000'
    $sanId = "/subscriptions/$subscriptionId/resourceGroups/rg/providers/Microsoft.ElasticSan/elasticSans/san"
    $cases = foreach ($variant in @('Named', 'Identity', 'IdentityComponents')) {
        foreach ($version in @('Omitted', 'V1', 'V1ExplicitCapacity', 'V2', 'V2ZeroTotals')) {
            @{ Variant = $variant; Version = $version; AsJob = $false; IopsParameter = 'TotalIops' }
        }
        @{ Variant = $variant; Version = 'V2'; AsJob = $false; IopsParameter = 'TotalIop' }
        foreach ($skuName in @('Premium_ZRS', 'FutureSku')) {
            @{ Variant = $variant; Version = 'V1'; AsJob = $false; IopsParameter = 'TotalIops'; SkuName = $skuName }
        }
        foreach ($version in @('Omitted', 'V1')) {
            foreach ($capacity in @('BaseOnly', 'ExtendedOnly')) {
                @{ Variant = $variant; Version = $version; AsJob = $false; IopsParameter = 'TotalIops'; Capacity = $capacity }
            }
        }
        @{ Variant = $variant; Version = 'V2'; AsJob = $false; IopsParameter = 'TotalIops'; Capacity = 'Mixed' }
        foreach ($version in @('V1', 'V2')) {
            @{ Variant = $variant; Version = $version; AsJob = $false; IopsParameter = 'TotalIops'; NoWait = $true }
            @{ Variant = $variant; Version = $version; AsJob = $true; IopsParameter = 'TotalIops' }
        }
    }

    It '<Variant> <Version> <IopsParameter> SkuName=<SkuName> Capacity=<Capacity> AsJob=<AsJob> NoWait=<NoWait> forwards the requested capacities and version through the public command' -TestCases $cases {
        param($Variant, $Version, $AsJob, $IopsParameter, $SkuName = 'Premium_LRS', $Capacity, $NoWait = $false)

        $responder = [ElasticSan.CreationTestResponder]::new()
        $responder.ExpectedPath = $sanId
        $responder.Pending = $NoWait
        $mock = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.PipelineMock]::new(
            (Join-Path $TestDrive 'unused-creation-recording.json')
        )
        $mock.SetPlayback()
        $parameters = @{
            Location = 'eastus'
            SkuName = $SkuName
            HttpPipelinePrepend = @($mock, $responder.Step)
            Confirm = $false
            ErrorAction = 'Stop'
        }
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
        switch ($Version) {
            'V1' { $parameters.Version = 'V1' }
            'V1ExplicitCapacity' {
                $parameters.Version = 'V1'
                $parameters.BaseSizeTiB = 3
                $parameters.ExtendedCapacitySizeTiB = 0
            }
            'V2' {
                $parameters.Version = 'V2'
                $parameters.SkuName = 'ElasticSAN_LRS'
                $parameters.TotalSizeTiB = 20
                $parameters[$IopsParameter] = 100000
                $parameters.TotalMBps = 4000
            }
            'V2ZeroTotals' {
                $parameters.Version = 'V2'
                $parameters.SkuName = 'ElasticSAN_LRS'
                $parameters.TotalSizeTiB = 0
                $parameters[$IopsParameter] = 0
                $parameters.TotalMBps = 0
            }
        }
        switch ($Capacity) {
            'BaseOnly' { $parameters.BaseSizeTiB = 0 }
            'ExtendedOnly' { $parameters.ExtendedCapacitySizeTiB = 6 }
            'Mixed' {
                $parameters.BaseSizeTiB = 3
                $parameters.ExtendedCapacitySizeTiB = 6
            }
        }
        if ($NoWait) {
            $parameters.NoWait = $true
        }

        if ($AsJob) {
            $job = New-AzElasticSan @parameters -AsJob
            try {
                $completed = Wait-Job -Job $job -Timeout 30 -ErrorAction Stop
                $completed | Should -Not -BeNullOrEmpty
                $san = Receive-Job -Job $job -ErrorAction Stop
                $job.State | Should -Be 'Completed'
            } finally {
                Remove-Job -Job $job -Force -ErrorAction Stop
            }
        } else {
            $san = New-AzElasticSan @parameters
        }
        if ($NoWait) {
            $responder.RequestCount | Should -Be 1
            $san | Should -BeOfType ([Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.PowerShell.AsyncOperationResponse])
            ([uri]$san.Target).AbsolutePath | Should -Be $sanId
            ([uri]$san.Target).Query | Should -Be '?api-version=2026-05-01-preview'
        } else {
            $responder.RequestCount | Should -Be 3
            $san.Id | Should -Be $sanId
        }
        $body = $responder.RequestBody | ConvertFrom-Json
        $body.properties.sku.name | Should -Be $parameters.SkuName
        $properties = $body.properties
        if ($Version -like 'V2*') {
            $properties.version | Should -Be 'V2'
            $properties.totalSizeTiB | Should -Be $parameters.TotalSizeTiB
            $properties.totalIops | Should -Be $parameters[$IopsParameter]
            $properties.totalMBps | Should -Be $parameters.TotalMBps
            if ($Capacity -eq 'Mixed') {
                $properties.baseSizeTiB | Should -Be 3
                $properties.extendedCapacitySizeTiB | Should -Be 6
            } else {
                $properties.PSObject.Properties.Name | Should -Not -Contain 'baseSizeTiB'
                $properties.PSObject.Properties.Name | Should -Not -Contain 'extendedCapacitySizeTiB'
            }
            $properties.PSObject.Properties.Name | Should -Not -Contain 'totalIop'
        } else {
            $expectedBase = if ($Capacity -eq 'BaseOnly') { 0 } elseif ($Version -eq 'V1ExplicitCapacity') { 3 } else { 20 }
            $expectedExtended = if ($Capacity -eq 'ExtendedOnly') { 6 } else { 0 }
            $properties.baseSizeTiB | Should -Be $expectedBase
            $properties.extendedCapacitySizeTiB | Should -Be $expectedExtended
            $properties.PSObject.Properties.Name | Should -Not -Contain 'totalSizeTiB'
            $properties.PSObject.Properties.Name | Should -Not -Contain 'totalIops'
            $properties.PSObject.Properties.Name | Should -Not -Contain 'totalMBps'
            if ($Version -eq 'Omitted') {
                $properties.PSObject.Properties.Name | Should -Not -Contain 'version'
            } else {
                $properties.version | Should -Be 'V1'
            }
        }
    }

    $missingTotalCases = foreach ($variant in @('Named', 'Identity', 'IdentityComponents')) {
        foreach ($name in @('TotalSizeTiB', 'TotalIops', 'TotalMBps')) {
            @{ Variant = $variant; MissingParameter = $name }
        }
    }
    It '<Variant> rejects missing <MissingParameter> for V2 before sending a request' -TestCases $missingTotalCases {
        param($Variant, $MissingParameter)

        $responder = [ElasticSan.CreationTestResponder]::new()
        $responder.ExpectedPath = $sanId
        $mock = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.PipelineMock]::new(
            (Join-Path $TestDrive 'unused-missing-v2-total-recording.json')
        )
        $mock.SetPlayback()
        $parameters = @{
            Location = 'eastus'
            SkuName = 'ElasticSAN_LRS'
            Version = 'V2'
            TotalSizeTiB = 20
            TotalIops = 100000
            TotalMBps = 4000
            HttpPipelinePrepend = @($mock, $responder.Step)
            Confirm = $false
            ErrorAction = 'Stop'
        }
        switch ($Variant) {
            'Named' {
                $parameters.Name = 'san'
                $parameters.ResourceGroupName = 'rg'
                $parameters.SubscriptionId = $subscriptionId
            }
            'Identity' { $parameters.InputObject = @{ Id = $sanId } }
            'IdentityComponents' {
                $parameters.InputObject = @{
                    SubscriptionId = $subscriptionId
                    ResourceGroupName = 'rg'
                    ElasticSanName = 'san'
                }
            }
        }
        $parameters.Remove($MissingParameter)
        { New-AzElasticSan @parameters } | Should -Throw "Parameter '$MissingParameter' is required when Version is V2."
        $responder.RequestCount | Should -Be 0
    }

    It 'Completes all supported SKU names without closing the string input' {
        $command = Get-Command New-AzElasticSan -Module Az.ElasticSan -ErrorAction Stop
        $command.Parameters['SkuName'].ParameterType | Should -Be ([string])
        @($command.Parameters['SkuName'].Attributes | Where-Object { $_ -is [System.Management.Automation.ValidateSetAttribute] }).Count | Should -Be 0
        $line = 'New-AzElasticSan -SkuName '
        $completion = TabExpansion2 $line $line.Length
        foreach ($skuName in @('Premium_LRS', 'Premium_ZRS', 'ElasticSAN_LRS')) {
            $completion.CompletionMatches.CompletionText | Should -Contain $skuName
        }
    }

    It 'Exposes the V2 inputs on both public parameter sets' {
        $command = Get-Command New-AzElasticSan -Module Az.ElasticSan -ErrorAction Stop
        foreach ($parameterSet in $command.ParameterSets) {
            foreach ($name in @('Version', 'TotalSizeTiB', 'TotalIops', 'TotalMBps')) {
                $parameter = $parameterSet.Parameters | Where-Object Name -EQ $name
                $parameter | Should -Not -BeNullOrEmpty
                $parameter.IsMandatory | Should -Be $false
                $expectedType = if ($name -eq 'Version') { [string] } else { [long] }
                $parameter.ParameterType | Should -Be $expectedType
            }
            ($parameterSet.Parameters | Where-Object Name -EQ 'TotalIops').Aliases | Should -Contain 'TotalIop'
            $parameterSet.Parameters.Name | Should -Not -Contain 'TotalIop'
        }
        $line = 'New-AzElasticSan -Version '
        $completion = TabExpansion2 $line $line.Length
        $completion.CompletionMatches.CompletionText | Should -Contain 'V1'
        $completion.CompletionMatches.CompletionText | Should -Contain 'V2'
    }
}
