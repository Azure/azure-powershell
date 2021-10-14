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
                $subnet = '/subscriptions/929287ae-832a-4946-8006-a6cc2a3f7244/resourceGroups/PostgreSqlTest/providers/Microsoft.Network/virtualNetworks/postgresqltestvnet/subnets/secondsubnet'
                $dnszone = '/subscriptions/929287ae-832a-4946-8006-a6cc2a3f7244/resourcegroups/PostgreSqlTest/providers/Microsoft.Network/privateDnsZones/daeunyim-powershell-test.postgres.database.azure.com'
                $sourceServer = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
                $server = Restore-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.restoreName -SourceServerName $env.flexibleServerName -RestorePointInTime 2021-08-23T22:20:00 -Zone 1 -Subnet $subnet -PrivateDnsZone $dnszone

                $server.NetworkDelegatedSubnetResourceId | Should -Be $subnet
                $server.NetworkPrivateDnsZoneArmResourceId | Should -Be $dnszone
                $server.SourceServerResourceId | Should -Be $sourceServer.Id
                $server.AvailabilityZone | Should -Be 1
            } | Should -Not -Throw
        }
    }
}
