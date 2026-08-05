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
            
            $package = Expand-AzWvdMsixImage -HostPoolName $env.HostPoolPersistent `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -SubscriptionId $env.SubscriptionId `
                -Uri $env.MSIXImagePath
             
            $package[0].PackageFamilyName | Should -Be  $env.MSIXImageFamilyName
            $package[0].ImagePath | Should -Be $env.MSIXImagePath
            $package[0].PackageName | Should -Be $env.MSIXImagePackageName
            $package[0].PackageAlias | Should -Be $env.MSIXImagePackageAlias
            $package[0].IsActive | Should -Be $False
            $package[0].IsRegularRegistration | Should -Be $False
            $package[0].PackageRelativePath | Should -Be $env.MSIXImagePackageRelativePath
        }
        finally{
        }

    }
}
