function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    
    # For any resources you created for test, you should add it to $env here.
    $rg = $env.AddWithCache("rg", "bez-rg", $UsePreviousConfigForRecord)
    $location = $env.AddWithCache("location", "eastus", $UsePreviousConfigForRecord)
    $repLocation = $env.AddWithCache("repLocation", "eastus2", $UsePreviousConfigForRecord)

    # initialize distributors
    $distributor = 
    
    # initialize customizers
    $customizerName = 'customizer-name-' + (RandomString -allChars $false -len 6)
    $sourceUri = 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh'
    $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
    $customizer = New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName $customizerName -ScriptUri $sourceUri -Sha256Checksum $sha256Checksum


    $env.Resources = @{Distributor= @{}; Template=@{}; RunOutputName=@{}; Customizer=@{}}

    

    # Deploy resource for test.
    # Deploy image
    <#
    Write-Host -ForegroundColor Green "Start deploying resource for test..."
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\managed-image\template.json -TemplateParameterFile .\test\deployment-templates\managed-image\parameters.json -ResourceGroupName $env.ResourceGroup
    # Failed: The source blob https://32rngewd8ofquuqtml5ggf2o.blob.core.windows.net/vhds/ffee76c3-a79b-43ae-a207-4fa9ee5e221a.vhd was not found.
    Write-Host -ForegroundColor Green "Successfully deployed resources."
    #>
    #$UserAssignedIdentity = Get-AzUserAssignedIdentity -ResourceGroupName $env.ResourceGroup -Name image-builder-user-assign-identity
    
    $env.userAssignedIdentity = "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/wyunchi-imagebuilder/providers/Microsoft.ManagedIdentity/userAssignedIdentities/image-builder-user-assign-identity"

    # For any resources you created for test, you should add it to $env here.
    $env.Source = @{PlatformImageLinux=@{};PlatformImageWind=@{};ManagedImageLinux=@{}; ManagedImageWind=@{}; SharedImageLinux=@{};SharedImageWind=@{}}
    $env.Source.PlatformImageLinux = @{publisher = 'Canonical';offer = 'UbuntuServer';sku = '18.04-LTS';version = 'latest'};
    $env.Source.ManagedImageLinux = @{imageId="/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Compute/images/test-linux-image"}
    $env.Source.SharedImageLinux = @{ imageVersionId= "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Compute/galleries/testsharedgallery/images/imagedefinition-linux/versions/1.0.0"}
    
    $env.Distributor = @{VHD = @{};ManagedImageLinux=@{}; SharedImageLinux=@{}}
    $env.Distributor.VHD = @{}
    $env.Distributor.ManagedImageLinux = @{imageId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Compute/images/$($env.Resources.Distributor.distributorName00)"}
    $env.Distributor.SharedImageLinux = @{galleryImageId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Compute/galleries/myimagegallery/images/lcuas-linux-share"}

    Write-Host -ForegroundColor Green "Start creating template image for test..."
    $srcPlatform = New-AzImageBuilderSourceObject -SourceTypePlatformImage -Publisher $env.Source.PlatformImageLinux.publisher -Offer $env.Source.PlatformImageLinux.offer -Sku $env.Source.PlatformImageLinux.sku -Version $env.Source.PlatformImageLinux.version  #-PlanName $null -PlanProduct $null -PlanPublisher $null
    $distributor = New-AzImageBuilderDistributorObject -ManagedImageDistributor -ArtifactTag @{source='platforimage';baseofimg='UbuntuServer'} -ImageId $env.Distributor.ManagedImageLinux.imageId -Location $env.Location -RunOutputName $env.Resources.RunOutputName.runOutputName20
    $customizerName = 'downloadBuildArtifacts'
    
    $tmpImage = New-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName10 -Source $srcPlatform -Distribute $distributor -Customize $customizer -ResourceGroupName $env.ResourceGroup -Location $env.Location -UserAssignedIdentityId $env.userAssignedIdentity
    Write-Host -ForegroundColor Green "Successfully created templeate image."
    
    Write-Host -ForegroundColor Green "Start $($env.Resources.Template.templateName10) template image for test."
    Start-AzImageBuilderTemplate -ResourceGroupName $env.ResourceGroup -ImageTemplateName $env.Resources.Template.templateName10
    Write-Host -ForegroundColor Green "Successfully started templeate image."
    
    # Cache variable




    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Get-AzImageBuilderTemplate -ResourceGroupName $env.ResourceGroup | Where-Object {$_.Name -Match '^template*'} | Remove-AzImageBuilderTemplate
}

