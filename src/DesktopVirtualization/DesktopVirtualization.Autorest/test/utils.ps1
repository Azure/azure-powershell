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

function setupEnv() {
    $env = @{}
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.

    #---------- Self Contained Resources ----------
    # The following resources are created and removed within each test.
    $envFile = 'env.json'
    $null = $env.Add("ResourceGroup", "alecbUserSessionTests")
    $null = $env.Add("Location", "westus2")
    $null = $env.Add("HostPool", "HostPoolPowershellContained1")
    $null = $env.Add("HostPool2", "HostPoolPowershellContained2")
    $null = $env.Add("Workspace", "WorkspacePowershellContained")
    $null = $env.Add("PvtLinkWS", "PrivateLinkWorkspace")
    $null = $env.Add("PvtLinkHP", "PrivateLinkHostPool")
    $null = $env.Add("RemoteApplicationGroup", "ApplicationGroupPowershell2")
    $null = $env.Add("DesktopApplicationGroup", "ApplicationGroupPowershell1")
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

    #---------- Persistent Resources ----------
    # The following resources are manually created and removed by the operator.
    $null = $env.Add("ResourceGroupPersistent", "alecbUserSessionTests")
    $null = $env.Add("HostPoolPersistent", "alecbUserSessionHP")
    $null = $env.Add("HostPoolPersistent2", "alecbRemoteAppHP")
    $null = $env.Add("HostPoolPersistentArmPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroupPersistent + "/providers/Microsoft.DesktopVirtualization/hostpools/"+ $env.HostPoolPersistent)
    $null = $env.Add("SessionHostName", "userSess-sh-0")
    $null = $env.Add("SessionHostNameRemove", "PSTestRmve-0")
    $null = $env.Add("PersistentDesktopAppGroup", "alecbUserSessionHP-DAG")
    $null = $env.Add("PersistentRemoteAppGroup", "alecbRemoteAppHP-RAG")
    $null = $env.Add("VnetName", "alecbUserSession-vnet")
    #TODO: Instead of this being a persistent resource on the HP, we should add the vhd to a Storage Account and access it from there.
    $null = $env.Add("MSIXImagePath", "C:\AppAttach\Firefox20110.0.1.vhdx")
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

    #Wrap up and create JSON file for tests to use
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    $ResourceGroup = "alecbUserSessionTests"
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

