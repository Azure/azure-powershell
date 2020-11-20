$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Expand-AzWvdMsixImage.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Expand-AzWvdMsixImage' {
    
    It 'Expand' {
        $package = Expand-AzWvdMsixImage -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId `
            -Uri $env.MSIXImagePath
         
        $package.PackageFamilyName | Should -Be  'MsixPackage_zf7zaz2wb1ayy'
        $package.ImagePath | Should -Be 'C:\msix\singlemsix.vhd'
        $package.PackageName | Should -Be 'MsixPackage'
        $package.PackageAlias | Should -Be 'msixpackage'
        $package.IsActive | Should -Be $False
        $package.IsRegularRegistration | Should -Be $False
        $package.PackageRelativePath | Should -Be '\apps\MsixPackage_1.0.0.0_neutral__zf7zaz2wb1ayy'

    }
}
