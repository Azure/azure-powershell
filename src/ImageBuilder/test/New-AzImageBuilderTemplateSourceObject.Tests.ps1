$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzImageBuilderSourceObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzImageBuilderSourceObject' {
    It 'PlatformImage' {
        $publisher = 'Canonical'
        $offer = 'UbuntuServer'
        $sku = '18.04-LTS'
        $version = 'latest'
        $planInfoPlanName = 'UbuntuServer'
        # New-AzImageBuilderSourceObject -SourceTypePlatformImage -Publisher 'Canonical' -Offer 'UbuntuServer' -Sku '18.04-LTS' -Version 'latest' -PlanInfoPlanName 'Canonical' -PlanInfoPlanProduct 'UbuntuServer' -PlanInfoPlanPublisher 'Canonical'
        {New-AzImageBuilderSourceObject -SourceTypePlatformImage -Publisher $publisher -Offer $offer -Sku $sku -Version $version} | Should -Not -Throw 
    }

    It 'ManagedImage' {
        $imageId = '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/images/test-linux-image'
        {New-AzImageBuilderSourceObject -SourceTypeManagedImage -ImageId $imageId} | Should -Not -Throw
    }

    It 'SharedImageVersion' {
        $imageVersionId = '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/galleries/lucasimagegallery/images/myimagedefinition/versions/1.0.0'
        {New-AzImageBuilderSourceObject -SourceTypeSharedImageVersion -ImageVersionId $imageVersionId} | Should -Not -Throw
    }
}
