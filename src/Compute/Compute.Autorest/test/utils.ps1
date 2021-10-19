function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)

    $env.ResourceGroupName = "RGComputeTest" + (RandomString $false 8)
    $env.Location = "EastUS"
    $env.GalleryName = "RGComputeTest" +  (RandomString $false 8)
    $env.GalleryApplicationName = "RGComputeTest" +  (RandomString $false 8)
    $env.GalleryApplicationVersionName = "RGComputeTest" +  (RandomString $false 8)
    

    # Create ResourceGroup
    Write-Host -ForegroundColor Yellow "Creating ResourceGroup" $env.ResourceGroupName
    New-AzResourceGroup -ResourceGroupName $env.ResourceGroupName -Location $env.Location

    # Create Gallery
    New-AzGallery -ResourceGroupName $env.ResourceGroupName -Name $env.GalleryName -Location $env.Location

    # Create GalleryApplication
    New-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $env.GalleryName -Name $env.GalleryApplicationName -Location $env.Location -SupportedOSType Windows
    # Create GalleryApplicationVersion
    New-AzGalleryApplicationVersion -ResourceGroupName $env.ResourceGroupName -GalleryName $env.GalleryName -GalleryApplicationName $env.GalleryApplicationName -Name $env.GalleryApplicationVersionName 
}
function cleanupEnv() {
    # Clean resources you create for testing
    Write-Host -ForegroundColor Yellow "Removing ResourceGroup" $env.ResourceGroupName
    Remove-AzResourceGroup -ResourceGroupName $env.ResourceGroupName
}

