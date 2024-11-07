$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Import-AzWvdAppAttachPackageInformation.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Import-AzWvdAppAttachPackageInfo' {
    It 'ImportExpanded' {
        $package = Import-AzWvdAppAttachPackageInfo -HostPoolName $env.HostPoolPersistent2 `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -SubscriptionId $env.SubscriptionId `
                -Path $env.MSIXImagePath

            $package.ImagePackageFamilyName | Should -Be  'Mozilla.MozillaFirefox_gmpnhwe7bv608'
            $package.ImagePath | Should -Be 'C:\AppAttach\Firefox20110.0.1.vhdx'
            $package.ImagePackageName | Should -Be 'Mozilla.MozillaFirefox'
            $package.ImagePackageAlias | Should -Be 'mozillamozillafirefox'
            $package.ImageIsActive | Should -Be $False
            $package.ImageIsRegularRegistration | Should -Be $False
            $package.ImagePackageRelativePath | Should -Be '\apps\Mozilla.MozillaFirefox_110.0.1.0_x64__gmpnhwe7bv608'
    }
}