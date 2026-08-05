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

# This test is duplicated with New-AzWvdAppAttachPackage 
Describe 'Import-AzWvdAppAttachPackageInfo' {
    It 'ImportExpanded' {
        $package = Import-AzWvdAppAttachPackageInfo -HostPoolName $env.HostPoolPersistent `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -SubscriptionId $env.SubscriptionId `
                -Path $env.MSIXImagePath

            if( $package.Count -gt 0)
            {
                $package = $package[0]
            }

            $package.ImagePackageFamilyName | Should -Be  $env.MSIXImageFamilyName
            $package.ImagePath | Should -Be $env.MSIXImagePath
            $package.ImagePackageName | Should -Be $env.MSIXImagePackageName
            $package.ImagePackageAlias | Should -Be $env.MSIXImagePackageAlias
            $package.ImageIsActive | Should -Be $False
            $package.ImageIsRegularRegistration | Should -Be $False
            $package.ImagePackageRelativePath | Should -Be $env.MSIXImagePackageRelativePath
    }
}