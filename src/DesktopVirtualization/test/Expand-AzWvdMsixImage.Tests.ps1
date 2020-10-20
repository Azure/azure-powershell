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
         
        $package.PackageFamilyName | Should -Be  'AcrobatReader_81q6ced8g4aa0'
        $package.ImagePath | Should -Be '\\stgeorgi-0\temp\AdobeReaders\adobereader.vhdx'
        $package.PackageName | Should -Be 'AcrobatReader'
        $package.PackageAlias | Should -Be 'acrobatreader'
        $package.IsActive | Should -Be $False
        $package.IsRegularRegistration | Should -Be $False
        $package.PackageRelativePath | Should -Be '\apps\AcrobatReader_1.0.0.0_x64__81q6ced8g4aa0'

    }
}
