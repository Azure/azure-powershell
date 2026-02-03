$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareLicense.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareLicense' {
    It 'Create' {
        {
            $result = New-AzVMwareLicense -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.Name | Should -Be "VmwareFirewall"
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $result = Get-AzVMwareLicense -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.Name | Should -Be "VmwareFirewall"
        } | Should -Not -Throw
    }

    It 'Get VCF License' {
        {
            $result = Get-AzVMwarePrivateCloudVcfLicense -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.Kind | Should -Be "vcf5"
        } | Should -Not -Throw
    }

    It 'Get Property' {
        {
            $result = Get-AzVMwareLicenseProperty -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.BroadcomSiteId | Should -Be "123456"
        } | Should -Not -Throw
    }

    It 'Update' {
        {
            $result = Update-AzVMwareLicense -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $result.Name | Should -Be "VmwareFirewall"
        } | Should -Not -Throw
    }

    It 'Remove' {
        {
            Remove-AzVMwareLicense -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
        } | Should -Not -Throw
    }
}