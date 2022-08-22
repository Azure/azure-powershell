$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzPostgreSqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restore-AzPostgreSqlFlexibleServer' {
    It 'PointInTimeRestore' {
        If ($TestMode -eq 'live' -Or $TestMode -eq 'record') {
            {
                $DnsZone = New-AzPrivateDnsZone -Name $env.DnsZoneName -ResourceGroupName $env.resourceGroup
                $SubnetId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/nonexistingvnetforpowershelltest/subnets/nonexistingsubnetforpowershelltest"
                $sourceServer = New-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName2 -Location $env.location -Subnet $SubnetId -PrivateDnsZone $DnsZone.ResourceId
                Start-Sleep -Seconds 60
                $server = Restore-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.restoreName -SourceServerName $env.flexibleServerName2 -RestorePointInTime $(Get-Date) -Subnet $SubnetId -PrivateDnsZone $DnsZone.ResourceId

                $server.NetworkDelegatedSubnetResourceId | Should -Be $SubnetId
                $server.NetworkPrivateDnsZoneArmResourceId | Should -Be $DnsZone.ResourceId
                $server.AvailabilityZone | Should -Be $sourceServer.AvailabilityZone
            } | Should -Not -Throw
        }
    }
}
