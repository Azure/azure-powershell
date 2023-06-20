$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWvdPrivateEndpointConnection.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzWvdPrivateEndpointConnection' {
    It 'DeleteWorkspace' {
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
                                                                            -WorkspaceName $env.Workspace 

            $privateEndpointConnection.Name | Should -Match $env.PrivateEndpointConnectionName

            Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                  -WorkspaceName $env.Workspace `
                                                  -Name $privateEndpointConnection.Name `

            try{
                $privateEndpointConnection = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                -WorkspaceName $env.Workspace
                throw "Get should have failed" 
            }
            catch {

            }
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

    It 'DeleteHostpool' {
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

            $privateEndpointConnection = Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                               -HostPoolName $env.HostPool `
                                                                               -name $privateEndpointConnection.Name `
                                                                               
            try{
                $privateEndpointConnection = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                                -HostpoolName $env.HostPool
                throw "Get should have failed" 
            }
            catch {

            }
        }
        finally {
            Remove-AzWvdHostPool -ResourceGroupName $env.ResourceGroup `
                                 -Name $env.HostPool

            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroup `
                                     -Name $env.PrivateEndpointName `
                                     -Force
        }
        
    }
}
