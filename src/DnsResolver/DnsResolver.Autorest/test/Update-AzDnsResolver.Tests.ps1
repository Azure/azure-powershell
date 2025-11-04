."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"
."$PSScriptRoot\dnsResolverAssertions.ps1"
."$PSScriptRoot\Constants.ps1"

Add-AssertionOperator -Name 'BeSuccessfullyCreated' -Test $Function:BeSuccessfullyCreated
Add-AssertionOperator -Name 'BeSameAsExpected' -Test $Function:BeSameAsExpected

$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolver.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDnsResolver' {
    It 'Update DNS Resolver by adding tag, expect DNS resolver updated' {
        # ARRANGE
        $dnsResolverName = "psdnsresolvername47";
        $virtualNetworkName = "psvirtualnetworkname47";
        $virtualNetworkName = "psvirtualnetworkforresolvername0gasfdzg";
        $virtualNetworkId = "/subscriptions/$SUBSCRIPTION_ID/resourceGroups/$RESOURCE_GROUP_NAME/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"

        if ($TestMode -eq "Record")
        {
            $defaultSubnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "10.0.0.0/24"
            $vnet = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $defaultSubnet -Force
        }

        $originalDnsResolver = New-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -VirtualNetworkId $virtualNetworkId -Location $LOCATION

        $tag  = GetRandomHashtable -size 5

        # ACT
        $updatedDnsResolver = Update-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME -Tag $tag

        # ASSERT
        $updatedDnsResolver | Should -BeSuccessfullyCreated
        $updatedDnsResolver | Should -BeSameAsExpected -ExpectedValue $originalDnsResolver
        $updatedDnsResolver.Tag.Count | Should -Be $tag.Count

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolver -Name $dnsResolverName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $RESOURCE_GROUP_NAME -Force
    }
}
