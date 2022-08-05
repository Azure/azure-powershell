$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzImageBuilderDistributorObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzImageBuilderDistributorObject' {
    It 'VhdDistributor' {
        $outName = 'run-template-vhd'
        $distributor = New-AzImageBuilderDistributorObject -ArtifactTag @{tag='VHD'} -VhdDistributor -RunOutputName $outName
        $distributor.RunOutputName | Should -Be $outName
    }

    It 'ManagedImageDistributor' {
        $outName = 'run-template-managedimg'
        $distributor = New-AzImageBuilderDistributorObject -ManagedImageDistributor  -ArtifactTag @{tag='lucasManage'} -ImageId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/images/lucas-linux-image' -RunOutputName $outName -Location $env.Location
        $distributor.RunOutputName | Should -Be $outName
    }

    It 'SharedImageDistributor' {
        $outName = 'run-template-sharedimg'
        $distributor = New-AzImageBuilderDistributorObject -SharedImageDistributor -ArtifactTag @{tag='dis-share'} -GalleryImageId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/galleries/myimagegallery/images/lcuas-linux-share' -ReplicationRegion $env.RepLocation -RunOutputName $outName -ExcludeFromLatest $false 
        $distributor.RunOutputName | Should -Be $outName
    }
}
