# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# ----------------------------------------------------------------------------------

# Run with Pester 4 after importing the built module; no loadEnv.ps1 or TestMode is needed.
# NoWait limits these checks to request serialization, not operation completion or output.
Describe 'DocumentDB stable API request bodies' {
    BeforeAll {
        if (-not (Get-Module Az.DocumentDB)) {
            throw 'Import the built Az.DocumentDB module before running the offline request tests.'
        }
        . (Join-Path $PSScriptRoot 'DocumentDB.RequestTestHelpers.ps1')
        $script:stableRequestTestState = Initialize-DocumentDBRequestTest

        $subscriptionId = '00000000-0000-0000-0000-000000000000'
        $resourceGroupName = 'wire-test-rg'
        $clusterName = 'wire-test-cluster'
        $clusterId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.DocumentDB/mongoClusters/$clusterName"
        $identityId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/wire-test-identity"
        $script:stableSecondIdentityId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/wire-test-identity-2"
        $keyUrl = 'https://wire-test.invalid/keys/synthetic-key/synthetic-version'

        # A service GET has no password. Non-default, unrelated writable properties expose
        # accidental resets or omissions in the generated GET + PUT update implementation.
        $script:stableExistingCluster = @{
            id = $clusterId
            name = $clusterName
            type = 'Microsoft.DocumentDB/mongoClusters'
            location = 'eastus'
            tags = @{ retained = 'original' }
            identity = @{
                type = 'UserAssigned'
                userAssignedIdentities = @{ $identityId = @{} }
            }
            properties = @{
                provisioningState = 'Succeeded'
                administrator = @{ userName = 'existing-admin' }
                serverVersion = '8.0'
                compute = @{ tier = 'M40' }
                storage = @{ sizeGb = 128; type = 'PremiumSSD' }
                sharding = @{ shardCount = 2 }
                highAvailability = @{ targetMode = 'ZoneRedundantPreferred' }
                publicNetworkAccess = 'Disabled'
                authConfig = @{ allowedModes = @('NativeAuth', 'MicrosoftEntraID') }
                encryption = @{
                    customerManagedKeyEncryption = @{
                        keyEncryptionKeyUrl = $keyUrl
                        keyEncryptionKeyIdentity = @{
                            identityType = 'UserAssignedIdentity'
                            userAssignedIdentityResourceId = $identityId
                        }
                    }
                }
            }
        } | ConvertTo-Json -Depth 10

        function Assert-DocumentDBResourceRequest {
            param($Capture, [string[]] $Methods)

            $Capture.Requests.Count | Should -Be $Methods.Count
            for ($index = 0; $index -lt $Methods.Count; $index++) {
                $request = $Capture.Requests[$index]
                $request.Method | Should -Be $Methods[$index]
                $uri = [System.Uri]$request.RequestUri
                $uri.AbsolutePath | Should -Be $clusterId
                $uri.Query | Should -Be '?api-version=2026-09-01'
                if ($request.Method -eq 'GET') {
                    $request.Content | Should -BeNullOrEmpty
                }
                else {
                    $request.ContentType | Should -Match '^application/json'
                }
            }
        }

        function Assert-DocumentDBRetainedProperty {
            param($Body, [long] $StorageSizeGb = 128, [string[]] $IdentityIds = @($identityId))

            $Body.location | Should -Be 'eastus'
            $Body.properties.storage.type | Should -Be 'PremiumSSD'
            $Body.properties.storage.sizeGb | Should -Be $StorageSizeGb
            $Body.properties.storage.PSObject.Properties.Name | Should -Not -Contain 'oldType'
            $Body.properties.administrator.userName | Should -Be 'existing-admin'
            $Body.properties.compute.tier | Should -Be 'M40'
            $Body.properties.serverVersion | Should -Be '8.0'
            $Body.properties.sharding.shardCount | Should -Be 2
            $Body.properties.highAvailability.targetMode | Should -Be 'ZoneRedundantPreferred'
            $Body.properties.publicNetworkAccess | Should -Be 'Disabled'
            (@($Body.properties.authConfig.allowedModes | Sort-Object) -join ',') |
                Should -Be 'MicrosoftEntraID,NativeAuth'
            $Body.identity.type | Should -Be 'UserAssigned'
            @($Body.identity.userAssignedIdentities.PSObject.Properties).Count | Should -Be $IdentityIds.Count
            foreach ($expectedIdentityId in $IdentityIds) {
                $Body.identity.userAssignedIdentities.PSObject.Properties.Name | Should -Contain $expectedIdentityId
            }
            $cmk = $Body.properties.encryption.customerManagedKeyEncryption
            $cmk.keyEncryptionKeyUrl | Should -Be $keyUrl
            $cmk.keyEncryptionKeyIdentity.identityType | Should -Be 'UserAssignedIdentity'
            $cmk.keyEncryptionKeyIdentity.userAssignedIdentityResourceId | Should -Be $identityId
        }
    }

    AfterAll {
        if ($script:stableRequestTestState) {
            Restore-DocumentDBRequestTest -State $script:stableRequestTestState
        }
    }

    BeforeEach {
        $syntheticPassword = 'A1!{0}' -f [System.Guid]::NewGuid().ToString('N')
        $securePassword = [System.Security.SecureString]::new()
        foreach ($character in $syntheticPassword.ToCharArray()) {
            $securePassword.AppendChar($character)
        }
        $securePassword.MakeReadOnly()
    }

    AfterEach {
        $securePassword.Dispose()
    }

    It 'serializes ordinary create with storage type <CaseName>' -TestCases @(
        @{ CaseName = 'omitted'; StorageType = $null }
        @{ CaseName = 'PremiumSSD'; StorageType = 'PremiumSSD' }
        @{ CaseName = 'PremiumSSDv2'; StorageType = 'PremiumSSDv2' }
    ) {
        param($StorageType)

        $capture = New-DocumentDBRequestCapture -Responses @(
            @{ Method = 'PUT'; Body = $script:stableExistingCluster }
        )
        $parameters = @{
            Name = $clusterName
            ResourceGroupName = $resourceGroupName
            SubscriptionId = $subscriptionId
            Location = 'eastus'
            AdministratorUserName = 'create-admin'
            AdministratorPassword = $securePassword
            ComputeTier = 'M30'
            StorageSizeGb = 128
            ShardingShardCount = 1
            HttpPipelinePrepend = $capture.Pipeline
            # Only request construction is under test, not long-running operation polling.
            NoWait = $true
            Confirm = $false
            ErrorAction = 'Stop'
        }
        if ($null -ne $StorageType) {
            $parameters.StorageType = $StorageType
        }

        New-AzDocumentDBMongoCluster @parameters | Out-Null

        Assert-DocumentDBResourceRequest -Capture $capture -Methods @('PUT')
        $body = $capture.Requests[0].Content | ConvertFrom-Json
        $body.location | Should -Be 'eastus'
        $body.properties.storage.sizeGb | Should -Be 128
        $body.properties.storage.PSObject.Properties.Name | Should -Not -Contain 'oldType'
        if ($null -eq $StorageType) {
            $body.properties.storage.PSObject.Properties.Name | Should -Not -Contain 'type'
        }
        else {
            $body.properties.storage.PSObject.Properties.Name | Should -Contain 'type'
            $body.properties.storage.type | Should -Be $StorageType
        }
        $body.properties.administrator.userName | Should -Be 'create-admin'
        $body.properties.administrator.password | Should -Be $syntheticPassword
        $body.properties.compute.tier | Should -Be 'M30'
        $body.properties.sharding.shardCount | Should -Be 1
    }

    It 'preserves storage, identity, CMK and authentication during a named tags-only update' {
        $capture = New-DocumentDBRequestCapture -Responses @(
            @{ Method = 'GET'; Body = $script:stableExistingCluster }
            @{ Method = 'PUT'; Body = $script:stableExistingCluster }
        )

        Update-AzDocumentDBMongoCluster -Name $clusterName -ResourceGroupName $resourceGroupName `
            -SubscriptionId $subscriptionId -Tag @{ changed = 'tags-only' } `
            -HttpPipelinePrepend $capture.Pipeline -NoWait -Confirm:$false -ErrorAction Stop | Out-Null

        Assert-DocumentDBResourceRequest -Capture $capture -Methods @('GET', 'PUT')
        $body = $capture.Requests[1].Content | ConvertFrom-Json
        Assert-DocumentDBRetainedProperty -Body $body
        $body.tags.changed | Should -Be 'tags-only'
        @($body.tags.PSObject.Properties).Count | Should -Be 1
        $body.properties.administrator.PSObject.Properties.Name | Should -Not -Contain 'password'
    }

    It 'binds a pipeline identity and retains unbound fields during a size-only update' {
        $capture = New-DocumentDBRequestCapture -Responses @(
            @{ Method = 'GET'; Body = $script:stableExistingCluster }
            @{ Method = 'PUT'; Body = $script:stableExistingCluster }
        )
        $identity = [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.DocumentDbIdentity]::new()
        $identity.Id = $clusterId

        $identity | Update-AzDocumentDBMongoCluster -StorageSizeGb 256 `
            -HttpPipelinePrepend $capture.Pipeline -NoWait -Confirm:$false -ErrorAction Stop | Out-Null

        Assert-DocumentDBResourceRequest -Capture $capture -Methods @('GET', 'PUT')
        $body = $capture.Requests[1].Content | ConvertFrom-Json
        Assert-DocumentDBRetainedProperty -Body $body -StorageSizeGb 256
        $body.tags.retained | Should -Be 'original'
        $body.properties.administrator.PSObject.Properties.Name | Should -Not -Contain 'password'
    }

    It 'resets a SecureString password with the existing user name and unrelated properties intact' {
        $capture = New-DocumentDBRequestCapture -Responses @(
            @{ Method = 'GET'; Body = $script:stableExistingCluster }
            @{ Method = 'GET'; Body = $script:stableExistingCluster }
            @{ Method = 'PUT'; Body = $script:stableExistingCluster }
        )

        Reset-AzDocumentDBMongoClusterPassword -Name $clusterName -ResourceGroupName $resourceGroupName `
            -SubscriptionId $subscriptionId -AdministratorPassword $securePassword `
            -HttpPipelinePrepend $capture.Pipeline -NoWait -Confirm:$false -ErrorAction Stop | Out-Null

        # Reset resolves the user name, then the generated update performs its own GET + PUT.
        Assert-DocumentDBResourceRequest -Capture $capture -Methods @('GET', 'GET', 'PUT')
        $body = $capture.Requests[2].Content | ConvertFrom-Json
        Assert-DocumentDBRetainedProperty -Body $body
        $body.tags.retained | Should -Be 'original'
        $body.properties.administrator.password | Should -Be $syntheticPassword
    }

    It 'serializes a pipeline cluster identity <Change> without resetting other properties' -TestCases @(
        @{ Change = 'addition'; Removing = $false }
        @{ Change = 'removal'; Removing = $true }
    ) {
        param($Removing)

        $existingCluster = $script:stableExistingCluster | ConvertFrom-Json
        $existingIdentities = @{ $identityId = @{} }
        $expectedIdentities = @($identityId, $script:stableSecondIdentityId)
        if ($Removing) {
            $existingIdentities[$script:stableSecondIdentityId] = @{}
            $expectedIdentities = @($identityId)
        }
        $existingCluster.identity.userAssignedIdentities = $existingIdentities
        $existingResponse = $existingCluster | ConvertTo-Json -Depth 10
        $capture = New-DocumentDBRequestCapture -Responses @(
            @{ Method = 'GET'; Body = $existingResponse }
            @{ Method = 'GET'; Body = $existingResponse }
            # Deliberately return the old membership: only the outgoing PUT proves the change.
            @{ Method = 'PUT'; Body = $existingResponse }
        )

        $cluster = Get-AzDocumentDBMongoCluster -Name $clusterName -ResourceGroupName $resourceGroupName `
            -SubscriptionId $subscriptionId -HttpPipelinePrepend $capture.Pipeline -ErrorAction Stop
        $cluster | Update-AzDocumentDBMongoCluster -UserAssignedIdentity $expectedIdentities `
            -HttpPipelinePrepend $capture.Pipeline -NoWait -Confirm:$false -ErrorAction Stop | Out-Null

        Assert-DocumentDBResourceRequest -Capture $capture -Methods @('GET', 'GET', 'PUT')
        $body = $capture.Requests[2].Content | ConvertFrom-Json
        Assert-DocumentDBRetainedProperty -Body $body -IdentityIds $expectedIdentities
        $body.tags.retained | Should -Be 'original'
        $body.properties.administrator.PSObject.Properties.Name | Should -Not -Contain 'password'
    }

    It 'rejects missing PUT identity membership even when the response contains both identities' {
        $responseCluster = $script:stableExistingCluster | ConvertFrom-Json
        $responseCluster.identity.userAssignedIdentities = @{
            $identityId = @{}
            $script:stableSecondIdentityId = @{}
        }
        $capture = New-DocumentDBRequestCapture -Responses @(
            @{ Method = 'GET'; Body = $script:stableExistingCluster }
            @{ Method = 'PUT'; Body = ($responseCluster | ConvertTo-Json -Depth 10) }
        )

        Update-AzDocumentDBMongoCluster -Name $clusterName -ResourceGroupName $resourceGroupName `
            -SubscriptionId $subscriptionId -Tag @{ retained = 'original' } `
            -HttpPipelinePrepend $capture.Pipeline -NoWait -Confirm:$false -ErrorAction Stop | Out-Null

        Assert-DocumentDBResourceRequest -Capture $capture -Methods @('GET', 'PUT')
        $body = $capture.Requests[1].Content | ConvertFrom-Json
        Assert-DocumentDBRetainedProperty -Body $body
        { Assert-DocumentDBRetainedProperty -Body $body -IdentityIds @($identityId, $script:stableSecondIdentityId) } |
            Should -Throw
    }
}
