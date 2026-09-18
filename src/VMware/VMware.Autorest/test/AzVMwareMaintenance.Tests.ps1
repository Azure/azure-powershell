$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareMaintenance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareMaintenance' {

    It 'Get' {
        {
            $result = Get-AzVMwareMaintenance -Name maintenance1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.Name | Should -Be "maintenance1"
        } | Should -Not -Throw
    }
    It 'Invoke Maintenance Check' {
        {
            $result = Invoke-AzVMwareInitiateMaintenanceCheck -MaintenanceName maintenance1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.DisplayName | Should -Be "vcsa 7.0 upgrade"
        } | Should -Not -Throw
    }

    It 'Invoke Reschedule Maintenance' {
        {
            $result = Invoke-AzVMwareRescheduleMaintenance -MaintenanceName maintenance1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.StateName | Should -Be "Scheduled"
        } | Should -Not -Throw
    }

    It 'Invoke Schedule Maintenance' {
        {
            $result = Invoke-AzVMwareScheduleMaintenance -MaintenanceName maintenance1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.Component | Should -Be "VCSA"
        } | Should -Not -Throw
    }
}