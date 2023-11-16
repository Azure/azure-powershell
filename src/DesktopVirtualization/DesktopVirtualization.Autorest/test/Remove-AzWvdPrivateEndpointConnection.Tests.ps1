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
        $privateEndpointConnection = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                        -WorkspaceName $env.PvtLinkWS 

        $privateEndpointConnection.Name | Should -Match $env.PrivateEndpointConnectionNameWS

        Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                -WorkspaceName $env.PvtLinkWS `
                                                -Name $privateEndpointConnection[1].Name

        Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                -WorkspaceName $env.PvtLinkWS `
                                                -Name $privateEndpointConnection[0].Name
        try{
            $privateEndpointConnection = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                            -WorkspaceName $env.PvtLinkWS
            throw "Get should have failed" 
        }
        catch {

        }
    }

    It 'DeleteHostpool' {
        $privateEndpointConnection = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                        -HostPoolName $env.PvtLinkHP

        $privateEndpointConnection.Name | Should -Match $env.PrivateEndpointConnectionNameHP

        Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                -HostPoolName $env.PvtLinkHP `
                                                -Name $privateEndpointConnection[0].Name

                                                                            
        Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                -HostPoolName $env.PvtLinkHP `
                                                -Name $privateEndpointConnection[1].Name

        try{
            $privateEndpointConnection = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                            -HostpoolName $env.PvtLinkHP
            throw "Get should have failed" 
        }
        catch {

        }
        
    }
}
