$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzImageBuilderTemplateSourceObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzImageBuilderTemplateSourceObject' {
    It 'PlatformImage' {
        $publisher = 'Canonical'
        $offer = 'UbuntuServer'
        $sku = '18.04-LTS'
        $version = 'latest'
        $planInfoPlanName = 'UbuntuServer'
        {New-AzImageBuilderTemplateSourceObject -PlatformImageSource -Publisher $publisher -Offer $offer -Sku $sku -Version $version} | Should -Not -Throw 
    }

    It 'ManagedImage' {
        $imageId = '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/images/test-linux-image'
        {New-AzImageBuilderTemplateSourceObject -ManagedImageSource -ImageId $imageId} | Should -Not -Throw
    }

    It 'SharedImageVersion' {
        $imageVersionId = '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/galleries/lucasimagegallery/images/myimagedefinition/versions/1.0.0'
        {New-AzImageBuilderTemplateSourceObject -SharedImageVersionSource -ImageVersionId $imageVersionId} | Should -Not -Throw
    }
}
