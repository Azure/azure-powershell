$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzConnectedPrivateLinkScope.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzConnectedPrivateLinkScope' {
    BeforeAll {
        $resourceGroupName = $env.ResourceGroupName
        $scopeName = $env.PrivateLinkScopeName
        $location = $env.Location
        $tags = @{Tag1="tag1"; Tag2="tag2"}
        $tags2 = @{hello="hello"; world="world"}
    }


    It "Create, Get and Remove a Private Link Scope" {
        New-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName -ScopeName $scopeName -PublicNetworkAccess "Enabled" -Location $location

        Get-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName | Should -HaveCount 1

        $privateLinkScope = Get-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName -ScopeName $scopeName
        $privateLinkScope.Name | Should -Be $scopeName
        $privateLinkScope.PublicNetworkAccess | Should -Be "Enabled"
        
        Set-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName -ScopeName $scopeName -PublicNetworkAccess "Disabled" -Tag $tags -Location $location

        $privateLinkScope = Get-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName -ScopeName $scopeName
        $privateLinkScope.Name | Should -Be $scopeName
        $privateLinkScope.PublicNetworkAccess | Should -Be "Disabled"
        $privateLinkScope.Tags.AdditionalProperties["Tag1"] | Should -Be "tag1"

        Update-AzConnectedPrivateLinkScopeTag -ResourceGroupName $resourceGroupName -ScopeName $scopeName -Tag $tags2

        $privateLinkScope = Get-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName -ScopeName $scopeName        
        $privateLinkScope.Name | Should -Be $scopeName
        $privateLinkScope.PublicNetworkAccess | Should -Be "Disabled"
        $privateLinkScope.Tags.AdditionalProperties["hello"] | Should -Be "hello"

        Remove-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName -ScopeName $scopeName

        Get-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName | Should -HaveCount 0
    }
}
