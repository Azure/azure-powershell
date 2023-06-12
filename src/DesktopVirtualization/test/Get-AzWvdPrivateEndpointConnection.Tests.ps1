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

            New-AzPrivateEndpoint -ResourceGroupName = $env.ResourceGroup `
                                  -Name = $env.PrivateEndpointName `
                                  -Location = $env.Location `
                                  -Subnet = $vnet.Subnets[0] `
                                  -PrivateLinkServiceConnection = $privateLinkServiceConnection

            New-AzPrivateEndpoint -ResourceGroupName = $env.ResourceGroup `
                                  -Name = $env.PrivateEndpointName1 `
                                  -Location = $env.Location `
                                  -Subnet = $vnet.Subnets[0] `
                                  -PrivateLinkServiceConnection = $privateLinkServiceConnection1
        
        

            $privateEndpointConnections = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                             -workspaceName $env.Workspace 

            $privateEndpointConnections[0].Name | Should -Be $env.PrivateEndpointConnectionName
            $privateEndpointConnections[0].PrivateEndpointId | Should -Be "test"
            $privateEndpointConnections[1].Name | Should -Be $env.PrivateEndpointConnectionName1
            $privateEndpointConnections[1].PrivateEndpointId | Should -Be "test1"
            
        }
        finally {
            Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                  -WorkspaceName $env.Workspace `
                                                  -Name $env.PrivateEndpointConnectionName
                                                  
            Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                  -WorkspaceName $env.Workspace `
                                                  -Name $env.PrivateEndpointConnectionName1

            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                     -Name $env.PrivateEndpointName

            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                     -Name $env.PrivateEndpointName1
                                     
            Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                  -ResourceGroupName $env.ResourceGroup `
                                  -Name $env.Workspace
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

            New-AzPrivateEndpoint -ResourceGroupName = $env.ResourceGroup `
                                  -Name = $env.PrivateEndpointName `
                                  -Location = $env.Location `
                                  -Subnet = $vnet.Subnets[0] `
                                  -PrivateLinkServiceConnection = $privateLinkServiceConnection `

            $privateEndpointConnection = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                            -workspaceName $env.Workspace 

            $privateEndpointConnection.Name | Should -Be $env.PrivateEndpointConnectionName
            $privateEndpointConnection.PrivateEndpointId | Should -Be "test"
        }
        finally {
            Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                  -WorkspaceName $env.Workspace `
                                                  -Name $env.PrivateEndpointConnectionName
                                                  
            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                     -Name $env.PrivateEndpointName

                                     
            Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroup `
            -Name $env.Workspace
        }
    }

    It 'GetHostPool' {
        try {
            $hostpool = Get-AzWvdHostPool -ResourceGroupName $env.ResourceGroup `
                                          -Name $env.HostPoolPersistent

            $privateLinkServiceConnection = New-AzPrivateLinkServiceConnection -Name $env.PrivateEndpointConnectionName `
                                               -PrivateLinkServiceId $hostpool.ID `
                                               -GroupId $env.PECGroupIdHostPool

            ## Create the private endpoints, which are required for Get-AzWvdPrivateEndpointConnection, do not remove. ##
            $vnet = Get-AzVirtualNetwork -ResourceGroupName $env.ResourceGroup `
                                         -Name $env.VnetName

            New-AzPrivateEndpoint -ResourceGroupName = $env.ResourceGroup `
                                  -Name = $env.PrivateEndpointName `
                                  -Location = $env.Location `
                                  -Subnet = $vnet.Subnets[0] `
                                  -PrivateLinkServiceConnection = $privateLinkServiceConnection

            $privateEndpointConnection = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                            -HostPoolName $env.HostPool 

            $privateEndpointConnection.Name | Should -Be $env.PrivateEndpointConnectionName
            $privateEndpointConnection.PrivateEndpointId | Should -Be "test"
        }
        finally {
            Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                  -HostPoolName $env.HostPoolPersistent `
                                                  -Name $env.PrivateEndpointConnectionName

            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                     -Name $env.PrivateEndpointName
        }
    }

    It 'ListHostPool' {
        try {
            $hostpool = Get-AzWvdHostPool -ResourceGroupName $env.ResourceGroup `
                                          -Name $env.HostPoolPersistent

            $privateLinkServiceConnection = New-AzPrivateLinkServiceConnection -Name $env.PrivateEndpointConnectionName `
                                                                               -PrivateLinkServiceId $hostpool.ID `
                                                                               -GroupId $env.PECGroupIdHostPool
                                               
            $privateLinkServiceConnection1 = New-AzPrivateLinkServiceConnection -Name $env.PrivateEndpointConnectionName1 `
                                                                                -PrivateLinkServiceId $hostpool.ID `
                                                                                -GroupId $env.PECGroupIdHostPool

            ## Create the private endpoints, which are required for Get-AzWvdPrivateEndpointConnection, do not remove. ##
            $vnet = Get-AzVirtualNetwork -ResourceGroupName $env.ResourceGroup `
                                         -Name $env.VnetName

            New-AzPrivateEndpoint -ResourceGroupName = $env.ResourceGroup `
                                  -Name = $env.PrivateEndpointName `
                                  -Location = $env.Location `
                                  -Subnet = $vnet.Subnets[0] `
                                  -PrivateLinkServiceConnection = $privateLinkServiceConnection

            New-AzPrivateEndpoint -ResourceGroupName = $env.ResourceGroup `
                                  -Name = $env.PrivateEndpointName1 `
                                  -Location = $env.Location `
                                  -Subnet = $vnet.Subnets[0] `
                                  -PrivateLinkServiceConnection = $privateLinkServiceConnection1

            $privateEndpointConnections = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                             -HostPoolName $env.HostPool 

            $privateEndpointConnections[0].Name | Should -Be $env.PrivateEndpointConnectionName
            $privateEndpointConnections[0].PrivateEndpointId | Should -Be "test"
            $privateEndpointConnections[1].Name | Should -Be $env.PrivateEndpointConnectionName
            $privateEndpointConnections[1].PrivateEndpointId | Should -Be "test1"
        }
        finally {
            Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                  -HostPoolName $env.HostPoolPersistent `
                                                  -Name $env.PrivateEndpointConnectionName
                                                  
            Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                  -HostPoolName $env.HostPoolPersistent `
                                                  -Name $env.PrivateEndpointConnectionName1

            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                     -Name $env.PrivateEndpointName

            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                     -Name $env.PrivateEndpointName1
        }
    }
}
