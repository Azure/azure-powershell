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

    It 'GetWorkspace' {
        $privateEndpointConnection = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                        -workspaceName $env.PvtLinkWS 

        $privateEndpointConnection.Name | Should -Match $env.PrivateEndpointConnectionName
    }

    It 'ListWorkspace' {
        $privateEndpointConnections = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                            -workspaceName $env.PvtLinkWS 

        #Index of name is random, so we need to check both each time
        $name0 = $env.PrivateEndpointConnectionName0
        $name1 = $env.PrivateEndpointConnectionName1
        $privateEndpointConnections[0].Name | Should -Match "$name0|$name1"
        $privateEndpointConnections[1].Name | Should -Match "$name0|$name1"

    }

    It 'GetHostPool' {

        $privateEndpointConnection = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                        -HostPoolName $env.PvtLinkHP

        $privateEndpointConnection.Name | Should -Match $env.PrivateEndpointConnectionName
    }

    It 'ListHostPool' {

        $privateEndpointConnections = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                            -HostPoolName $env.PvtLinkHP

        #Index of name is random, so we need to check both each time
        $name0 = $env.PrivateEndpointConnectionName0
        $name1 = $env.PrivateEndpointConnectionName1
        $privateEndpointConnections[0].Name | Should -Match "$name0|$name1"
        $privateEndpointConnections[1].Name | Should -Match "$name0|$name1"
    }
}
