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
        public string ExpectedLocation { get; set; } = "eastus";
        public int ExpectedCreateCount { get; set; } = 1;
        public bool Pending { get; set; }
        public string RequestBody { get; private set; }
        public string SkuResponseBody { get; set; } =
            "{\"value\":[" +
            "{\"resourceType\":\"elasticSans\",\"name\":\"Premium_LRS\",\"locations\":[\"eastus\"],\"capabilities\":[{\"name\":\"elasticSanMaxTotalCapacityTiB\",\"value\":\"9999\"}]}," +
            "{\"resourceType\":\"elasticSans\",\"name\":\"ElasticSAN_LRS\",\"locations\":[\"westus\"],\"capabilities\":[{\"name\":\"elasticSanMaxTotalCapacityTiB\",\"value\":\"9999\"}]}," +
            "{\"resourceType\":\"elasticSans\",\"name\":\"ElasticSAN_ZRS\",\"locations\":[\"eastus\"],\"capabilities\":[{\"name\":\"elasticSanMaxTotalCapacityTiB\",\"value\":\"10\"}]}," +
            "{\"resourceType\":\"elasticSans\",\"name\":\"ElasticSAN_LRS\",\"locations\":[\"eastus\"],\"capabilities\":[{\"name\":\"elasticSanMaxSizeTiB\",\"value\":\"9999\"},{\"name\":\"elasticSanMaxTotalCapacityTiB\",\"value\":\"80\"}]}]}";
        public HttpStatusCode SkuStatusCode { get; set; } = HttpStatusCode.OK;
        private int requestCount;
        private int skuRequestCount;
        public int RequestCount { get { return requestCount; } }
        public int SkuRequestCount { get { return skuRequestCount; } }
        public SendAsyncStep Step { get { return Respond; } }

        private async Task<HttpResponseMessage> Respond(HttpRequestMessage request, IEventListener callback, ISendAsync next)
        {
            var skuPath = "/subscriptions/" + ExpectedPath.Split('/')[2] + "/providers/Microsoft.ElasticSan/skus";
            if (request.RequestUri.AbsolutePath == skuPath)
            {
                if (Interlocked.Increment(ref skuRequestCount) > ExpectedCreateCount ||
                    request.Method != HttpMethod.Get ||
                    Uri.UnescapeDataString(request.RequestUri.Query) != "?api-version=2026-05-01-preview&$filter=location eq " + ExpectedLocation)
                {
                    throw new InvalidOperationException("Unexpected SKU request: " + request.Method + " " + request.RequestUri);
                }
                return new HttpResponseMessage(SkuStatusCode)
                {
                    RequestMessage = request,
                    Content = new StringContent(SkuResponseBody, Encoding.UTF8, "application/json")
                };
            }
            var requestNumber = Interlocked.Increment(ref requestCount);
            if (requestNumber > 3 * ExpectedCreateCount ||
                request.Method != (requestNumber % 3 == 1 ? HttpMethod.Put : HttpMethod.Get) ||
                request.RequestUri.AbsolutePath != ExpectedPath ||
                request.RequestUri.Query != "?api-version=2026-05-01-preview")
            {
                throw new InvalidOperationException("Unexpected creation request: " + request.Method + " " + request.RequestUri);
            }
            if (requestNumber % 3 == 1)
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
        foreach ($version in @('Omitted', 'V1', 'V2')) {
            foreach ($enforcement in @('Enabled', 'Disabled', 'None')) {
                if ($version -ne 'V2' -or $enforcement -eq 'Enabled') {
                    @{ Variant = $variant; Version = $version; AsJob = $false; IopsParameter = 'TotalIops'; Enforcement = $enforcement }
                }
            }
        }
        foreach ($scenario in @('BelowLimit', 'AtLimit', 'Int64Max', 'ExplicitLimit', 'ExplicitAll', 'ExplicitZeros', 'Partial', 'DifferentRegion', 'DifferentSku', 'Int64RegionalLimit')) {
            @{ Variant = $variant; Version = 'V2'; AsJob = $false; IopsParameter = 'TotalIops'; AutoScaleScenario = $scenario }
        }
        foreach ($location in @('East US', 'EASTUS', ' East US ', "East`tUS")) {
            @{ Variant = $variant; Version = 'V2'; AsJob = $false; IopsParameter = 'TotalIops'; Location = $location }
        }
        foreach ($version in @('Omitted', 'V1', 'V2')) {
            @{ Variant = $variant; Version = $version; AsJob = $false; IopsParameter = 'TotalIops'; Location = 'East US'; AutoScaleScenario = 'ExplicitAll' }
        }
    }

    It '<Variant> <Version> <IopsParameter> SkuName=<SkuName> Capacity=<Capacity> AsJob=<AsJob> NoWait=<NoWait> Enforcement=<Enforcement> AutoScale=<AutoScaleScenario> Location=<Location> forwards the requested capacities and version through the public command' -TestCases $cases {
        param($Variant, $Version, $AsJob, $IopsParameter, $SkuName = 'Premium_LRS', $Capacity, $NoWait = $false, $Enforcement, $AutoScaleScenario, $Location = 'eastus')

        $responder = [ElasticSan.CreationTestResponder]::new()
        $responder.ExpectedPath = $sanId
        $responder.Pending = $NoWait
        $mock = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.PipelineMock]::new(
            (Join-Path $TestDrive 'unused-creation-recording.json')
        )
        $mock.SetPlayback()
        $parameters = @{
            Location = $Location
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
                $parameters.InputObject = @{ Id = $sanId; SubscriptionId = '11111111-1111-1111-1111-111111111111' }
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
        if ($Enforcement) {
            $parameters.AutoScalePolicyEnforcement = $Enforcement
        }
        switch ($AutoScaleScenario) {
            'BelowLimit' { $parameters.TotalSizeTiB = 10 }
            'AtLimit' { $parameters.TotalSizeTiB = 16 }
            'Int64Max' { $parameters.TotalSizeTiB = [long]::MaxValue }
            'ExplicitLimit' { $parameters.CapacityUnitScaleUpLimitTiB = 500 }
            'ExplicitAll' {
                $parameters.CapacityUnitScaleUpLimitTiB = 500
                $parameters.IncreaseCapacityUnitByTiB = 7
                $parameters.UnusedSizeTiB = 3
                $parameters.AutoScalePolicyEnforcement = 'Enabled'
            }
            'ExplicitZeros' {
                $parameters.CapacityUnitScaleUpLimitTiB = 0
                $parameters.IncreaseCapacityUnitByTiB = 0
                $parameters.UnusedSizeTiB = 0
            }
            'Partial' {
                $parameters.IncreaseCapacityUnitByTiB = 7
                $parameters.UnusedSizeTiB = 3
            }
            'DifferentRegion' {
                $parameters.Location = 'westus'
                $responder.ExpectedLocation = 'westus'
            }
            'DifferentSku' { $parameters.SkuName = 'ElasticSAN_ZRS' }
            'Int64RegionalLimit' {
                $parameters.TotalSizeTiB = [long]::MaxValue
                $responder.SkuResponseBody = $responder.SkuResponseBody.Replace('"value":"80"', '"value":"9223372036854775807"')
            }
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
        $body.location | Should -Be $parameters.Location
        $body.properties.sku.name | Should -Be $parameters.SkuName
        $properties = $body.properties
        $autoscale = $properties.autoScaleProperties.scaleUpProperties
        if ($parameters.ContainsKey('AutoScalePolicyEnforcement')) {
            $autoscale.autoScalePolicyEnforcement | Should -Be $parameters.AutoScalePolicyEnforcement
        }
        if ($Version -like 'V2*') {
            $expectedEnforcement = if ($parameters.ContainsKey('AutoScalePolicyEnforcement')) { $parameters.AutoScalePolicyEnforcement } else { 'Enabled' }
            $expectedIncrease = if ($parameters.ContainsKey('IncreaseCapacityUnitByTiB')) { $parameters.IncreaseCapacityUnitByTiB } else { 1 }
            $expectedUnused = if ($parameters.ContainsKey('UnusedSizeTiB')) { $parameters.UnusedSizeTiB } else { 1 }
            $regionalLimit = switch ($AutoScaleScenario) {
                'DifferentRegion' { 9999 }
                'DifferentSku' { 10 }
                'Int64RegionalLimit' { [long]::MaxValue }
                default { 80 }
            }
            $expectedLimit = if ($parameters.ContainsKey('CapacityUnitScaleUpLimitTiB')) { $parameters.CapacityUnitScaleUpLimitTiB } else { [Math]::Min(([decimal]$parameters.TotalSizeTiB * 5), [decimal]$regionalLimit) }
            $expectedSkuRequests = if ($parameters.ContainsKey('CapacityUnitScaleUpLimitTiB')) { 0 } else { 1 }
            $responder.SkuRequestCount | Should -Be $expectedSkuRequests
            $autoscale.autoScalePolicyEnforcement | Should -Be $expectedEnforcement
            $autoscale.increaseCapacityUnitByTiB | Should -Be $expectedIncrease
            $autoscale.unusedSizeTiB | Should -Be $expectedUnused
            $autoscale.capacityUnitScaleUpLimitTiB | Should -Be $expectedLimit
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
            $responder.SkuRequestCount | Should -Be 0
            if (-not $parameters.ContainsKey('AutoScalePolicyEnforcement')) {
                $properties.PSObject.Properties.Name | Should -Not -Contain 'autoScaleProperties'
            }
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
        $responder.SkuRequestCount | Should -Be 0
    }

    $disabledCases = foreach ($variant in @('Named', 'Identity', 'IdentityComponents')) {
        foreach ($enforcement in @('Disabled', 'dIsAbLeD', 'None', 'nOnE')) {
            foreach ($explicitLimit in @($false, $true)) {
                @{ Variant = $variant; Enforcement = $enforcement; ExplicitLimit = $explicitLimit }
            }
        }
    }
    It '<Variant> rejects <Enforcement> autoscale for V2 with ExplicitLimit=<ExplicitLimit> before sending a request' -TestCases $disabledCases {
        param($Variant, $Enforcement, $ExplicitLimit)

        $responder = [ElasticSan.CreationTestResponder]::new()
        $responder.ExpectedPath = $sanId
        $mock = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.PipelineMock]::new(
            (Join-Path $TestDrive 'unused-disabled-v2-autoscale-recording.json')
        )
        $mock.SetPlayback()
        $parameters = @{
            Location = 'eastus'
            SkuName = 'ElasticSAN_LRS'
            Version = 'V2'
            TotalSizeTiB = 20
            TotalIops = 100000
            TotalMBps = 4000
            AutoScalePolicyEnforcement = $Enforcement
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
        if ($ExplicitLimit) {
            $parameters.CapacityUnitScaleUpLimitTiB = 100
        }
        { New-AzElasticSan @parameters } | Should -Throw 'AutoScalePolicyEnforcement cannot be Disabled or None when Version is V2.'
        $responder.RequestCount | Should -Be 0
        $responder.SkuRequestCount | Should -Be 0
    }

    It 'Resolves V2 autoscale defaults separately for each piped SAN identity' {
        $responder = [ElasticSan.CreationTestResponder]::new()
        $responder.ExpectedPath = $sanId
        $responder.ExpectedCreateCount = 2
        $mock = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.PipelineMock]::new(
            (Join-Path $TestDrive 'unused-piped-v2-autoscale-recording.json')
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
        $identities = @(
            [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.ElasticSanIdentity]@{ Id = $sanId },
            [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.ElasticSanIdentity]@{ Id = $sanId }
        )
        $sans = @($identities | New-AzElasticSan @parameters)
        $sans.Count | Should -Be 2
        $responder.SkuRequestCount | Should -Be 2
        $responder.RequestCount | Should -Be 6
    }

    $lookupFailureCases = @(
        @{ Scenario = 'NoSku'; Skus = @(); ExpectedMessage = 'found 0.' }
        @{ Scenario = 'WrongSku'; Skus = @(@{ resourceType = 'elasticSans'; name = 'Premium_LRS'; locations = @('eastus') }); ExpectedMessage = 'found 0.' }
        @{ Scenario = 'WrongRegion'; Skus = @(@{ resourceType = 'elasticSans'; name = 'ElasticSAN_LRS'; locations = @('westus') }); ExpectedMessage = 'found 0.' }
        @{ Scenario = 'WrongResourceType'; Skus = @(@{ resourceType = 'volumes'; name = 'ElasticSAN_LRS'; locations = @('eastus') }); ExpectedMessage = 'found 0.' }
    )
    $matchingSku = @{ resourceType = 'elasticSans'; name = 'ElasticSAN_LRS'; locations = @('eastus') }
    $lookupFailureCases += @{ Scenario = 'DuplicateSku'; Skus = @($matchingSku, $matchingSku); ExpectedMessage = 'found 2.' }
    foreach ($value in @('missing', 'invalid', '0', '-1', '80.5', '9223372036854775808')) {
        $sku = $matchingSku.Clone()
        $sku.capabilities = if ($value -eq 'missing') { @() } else { @(@{ name = 'elasticSanMaxTotalCapacityTiB'; value = $value }) }
        $lookupFailureCases += @{ Scenario = "Capability$value"; Skus = @($sku); ExpectedMessage = 'must provide one positive integer elasticSanMaxTotalCapacityTiB value' }
    }
    $duplicateCapabilitySku = $matchingSku.Clone()
    $duplicateCapabilitySku.capabilities = @(
        @{ name = 'elasticSanMaxTotalCapacityTiB'; value = '80' },
        @{ name = 'elasticSanMaxTotalCapacityTiB'; value = '100' }
    )
    $lookupFailureCases += @{ Scenario = 'DuplicateCapability'; Skus = @($duplicateCapabilitySku); ExpectedMessage = 'must provide one positive integer elasticSanMaxTotalCapacityTiB value' }
    $lookupFailureCases += @{ Scenario = 'Forbidden'; Skus = @(); ExpectedMessage = 'SKU lookup denied' }
    It 'Rejects <Scenario> during the SKU lookup without creating a SAN' -TestCases $lookupFailureCases {
        param($Scenario, $Skus, $ExpectedMessage)

        $responder = [ElasticSan.CreationTestResponder]::new()
        $responder.ExpectedPath = $sanId
        $responder.SkuResponseBody = @{ value = @($Skus) } | ConvertTo-Json -Depth 10 -Compress
        if ($Scenario -eq 'Forbidden') {
            $responder.SkuStatusCode = [System.Net.HttpStatusCode]::Forbidden
            $responder.SkuResponseBody = '{"error":{"code":"AuthorizationFailed","message":"SKU lookup denied"}}'
        }
        $mock = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.PipelineMock]::new(
            (Join-Path $TestDrive 'unused-v2-sku-failure-recording.json')
        )
        $mock.SetPlayback()
        $parameters = @{
            Name = 'san'
            ResourceGroupName = 'rg'
            SubscriptionId = $subscriptionId
            Location = 'eastus'
            SkuName = 'ElasticSAN_LRS'
            Version = 'V2'
            TotalSizeTiB = 20
            TotalIops = 100000
            TotalMBps = 4000
            HttpPipelinePrepend = @($mock, $responder.Step)
            Confirm = $false
            ErrorAction = 'Continue'
        }
        { New-AzElasticSan @parameters } | Should -Throw $ExpectedMessage
        $responder.SkuRequestCount | Should -Be 1
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
