$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdPrivateLinkResource.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdPrivateLinkResource' {
    It 'GetWorkspace' {
        try {

            New-AzWvdWorkspace -ResourceGroupName $env.ResourceGroup `
            -Location $env.Location `
            -Name $env.Workspace `
            -FriendlyName 'fri' `
            -ApplicationGroupReference $null `
            -Description 'des'

            $privateLinkResource = Get-AzWvdPrivateLinkResource -ResourceGroupName $env.ResourceGroup `
                                                                -WorkspaceName $env.Workspace

            $privateLinkResource.Name | Should -Match "feed|global"
        }
        finally {
            Remove-AzWvdWorkspace -SubscriptionId $env.SubscriptionId `
                                  -ResourceGroupName $env.ResourceGroup `
                                  -Name $env.Workspace
        }
        
    }

    It 'GetHostPool' {
        $privateLinkResource = Get-AzWvdPrivateLinkResource -ResourceGroupName $env.ResourceGroup `
                                                            -HostPoolName $env.HostPoolPersistent

        $privateLinkResource.Name | Should -Match "connection"
    }
}
