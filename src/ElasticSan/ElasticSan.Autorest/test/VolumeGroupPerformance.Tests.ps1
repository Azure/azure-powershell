# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

if (-not ('ElasticSan.VolumeGroupPerformanceTestResponder' -as [type])) {
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

    public class VolumeGroupPerformanceTestResponder
    {
        public string ExpectedPath { get; set; }
        public bool Create { get; set; }
        public bool Pending { get; set; }
        public string ResponseProperties { get; set; }
        public string Method { get; set; }
        public string RequestBody { get; private set; }
        private int requestCount;
        public int RequestCount { get { return requestCount; } }
        public SendAsyncStep Step { get { return Respond; } }

        private async Task<HttpResponseMessage> Respond(HttpRequestMessage request, IEventListener callback, ISendAsync next)
        {
            var requestNumber = Interlocked.Increment(ref requestCount);
            var expectedMethod = requestNumber == 1 ? (Method ?? (Create ? "PUT" : "PATCH")) : "GET";
            if (requestNumber > (Create ? 3 : 1) ||
                request.Method.Method != expectedMethod ||
                request.RequestUri.AbsolutePath != ExpectedPath ||
                request.RequestUri.Query != "?api-version=2026-05-01-preview")
            {
                throw new InvalidOperationException("Unexpected volume-group request: " + request.Method + " " + request.RequestUri);
            }
            if (requestNumber == 1 && request.Content != null)
            {
                RequestBody = await request.Content.ReadAsStringAsync();
            }
            var response = new HttpResponseMessage(Pending ? HttpStatusCode.Accepted : HttpStatusCode.OK);
            response.RequestMessage = request;
            response.Headers.Location = request.RequestUri;
            response.Headers.TryAddWithoutValidation("Retry-After", "0");
            response.Content = new StringContent(
                "{\"id\":\"" + ExpectedPath + "\",\"name\":\"group\"," +
                "\"properties\":{\"provisioningState\":\"Succeeded\"" + ResponseProperties + "}}",
                Encoding.UTF8, "application/json");
            return response;
        }
    }
}
'@
}

