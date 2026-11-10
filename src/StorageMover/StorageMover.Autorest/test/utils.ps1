function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

function Invoke-StorageMoverTestRequest {
    param([scriptblock]$Command, [hashtable]$Response, [int]$StatusCode = 200)

    $state = @{
        Requests = [System.Collections.Generic.List[object]]::new()
        Response = $Response
        StatusCode = $StatusCode
    }
    $step = [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Runtime.SendAsyncStep]{
        param($request, $callback, $next)
        $content = if ($null -ne $request.Content) { $request.Content.ReadAsStringAsync().GetAwaiter().GetResult() }
        $state.Requests.Add([pscustomobject]@{
            Method = $request.Method.Method
            Uri = $request.RequestUri
            Content = $content
        })
        $responseMessage = [System.Net.Http.HttpResponseMessage]::new($state.StatusCode)
        $responseMessage.RequestMessage = $request
        $responseMessage.Content = [System.Net.Http.StringContent]::new(
            ($state.Response | ConvertTo-Json -Depth 20), [System.Text.Encoding]::UTF8, 'application/json')
        [System.Threading.Tasks.Task[System.Net.Http.HttpResponseMessage]]::FromResult($responseMessage)
    }.GetNewClosure()

    $previousPlaybackMode = $env:AzPSAutorestTestPlaybackMode
    try {
        $env:AzPSAutorestTestPlaybackMode = 'true'
        $result = & $Command $step
    } finally {
        $env:AzPSAutorestTestPlaybackMode = $previousPlaybackMode
    }
    [pscustomobject]@{ Result = $result; Requests = $state.Requests.ToArray() }
}

function Invoke-StorageMoverTestArmRequest {
    param([string]$Method, [string]$Path, [hashtable]$Body, [switch]$IgnoreNotFound)

    $parameters = @{ Method = $Method; Uri = "https://management.azure.com$Path"; ErrorAction = 'Stop' }
    if ($Body) {
        $parameters.Payload = $Body | ConvertTo-Json -Depth 20
    }
    $response = Invoke-AzRestMethod @parameters
    if ($IgnoreNotFound -and $response.StatusCode -eq 404) {
        return
    }
    if ($response.StatusCode -lt 200 -or $response.StatusCode -ge 300) {
        throw "ARM $Method $Path returned $($response.StatusCode): $($response.Content)"
    }
    if ($response.Content) {
        $response.Content | ConvertFrom-Json
    }
}

function New-StorageMoverScenarioPipeline {
    param($Recorder, [string]$Mode)

    [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Runtime.SendAsyncStep]{
        param($request, $callback, $next)
        $actualContent = if ($null -ne $request.Content) { $request.Content.ReadAsStringAsync().GetAwaiter().GetResult() }
        $responseTask = $Recorder.SendAsync($request, $callback, $next)
        if ($Mode -eq 'playback') {
            # The generated recorder matches URIs but does not compare request bodies.
            $response = $responseTask.GetAwaiter().GetResult()
            $recordedContent = if ($null -ne $response.RequestMessage.Content) {
                $response.RequestMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult()
            }
            $equal = [string]::IsNullOrWhiteSpace($actualContent) -and [string]::IsNullOrWhiteSpace($recordedContent)
            if (-not [string]::IsNullOrWhiteSpace($actualContent) -and -not [string]::IsNullOrWhiteSpace($recordedContent)) {
                $equal = [Newtonsoft.Json.Linq.JToken]::DeepEquals(
                    [Newtonsoft.Json.Linq.JToken]::Parse($actualContent),
                    [Newtonsoft.Json.Linq.JToken]::Parse($recordedContent))
            }
            if (-not $equal) {
                throw "Playback request body differs from the recording for $($request.Method) $($request.RequestUri)."
            }
        }
        $responseTask
    }.GetNewClosure()
}

