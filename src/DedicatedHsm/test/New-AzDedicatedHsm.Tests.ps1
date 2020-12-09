$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDedicatedHsm.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDedicatedHsm' {
    It 'CreateExpanded' {
        $hsm = New-AzDedicatedHsm -Name  $env.dedicatedHsmName02 -ResourceGroupName $env.resourceGroup -Location $env.location -Sku "SafeNet Luna Network HSM A790" -StampId stamp1 -SubnetId $env.vnetSubnetId -NetworkInterface @{PrivateIPAddress = '10.2.1.120' }
        $hsm.ProvisioningState | Should -Be 'CheckingQuota'
    }
}
