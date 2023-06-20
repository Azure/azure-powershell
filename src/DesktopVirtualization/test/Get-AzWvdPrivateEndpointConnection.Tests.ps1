$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdPrivateEndpointConnection.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdPrivateEndpointConnection' {
    It 'ListWorkspace' {
        try {
            $workspace = New-AzWvdWorkspace -ResourceGroupName $env.ResourceGroup `
                                            -Location $env.Location `
                                            -Name $env.Workspace `
                                            -FriendlyName 'fri' `
                                            -ApplicationGroupReference $null `
                                            -Description 'des'

            $privateLinkServiceConnection = New-AzPrivateLinkServiceConnection -Name $env.PrivateEndpointConnectionName `
                                                                               -PrivateLinkServiceId $workspace.ID `
                                                                               -GroupId $env.PECGroupIdWorkspace
               
            $privateLinkServiceConnection1 = New-AzPrivateLinkServiceConnection -Name $env.PrivateEndpointConnectionName1 `
                                                                                -PrivateLinkServiceId $workspace.ID `
                                                                                -GroupId $env.PECGroupIdWorkspace

            ## Create the private endpoints, which are required for Get-AzWvdPrivateEndpointConnection, do not remove. ##
            $vnet = Get-AzVirtualNetwork -ResourceGroupName $env.ResourceGroup `
                                         -Name $env.VnetName

            New-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                  -Name $env.PrivateEndpointName `
                                  -Location $env.Location `
                                  -Subnet $vnet.Subnets[0] `
                                  -PrivateLinkServiceConnection $privateLinkServiceConnection `
                                  -Force

            New-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                  -Name $env.PrivateEndpointName1 `
                                  -Location $env.Location `
                                  -Subnet $vnet.Subnets[0] `
                                  -PrivateLinkServiceConnection $privateLinkServiceConnection1 `
                                  -Force
        
        

            $privateEndpointConnections = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                             -workspaceName $env.Workspace 

           #Index of name is random, so we need to check both each time
           $name0 = $env.PrivateEndpointConnectionName0
           $name1 = $env.PrivateEndpointConnectionName1
           $privateEndpointConnections[0].Name | Should -Match "$name0|$name1"
           $privateEndpointConnections[1].Name | Should -Match "$name0|$name1"
            
        }
        finally {
                                                 
            Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                  -ResourceGroupName $env.ResourceGroup `
                                  -Name $env.Workspace

            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                     -Name $env.PrivateEndpointName `
                                     -Force

            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                     -Name $env.PrivateEndpointName1 `
                                     -Force
        }

    }

    It 'GetWorkspace' {
        try {
            $workspace = New-AzWvdWorkspace -ResourceGroupName $env.ResourceGroup `
                                            -Location $env.Location `
                                            -Name $env.Workspace `
                                            -FriendlyName 'fri' `
                                            -ApplicationGroupReference $null `
                                            -Description 'des'

            $privateLinkServiceConnection = New-AzPrivateLinkServiceConnection -Name $env.PrivateEndpointConnectionName `
                                               -PrivateLinkServiceId $workspace.ID `
                                               -GroupId $env.PECGroupIdWorkspace

            ## Create the private endpoints, which are required for Get-AzWvdPrivateEndpointConnection, do not remove. ##
            $vnet = Get-AzVirtualNetwork -ResourceGroupName $env.ResourceGroup `
                                         -Name $env.VnetName

            New-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                  -Name $env.PrivateEndpointName `
                                  -Location $env.Location `
                                  -Subnet $vnet.Subnets[0] `
                                  -PrivateLinkServiceConnection $privateLinkServiceConnection `
                                  -Force

            $privateEndpointConnection = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                            -workspaceName $env.Workspace 

            $privateEndpointConnection.Name | Should -Match $env.PrivateEndpointConnectionName
        }
        finally {
                                         
            Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroup `
            -Name $env.Workspace
            
            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                     -Name $env.PrivateEndpointName `
                                     -Force
        }
    }

    It 'GetHostPool' {
        try {
            $hostpool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroup `
            -Name $env.HostPool `
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

            $privateLinkServiceConnection = New-AzPrivateLinkServiceConnection -Name $env.PrivateEndpointConnectionName `
                                               -PrivateLinkServiceId $hostpool.ID `
                                               -GroupId $env.PECGroupIdHostPool

            ## Create the private endpoints, which are required for Get-AzWvdPrivateEndpointConnection, do not remove. ##
            $vnet = Get-AzVirtualNetwork -ResourceGroupName $env.ResourceGroup `
                                         -Name $env.VnetName

            New-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                  -Name $env.PrivateEndpointName `
                                  -Location $env.Location `
                                  -Subnet $vnet.Subnets[0] `
                                  -PrivateLinkServiceConnection $privateLinkServiceConnection `
                                  -Force

            $privateEndpointConnection = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                            -HostPoolName $env.HostPool

            $privateEndpointConnection.Name | Should -Match $env.PrivateEndpointConnectionName
        }
        finally {
            Remove-AzWvdHostPool -ResourceGroupName $env.ResourceGroup `
                                 -Name $env.HostPool

            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                     -Name $env.PrivateEndpointName `
                                     -Force
        }
    }

    It 'ListHostPool' {
        try {
            $hostpool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroup `
            -Name $env.HostPool `
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

            $privateLinkServiceConnection = New-AzPrivateLinkServiceConnection -Name $env.PrivateEndpointConnectionName `
                                                                               -PrivateLinkServiceId $hostpool.ID `
                                                                               -GroupId $env.PECGroupIdHostPool
                                               
            $privateLinkServiceConnection1 = New-AzPrivateLinkServiceConnection -Name $env.PrivateEndpointConnectionName1 `
                                                                                -PrivateLinkServiceId $hostpool.ID `
                                                                                -GroupId $env.PECGroupIdHostPool

            ## Create the private endpoints, which are required for Get-AzWvdPrivateEndpointConnection, do not remove. ##
            $vnet = Get-AzVirtualNetwork -ResourceGroupName $env.ResourceGroup `
                                         -Name $env.VnetName

            New-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                  -Name $env.PrivateEndpointName `
                                  -Location $env.Location `
                                  -Subnet $vnet.Subnets[0] `
                                  -PrivateLinkServiceConnection $privateLinkServiceConnection `
                                  -Force

            New-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                  -Name $env.PrivateEndpointName1 `
                                  -Location $env.Location `
                                  -Subnet $vnet.Subnets[0] `
                                  -PrivateLinkServiceConnection $privateLinkServiceConnection1 `
                                  -Force

            $privateEndpointConnections = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                             -HostPoolName $env.HostPool

            #Index of name is random, so we need to check both each time
            $name0 = $env.PrivateEndpointConnectionName0
            $name1 = $env.PrivateEndpointConnectionName1
            $privateEndpointConnections[0].Name | Should -Match "$name0|$name1"
            $privateEndpointConnections[1].Name | Should -Match "$name0|$name1"
        }
        finally {
            Remove-AzWvdHostPool -ResourceGroupName $env.ResourceGroup `
                                 -Name $env.HostPool

            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                     -Name $env.PrivateEndpointName `
                                     -Force

            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                     -Name $env.PrivateEndpointName1 `
                                     -Force
        }
    }
}