function Initialize-StorageMoverScenarioEnvironment {
    $subscriptionId = (Get-AzContext).Subscription.Id
    $suffix = RandomString $false 8
    $sharedSubscriptionId = ($env.MultiCloudConnectorId -split '/')[2]
    $sharedPrefix = "/subscriptions/$sharedSubscriptionId"
    $fixtures = @{
        ScenarioSubscriptionId = $subscriptionId
        ScenarioResourceGroupName = "sm-ps-parity-$suffix"
        ScenarioRunId = [guid]::NewGuid().ToString()
        ScenarioScheduleStartDate = [datetime]::UtcNow.Date.AddDays(1).ToString('o')
        ScenarioScheduleEndDate = [datetime]::UtcNow.Date.AddDays(30).ToString('o')
        ScenarioMultiCloudConnectorId = $env.MultiCloudConnectorId
        ScenarioPublicS3BucketId = $env.AwsS3BucketId
        ScenarioPrivateS3BucketId = "$sharedPrefix/resourceGroups/aws_640698235822/providers/Microsoft.AWSConnector/s3Buckets/e2e-sm-rp-private-bucket"
        ScenarioStorageAccountId = "$sharedPrefix/resourceGroups/CP_Mover_IN_WCUS/providers/Microsoft.Storage/storageAccounts/cpmoveraccount"
        ScenarioPrivateLinkServiceId = "$sharedPrefix/resourceGroups/E2E-Management-RGsyn/providers/Microsoft.Network/privateLinkServices/E2E-VPC-PLS-E2ETest.Test.WCUS"
        ScenarioAgentlessPrivateLinkServiceId = "$sharedPrefix/resourceGroups/E2E-Management-RGsyn/providers/Microsoft.Network/privateLinkServices/E2E-VPC-PLS-E2ETest.Test.ECY"
        ScenarioPublicContainerName = "ps-public-$suffix"
        ScenarioPrivateContainerName = "ps-private-$suffix"
        ScenarioPublicRoleAssignmentName = [guid]::NewGuid().ToString()
        ScenarioPrivateRoleAssignmentName = [guid]::NewGuid().ToString()
    }
    foreach ($key in $fixtures.Keys) {
        $env[$key] = $fixtures[$key]
    }
    $path = "/subscriptions/$subscriptionId/resourceGroups/$($fixtures.ScenarioResourceGroupName)?api-version=2022-09-01"
    $existing = Invoke-AzRestMethod -Method GET -Uri "https://management.azure.com$path" -ErrorAction Stop
    if ($existing.StatusCode -ne 404) {
        throw "Refusing to reuse scenario resource group $($fixtures.ScenarioResourceGroupName)."
    }
    Invoke-StorageMoverTestArmRequest -Method PUT -Path $path -Body @{
        location = 'eastus'
        tags = @{ testSuite = 'Az.StorageMover.PythonParity'; runId = $fixtures.ScenarioRunId }
    } | Out-Null
    $fixtures
}

function New-StorageMoverTestContext {
    param([string]$Name, [string]$Location = 'eastus', [switch]$Project, [switch]$JobEndpoints)

    $context = @{
        SubscriptionId = $env.ScenarioSubscriptionId
        ResourceGroupName = $env.ScenarioResourceGroupName
        StorageMoverName = $Name
        HttpPipelinePrepend = (New-StorageMoverScenarioPipeline -Recorder $Mock -Mode $TestMode)
    }
    New-AzStorageMover -SubscriptionId $context.SubscriptionId -ResourceGroupName $context.ResourceGroupName -Name $Name -Location $Location -HttpPipelinePrepend $context.HttpPipelinePrepend | Out-Null
    if ($Project -or $JobEndpoints) {
        New-AzStorageMoverProject @context -Name 'project' | Out-Null
    }
    if ($JobEndpoints) {
        New-AzStorageMoverNfsEndpoint @context -Name 'source' -Host '10.0.0.1' -Export '/' -NfsVersion NFSv3 -EndpointKind Source | Out-Null
        $accountId = "/subscriptions/$($context.SubscriptionId)/resourceGroups/$($context.ResourceGroupName)/providers/Microsoft.Storage/storageAccounts/testaccount"
        New-AzStorageMoverAzStorageContainerEndpoint @context -Name 'target' -StorageAccountResourceId $accountId -BlobContainerName 'testcontainer' -EndpointKind Target | Out-Null
    }
    $context
}

