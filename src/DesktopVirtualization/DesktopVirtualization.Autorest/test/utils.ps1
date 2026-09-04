function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

function Get-AvdProvisionState {
    $statePath = Join-Path $PSScriptRoot 'provision-state.json'
    if (-not (Test-Path -Path $statePath)) {
        return $null
    }
    return Get-Content -Raw -Path $statePath | ConvertFrom-Json
}

function Get-AvdSelfContainedNames([string]$suffix) {
    # Names for resources that setupEnv/the tests CREATE and DELETE within a run.
    # Generated per-run from $suffix so they do not need to be maintained as inputs.
    # PECGroupId* are fixed API group ids, not resource names.
    return [ordered]@{
        HostPool                         = "pshostpool1$suffix"
        HostPool2                        = "pshostpool2$suffix"
        Workspace                        = "psworkspace$suffix"
        PvtLinkWS                        = "pspvtlinkws$suffix"
        PvtLinkHP                        = "pspvtlinkhp$suffix"
        RemoteApplicationGroup           = "psremoteag$suffix"
        DesktopApplicationGroup          = "psdesktopag$suffix"
        PrivateEndpointConnectionNameWS  = "pspecws$suffix"
        PrivateEndpointConnectionNameWS1 = "pspecws1$suffix"
        PrivateEndpointConnectionNameHP  = "pspechp$suffix"
        PrivateEndpointConnectionNameHP1 = "pspechp1$suffix"
        PrivateEndpointNameWS            = "pspews$suffix"
        PrivateEndpointNameWS1           = "pspews1$suffix"
        PrivateEndpointNameHP            = "pspehp$suffix"
        PrivateEndpointNameHP1           = "pspehp1$suffix"
        PECGroupIdWorkspace              = "feed"
        PECGroupIdHostPool               = "connection"
    }
}

function Get-AvdStableNameSuffix([string]$resourceGroup) {
    $state = Get-AvdProvisionState
    $subscriptionId = if ([string]::IsNullOrWhiteSpace($env:AVD_TEST_SUBSCRIPTION_ID)) {
        if ($state -and -not [string]::IsNullOrWhiteSpace($state.SubscriptionId)) {
            $state.SubscriptionId
        } else {
            (Get-AzContext).Subscription.Id
        }
    } else {
        $env:AVD_TEST_SUBSCRIPTION_ID
    }
    $bytes = [System.Text.Encoding]::UTF8.GetBytes("$subscriptionId|$resourceGroup".ToLowerInvariant())
    $sha = [System.Security.Cryptography.SHA256]::Create()
    try {
        $hash = $sha.ComputeHash($bytes)
    } finally {
        $sha.Dispose()
    }
    return -join ($hash[0..3] | ForEach-Object { $_.ToString('x2') })
}

function Get-AvdTestResourceConfig() {
    # The one place that names persistent test dependencies. setupEnv and
    # provision.ps1 use this function so the values cannot drift.
    $state = Get-AvdProvisionState
    $resourceGroup = if ([string]::IsNullOrWhiteSpace($env:AVD_TEST_RESOURCE_GROUP)) {
        if ($state -and -not [string]::IsNullOrWhiteSpace($state.ResourceGroupName)) {
            $state.ResourceGroupName
        } else {
            'zhongjie-rg-wus'
        }
    } else {
        $env:AVD_TEST_RESOURCE_GROUP
    }
    $location = if ([string]::IsNullOrWhiteSpace($env:AVD_TEST_LOCATION)) {
        if ($state -and -not [string]::IsNullOrWhiteSpace($state.Location)) {
            $state.Location
        } else {
            'westus2'
        }
    } else {
        $env:AVD_TEST_LOCATION
    }
    $suffix = Get-AvdStableNameSuffix $resourceGroup
    $prefix = "azps-avd-$suffix"
    $storageAccount = "azpsavd${suffix}sa"
    $sessionHostPrefix = "azps-$suffix"
    return [pscustomobject]@{
        Location = $location
        ResourceGroup = $resourceGroup
        VnetName = "$prefix-vnet"
        MSIXImagePath = "\\$storageAccount.file.core.windows.net\appattach\Apps\VHDX\XmlNotepad\XmlNotepad.vhdx"
        MSIXImageFamilyName = '43906ChrisLovett.XmlNotepad_hndwmj480pefj'
        MSIXImagePackageName = '43906ChrisLovett.XmlNotepad'
        MSIXImagePackageAlias = '43906chrislovettxmlnotepad'
        MSIXImagePackageRelativePath = '\apps\43906ChrisLovett.XmlNotepad_2.9.0.16_neutral__hndwmj480pefj'
        ResourceGroupPersistent = $resourceGroup
        HostPoolPersistent = "$prefix-hp"
        AutomatedHostpoolPersistent = "$prefix-hp"
        SessionHostNamePrefixOfAutomatedHostpoolPersistent = $sessionHostPrefix
        SessionHostName = "$sessionHostPrefix-0"
        PersistentDesktopAppGroup = "$prefix-dag"
        PersistentRemoteAppGroup = "$prefix-rag"
        SHMHostPoolPersistent = "$prefix-shm-hp"
        SHMSessionHostReprovisioning = "$sessionHostPrefix-1"
        SHMSessionHostNameRemove = "$sessionHostPrefix-2"
        SHMSessionHostNamePrefix = $sessionHostPrefix
        KeyVaultPersistentResourceName = "azpsavd${suffix}kv"
        MarketplaceInfoPublisher = 'microsoftwindowsdesktop'
        MarketplaceInfoSku = 'win11-24h2-avd'
        MarketplaceInfoOffer = 'windows-11'
    }
}

