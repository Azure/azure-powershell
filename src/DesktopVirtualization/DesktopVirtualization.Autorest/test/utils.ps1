function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function setupEnv() {
    $env = @{}
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    # The wvdtesttenant.onmicrosoft.com tenant is inactive, please update the parameters below to your own resource group to finish the test.
    # By now, we are using w365runner250520sh01.onmicrosoft.com tenant to test it. TenantId: 715492f1-ef6e-4eea-9176-7c81e765c3c8
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.

    #---------- Self Contained Resources ----------
    # The following resources are created and removed within each test.
    $envFile = 'env.json'
    $null = $env.Add("ResourceGroup", "zhongjie-rg-wus")
    $null = $env.Add("Location", "westus2")
    $null = $env.Add("HostPool", "HostPoolPowershellContained1")
    $null = $env.Add("HostPool2", "HostPoolPowershellContained2")
    $null = $env.Add("Workspace", "WorkspacePowershellContained")
    $null = $env.Add("PvtLinkWS", "PrivateLinkWorkspace")
    $null = $env.Add("PvtLinkHP", "PrivateLinkHostPool")
    $null = $env.Add("RemoteApplicationGroup", "ApplicationGroupPowershell2")
    $null = $env.Add("DesktopApplicationGroup", "ApplicationGroupPowershell1")
    # Using vhdx file in the storage account.
    $null = $env.Add("MSIXImagePath", "\\liweiavdtestsa.file.core.windows.net\avdtestfs\Apps\VHDX\XmlNotepad\XmlNotepad.vhdx")
    $null = $env.Add("MSIXImageFamilyName", "43906ChrisLovett.XmlNotepad_hndwmj480pefj")
    $null = $env.Add("MSIXImagePackageName", "43906ChrisLovett.XmlNotepad")
    $null = $env.Add("MSIXImagePackageAlias", "43906chrislovettxmlnotepad-1")
    $null = $env.Add("MSIXImagePackageRelativePath", "\apps\43906ChrisLovett.XmlNotepad_2.9.0.16_neutral__hndwmj480pefj")
    $null = $env.Add("PrivateEndpointConnectionNameWS", "pwshTestPECWS")
    $null = $env.Add("PrivateEndpointConnectionNameWS1", "pwshTestPECWS1")
    $null = $env.Add("PrivateEndpointConnectionNameHP", "pwshTestPECHP")
    $null = $env.Add("PrivateEndpointConnectionNameHP1", "pwshTestPECHP1")
    $null = $env.Add("PrivateEndpointNameWS", "pwshTestPrivateEndpointWS")
    $null = $env.Add("PrivateEndpointNameWS1", "pwshTestPrivateEndpointWS1")
    $null = $env.Add("PrivateEndpointNameHP", "pwshTestPrivateEndpointHP")
    $null = $env.Add("PrivateEndpointNameHP1", "pwshTestPrivateEndpointHP1")
    $null = $env.Add("PECGroupIdWorkspace", "feed")
    $null = $env.Add("PECGroupIdHostPool", "connection")

    #auto-set based on the values above, do not edit
    $null = $env.Add("HostPoolArmPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.DesktopVirtualization/hostpools/"+ $env.HostPool)
    $null = $env.Add("HostPoolArmPath2", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.DesktopVirtualization/hostpools/"+ $env.HostPool2)
    $null = $env.Add("DesktopApplicationGroupPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.DesktopVirtualization/applicationgroups/" + $env.DesktopApplicationGroup)
    $null = $env.Add("RemoteApplicationGroupPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.DesktopVirtualization/applicationgroups/" + $env.RemoteApplicationGroup)
    $null = $env.Add("ResourceGroupArmPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup)
    
    #---------- Persistent Resources ----------
    # Todo: Remove and combine duplicated/useless parameters. And we should remove the presistent resources as much as we can. In most cases, we only need one automated hostpool with two active session hosts to finish all tests.
    # The following resources are manually created and removed by the operator.
    $null = $env.Add("ResourceGroupPersistent", $env.ResourceGroup)
    # Using this HostPool to run test depending on the existed session host/user sessions, so you need to create a session host manually and connect to the VM manually.
    $null = $env.Add("HostPoolPersistent", "zhongjie-automated")
    $null = $env.Add("AutomatedHostpoolPersistent", "zhongjie-automated")
    $null = $env.Add("SessionHostNamePrefixOfAutomatedHostpoolPersistent", "auto")
    $null = $env.Add("HostPoolPersistentArmPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroupPersistent + "/providers/Microsoft.DesktopVirtualization/hostpools/"+ $env.HostPoolPersistent)
    $null = $env.Add("SessionHostName", "auto-0")
    $null = $env.Add("PersistentDesktopAppGroup", "zhongjie-automated-DAG")
    $null = $env.Add("PersistentRemoteAppGroup", "zhongjie-automated-RAG")
    $null = $env.Add("VnetName", "zhongjievirtualnetworkwestus")
    $null = $env.Add("VnetSubnetId", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.Network/virtualNetworks/" + $env.VnetName + "/subnets/default" )
    # Using this HostPool to run the test related to the SHC/SHM/Session Host repovisioning, this doesn't require connect to the VM, but you still might need to create a session host manually in it.
    $null = $env.Add("SHMHostPoolPersistent", "zhongjie-automated2")
    $null = $env.Add("SHMSessionHostReprovisioning", "auto2-0")
    $null = $env.Add("SHMSessionHostNameRemove", "auto2-2")
    $null = $env.Add("SHMSessionHostNamePrefix", "auto2")
    # Key vault is used in the SHC creating: New-AzWvdSessionHostConfiguration. Todo: Create this Key vault in the SHC creating test process
    $null = $env.Add("KeyVaultPersistentResourceName", "zhongjie-kv")
    $null = $env.Add("KeyVaultPersistentArmPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup)
    $null = $env.Add("VMAdminCredentialsPasswordKeyvaultSecretUri", "https://" +$env.KeyVaultPersistentResourceName + ".vault.azure.net/secrets/password")
    $null = $env.Add("VMAdminCredentialsUserNameKeyvaultSecretUri", "https://" +$env.KeyVaultPersistentResourceName + ".vault.azure.net/secrets/username")
    # VM information for SHC
    $null = $env.Add("MarketplaceInfoPublisher", "microsoftwindowsdesktop")
    $null = $env.Add("MarketplaceInfoSku", "win11-24h2-avd")
    $null = $env.Add("MarketplaceInfoOffer", "windows-11")
    
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
            -StartVMOnConnect:$false `
            -ManagementType 'Standard'

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
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    $ResourceGroup = "zhongjie-rg-wus"
    $PvtLinkWS = "PrivateLinkWorkspace"
    $PvtLinkHP = "PrivateLinkHostPool"
    $PrivateEndpointNameWS = "pwshTestPrivateEndpointWS"
    $PrivateEndpointNameWS1 = "pwshTestPrivateEndpointWS1"
    $PrivateEndpointNameHP = "pwshTestPrivateEndpointHP"
    $PrivateEndpointNameHP1 = "pwshTestPrivateEndpointHP1"

    Remove-AzWvdWorkspace -ResourceGroupName $ResourceGroup `
                          -Name $PvtLinkWS

    Remove-AzPrivateEndpoint -ResourceGroupName $ResourceGroup `
                             -Name $PrivateEndpointNameWS `
                             -Force

    Remove-AzPrivateEndpoint -ResourceGroupName $ResourceGroup `
                             -Name $PrivateEndpointNameWS1 `
                             -Force

    Remove-AzWvdHostPool -ResourceGroupName $ResourceGroup `
                         -Name $PvtLinkHP
    
    Remove-AzPrivateEndpoint -ResourceGroupName $ResourceGroup `
                             -Name $PrivateEndpointNameHP `
                             -Force

    Remove-AzPrivateEndpoint -ResourceGroupName $ResourceGroup `
                             -Name $PrivateEndpointNameHP1 `
                             -Force
}