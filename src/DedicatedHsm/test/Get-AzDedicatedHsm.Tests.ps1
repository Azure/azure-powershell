$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDedicatedHsm.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDedicatedHsm' {
    It 'List1' {
        $hsmList = Get-AzDedicatedHsm
        $hsmList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $hsm = Get-AzDedicatedHsm -Name $env.dedicatedHsmName01 -ResourceGroupName $env.resourceGroup
        $hsm.Name | Should -Be $env.dedicatedHsmName01
    }

    It 'List' {
        $hsmList = Get-AzDedicatedHsm -ResourceGroupName $env.resourceGroup
        $hsmList.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $hsm = Get-AzDedicatedHsm -Name $env.dedicatedHsmName01 -ResourceGroupName $env.resourceGroup 
        $hsm = Get-AzDedicatedHsm -InputObject $hsm
        $hsm.Name | Should -Be $env.dedicatedHsmName01
    }
}
