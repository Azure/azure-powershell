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
        try{
            
            $package = Expand-AzWvdMsixImage -HostPoolName $env.HostPoolPersistent2 `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -SubscriptionId $env.SubscriptionId `
                -Uri $env.MSIXImagePath
             
            $package.PackageFamilyName | Should -Be  'Mozilla.MozillaFirefox_gmpnhwe7bv608'
            $package.ImagePath | Should -Be 'C:\AppAttach\Firefox20110.0.1.vhdx'
            $package.PackageName | Should -Be 'Mozilla.MozillaFirefox'
            $package.PackageAlias | Should -Be 'mozillamozillafirefox'
            $package.IsActive | Should -Be $False
            $package.IsRegularRegistration | Should -Be $False
            $package.PackageRelativePath | Should -Be '\apps\Mozilla.MozillaFirefox_110.0.1.0_x64__gmpnhwe7bv608'
        }
        finally{
        }

    }
}
