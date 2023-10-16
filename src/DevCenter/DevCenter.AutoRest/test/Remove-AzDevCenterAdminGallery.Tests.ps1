if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterAdminGallery')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterAdminGallery.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterAdminGallery' {
    It 'Delete' {
        Remove-AzDevCenterAdminGallery -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.galleryNameDelete
        { Get-AzDevCenterAdminGallery -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.galleryNameDelete } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $gallery = Get-AzDevCenterAdminGallery -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.galleryNameDelete2
        Remove-AzDevCenterAdminGallery -InputObject $gallery
        { Get-AzDevCenterAdminGallery -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name $env.galleryNameDelete2 } | Should -Throw

    }
}
