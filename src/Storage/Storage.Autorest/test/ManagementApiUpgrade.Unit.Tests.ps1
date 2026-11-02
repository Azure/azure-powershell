# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

Describe 'ManagementApiUpgrade.Unit' {
    if (-not ('StorageManagementApiTestTransport' -as [type])) {
        $references = @(
            [System.Net.Http.HttpResponseMessage].Assembly.Location,
            [System.Net.HttpStatusCode].Assembly.Location
        )
        if ($PSVersionTable.PSEdition -eq 'Core') {
            $references += 'System.Collections'
        }
        # Generated client continuations may call the transport without a PowerShell runspace.
        Add-Type -ReferencedAssemblies $references -TypeDefinition @'
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public sealed class StorageManagementApiTestTransport
{
    public readonly List<Dictionary<string, object>> Requests = new List<Dictionary<string, object>>();
    public readonly Queue<string> Responses = new Queue<string>();
    public string ResponseJson = "{}";
    public HttpStatusCode StatusCode = HttpStatusCode.OK;

    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, object listener)
    {
        Requests.Add(new Dictionary<string, object> {
            { "Method", request.Method.Method },
            { "Uri", request.RequestUri },
            { "Body", request.Content == null ? null : request.Content.ReadAsStringAsync().GetAwaiter().GetResult() }
        });
        var response = new HttpResponseMessage(StatusCode);
        response.Content = new StringContent(Responses.Count == 0 ? ResponseJson : Responses.Dequeue(), Encoding.UTF8, "application/json");
        response.RequestMessage = request;
        return Task.FromResult(response);
    }

    public Task<HttpResponseMessage> Step(HttpRequestMessage request, object listener, object next)
    {
        return SendAsync(request, listener);
    }
}
'@
    }

    BeforeEach {
        $transport = [StorageManagementApiTestTransport]::new()
        $send = [System.Delegate]::CreateDelegate(
            [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.SendAsync], $transport,
            $transport.GetType().GetMethod('SendAsync'))
        $terminal = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.SendAsyncTerminalFactory]::new($send)
        $listener = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.EventListener]::new()
        $client = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Storage]::new()
        $step = [System.Delegate]::CreateDelegate(
            [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.SendAsyncStep], $transport,
            $transport.GetType().GetMethod('Step'))
        $create = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.SerializationMode]::IncludeCreate
        $update = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.SerializationMode]::IncludeUpdate
    }

    function New-OfflineStorageTestSecret {
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute(
            'PSAvoidUsingConvertToSecureStringWithPlainText', '',
            Justification = 'This is a fixed synthetic credential used only by the offline transport tests.')]
        param()
        ConvertTo-SecureString 'offline-test-secret' -AsPlainText -Force
    }

    It 'Uses the September API and correct scope for <Operation>' -TestCases @(
        @{ Operation = 'MetricsGet'; Path = '/storageAccounts/account/advancedPlatformMetrics/ContainerLevelCapacityMetrics'; Method = 'GET' },
        @{ Operation = 'MetricsList'; Path = '/storageAccounts/account/advancedPlatformMetrics'; Method = 'GET' },
        @{ Operation = 'AccessPointGet'; Path = '/storageAccounts/account/blobAccessPointConfigurations/point'; Method = 'GET' },
        @{ Operation = 'AccessPointList'; Path = '/storageAccounts/account/blobAccessPointConfigurations'; Method = 'GET' },
        @{ Operation = 'CacheGet'; Path = '/resourceGroups/group/providers/Microsoft.Storage/contextCaches/cache'; Method = 'GET' },
        @{ Operation = 'CacheListGroup'; Path = '/resourceGroups/group/providers/Microsoft.Storage/contextCaches'; Method = 'GET' },
        @{ Operation = 'CacheListSubscription'; Path = '/subscriptions/sub/providers/Microsoft.Storage/contextCaches'; Method = 'GET' },
        @{ Operation = 'ContainerGet'; Path = '/contextCaches/cache/contextCacheContainers/container'; Method = 'GET' },
        @{ Operation = 'ContainerList'; Path = '/contextCaches/cache/contextCacheContainers'; Method = 'GET' }
    ) {
        param($Operation, $Path, $Method)
        $transport.ResponseJson = '{"value":[]}'
        $task = switch ($Operation) {
            'MetricsGet' { $client.AdvancedPlatformMetricsGetWithResult('sub', 'group', 'account', $listener, $terminal) }
            'MetricsList' { $client.AdvancedPlatformMetricsListWithResult('sub', 'group', 'account', $listener, $terminal) }
            'AccessPointGet' { $client.BlobAccessPointConfigurationsGetWithResult('sub', 'group', 'account', 'point', $listener, $terminal) }
            'AccessPointList' { $client.BlobAccessPointConfigurationsListByStorageAccountWithResult('sub', 'group', 'account', $listener, $terminal) }
            'CacheGet' { $client.ContextCachesGetWithResult('sub', 'group', 'cache', $listener, $terminal) }
            'CacheListGroup' { $client.ContextCachesListByResourceGroupWithResult('sub', 'group', $listener, $terminal) }
            'CacheListSubscription' { $client.ContextCachesListBySubscriptionWithResult('sub', $listener, $terminal) }
            'ContainerGet' { $client.ContextCacheContainersGetWithResult('sub', 'group', 'cache', 'container', $listener, $terminal) }
            'ContainerList' { $client.ContextCacheContainersListByContextCacheWithResult('sub', 'group', 'cache', $listener, $terminal) }
        }
        $null = $task.GetAwaiter().GetResult()
        $transport.Requests.Count | Should Be 1
        $transport.Requests[0].Method | Should Be $Method
        $transport.Requests[0].Uri.AbsolutePath.EndsWith($Path) | Should Be $true
        $transport.Requests[0].Uri.Query | Should Be '?api-version=2026-09-01'
    }

    It 'Preserves <SourceType> source, connection, and secure authentication in create and update requests' -TestCases @(
        @{ SourceType = 'AzureNetAppFiles' },
        @{ SourceType = 'Commvault' },
        @{ SourceType = 'DellOneFs' },
        @{ SourceType = 'S3Compatible' },
        @{ SourceType = 'Nasuni' },
        @{ SourceType = 'NetAppOntap' },
        @{ SourceType = 'Qumulo' }
    ) {
        param($SourceType)
        $json = '{"location":"eastus","properties":{"source":{"sourceType":"' + $SourceType +
            '","connection":{"connectionType":"Endpoint","endpoint":"https://offline.invalid","tlsVerification":"Perform"},' +
            '"auth":{"authType":"AccessKey","accessKeyId":"offline"}}}}'
        $resource = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.BlobAccessPointConfiguration]::FromJsonString($json)
        $resource.Source.GetType().Name | Should Not Be 'BlobAccessPointSourceProperties'
        $resource.Source.Auth.SecretAccessKey = New-OfflineStorageTestSecret
        $transport.ResponseJson = $json
        $null = $client.BlobAccessPointConfigurationsCreateWithResult(
            'sub', 'group', 'account', 'point', $resource, $listener, $terminal, $create).GetAwaiter().GetResult()
        $patch = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.BlobAccessPointConfigurationUpdate]::FromJsonString($json)
        $patch.Source.Auth.SecretAccessKey = New-OfflineStorageTestSecret
        $null = $client.BlobAccessPointConfigurationsUpdateWithResult(
            'sub', 'group', 'account', 'point', $patch, $listener, $terminal, $update).GetAwaiter().GetResult()
        $writes = @($transport.Requests | Where-Object { $_.Method -ne 'GET' })
        $writes.Count | Should Be 2
        $writes[0].Method | Should Be 'PUT'
        $writes[1].Method | Should Be 'PATCH'
        foreach ($request in $writes) {
            $body = $request.Body | ConvertFrom-Json
            $body.properties.source.sourceType | Should Be $SourceType
            $body.properties.source.connection.tlsVerification | Should Be 'Perform'
            $body.properties.source.auth.secretAccessKey | Should Be 'offline-test-secret'
        }
        (($writes[0].Body | ConvertFrom-Json).properties.source.connection.endpoint) | Should Be 'https://offline.invalid'
        ($null -eq ($writes[1].Body | ConvertFrom-Json).properties.source.connection.endpoint) | Should Be $true
        $resource.ToString().Contains('offline-test-secret') | Should Be $false
        $resource.Source.ToString().Contains('offline-test-secret') | Should Be $false
        $resource.Source.Auth.ToString().Contains('offline-test-secret') | Should Be $false
        $resource.Source.Auth.SecretAccessKey.GetType().FullName | Should Be 'System.Security.SecureString'
    }

    It 'Sends raw JSON credentials without dropping write-only fields' {
        $json = '{"location":"eastus","properties":{"source":{"sourceType":"S3Compatible","connection":{"connectionType":"Endpoint","endpoint":"https://offline.invalid"},"auth":{"authType":"AccessKey","accessKeyId":"offline","secretAccessKey":"offline-test-secret"}}}}'
        $null = $client.BlobAccessPointConfigurationsCreateViaJsonStringWithResult(
            'sub', 'group', 'account', 'point', $json, $listener, $terminal).GetAwaiter().GetResult()
        (($transport.Requests[0].Body | ConvertFrom-Json).properties.source.auth.secretAccessKey) | Should Be 'offline-test-secret'
    }

    It 'Keeps proposed and existing connection tests distinct' {
        $source = '{"source":{"sourceType":"S3Compatible","connection":{"connectionType":"Endpoint","endpoint":"https://offline.invalid"},"auth":{"authType":"AccessKey","accessKeyId":"offline"}}}'
        $proposed = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.BlobAccessPointProposedConnectionTestRequest]::FromJsonString($source)
        $proposed.Source.Auth.SecretAccessKey = New-OfflineStorageTestSecret
        $existing = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.BlobAccessPointConnectionTestRequest]::FromJsonString('{"uniqueId":"offline-id"}')
        $transport.ResponseJson = '{"methodName":"ListObjectsV2","requestId":"offline-request"}'
        $result = $client.BlobAccessPointConnectionTestsTestProposedConnectionWithResult(
            'sub', 'group', 'account', $proposed, $listener, $terminal, $create).GetAwaiter().GetResult()
        $result.MethodName | Should Be 'ListObjectsV2'
        $null = $client.BlobAccessPointConfigurationsTestExistingConnectionWithResult(
            'sub', 'group', 'account', 'point', $existing, $listener, $terminal, $create).GetAwaiter().GetResult()
        $transport.Requests[0].Method | Should Be 'POST'
        $transport.Requests[1].Method | Should Be 'POST'
        $transport.Requests[0].Uri.AbsolutePath | Should Not Be $transport.Requests[1].Uri.AbsolutePath
        (($transport.Requests[0].Body | ConvertFrom-Json).source.auth.secretAccessKey) | Should Be 'offline-test-secret'
        (($transport.Requests[1].Body | ConvertFrom-Json).uniqueId) | Should Be 'offline-id'
    }

    It 'Preserves managed identity, encryption, and tags for context caches' -TestCases @(
        @{ IdentityType = 'SystemAssigned' },
        @{ IdentityType = 'UserAssigned' },
        @{ IdentityType = 'SystemAssigned, UserAssigned' }
    ) {
        param($IdentityType)
        $json = '{"location":"eastus","tags":{"purpose":"offline"},"identity":{"type":"' + $IdentityType +
            '","userAssignedIdentities":{"/subscriptions/sub/resourceGroups/group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity":{}}},' +
            '"properties":{"accountKind":"Regional","description":"offline","encryption":{"infrastructureEncryption":"Enabled","customerManagedKeyEncryption":{"keyEncryptionKeyUrl":"https://offline.vault.azure.net/keys/key","keyEncryptionKeyIdentity":{"identityType":"UserAssignedIdentity","userAssignedIdentityResourceId":"/identities/offline"}}}}}'
        $resource = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ContextCache]::FromJsonString($json)
        $transport.ResponseJson = $json
        $null = $client.ContextCachesCreateOrUpdateWithResult(
            'sub', 'group', 'cache', $resource, $listener, $terminal, $create).GetAwaiter().GetResult()
        $body = $transport.Requests[0].Body | ConvertFrom-Json
        $body.identity.type | Should Be $IdentityType
        $body.identity.userAssignedIdentities.PSObject.Properties.Count | Should Be 1
        $body.tags.purpose | Should Be 'offline'
        $body.properties.encryption.customerManagedKeyEncryption.keyEncryptionKeyUrl | Should Be 'https://offline.vault.azure.net/keys/key'
        $patch = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ContextCacheUpdate]::FromJsonString('{"properties":{"description":"updated"}}')
        $null = $client.ContextCachesUpdateWithResult(
            'sub', 'group', 'cache', $patch, $listener, $terminal, $update).GetAwaiter().GetResult()
        $body = ($transport.Requests | Where-Object { $_.Method -eq 'PATCH' }).Body | ConvertFrom-Json
        $body.properties.description | Should Be 'updated'
        ($null -eq $body.identity) | Should Be $true
        ($null -eq $body.properties.encryption) | Should Be $true
    }

    It 'Sends the constant provider and preserves an omitted TTL' {
        $resource = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ContextCacheContainer]::FromJsonString('{"properties":{"modelName":"gpt-4"}}')
        $null = $client.ContextCacheContainersCreateOrUpdateWithResult(
            'sub', 'group', 'cache', 'container', $resource, $listener, $terminal, $create).GetAwaiter().GetResult()
        $body = $transport.Requests[0].Body | ConvertFrom-Json
        $body.properties.provider | Should Be 'OpenAI'
        $body.properties.modelName | Should Be 'gpt-4'
        ($null -eq $body.properties.timeToLive) | Should Be $true
        $patch = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ContextCacheContainerUpdate]::FromJsonString('{"properties":{"timeToLive":30}}')
        $null = $client.ContextCacheContainersUpdateWithResult(
            'sub', 'group', 'cache', 'container', $patch, $listener, $terminal, $update).GetAwaiter().GetResult()
        $patchBody = ($transport.Requests | Where-Object { $_.Method -eq 'PATCH' }).Body | ConvertFrom-Json
        $patchBody.properties.timeToLive | Should Be 30
    }

    It 'Preserves metrics filters when the public update command disables emission' {
        $transport.ResponseJson = '{"properties":{"ruleType":"ContainerLevelCapacityMetrics","enabled":true,"ruleConfig":{"filterType":"ContainerListFilter","filterValues":["documents","images"]}}}'
        $null = Update-AzStorageAdvancedPlatformMetricsRule -ResourceGroupName group -AccountName account `
            -SubscriptionId '00000000-0000-0000-0000-000000000001' -Enabled:$false -HttpPipelinePrepend $step -Confirm:$false -ErrorAction Stop
        $transport.Requests.Count | Should Be 2
        $transport.Requests[0].Method | Should Be 'GET'
        $transport.Requests[1].Method | Should Be 'PUT'
        $body = $transport.Requests[1].Body | ConvertFrom-Json
        $body.properties.enabled | Should Be $false
        $body.properties.ruleConfig.filterType | Should Be 'ContainerListFilter'
        ($body.properties.ruleConfig.filterValues -join ',') | Should Be 'documents,images'
    }

    It 'Checks context cache name availability with the resource type constant' {
        $resource = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ContextCacheCheckNameAvailabilityParameters]::new()
        $resource.Name = 'offline'
        $transport.ResponseJson = '{"nameAvailable":false,"reason":"AlreadyExists","message":"Name is in use."}'
        $result = $client.ContextCachesCheckNameAvailabilityWithResult('sub', $resource, $listener, $terminal, $create).GetAwaiter().GetResult()
        $result.NameAvailable | Should Be $false
        $result.Reason | Should Be 'AlreadyExists'
        $transport.Requests[0].Method | Should Be 'POST'
        $body = $transport.Requests[0].Body | ConvertFrom-Json
        $body.name | Should Be 'offline'
        $body.type | Should Be 'Microsoft.Storage/contextCaches'
    }

    It 'Retains the existing MockRun task assignment trigger' {
        $resource = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.StorageTaskAssignment]::FromJsonString(
            '{"properties":{"executionContext":{"trigger":{"type":"MockRun"}}}}')
        $body = $resource.ToJsonString() | ConvertFrom-Json
        $body.properties.executionContext.trigger.type | Should Be 'MockRun'
        (Get-Command New-AzStorageTaskAssignment).Parameters.ContainsKey('TriggerType') | Should Be $true
    }

    It 'Follows the nextLink through the public cache list command' {
        $nextLink = 'https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000001/providers/Microsoft.Storage/contextCaches?api-version=2026-09-01&$skiptoken=next'
        $transport.Responses.Enqueue('{"value":[{"name":"first","location":"eastus","properties":{}}],"nextLink":"' + $nextLink + '"}')
        $transport.Responses.Enqueue('{"value":[{"name":"second","location":"eastus","properties":{}}]}')
        $result = @(Get-AzStorageContextCache -SubscriptionId '00000000-0000-0000-0000-000000000001' -HttpPipelinePrepend $step -ErrorAction Stop)
        $transport.Requests.Count | Should Be 2
        ($result.Name -join ',') | Should Be 'first,second'
        $transport.Requests[1].Uri.AbsoluteUri | Should Be $nextLink
    }

    It 'Preserves service error details instead of returning a successful empty result' {
        $transport.StatusCode = [System.Net.HttpStatusCode]::Forbidden
        $transport.ResponseJson = '{"error":{"code":"AuthorizationFailed","message":"Offline request denied."}}'
        {
            Get-AzStorageContextCache -Name cache -ResourceGroupName group `
                -SubscriptionId '00000000-0000-0000-0000-000000000001' -HttpPipelinePrepend $step -ErrorAction Stop
        } | Should Throw 'Offline request denied.'
        $transport.Requests.Count | Should Be 1
    }

    It 'Exposes guardrail scalars and inbound service tags in responses' {
        $transport.ResponseJson = '{"properties":{"fileShareLimits":{"guardrailIOScalar":1.5,"guardrailBandwidthScalar":2.5}}}'
        $result = $client.FileServicesGetServiceUsageWithResult('sub', 'group', 'account', $listener, $terminal).GetAwaiter().GetResult()
        $result.FileShareLimitGuardrailIoScalar | Should Be 1.5
        $result.FileShareLimitGuardrailBandwidthScalar | Should Be 2.5
        $rule = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.NspAccessRule]::FromJsonString('{"properties":{"direction":"Inbound","serviceTags":["Storage","AzureMonitor"]}}')
        ($rule.ServiceTag -join ',') | Should Be 'Storage,AzureMonitor'
    }

    It 'Maps public context cache identity inputs to <IdentityType>' -TestCases @(
        @{ IdentityType = 'SystemAssigned'; SystemAssigned = $true; UserAssigned = $false },
        @{ IdentityType = 'UserAssigned'; SystemAssigned = $false; UserAssigned = $true },
        @{ IdentityType = 'SystemAssigned,UserAssigned'; SystemAssigned = $true; UserAssigned = $true }
    ) {
        param($IdentityType, $SystemAssigned, $UserAssigned)
        $identityId = '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity'
        $parameters = @{
            Name = 'cache'
            ResourceGroupName = 'group'
            SubscriptionId = '00000000-0000-0000-0000-000000000001'
            AccountKind = 'Regional'
            Location = 'eastus'
            EnableSystemAssignedIdentity = $SystemAssigned
            NoWait = $true
            HttpPipelinePrepend = $step
            Confirm = $false
            ErrorAction = 'Stop'
        }
        if ($UserAssigned) {
            $parameters.UserAssignedIdentity = @($identityId)
        }
        $transport.ResponseJson = '{"name":"cache","location":"eastus","properties":{"provisioningState":"Succeeded"}}'
        $null = New-AzStorageContextCache @parameters
        $body = ($transport.Requests | Where-Object { $_.Method -eq 'PUT' }).Body | ConvertFrom-Json
        $body.identity.type | Should Be $IdentityType
        if ($UserAssigned) {
            $body.identity.userAssignedIdentities.PSObject.Properties.Name | Should Be $identityId
        }
    }

    It 'Uses DELETE for the public <Resource> removal operation' -TestCases @(
        @{ Resource = 'Cache'; Path = '/contextCaches/cache' },
        @{ Resource = 'Container'; Path = '/contextCaches/cache/contextCacheContainers/container' },
        @{ Resource = 'AccessPoint'; Path = '/storageAccounts/account/blobAccessPointConfigurations/point' },
        @{ Resource = 'Metrics'; Path = '/storageAccounts/account/advancedPlatformMetrics/ContainerLevelCapacityMetrics' }
    ) {
        param($Resource, $Path)
        $transport.StatusCode = [System.Net.HttpStatusCode]::NoContent
        $parameters = @{
            ResourceGroupName = 'group'
            SubscriptionId = '00000000-0000-0000-0000-000000000001'
            HttpPipelinePrepend = $step
            Confirm = $false
            ErrorAction = 'Stop'
        }
        $null = switch ($Resource) {
            'Cache' { Remove-AzStorageContextCache -Name cache @parameters }
            'Container' { Remove-AzStorageContextCacheContainer -ContextCacheName cache -Name container @parameters }
            'AccessPoint' { Remove-AzStorageBlobAccessPointConfiguration -AccountName account -Name point @parameters }
            'Metrics' { Remove-AzStorageAdvancedPlatformMetricsRule -AccountName account @parameters }
        }
        $transport.Requests.Count | Should Be 1
        $transport.Requests[0].Method | Should Be 'DELETE'
        $transport.Requests[0].Uri.AbsolutePath.EndsWith($Path) | Should Be $true
        $transport.Requests[0].Uri.Query | Should Be '?api-version=2026-09-01'
    }

    It 'Validates the actual TTL limits for <Command>' -TestCases @(
        @{ Command = 'New-AzStorageContextCacheContainer' },
        @{ Command = 'Set-AzStorageContextCacheContainer' },
        @{ Command = 'Update-AzStorageContextCacheContainer' }
    ) {
        param($Command)
        $binaryName = $Command + '_CreateExpanded'
        if (-not $Command.StartsWith('New-')) {
            $binaryName = $Command + '_UpdateExpanded'
        }
        $binary = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Storage].Assembly.GetTypes() |
            Where-Object {
                $attribute = $_.GetCustomAttributes([System.Management.Automation.CmdletAttribute], $false)
                $attribute.Count -gt 0 -and ($attribute[0].VerbName + '-' + $attribute[0].NounName) -eq $binaryName
            }
        $attributes = $binary.GetProperty('TimeToLive').GetCustomAttributes($false)
        $range = @($attributes | Where-Object { $_ -is [System.Management.Automation.ValidateRangeAttribute] })
        $range.Count | Should Be 1
        $range[0].MinRange | Should Be 1
        $range[0].MaxRange | Should Be 30
        foreach ($ttl in @(0, 31)) {
            $parameters = @{
                Name = 'container'
                ContextCacheName = 'cache'
                ResourceGroupName = 'group'
                SubscriptionId = '00000000-0000-0000-0000-000000000001'
                TimeToLive = $ttl
                WhatIf = $true
                ErrorAction = 'Stop'
            }
            if (-not $Command.StartsWith('Update-')) {
                $parameters.ModelName = 'gpt-4'
            }
            { & $Command @parameters } | Should Throw 'TimeToLive'
        }
    }

    It 'Exposes normalized commands without excluded operation families' {
        foreach ($name in @('Get-AzStorageContextCache', 'New-AzStorageContextCacheContainer',
                'Test-AzStorageContextCacheNameAvailability', 'New-AzStorageAdvancedPlatformMetricsRule',
                'Test-AzStorageBlobAccessPointConnection', 'Test-AzStorageBlobAccessPointConfigurationConnection')) {
            (Get-Command $name -ErrorAction Stop).Name | Should Be $name
        }
        $names = @(Get-Command -Module Az.Storage | Select-Object -ExpandProperty Name)
        @($names | Where-Object { $_ -match 'StorageConnector|StorageDataShare|Stop-AzStorageTaskAssignment|StorageContextCach$|AdvancedPlatformMetric$' }).Count | Should Be 0
        (Get-Command New-AzStorageContextCache).Parameters.ContainsKey('Name') | Should Be $true
        foreach ($name in @('New-AzStorageBlobAccessPointConfiguration', 'Update-AzStorageBlobAccessPointConfiguration')) {
            $parameters = (Get-Command $name).Parameters
            $parameters.ContainsKey('JsonString') | Should Be $true
            $parameters.ContainsKey('JsonFilePath') | Should Be $true
        }
    }
}
