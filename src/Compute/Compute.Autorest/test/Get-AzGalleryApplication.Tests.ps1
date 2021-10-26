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

Describe 'Get-AzGalleryApplication' {
    It 'List Get-AzGalleryApplication' -skip {
        Write-Host -ForegroundColor Yellow "Checking GalleryApplication Get" 
        $galApp = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $env.GalleryName
        Write-Host -ForegroundColor Yellow "Gallery Application Count: " $galApp.Count
        $galApp.Count | Should BeGreaterThan 0
    }

    It 'Get' -skip {
        $galApp = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $env.GalleryName -Name $env.GalleryApplicationName
        $galApp.Count | Should BeGreaterThan 0
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
