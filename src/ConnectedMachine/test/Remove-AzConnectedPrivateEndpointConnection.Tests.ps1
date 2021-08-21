$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzConnectedPrivateEndpointConnection.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzConnectedPrivateEndpointConnection' {
    BeforeAll {
        $privateConnectionName = ""
        $scopeName = "test-azpowershell"
        $rg = "az-sdk-test"
        $description = "Rejected by the test"
    }

    It "Update, Get and Remove a Private Endpoint Connection" {
        Get-AzConnectedPrivateEndpointConnection -ResourceGroupName $rg -ScopeName $scopeName | Should -HaveCount 1
        
        (Get-AzConnectedPrivateEndpointConnection -ResourceGroupName $rg -ScopeName $scopeName -Name $privateConnectionName).Name | Should -Be $privateConnectionName

        Set-AzConnectedPrivateEndpointConnection -ResourceGroupName $rg -ScopeName $scopeName -Name $privateConnectionName -PrivateLinkServiceConnectionStateDescription $description -PrivateLinkServiceConnectionStateStatus "Rejected"

        $privateConnection = Get-AzConnectedPrivateEndpointConnection -ResourceGroupName $rg -ScopeName $scopeName -Name $privateConnectionName
    }
}