function Remove-StorageMoverTestContext {
    param([hashtable]$Context)

    if ($Context) {
        Remove-AzStorageMover -SubscriptionId $Context.SubscriptionId -ResourceGroupName $Context.ResourceGroupName -Name $Context.StorageMoverName -Force -HttpPipelinePrepend $Context.HttpPipelinePrepend
    }
}

function Invoke-StorageMoverTestFailure {
    param([scriptblock]$Command, [string]$Code = 'InvalidRequestPropertyValue')

    $failure = $null
    try {
        & $Command | Out-Null
    } catch {
        $failure = $_
    }
    $failure | Should -Not -BeNullOrEmpty
    ($failure.FullyQualifiedErrorId + ' ' + $failure.Exception.Message + ' ' + [string]$failure.ErrorDetails) |
        Should -Match ([regex]::Escape($Code))
}

function Invoke-StorageMoverTransferScenario {
    param([switch]$PrivateSource)

    $context = $null
    $containerName = $env.ScenarioPublicContainerName
    $roleName = $env.ScenarioPublicRoleAssignmentName
    $bucketId = $env.ScenarioPublicS3BucketId
    $moverName = 'sm-public-transfer'
    if ($PrivateSource) {
        $containerName = $env.ScenarioPrivateContainerName
        $roleName = $env.ScenarioPrivateRoleAssignmentName
        $bucketId = $env.ScenarioPrivateS3BucketId
        $moverName = 'sm-private-transfer'
    }
    $containerId = "$($env.ScenarioStorageAccountId)/blobServices/default/containers/$containerName"
    $roleId = "$containerId/providers/Microsoft.Authorization/roleAssignments/$roleName"
    $connectionCreated = $false
    $containerCreated = $false
    $roleCreated = $false
    try {
        $context = New-StorageMoverTestContext -Name $moverName -Location westcentralus -Project
        $jobParameters = @{ ProjectName = 'project'; Name = 'job'; SourceName = 'source'; TargetName = 'target'; CopyMode = 'Additive'; JobType = 'CloudToCloud' }
        if ($PrivateSource) {
            $connection = New-AzStorageMoverConnection @context -Name 'private' -PrivateLinkServiceId $env.ScenarioPrivateLinkServiceId
            $connectionCreated = $true
            $connection.PrivateEndpointResourceId | Should -Not -BeNullOrEmpty
            if ($TestMode -ne 'playback') {
                $privateEndpointConnection = $null
                for ($attempt = 0; $attempt -lt 10; $attempt++) {
                    $connections = Invoke-StorageMoverTestArmRequest -Method GET -Path "$($env.ScenarioPrivateLinkServiceId)/privateEndpointConnections?api-version=2024-05-01"
                    $privateEndpointConnection = $connections.value | Where-Object { $_.properties.privateEndpoint.id -eq $connection.PrivateEndpointResourceId }
                    if ($privateEndpointConnection) { break }
                    Start-TestSleep -Seconds 15
                }
                $privateEndpointConnection | Should -Not -BeNullOrEmpty
                Invoke-StorageMoverTestArmRequest -Method PUT -Path "$($privateEndpointConnection.id)?api-version=2024-05-01" -Body @{
                    properties = @{ privateLinkServiceConnectionState = @{ status = 'Approved'; description = 'Approved by Az.StorageMover scenario test'; actionsRequired = 'None' } }
                } | Out-Null
            }
            for ($attempt = 0; $attempt -lt 10; $attempt++) {
                $connection = Get-AzStorageMoverConnection @context -Name 'private'
                if ($connection.Status -eq 'Approved') { break }
                Start-TestSleep -Seconds 30
            }
            $connection.Status | Should -Be 'Approved'
            $jobParameters.Connection = @($connection.Id)
        }

        $source = New-AzStorageMoverMultiCloudConnectorEndpoint @context -Name 'source' -MultiCloudConnectorId $env.ScenarioMultiCloudConnectorId -AWSS3BucketId $bucketId -EndpointKind Source
        $source.Property.EndpointKind | Should -Be 'Source'
        $target = New-AzStorageMoverAzStorageContainerEndpoint @context -Name 'target' -StorageAccountResourceId $env.ScenarioStorageAccountId -BlobContainerName $containerName -EndpointKind Target
        $target.IdentityPrincipalId | Should -Not -BeNullOrEmpty
        if ($TestMode -ne 'playback') {
            $existingContainer = Invoke-StorageMoverTestArmRequest -Method GET -Path "$containerId`?api-version=2023-05-01" -IgnoreNotFound
            if ($existingContainer) { throw "Refusing to reuse container $containerName." }
            Invoke-StorageMoverTestArmRequest -Method PUT -Path "$containerId`?api-version=2023-05-01" -Body @{
                properties = @{ metadata = @{ azstoragemoverparityrunid = $env.ScenarioRunId } }
            } | Out-Null
            $containerCreated = $true
            $sharedSubscriptionId = ($env.ScenarioStorageAccountId -split '/')[2]
            Invoke-StorageMoverTestArmRequest -Method PUT -Path "$roleId`?api-version=2022-04-01" -Body @{
                properties = @{
                    roleDefinitionId = "/subscriptions/$sharedSubscriptionId/providers/Microsoft.Authorization/roleDefinitions/ba92f5b4-2d11-453d-a403-e96b0029c9fe"
                    principalId = $target.IdentityPrincipalId
                    principalType = 'ServicePrincipal'
                }
            } | Out-Null
            $roleCreated = $true
        }

        $job = New-AzStorageMoverJobDefinition @context @jobParameters
        $job.SourceName | Should -Be 'source'
        $job.TargetName | Should -Be 'target'
        $job.CopyMode | Should -Be 'Additive'
        $job = Get-AzStorageMoverJobDefinition @context -ProjectName 'project' -Name 'job'
        $job.JobType | Should -Be 'CloudToCloud'
        $jobs = Get-AzStorageMoverJobDefinition @context -ProjectName 'project'
        @($jobs.Name) | Should -Contain 'job'

        $started = Start-AzStorageMoverJobDefinition @context -ProjectName 'project' -JobDefinitionName 'job'
        $started.JobRunResourceId1 | Should -Not -BeNullOrEmpty
        $runName = $started.JobRunResourceId1.TrimEnd('/').Split('/')[-1]
        for ($attempt = 0; $attempt -lt 60; $attempt++) {
            $run = Get-AzStorageMoverJobRun @context -ProjectName 'project' -JobDefinitionName 'job' -Name $runName
            if ($run.Status -in @('Succeeded', 'Failed', 'Canceled', 'Cancelled', 'PartialSucceeded')) { break }
            Start-TestSleep -Seconds 30
        }
        $run.Status | Should -Be 'Succeeded'
        $run.SourceName | Should -Be 'source'
        $run.TargetName | Should -Be 'target'
        $runs = Get-AzStorageMoverJobRun @context -ProjectName 'project' -JobDefinitionName 'job'
        @($runs.Name) | Should -Contain $runName
        Remove-AzStorageMoverJobDefinition @context -ProjectName 'project' -Name 'job'
    } finally {
        $cleanupFailures = @()
        foreach ($cleanup in @(
            { if ($roleCreated) { Invoke-StorageMoverTestArmRequest -Method DELETE -Path "$roleId`?api-version=2022-04-01" -IgnoreNotFound | Out-Null } },
            { if ($containerCreated) { Invoke-StorageMoverTestArmRequest -Method DELETE -Path "$containerId`?api-version=2023-05-01" -IgnoreNotFound | Out-Null } },
            { if ($connectionCreated) { Remove-AzStorageMoverConnection @context -Name 'private' } },
            { Remove-StorageMoverTestContext -Context $context }
        )) {
            try { & $cleanup } catch { $cleanupFailures += $_ }
        }
        if ($cleanupFailures.Count) {
            throw ($cleanupFailures -join [Environment]::NewLine)
        }
    }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }

    $env.RandomString = (RandomString $false 8)
    $env.ResourceGroupName = "choudharysutest"
    $env.StorageMoverNameWithAgent = "testmoverpreview1"
    $env.AgentName = "testagent12"
    $env.Location = "eastus2euap"
    $env.InitialStoMoverName = "testStoMover1" + $env.RandomString
    $env.InitialSMDescription = "initial test SM description"
    $env.InitialStoMoverTag = @{"tag1" = "value1"; "tag2" = "value2"}

    #Create Resource Group Name: teststoragemover Location: eastus2 Tag: @{"DateCreated" = "$(Get-Date -Format 'yyyy-MM-dd')"}
    #Create Storage Mover with name: testmoverpreview1, agent name: testagent12, resource group: teststoragemover, location: eastus2
    
    $stomover1 = New-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $env.InitialStoMoverName -Location $env.Location -Description $env.InitialSMDescription -Tag $env.InitialStoMoverTag

    # Initialize a Storage account and a Blob container
    $env.StorageAccountName = "storacc" + $env.RandomString
    $env.ContainerName = "container" + $env.RandomString

    $storacc = New-AzStorageAccount -ResourceGroupName $env.ResourceGroupName -Name $env.StorageAccountName -SkuName Standard_LRS -Location $env.Location -AllowBlobPublicAccess $false -AllowSharedKeyAccess $false -RequireInfrastructureEncryption -EnableHttpsTrafficOnly $true -MinimumTlsVersion TLS1_2
    $env.StoraccId = $storacc.Id
    # Create storage context using Azure AD authentication instead of keys
    $storageContext = New-AzStorageContext -StorageAccountName $env.StorageAccountName `
        -UseConnectedAccount
    
    # Ensure current user has Storage Blob Data Contributor role
    $currentUserId = (Get-AzContext).Account.Id
    $roleAssignment = Get-AzRoleAssignment -SignInName $currentUserId `
        -RoleDefinitionName "Storage Blob Data Contributor" `
        -Scope $storacc.Id -ErrorAction SilentlyContinue
    
    if (-not $roleAssignment) {
        Write-Host "Assigning Storage Blob Data Contributor role..." -ForegroundColor Yellow
        New-AzRoleAssignment -SignInName $currentUserId `
            -RoleDefinitionName "Storage Blob Data Contributor" `
            -Scope $storacc.Id
        
        # Wait for role assignment to propagate
        Start-TestSleep -Seconds 30
    }
    
    $container = New-AzStorageContainer -Name $env.ContainerName -Context $storageContext

    $env.ContainerEndpointName = "containerEndpoint" + $env.RandomString
    $env.NfsEndpointName = "nfsEndpoint" + $env.RandomString
    $containerEndpoint = New-AzStorageMoverAzStorageContainerEndpoint -Name $env.ContainerEndpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -BlobContainerName $env.ContainerName -StorageAccountResourceId $env.StoraccId
    $nfsEndpoint = New-AzStorageMoverNfsEndpoint -Name $env.NfsEndpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Host "10.0.0.1" -Export "/"

    $env.ProjectName = "testProject" + $env.RandomString
    $env.ProjectName2 = "testProject2" + $env.RandomString
    $project1 = New-AzStorageMoverProject -Name $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
    $project2 = New-AzStorageMoverProject -Name $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent

    $env.JobDefinitionName = "testJob" + $env.RandomString
    $jobDefinition = New-AzStorageMoverJobDefinition -Name $env.JobDefinitionName -ProjectName $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -AgentName $env.AgentName -CopyMode "Additive" -SourceName $env.NfsEndpointName -TargetName $env.ContainerEndpointName

    $env.MultiCloudConnectorId = "/subscriptions/b6b34ad8-ca89-4f85-beb7-c2ec13702dac/resourceGroups/E2E-Management-RGsyn/providers/Microsoft.HybridConnectivity/publicCloudConnectors/e2e-sm-rp-connector"
    $env.AwsS3BucketId = "/subscriptions/b6b34ad8-ca89-4f85-beb7-c2ec13702dac/resourceGroups/aws_640698235822/providers/Microsoft.AWSConnector/s3Buckets/e2e-sm-rp-bucket"

    # Create a destination IP-based Private Link Service for Connection cmdlet tests.
    # Reuses an existing VNet/subnet that has connectivity to the destination IP.
    # The subnet must have privateLinkServiceNetworkPolicies disabled.
    $env.VNetResourceGroupName = "E2E-Management-RGsyn"
    $env.VNetName = "e2e-sm-vpc-vnet-eastus2euap"
    $env.SubnetName = "pls-subnet"
    $env.PrivateLinkServiceName = "testPls" + $env.RandomString
    $env.ConnectionName = "conn" + $env.RandomString
    $env.PlsDestinationIp = "10.1.0.186"

    $vnet = Get-AzVirtualNetwork -Name $env.VNetName -ResourceGroupName $env.VNetResourceGroupName
    $subnet = Get-AzVirtualNetworkSubnetConfig -Name $env.SubnetName -VirtualNetwork $vnet

    # New-AzPrivateLinkService doesn't support -DestinationIPAddress, so use
    # the REST API directly to create a destination-IP-based PLS.
    $plsPath = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.VNetResourceGroupName)/providers/Microsoft.Network/privateLinkServices/$($env.PrivateLinkServiceName)?api-version=2024-05-01"
    $plsBody = @{
        location = $env.Location
        properties = @{
            ipConfigurations = @(
                @{
                    name = "testPlsIpConfig1"
                    properties = @{
                        privateIPAllocationMethod = "Dynamic"
                        subnet = @{ id = $subnet.Id }
                        primary = $true
                    }
                },
                @{
                    name = "testPlsIpConfig2"
                    properties = @{
                        privateIPAllocationMethod = "Dynamic"
                        subnet = @{ id = $subnet.Id }
                    }
                }
            )
            destinationIPAddress = $env.PlsDestinationIp
        }
    } | ConvertTo-Json -Depth 10
    $plsResponse = Invoke-AzRestMethod -Method PUT -Path $plsPath -Payload $plsBody
    if ($plsResponse.StatusCode -ne 200 -and $plsResponse.StatusCode -ne 201) {
        throw "Failed to create PLS: $($plsResponse.Content)"
    }
    $plsResult = $plsResponse.Content | ConvertFrom-Json
    $env.PrivateLinkServiceId = $plsResult.id

    # Pre-create a connection on the initial Storage Mover so Get-AzStorageMoverConnection tests can find it.
    New-AzStorageMoverConnection -Name $env.ConnectionName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -PrivateLinkServiceId $env.PrivateLinkServiceId -Description "setupEnv connection" | Out-Null

    # API 2026-05-01 endpoint scenarios reuse the initial storage mover and test storage account, and need a file share.
    $env.EndpointStoMoverName = $env.InitialStoMoverName
    $env.EndpointStorageAccountId = $env.StoraccId
    $env.EndpointContainerName = $env.ContainerName
    $env.EndpointFileShareName = "share" + $env.RandomString
    New-AzRmStorageShare -ResourceGroupName $env.ResourceGroupName -StorageAccountName $env.StorageAccountName -Name $env.EndpointFileShareName | Out-Null

    # The cross-tenant job definition scenario needs a partner tenant whose storage mover has a cross-tenant Target endpoint
    # that allows $env.CrossTenantStorageAccountId. Provide its details through SM_XT_PARTNER_TENANT,
    # SM_XT_PARTNER_STORAGE_ACCOUNT_ID and SM_XT_PARTNER_ENDPOINT_ID, and replace the partner IDs with placeholders in
    # env.json and the recordings before committing. The scenario is skipped when they are not provided.
    $env.CrossTenantLocation = "eastus"
    $env.CrossTenantStoMoverName = "testStoMoverXt" + $env.RandomString
    New-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $env.CrossTenantStoMoverName -Location $env.CrossTenantLocation | Out-Null
    $env.CrossTenantStorageAccountName = "storaccxt" + $env.RandomString
    $crossTenantStorageAccount = New-AzStorageAccount -ResourceGroupName $env.ResourceGroupName -Name $env.CrossTenantStorageAccountName -SkuName Standard_LRS -Location $env.CrossTenantLocation -AllowBlobPublicAccess $false -AllowSharedKeyAccess $false -RequireInfrastructureEncryption -EnableHttpsTrafficOnly $true -MinimumTlsVersion TLS1_2
    $env.CrossTenantStorageAccountId = $crossTenantStorageAccount.Id
    $env.CrossTenantContainerName = "container" + $env.RandomString
    New-AzRmStorageContainer -ResourceGroupName $env.ResourceGroupName -StorageAccountName $env.CrossTenantStorageAccountName -Name $env.CrossTenantContainerName | Out-Null
    $env.PartnerTenantId = $env:SM_XT_PARTNER_TENANT
    $env.PartnerStorageAccountId = $env:SM_XT_PARTNER_STORAGE_ACCOUNT_ID
    $env.PartnerEndpointId = $env:SM_XT_PARTNER_ENDPOINT_ID
    if ($env.PartnerEndpointId) {
        $env.PartnerEndpointName = ($env.PartnerEndpointId -split '/')[-1]
    }

    $scenarioFixtures = Initialize-StorageMoverScenarioEnvironment
    foreach ($key in $scenarioFixtures.Keys) {
        $env[$key] = $scenarioFixtures[$key]
    }

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    if ($env.ScenarioResourceGroupName) {
        $groupPath = "/subscriptions/$($env.ScenarioSubscriptionId)/resourceGroups/$($env.ScenarioResourceGroupName)?api-version=2022-09-01"
        $group = Invoke-StorageMoverTestArmRequest -Method GET -Path $groupPath -IgnoreNotFound
        if ($group -and $group.tags.runId -eq $env.ScenarioRunId) {
            Invoke-StorageMoverTestArmRequest -Method DELETE -Path $groupPath | Out-Null
        }
    }

    # Delete the storage mover and storage account created for the cross-tenant job definition scenario.
    if ($env.CrossTenantStoMoverName) {
        Remove-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $env.CrossTenantStoMoverName -Force -ErrorAction SilentlyContinue
    }
    if ($env.CrossTenantStorageAccountName) {
        Remove-AzStorageAccount -ResourceGroupName $env.ResourceGroupName -Name $env.CrossTenantStorageAccountName -Force -ErrorAction SilentlyContinue
    }

    # Delete the Connection resource created by setupEnv/tests.
    if ($env.ConnectionName) {
        Remove-AzStorageMoverConnection -Name $env.ConnectionName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -ErrorAction SilentlyContinue
    }

    # Delete the Private Link Service created by setupEnv. The PLS cannot be
    # deleted while it has Private Endpoint Connections referencing it, so we
    # first delete each linked private endpoint, then the PLS itself.
    if ($env.PrivateLinkServiceName) {
        $plsRg = if ($env.VNetResourceGroupName) { $env.VNetResourceGroupName } else { $env.ResourceGroupName }
        $pls = Get-AzPrivateLinkService -Name $env.PrivateLinkServiceName -ResourceGroupName $plsRg -ErrorAction SilentlyContinue
        if ($pls) {
            foreach ($pec in $pls.PrivateEndpointConnections) {
                # PrivateEndpoint.Id format:
                # /subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Network/privateEndpoints/{name}
                if ($pec.PrivateEndpoint -and $pec.PrivateEndpoint.Id) {
                    $peSegments = $pec.PrivateEndpoint.Id -split '/'
                    $peRg = $peSegments[4]
                    $peName = $peSegments[-1]
                    Remove-AzPrivateEndpoint -Name $peName -ResourceGroupName $peRg -Force -ErrorAction SilentlyContinue
                }
            }
            Remove-AzPrivateLinkService -Name $env.PrivateLinkServiceName -ResourceGroupName $plsRg -Force -ErrorAction SilentlyContinue
        }
    }
}

