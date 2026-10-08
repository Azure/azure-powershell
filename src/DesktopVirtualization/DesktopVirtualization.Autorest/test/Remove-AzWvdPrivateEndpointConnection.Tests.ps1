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

        ($privateEndpointConnection.Name -match "^$([regex]::Escape($env.PrivateEndpointConnectionNameWS))\.").Count | Should -Be 1
        ($privateEndpointConnection.Name -match "^$([regex]::Escape($env.PrivateEndpointConnectionNameWS1))\.").Count | Should -Be 1

        foreach ($connection in $privateEndpointConnection) {
            Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                   -WorkspaceName $env.PvtLinkWS `
                                                   -Name $connection.Name
        }
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

        ($privateEndpointConnection.Name -match "^$([regex]::Escape($env.PrivateEndpointConnectionNameHP))\.").Count | Should -Be 1
        ($privateEndpointConnection.Name -match "^$([regex]::Escape($env.PrivateEndpointConnectionNameHP1))\.").Count | Should -Be 1

        foreach ($connection in $privateEndpointConnection) {
            Remove-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                   -HostPoolName $env.PvtLinkHP `
                                                   -Name $connection.Name
        }

        try{
            $privateEndpointConnection = Get-AzWvdPrivateEndpointConnection -ResourceGroupName $env.ResourceGroup `
                                                                            -HostpoolName $env.PvtLinkHP
            throw "Get should have failed" 
        }
        catch {

        }
        
    }
}