Describe 'Elastic SAN volume-group performance forwarding' {
    $subscriptionId = '00000000-0000-0000-0000-000000000000'
    $sanId = "/subscriptions/$subscriptionId/resourceGroups/rg/providers/Microsoft.ElasticSan/elasticSans/san"
    $groupId = "$sanId/volumegroups/group"
    $identityId = "/subscriptions/$subscriptionId/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity"
    $cases = foreach ($operation in @('New', 'Update')) {
        foreach ($variant in @('Named', 'Identity', 'IdentityComponents', 'ElasticSanIdentity', 'ElasticSanIdentityComponents')) {
            foreach ($configuration in @('Legacy', 'Performance', 'Zero', 'Alias')) {
                @{ Operation = $operation; Variant = $variant; Configuration = $configuration; AsJob = $false }
            }
            if ($operation -eq 'New') {
                @{ Operation = $operation; Variant = $variant; Configuration = 'GeneralPurpose'; AsJob = $false }
                foreach ($encryptionInTransit in @($true, $false)) {
                    foreach ($dataIntegrity in @($true, $false)) {
                        @{ Operation = $operation; Variant = $variant; Configuration = 'Legacy'; AsJob = $false; EncryptionInTransit = $encryptionInTransit; DataIntegrity = $dataIntegrity }
                    }
                    foreach ($mode in @('AsJob', 'NoWait')) {
                        @{ Operation = $operation; Variant = $variant; Configuration = 'Legacy'; AsJob = ($mode -eq 'AsJob'); NoWait = ($mode -eq 'NoWait'); EncryptionInTransit = $encryptionInTransit }
                    }
                }
            }
            foreach ($protocolType in @('None', 'DirectAttach', 'FutureProtocol')) {
                @{ Operation = $operation; Variant = $variant; Configuration = 'Legacy'; AsJob = $false; ProtocolType = $protocolType }
            }
            foreach ($configuration in @('Legacy', 'Performance')) {
                @{ Operation = $operation; Variant = $variant; Configuration = $configuration; AsJob = $false; NoWait = $true }
            }
            @{ Operation = $operation; Variant = $variant; Configuration = 'Performance'; AsJob = $true }
            @{ Operation = $operation; Variant = $variant; Configuration = 'Legacy'; AsJob = $true; ProtocolType = 'DirectAttach' }
        }
        foreach ($configuration in @('IopsOnly', 'MBpsOnly', 'Maximum')) {
            @{ Operation = $operation; Variant = 'Named'; Configuration = $configuration; AsJob = $false }
        }
    }

    It '<Operation> <Variant> <Configuration> ProtocolType=<ProtocolType> EncryptionInTransit=<EncryptionInTransit> DataIntegrity=<DataIntegrity> AsJob=<AsJob> NoWait=<NoWait> forwards performance settings without changing existing inputs' -TestCases $cases {
        param($Operation, $Variant, $Configuration, $AsJob, $ProtocolType = 'Iscsi', $NoWait = $false, $EncryptionInTransit = $null, $DataIntegrity = $false)

        $responder = [ElasticSan.VolumeGroupPerformanceTestResponder]::new()
        $responder.ExpectedPath = $groupId
        $responder.Create = $Operation -eq 'New'
        $responder.Pending = $NoWait
        $mock = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.PipelineMock]::new(
            (Join-Path $TestDrive 'unused-volume-group-performance-recording.json')
        )
        $mock.SetPlayback()
        $parameters = @{
            ProtocolType = $ProtocolType
            Encryption = 'EncryptionAtRestWithPlatformKey'
            EnforceDataIntegrityCheckForIscsi = $DataIntegrity
            HttpPipelinePrepend = @($mock, $responder.Step)
            Confirm = $false
            WarningAction = 'SilentlyContinue'
            ErrorAction = 'Stop'
        }
        switch ($Variant) {
            'Named' {
                $parameters.Name = 'group'
                $parameters.ResourceGroupName = 'rg'
                $parameters.ElasticSanName = 'san'
                $parameters.SubscriptionId = $subscriptionId
            }
            'Identity' {
                $parameters.InputObject = @{ Id = $groupId }
            }
            'IdentityComponents' {
                $parameters.InputObject = @{
                    SubscriptionId = $subscriptionId
                    ResourceGroupName = 'rg'
                    ElasticSanName = 'san'
                    VolumeGroupName = 'group'
                }
            }
            'ElasticSanIdentity' {
                $parameters.ElasticSanInputObject = @{ Id = $sanId }
                $parameters.Name = 'group'
            }
            'ElasticSanIdentityComponents' {
                $parameters.ElasticSanInputObject = @{
                    SubscriptionId = $subscriptionId
                    ResourceGroupName = 'rg'
                    ElasticSanName = 'san'
                }
                $parameters.Name = 'group'
            }
        }

        $hasIops = $Configuration -in @('Performance', 'Zero', 'Alias', 'IopsOnly', 'Maximum')
        $hasMBps = $Configuration -in @('Performance', 'Zero', 'Alias', 'MBpsOnly', 'Maximum')
        $expectedIops = if ($Configuration -eq 'Zero') { 0 } elseif ($Configuration -eq 'Maximum') { [int]::MaxValue } else { 10000 }
        $expectedMBps = if ($Configuration -eq 'Zero') { 0 } elseif ($Configuration -eq 'Maximum') { [int]::MaxValue } else { 400 }
        if ($hasIops) {
            $iopsName = if ($Configuration -eq 'Alias') { 'ReservedIop' } else { 'ReservedIops' }
            $parameters[$iopsName] = $expectedIops
        }
        if ($hasMBps) {
            $parameters.ReservedMBps = $expectedMBps
        }
        if ($null -ne $EncryptionInTransit) {
            $parameters.EncryptionInTransit = $EncryptionInTransit
            $responder.ResponseProperties = ',"encryptionInTransit":' + $EncryptionInTransit.ToString().ToLowerInvariant()
        }
        if ($Operation -eq 'New') {
            $parameters.IdentityType = 'UserAssigned'
            $parameters.IdentityUserAssignedIdentityId = $identityId
            if ($Configuration -ne 'Legacy') {
                $parameters.QualityOfService = if ($Configuration -eq 'GeneralPurpose') { 'GeneralPurpose' } else { 'PerformanceCritical' }
            }
        }

        $commandName = "$Operation-AzElasticSanVolumeGroup"
        if ($NoWait) {
            $parameters.NoWait = $true
        }
        if ($AsJob) {
            $job = & $commandName @parameters -AsJob
            try {
                $completed = Wait-Job -Job $job -Timeout 30 -ErrorAction Stop
                $completed | Should -Not -BeNullOrEmpty
                $group = Receive-Job -Job $job -ErrorAction Stop
                $job.State | Should -Be 'Completed'
            } finally {
                Remove-Job -Job $job -Force -ErrorAction Stop
            }
        } else {
            $group = & $commandName @parameters
        }
        $expectedRequests = if ($Operation -eq 'New' -and -not $NoWait) { 3 } else { 1 }
        $responder.RequestCount | Should -Be $expectedRequests
        if ($NoWait) {
            $group | Should -BeOfType ([Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.PowerShell.AsyncOperationResponse])
            ([uri]$group.Target).AbsolutePath | Should -Be $groupId
            ([uri]$group.Target).Query | Should -Be '?api-version=2026-05-01-preview'
        } else {
            $group.Id | Should -Be $groupId
        }
        $body = $responder.RequestBody | ConvertFrom-Json
        $properties = $body.properties
        $properties.protocolType | Should -Be $ProtocolType
        $properties.encryption | Should -Be 'EncryptionAtRestWithPlatformKey'
        $properties.enforceDataIntegrityCheckForIscsi | Should -Be $DataIntegrity
        if ($null -ne $EncryptionInTransit) {
            $properties.PSObject.Properties.Name | Should -Contain 'encryptionInTransit'
            $properties.encryptionInTransit | Should -Be $EncryptionInTransit
            if (-not $NoWait) {
                $group.EncryptionInTransit | Should -Be $EncryptionInTransit
            }
        } else {
            $properties.PSObject.Properties.Name | Should -Not -Contain 'encryptionInTransit'
        }
        if ($hasIops) {
            $properties.PSObject.Properties.Name | Should -Contain 'reservedIops'
            $properties.reservedIops | Should -Be $expectedIops
        } else {
            $properties.PSObject.Properties.Name | Should -Not -Contain 'reservedIops'
        }
        if ($hasMBps) {
            $properties.PSObject.Properties.Name | Should -Contain 'reservedMBps'
            $properties.reservedMBps | Should -Be $expectedMBps
        } else {
            $properties.PSObject.Properties.Name | Should -Not -Contain 'reservedMBps'
        }
        $properties.PSObject.Properties.Name | Should -Not -Contain 'reservedIop'
        if ($Operation -eq 'New') {
            $body.identity.type | Should -Be 'UserAssigned'
            $body.identity.userAssignedIdentities.PSObject.Properties.Name | Should -Contain $identityId
            if ($Configuration -ne 'Legacy') {
                $properties.qualityOfService | Should -Be $parameters.QualityOfService
            } else {
                $properties.PSObject.Properties.Name | Should -Not -Contain 'qualityOfService'
            }
        } else {
            $properties.PSObject.Properties.Name | Should -Not -Contain 'qualityOfService'
        }
    }

    It '<Command> reads plural IOPS outputs and singular compatibility properties' -TestCases @(
        @{ Command = 'Get-AzElasticSan'; Property = 'TotalReservedIops'; Alias = 'TotalReservedIop'; WireName = 'totalReservedIops'; VolumeGroup = $false },
        @{ Command = 'Get-AzElasticSanVolumeGroup'; Property = 'ReservedIops'; Alias = 'ReservedIop'; WireName = 'reservedIops'; VolumeGroup = $true }
    ) {
        param($Command, $Property, $Alias, $WireName, $VolumeGroup)

        $responder = [ElasticSan.VolumeGroupPerformanceTestResponder]::new()
        $responder.ExpectedPath = if ($VolumeGroup) { $groupId } else { $sanId }
        $responder.Method = 'GET'
        $responder.ResponseProperties = ',"' + $WireName + '":10000'
        $mock = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.PipelineMock]::new(
            (Join-Path $TestDrive 'unused-iops-read-recording.json')
        )
        $mock.SetPlayback()
        $parameters = @{
            Name = 'san'
            ResourceGroupName = 'rg'
            SubscriptionId = $subscriptionId
            HttpPipelinePrepend = @($mock, $responder.Step)
            ErrorAction = 'Stop'
        }
        if ($VolumeGroup) {
            $parameters.Name = 'group'
            $parameters.ElasticSanName = 'san'
        }
        $resource = & $Command @parameters
        $responder.RequestCount | Should -Be 1
        $resource.Id | Should -Be $responder.ExpectedPath
        $resource.$Property | Should -Be 10000
        $resource.$Alias | Should -Be 10000
    }

    It '<Operation> completes all supported protocols without closing the string input' -TestCases @(@{ Operation = 'New' }, @{ Operation = 'Update' }) {
        param($Operation)

        $command = Get-Command "$Operation-AzElasticSanVolumeGroup" -Module Az.ElasticSan -ErrorAction Stop
        $command.Parameters['ProtocolType'].ParameterType | Should -Be ([string])
        @($command.Parameters['ProtocolType'].Attributes | Where-Object { $_ -is [System.Management.Automation.ValidateSetAttribute] }).Count | Should -Be 0
        $line = "$Operation-AzElasticSanVolumeGroup -ProtocolType "
        $completion = TabExpansion2 $line $line.Length
        foreach ($protocolType in @('Iscsi', 'None', 'DirectAttach')) {
            $completion.CompletionMatches.CompletionText | Should -Contain $protocolType
        }
    }

    It 'Exposes optional Int32 reservations on every public parameter set and creation-only quality of service and encryption in transit' {
        foreach ($operation in @('New', 'Update')) {
            $command = Get-Command "$operation-AzElasticSanVolumeGroup" -Module Az.ElasticSan -ErrorAction Stop
            foreach ($parameterSet in $command.ParameterSets) {
                foreach ($name in @('ReservedIops', 'ReservedMBps')) {
                    $parameter = $parameterSet.Parameters | Where-Object Name -EQ $name
                    $parameter | Should -Not -BeNullOrEmpty
                    $parameter.ParameterType | Should -Be ([int])
                    $parameter.IsMandatory | Should -Be $false
                }
                ($parameterSet.Parameters | Where-Object Name -EQ 'ReservedIops').Aliases | Should -Contain 'ReservedIop'
                $parameterSet.Parameters.Name | Should -Not -Contain 'ReservedIop'
                if ($operation -eq 'New') {
                    $parameterSet.Parameters.Name | Should -Contain 'QualityOfService'
                    $encryption = $parameterSet.Parameters | Where-Object Name -EQ 'EncryptionInTransit'
                    $encryption.ParameterType | Should -Be ([System.Management.Automation.SwitchParameter])
                    $encryption.IsMandatory | Should -Be $false
                } else {
                    $parameterSet.Parameters.Name | Should -Not -Contain 'QualityOfService'
                    $parameterSet.Parameters.Name | Should -Not -Contain 'EncryptionInTransit'
                }
            }
        }
        $line = 'New-AzElasticSanVolumeGroup -QualityOfService '
        $completion = TabExpansion2 $line $line.Length
        $completion.CompletionMatches.CompletionText | Should -Contain 'GeneralPurpose'
        $completion.CompletionMatches.CompletionText | Should -Contain 'PerformanceCritical'
    }

    $invalidCases = foreach ($operation in @('New', 'Update')) {
        foreach ($name in @('ReservedIops', 'ReservedMBps')) {
            foreach ($value in @(-1L, 2147483648L)) {
                @{ Operation = $operation; ParameterName = $name; Value = $value }
            }
        }
    }
    It '<Operation> rejects <ParameterName>=<Value> before sending a request' -TestCases $invalidCases {
        param($Operation, $ParameterName, $Value)

        $responder = [ElasticSan.VolumeGroupPerformanceTestResponder]::new()
        $responder.ExpectedPath = $groupId
        $responder.Create = $Operation -eq 'New'
        $mock = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Runtime.PipelineMock]::new(
            (Join-Path $TestDrive 'unused-invalid-reservation-recording.json')
        )
        $mock.SetPlayback()
        $parameters = @{
            Name = 'group'
            ResourceGroupName = 'rg'
            ElasticSanName = 'san'
            SubscriptionId = $subscriptionId
            HttpPipelinePrepend = @($mock, $responder.Step)
            Confirm = $false
            WarningAction = 'SilentlyContinue'
            ErrorAction = 'Stop'
        }
        $parameters[$ParameterName] = $Value
        $commandName = "$Operation-AzElasticSanVolumeGroup"
        { & $commandName @parameters } | Should -Throw
        $responder.RequestCount | Should -Be 0
    }
}
