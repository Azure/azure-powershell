$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDedicatedHsm.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDedicatedHsm' {
    It 'UpdateExpanded'  {
        $tag = @{'key1' = '1'; 'key2' = 2; 'key3' = 3}
        $hsm = Update-AzDedicatedHsm -Name  $env.dedicatedHsmName01 -ResourceGroupName $env.resourceGroup -Tag $tag
        $hsm.Tag.Count | Should -Be $tag.Count
    }

    It 'UpdateViaIdentityExpanded' {
        $tag = @{'key1' = '1'; 'key2' = 2; 'key3' = 3; 'key4' = 4}
        $hsm = Get-AzDedicatedHsm -Name  $env.dedicatedHsmName01 -ResourceGroupName $env.resourceGroup 
        $hsm = Update-AzDedicatedHsm -InputObject $hsm -Tag $tag
        $hsm.Tag.Count | Should -Be $tag.Count
    }
}
