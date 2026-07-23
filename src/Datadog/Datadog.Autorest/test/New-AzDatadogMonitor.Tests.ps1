$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDatadogMonitor.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDatadogMonitor' {
    It 'CreateExpanded' {
        {
            New-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $($env.monitorName03) -SubscriptionId "b16e4b4e-2ed8-4f32-bac1-0e3eb56bef5c" -EnableSystemAssignedIdentity -Location "centraluseuap" -MonitoringStatus "Enabled" -SkuName "pro_testing_20200911_Monthly@TIDgmz7xq9ge3py" -UserInfoEmailAddress 'bhanuchandj@microsoft.com' -UserInfoName 'bhanuchand' -UserInfoPhoneNumber '11111111111' -OrganizationName "bhanu-test-env-dd1"
        } | Should -Not -Throw
    }
}
