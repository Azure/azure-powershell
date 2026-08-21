$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverIPConfigurationObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName
Describe 'New-AzDnsResolverIPConfigurationObject' {
    It 'Create an IP configuration object' {
        $ipConfig = New-AzDnsResolverIPConfigurationObject -SubnetId "/subscriptions/fake/resourceGroups/fake/providers/Microsoft.Network/virtualNetworks/fake/subnets/fake" -PrivateIPAllocationMethod "Dynamic"
        $ipConfig | Should -Not -BeNullOrEmpty
        $ipConfig.PrivateIPAllocationMethod | Should -Be "Dynamic"
    }
    It 'Create an IP configuration object with static IP' {
        $ipConfig = New-AzDnsResolverIPConfigurationObject -SubnetId "/subscriptions/fake/resourceGroups/fake/providers/Microsoft.Network/virtualNetworks/fake/subnets/fake" -PrivateIPAddress "10.0.0.4" -PrivateIPAllocationMethod "Static"
        $ipConfig.PrivateIPAddress | Should -Be "10.0.0.4"
    }
}

