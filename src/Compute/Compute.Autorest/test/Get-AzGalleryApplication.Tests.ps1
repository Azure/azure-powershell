$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzGalleryApplication.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzGalleryApplication' -Tag 'LiveOnly' {
    
    BeforeAll { 
        $galleryName = "testgallery" + $env.RandomString
        $galleryApplicationName = "testgalapp" + $env.RandomString
        New-AzGallery -ResourceGroupName $env.ResourceGroupName -Name $galleryName -Location $env.Location
        New-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName -Location $env.Location -SupportedOSType Windows
    }

    It 'List Get-AzGalleryApplication' {
        Import-Module Az.Compute
        Write-Host -ForegroundColor Yellow "Checking GalleryApplication Get" 
        $galApp = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName
        Write-Host -ForegroundColor Yellow "Gallery Application Count: " $galApp.Count
        $galApp.Count | Should BeGreaterThan 0
    }

    It 'Get' {
        Import-Module Az.Compute
        $galApp = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName
        $galApp.Count | Should BeGreaterThan 0
    }

    It 'GetViaIdentity' {
        Import-Module Az.Compute
        $galApp = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName
        $galAppId = Get-AzGalleryApplication -InputObject $galApp.Id
        $galAppId.Count | Should BeGreaterThan 0
    }
}
