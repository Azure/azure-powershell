$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzImageBuilderTemplate.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzImageBuilderTemplate' {
    It 'Cancel' {
        # Create a platform image source
        $srcPlatform = New-AzImageBuilderTemplateSourceObject -PlatformImageSource -Publisher 'Canonical' -Offer 'UbuntuServer' -Sku '18.04-LTS' -Version 'latest'
        # Create a shell customizer
        $customizer = New-AzImageBuilderTemplateCustomizerObject -ShellCustomizer -Name 'downloadBuildArtifacts' -ScriptUri 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh' -Sha256Checksum 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        # Create a shared image distributor
        $disManagedImg = New-AzImageBuilderTemplateDistributorObject -SharedImageDistributor -ArtifactTag @{tag='dis-share'} -GalleryImageId $env.image.Id -ReplicationRegion 'eastus2' -RunOutputName runOutputName21 -ExcludeFromLatest $false
        
        $tempName = 'azps-tmp-test4start'
        Write-Host -ForegroundColor Green "Start creating $tempName template image."
        New-AzImageBuilderTemplate -Name $tempName -ResourceGroupName $env.rg -Source $srcPlatform -Distribute $disManagedImg -Customize $customizer -Location $env.Location -UserAssignedIdentity $env.identity.Id

        Start-TestSleep -Seconds 25
        Write-Host -ForegroundColor Green "Starting the image builder template..."
        Start-AzImageBuilderTemplate -Name $tempName -ResourceGroupName $env.rg -NoWait
        Start-TestSleep -Seconds 5
        Stop-AzImageBuilderTemplate -Name $tempName -ResourceGroupName $env.rg
        $template = Get-AzImageBuilderTemplate -Name $tempName -ResourceGroupName $env.rg
        $template.LastRunStatusRunState | Should -Be 'Canceling'
    }

    It 'CancelViaIdentity' -Skip {
        $template = Get-AzImageBuilderTemplate -Name $env.templateName -ResourceGroupName $env.rg
        Stop-AzImageBuilderTemplate -InputObject $template
        $template = Get-AzImageBuilderTemplate -Name $env.templateName -ResourceGroupName $env.rg
        $template.LastRunStatusRunState | Should -Be 'Canceling'
    }
}
