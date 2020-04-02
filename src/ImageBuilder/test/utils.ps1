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
    $env.ResourceGroup = 'wyunchi-imagebuilder'
    $env.Location = 'eastus'
    $env.RepLocation = 'eastus2'

    #Generate some strings for use in the test.
    $env.Resources = @{Distributor= @{}; Template=@{}; RunOutputName=@{}; Customizer=@{}}

    $distributorName00 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName01 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName02 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName03 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName04 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName05 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName06 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName07 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName08 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName09 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName000 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName001 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName002 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName003 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $distributorName004 = 'dis-img-' + (RandomString -allChars $false -len 6)
    $env.Resources.Distributor.Add('distributorName00', $distributorName00);
    $env.Resources.Distributor.Add('distributorName01', $distributorName01);
    $env.Resources.Distributor.Add('distributorName02', $distributorName02);
    $env.Resources.Distributor.Add('distributorName03', $distributorName03);
    $env.Resources.Distributor.Add('distributorName04', $distributorName04);
    $env.Resources.Distributor.Add('distributorName05', $distributorName05);
    $env.Resources.Distributor.Add('distributorName06', $distributorName06);
    $env.Resources.Distributor.Add('distributorName07', $distributorName07);
    $env.Resources.Distributor.Add('distributorName08', $distributorName08);
    $env.Resources.Distributor.Add('distributorName09', $distributorName09);
    $env.Resources.Distributor.Add('distributorName000', $distributorName000);
    $env.Resources.Distributor.Add('distributorName001', $distributorName001);
    $env.Resources.Distributor.Add('distributorName002', $distributorName002);
    $env.Resources.Distributor.Add('distributorName003', $distributorName003);

    $templateName10 = 'template-name-' + (RandomString -allChars $false -len 6)
    $templateName11 = 'template-name-' + (RandomString -allChars $false -len 6)
    $templateName12 = 'template-name-' + (RandomString -allChars $false -len 6)
    $templateName13 = 'template-name-' + (RandomString -allChars $false -len 6)
    $templateName14 = 'template-name-' + (RandomString -allChars $false -len 6)
    $templateName15 = 'template-name-' + (RandomString -allChars $false -len 6)
    $templateName16 = 'template-name-' + (RandomString -allChars $false -len 6)
    $templateName17 = 'template-name-' + (RandomString -allChars $false -len 6)
    $templateName18 = 'template-name-' + (RandomString -allChars $false -len 6)
    $templateName19 = 'template-name-' + (RandomString -allChars $false -len 6)
    $templateName100 = 'template-name-' + (RandomString -allChars $false -len 6)
    $templateName101 = 'template-name-' + (RandomString -allChars $false -len 6)
    $templateName102 = 'template-name-' + (RandomString -allChars $false -len 6)
    $templateName103 = 'template-name-' + (RandomString -allChars $false -len 6)
    $env.Resources.Template.Add('templateName10', $templateName10);
    $env.Resources.Template.Add('templateName11', $templateName11);
    $env.Resources.Template.Add('templateName12', $templateName12);
    $env.Resources.Template.Add('templateName13', $templateName13);
    $env.Resources.Template.Add('templateName14', $templateName14);
    $env.Resources.Template.Add('templateName15', $templateName15);
    $env.Resources.Template.Add('templateName16', $templateName16);
    $env.Resources.Template.Add('templateName17', $templateName17);
    $env.Resources.Template.Add('templateName18', $templateName18);
    $env.Resources.Template.Add('templateName19', $templateName19);
    $env.Resources.Template.Add('templateName100', $templateName100);
    $env.Resources.Template.Add('templateName101', $templateName101);
    $env.Resources.Template.Add('templateName102', $templateName102);
    $env.Resources.Template.Add('templateName103', $templateName103);

    $runOutputName20 = 'runout-' +  $templateName10
    $runOutputName21 = 'runout-' +  $templateName11
    $runOutputName22 = 'runout-' +  $templateName12
    $runOutputName23 = 'runout-' +  $templateName13
    $runOutputName24 = 'runout-' +  $templateName14
    $runOutputName25 = 'runout-' +  $templateName15
    $runOutputName26 = 'runout-' +  $templateName16
    $runOutputName27 = 'runout-' +  $templateName17
    $runOutputName28 = 'runout-' +  $templateName18
    $runOutputName29 = 'runout-' +  $templateName19
    $runOutputName200 = 'runout-' +  $templateName100
    $runOutputName201 = 'runout-' +  $templateName101
    $runOutputName202 = 'runout-' +  $templateName102
    $runOutputName203 = 'runout-' +  $templateName103
    $env.Resources.RunOutputName.Add('runOutputName20', $runOutputName20);
    $env.Resources.RunOutputName.Add('runOutputName21', $runOutputName21);
    $env.Resources.RunOutputName.Add('runOutputName22', $runOutputName22);
    $env.Resources.RunOutputName.Add('runOutputName23', $runOutputName23);
    $env.Resources.RunOutputName.Add('runOutputName24', $runOutputName24);
    $env.Resources.RunOutputName.Add('runOutputName25', $runOutputName25);
    $env.Resources.RunOutputName.Add('runOutputName26', $runOutputName26);
    $env.Resources.RunOutputName.Add('runOutputName27', $runOutputName27);
    $env.Resources.RunOutputName.Add('runOutputName28', $runOutputName28);
    $env.Resources.RunOutputName.Add('runOutputName29', $runOutputName29);
    $env.Resources.RunOutputName.Add('runOutputName200', $runOutputName200);
    $env.Resources.RunOutputName.Add('runOutputName201', $runOutputName201);
    $env.Resources.RunOutputName.Add('runOutputName202', $runOutputName202);
    $env.Resources.RunOutputName.Add('runOutputName203', $runOutputName203);
    

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

    $customizerName30 = 'customizer-name-' + (RandomString -allChars $false -len 6)
    $env.Resources.Customizer.Add('customizerName30', $customizerName30);

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
    $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
    $sourceUri = 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh'
    $customizer = New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName $customizerName -ScriptUri $sourceUri -Sha256Checksum $sha256Checksum
    
    $tmplPlatformManaged = New-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName10 -Source $srcPlatform -Distribute $distributor -Customize $customizer -ResourceGroupName $env.ResourceGroup -Location $env.Location -UserAssignedIdentityId $env.userAssignedIdentity
    Write-Host -ForegroundColor Green "Successfully created templeate image."
    
    Write-Host -ForegroundColor Green "Start $($env.Resources.Template.templateName10) template image for test."
    Start-AzImageBuilderTemplate -ResourceGroupName $env.ResourceGroup -ImageTemplateName $env.Resources.Template.templateName10
    Write-Host -ForegroundColor Green "Successfully started templeate image."
    
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