function Build-AvdTestEnv([object]$cfg, [string]$subscriptionId, [string]$tenant, [string]$suffix) {
    # Builds the fully-derived runtime env hashtable from an input config object.
    # Pure (no Azure calls), so it can be unit tested offline.
    $env = @{}
    $env.SubscriptionId = $subscriptionId
    $env.Tenant = $tenant

    # Copy persistent resource inputs. Identity is resolved from Get-AzContext.
    foreach ($prop in $cfg.PSObject.Properties) {
        if (-not $env.ContainsKey($prop.Name)) {
            $env[$prop.Name] = $prop.Value
        }
    }

    # Convenience default: many tests use ResourceGroupPersistent simply as "the
    # resource group". When it is not supplied, fall back to ResourceGroup so a
    # minimal config only needs ResourceGroup filled in.
    if ([string]::IsNullOrWhiteSpace([string]$env['ResourceGroupPersistent'])) {
        $env['ResourceGroupPersistent'] = $env['ResourceGroup']
    }

    # Self-contained resource names are generated per-run from $suffix (not
    # maintained in config). setupEnv writes them to the runtime env file so tests
    # and cleanupEnv use the same values.
    $selfNames = Get-AvdSelfContainedNames $suffix
    foreach ($k in $selfNames.Keys) { $env[$k] = $selfNames[$k] }

    #auto-set based on the values above, do not edit
    $null = $env.Add("HostPoolArmPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.DesktopVirtualization/hostpools/"+ $env.HostPool)
    $null = $env.Add("HostPoolArmPath2", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.DesktopVirtualization/hostpools/"+ $env.HostPool2)
    $null = $env.Add("DesktopApplicationGroupPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.DesktopVirtualization/applicationgroups/" + $env.DesktopApplicationGroup)
    $null = $env.Add("RemoteApplicationGroupPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.DesktopVirtualization/applicationgroups/" + $env.RemoteApplicationGroup)
    $null = $env.Add("ResourceGroupArmPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup)
    $null = $env.Add("HostPoolPersistentArmPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroupPersistent + "/providers/Microsoft.DesktopVirtualization/hostpools/"+ $env.HostPoolPersistent)
    $null = $env.Add("VnetSubnetId", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.Network/virtualNetworks/" + $env.VnetName + "/subnets/default" )
    $null = $env.Add("KeyVaultPersistentArmPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup)
    $null = $env.Add("VMAdminCredentialsPasswordKeyvaultSecretUri", "https://" +$env.KeyVaultPersistentResourceName + ".vault.azure.net/secrets/password")
    $null = $env.Add("VMAdminCredentialsUserNameKeyvaultSecretUri", "https://" +$env.KeyVaultPersistentResourceName + ".vault.azure.net/secrets/username")

    return $env
}

function setupEnv() {
    $cfg = Get-AvdTestResourceConfig
    $state = Get-AvdProvisionState
    Write-Host -ForegroundColor Green 'Setting up the test environment.'
    $subscriptionId = if ([string]::IsNullOrWhiteSpace($env:AVD_TEST_SUBSCRIPTION_ID)) {
        if ($state -and -not [string]::IsNullOrWhiteSpace($state.SubscriptionId)) {
            $state.SubscriptionId
        } else {
            (Get-AzContext).Subscription.Id
        }
    } else {
        $env:AVD_TEST_SUBSCRIPTION_ID
    }
    $tenant = if ([string]::IsNullOrWhiteSpace($env:AVD_TEST_TENANT_ID)) {
        if ($state -and -not [string]::IsNullOrWhiteSpace($state.TenantId)) {
            $state.TenantId
        } else {
            (Get-AzContext).Tenant.Id
        }
    } else {
        $env:AVD_TEST_TENANT_ID
    }
    $currentContext = Get-AzContext
    if ($currentContext.Subscription.Id -ne $subscriptionId -or $currentContext.Tenant.Id -ne $tenant) {
        Set-AzContext -SubscriptionId $subscriptionId -Tenant $tenant -ErrorAction Stop | Out-Null
    }

    # Generate a per-run suffix for the self-contained resource names.
    $suffix = RandomString $false 10
    $env = Build-AvdTestEnv -cfg $cfg -subscriptionId $subscriptionId -tenant $tenant -suffix $suffix

    # Persist the generated names early so cleanupEnv can find them even if a later
    # step (e.g. Private Link setup) fails. The final write below adds the image version.
    $envFile = if ($TestMode -eq 'live') { 'localEnv.json' } else { 'env.json' }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
    
    #---------- Persistent Resources ----------
    # Persistent resource names come from Get-AvdTestResourceConfig above; their
    # derived ARM paths are computed in Build-AvdTestEnv.
    
    # The context in which the tests are run will change the tenant and subscription ID when -record is run. 
    # Currently the scaling tests need to be run in a context with @microsoft, while the other tests are run with a test account
    # Modify the env.json manually after recording the necessary tests to get around this issue.

    # Due to a limitation on how the powershell tests are validated during the PR process,
    # any "cross-module" calls (Az.Network or similar) cannot be ran in the test file.
    # the following commands will set up non-persistent resources that will be cleaned up at
    # the end of each test run.

    #variables used for internal setup

    #PrivateLink Workspace resources
    Write-Host -ForegroundColor Green 'Creating Private Link resources required for testing...'
    try {
        $workspace = New-AzWvdWorkspace -ResourceGroupName $env.ResourceGroup `
        -Location $env.Location `
        -Name $env.PvtLinkWS `
        -FriendlyName 'fri' `
        -ApplicationGroupReference $null `
        -Description 'des'

        $privateLinkServiceConnectionWS = New-AzPrivateLinkServiceConnection -Name $env.PrivateEndpointConnectionNameWS `
                                            -PrivateLinkServiceId $workspace.ID `
                                            -GroupId $env.PECGroupIdWorkspace

        $privateLinkServiceConnectionWS1 = New-AzPrivateLinkServiceConnection -Name $env.PrivateEndpointConnectionNameWS1 `
                                                -PrivateLinkServiceId $workspace.ID `
                                                -GroupId $env.PECGroupIdWorkspace

        $vnet = Get-AzVirtualNetwork -ResourceGroupName $env.ResourceGroup `
        -Name $env.VnetName

        New-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
        -Name $env.PrivateEndpointNameWS `
        -Location $env.Location `
        -Subnet $vnet.Subnets[0] `
        -PrivateLinkServiceConnection $privateLinkServiceConnectionWS `
        -Force

        New-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
        -Name $env.PrivateEndpointNameWS1 `
        -Location $env.Location `
        -Subnet $vnet.Subnets[0] `
        -PrivateLinkServiceConnection $privateLinkServiceConnectionWS1 `
        -Force

        #Private Link HostPool Resources
        $hostpool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroup `
            -Name $env.PvtLinkHP `
            -Location $env.Location `
            -HostPoolType 'Pooled' `
            -LoadBalancerType 'DepthFirst' `
            -RegistrationTokenOperation 'Update' `
            -ExpirationTime $((get-date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')) `
            -Description 'des' `
            -FriendlyName 'fri' `
            -MaxSessionLimit 5 `
            -VMTemplate '{option1}' `
            -CustomRdpProperty $null `
            -Ring $null `
            -ValidationEnvironment:$false `
            -PreferredAppGroupType 'Desktop' `
            -StartVMOnConnect:$false 

        $privateLinkServiceConnectionHP = New-AzPrivateLinkServiceConnection -Name $env.PrivateEndpointConnectionNameHP `
                                            -PrivateLinkServiceId $hostpool.ID `
                                            -GroupId $env.PECGroupIdHostPool

        $privateLinkServiceConnectionHP1 = New-AzPrivateLinkServiceConnection -Name $env.PrivateEndpointConnectionNameHP1 `
                                            -PrivateLinkServiceId $hostpool.ID `
                                            -GroupId $env.PECGroupIdHostPool

        $vnet = Get-AzVirtualNetwork -ResourceGroupName $env.ResourceGroup `
                                    -Name $env.VnetName

        New-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                -Name $env.PrivateEndpointNameHP `
                                -Location $env.Location `
                                -Subnet $vnet.Subnets[0] `
                                -PrivateLinkServiceConnection $privateLinkServiceConnectionHP `
                                -Force

        New-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                -Name $env.PrivateEndpointNameHP1 `
                                -Location $env.Location `
                                -Subnet $vnet.Subnets[0] `
                                -PrivateLinkServiceConnection $privateLinkServiceConnectionHP1 `
                                -Force
    }
    catch {
        Write-Host -ForegroundColor Red 'Failed to create Private Link Workspace resources required for testing...'
        Write-Host -ForegroundColor Red $_.Exception.Message
    }

    #Grab latest Marketplace images
    $imageList = Get-AzVMImage -Location $env.Location -PublisherName $env.MarketplaceInfoPublisher -Offer $env.MarketplaceInfoOffer -Sku $env.MarketplaceInfoSku | Select Version
    $env.Add("MarketplaceImageVersion", $imageList[0].Version)
    Write-Host -ForegroundColor Green 'Marketplace image version: ' $env.MarketplaceImageVersion
    #Wrap up and create JSON file for tests to use
    $envFile = if ($TestMode -eq 'live') { 'localEnv.json' } else { 'env.json' }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
    Write-Host -ForegroundColor Green "Wrote runtime env file '$envFile'."
}
function cleanupEnv() {
    # Self-contained resource names are generated per-run by setupEnv and written to
    # the runtime env file; read them back so cleanup targets the same resources.
    $cfg = Get-AvdTestResourceConfig
    $ResourceGroup = $cfg.ResourceGroup
    $envFile = if ($TestMode -eq 'live') { 'localEnv.json' } else { 'env.json' }
    $envPath = Join-Path $PSScriptRoot $envFile
    if (-not (Test-Path -Path $envPath)) {
        Write-Warning "cleanupEnv: runtime env file '$envFile' not found; nothing to clean."
        return
    }
    $envData = Get-Content -Raw -Path $envPath | ConvertFrom-Json
    $PvtLinkWS = $envData.PvtLinkWS
    $PvtLinkHP = $envData.PvtLinkHP
    $PrivateEndpointNameWS = $envData.PrivateEndpointNameWS
    $PrivateEndpointNameWS1 = $envData.PrivateEndpointNameWS1
    $PrivateEndpointNameHP = $envData.PrivateEndpointNameHP
    $PrivateEndpointNameHP1 = $envData.PrivateEndpointNameHP1

    if (Get-AzWvdWorkspace -SubscriptionId $envData.SubscriptionId -ResourceGroupName $ResourceGroup -Name $PvtLinkWS -ErrorAction SilentlyContinue) {
        Remove-AzWvdWorkspace -SubscriptionId $envData.SubscriptionId -ResourceGroupName $ResourceGroup -Name $PvtLinkWS
    }

    foreach ($privateEndpointName in @(
        $PrivateEndpointNameWS,
        $PrivateEndpointNameWS1,
        $PrivateEndpointNameHP,
        $PrivateEndpointNameHP1
    )) {
        if (Get-AzPrivateEndpoint -ResourceGroupName $ResourceGroup -Name $privateEndpointName -ErrorAction SilentlyContinue) {
            Remove-AzPrivateEndpoint -ResourceGroupName $ResourceGroup -Name $privateEndpointName -Force
        }
    }

    if (Get-AzWvdHostPool -SubscriptionId $envData.SubscriptionId -ResourceGroupName $ResourceGroup -Name $PvtLinkHP -ErrorAction SilentlyContinue) {
        Remove-AzWvdHostPool -SubscriptionId $envData.SubscriptionId -ResourceGroupName $ResourceGroup -Name $PvtLinkHP
    }
}