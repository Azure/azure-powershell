$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzImageBuilderTemplate.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzImageBuilderTemplate' {
    #1 Source: PlatformImage Distributor: ManagedImage
    It 'platformimg-managedimg' {
        #region OS:Linux
        $srcPlatform = New-AzImageBuilderSourceObject -SourceTypePlatformImage -Publisher $env.Source.PlatformImageLinux.publisher -Offer $env.Source.PlatformImageLinux.offer -Sku $env.Source.PlatformImageLinux.sku -Version $env.Source.PlatformImageLinux.version
        $disManagedImg = New-AzImageBuilderDistributorObject -ManagedImageDistributor -ArtifactTag @{source='azVmPlatform';baseofimg='UbuntuServer'} -ImageId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Compute/images/$($env.Resources.Distributor.distributorName01)" -Location $env.Location -RunOutputName $env.Resources.RunOutputName.runOutputName21
        $customizerName = 'downloadBuildArtifacts'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $sourceUri = 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh'
        $customizer = New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName $customizerName -ScriptUri $sourceUri -Sha256Checksum $sha256Checksum
        Write-Host -ForegroundColor Green "Start creating $($env.Resources.Template.templateName11) template image."
        
        New-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName11 -ResourceGroupName $env.ResourceGroup -Source $srcPlatform -Distribute $disManagedImg -Customize $customizer -Location $env.Location -UserAssignedIdentityId $env.userAssignedIdentity
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName11 -ResourceGroupName $env.ResourceGroup
        #endregion OS:Linux

        #region OS:Windows
        $srcPlatformWind = New-AzImageBuilderSourceObject -SourceTypePlatformImage -Publisher 'MicrosoftWindowsServer' -Offer 'WindowsServer' -Sku '2019-Datacenter' -Version 'latest'
        $disManagedImgWind = New-AzImageBuilderDistributorObject -ManagedImageDistributor -ArtifactTag @{source='azVmPlatform';baseofimg='MicrosoftWindowsServer'} -ImageId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Compute/images/$($env.Resources.Distributor.distributorName001)" -Location $env.Location -RunOutputName $env.Resources.RunOutputName.runOutputName201
        $customizerName = 'downloadBuildArtifacts'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $destination = 'c:\\buildArtifacts\\index.html'
        $sourceUri = 'https://github.com/danielsollondon/azvmimagebuilder/blob/master/quickquickstarts/exampleArtifacts/buildArtifacts/index.html'
        $customizer = New-AzImageBuilderCustomizerObject -FileCustomizer -CustomizerName $customizerName -Sha256Checksum  $sha256Checksum -Destination $destination -SourceUri $sourceUri
        New-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName101 -ResourceGroupName $env.ResourceGroup -Source $srcPlatformWind -Distribute $disManagedImgWind -Customize $customizer -Location $env.Location -UserAssignedIdentityId $env.userAssignedIdentity
        $templateWind = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName101 -ResourceGroupName $env.ResourceGroup
        #endregion OS:Windows

        $template.ProvisioningState | Should -Be 'Succeeded'
        $templateWind.Name | Should -Be $env.Resources.Template.templateName101
    }
    #2 Source: PlatformImage Distributor: VHD
    It 'platformimg-vhd' {
        #region OS:Linux
        $srcPlatform = New-AzImageBuilderSourceObject -SourceTypePlatformImage -Publisher $env.Source.PlatformImageLinux.publisher -Offer $env.Source.PlatformImageLinux.offer -Sku $env.Source.PlatformImageLinux.sku -Version $env.Source.PlatformImageLinux.version 
        $disVhd = New-AzImageBuilderDistributorObject -VhdDistributor -ArtifactTag @{tag='VHD'} -RunOutputName $env.Resources.RunOutputName.runOutputName22
        $customizerName = 'HelloImageScript1'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $sourceUri = 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript.sh'
        $customizer = New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName $customizerName -ScriptUri $sourceUri -Sha256Checksum  $sha256Checksum
        Write-Host -ForegroundColor Green "Start creating $($env.Resources.Template.templateName12) template image."

        New-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName12 -ResourceGroupName $env.ResourceGroup -Source $srcPlatform -Distribute $disVhd -Location $env.Location -UserAssignedIdentityId $env.userAssignedIdentity
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName12 -ResourceGroupName $env.ResourceGroup
        $template.ProvisioningState | Should -Be 'Succeeded'
        #endregion OS:Linux
    }
    #3 Source: PlatformImage Distributor: SharedImage
    It 'platformimg-sharedimg' {
        #region OS:Linux
        $srcPlatform = New-AzImageBuilderSourceObject -SourceTypePlatformImage -Publisher $env.Source.PlatformImageLinux.publisher -Offer $env.Source.PlatformImageLinux.offer -Sku $env.Source.PlatformImageLinux.sku -Version $env.Source.PlatformImageLinux.version 
        $disSharedImg = New-AzImageBuilderDistributorObject -SharedImageDistributor -ArtifactTag @{tag='dis-share'} -GalleryImageId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Compute/galleries/testsharedgallery/images/imagedefinition-linux/versions/1.0.0" -ReplicationRegion $env.RepLocation -RunOutputName $env.Resources.RunOutputName.runOutputName23 -ExcludeFromLatest $false
        $customizerName = 'CheckSumCompareShellScript'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $sourceUri = 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh'
        $customizer = New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName $customizerName -ScriptUri $sourceUri -Sha256Checksum $sha256Checksum
        Write-Host -ForegroundColor Green "Start creating $($env.Resources.Template.templateName13) template image."

        New-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName13 -ResourceGroupName $env.ResourceGroup -Source $srcPlatform -Distribute $disSharedImg -Customize $customizer -Location $env.Location -UserAssignedIdentityId $env.userAssignedIdentity
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName13 -ResourceGroupName $env.ResourceGroup
        #$template.ProvisioningState | Should -Be 'Succeeded'
        #endregion OS:Linux
        
        #region OS:Windows
        $srcPlatformWind = New-AzImageBuilderSourceObject -SourceTypePlatformImage -Publisher 'MicrosoftWindowsServer' -Offer 'WindowsServer' -Sku '2019-Datacenter' -Version 'latest'
        $disSharedImgWind = New-AzImageBuilderDistributorObject -SharedImageDistributor -ArtifactTag @{tag='dis-share'} -GalleryImageId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Compute/galleries/testsharedgallery/images/imagedefinition-wind/versions/1.0.0" -ReplicationRegion $env.RepLocation -RunOutputName $env.Resources.RunOutputName.runOutputName203 -ExcludeFromLatest $false
        $customizerName = 'downloadBuildArtifacts'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $destination = 'c:\\buildArtifacts\\index.html'
        $sourceUri = 'https://github.com/danielsollondon/azvmimagebuilder/blob/master/quickquickstarts/exampleArtifacts/buildArtifacts/index.html'
        $customizer = New-AzImageBuilderCustomizerObject -FileCustomizer -CustomizerName $customizerName -Sha256Checksum  $sha256Checksum -Destination $destination -SourceUri $sourceUri
        New-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName103 -ResourceGroupName $env.ResourceGroup -Source $srcPlatformWind -Distribute $disSharedImgWind -Customize $customizer -Location $env.Location -UserAssignedIdentityId $env.userAssignedIdentity
        $templateWind = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName103 -ResourceGroupName $env.ResourceGroup
        #endregion OS:Windows

        $template.Name | Should -Be $env.Resources.Template.templateName13
        $templateWind.Name | Should -Be $env.Resources.Template.templateName103
        
    }
    #4 Source: ManagedImage Distributor: ManagedImage
    It 'managedimg-managedimg' {
        #region OS:Linux
        $srcManagedImg = New-AzImageBuilderSourceObject -SourceTypeManagedImage -ImageId $env.Source.ManagedImageLinux.imageId
        $disManagedImg = New-AzImageBuilderDistributorObject -ManagedImageDistributor -ArtifactTag @{source='azVmMangedImage';baseofimg='UbuntuServer'} -ImageId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Compute/images/$($env.Resources.Distributor.distributorName04)" -Location $env.Location -RunOutputName $env.Resources.RunOutputName.runOutputName24
        $customizerName = 'downloadBuildArtifacts'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $sourceUri = 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh'
        $customizer = New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName $customizerName -ScriptUri $sourceUri -Sha256Checksum $sha256Checksum
        Write-Host -ForegroundColor Green "Start creating $($env.Resources.Template.templateName14) template image."

        New-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName14 -ResourceGroupName $env.ResourceGroup -Source $srcManagedImg -Distribute $disManagedImg -Customize $customizer -Location $env.Location -UserAssignedIdentityId $env.userAssignedIdentity
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName14 -ResourceGroupName $env.ResourceGroup
        #$template.ProvisioningState | Should -Be 'Succeeded'
        $template.Name | Should -Be $env.Resources.Template.templateName14
        #endregion OS:Linux
    }
    #4 Source: ManagedImage Distributor: VHD
    It 'managedimg-vhd' {
        #region OS:Linux
        $srcManagedImg = New-AzImageBuilderSourceObject -SourceTypeManagedImage -ImageId $env.Source.ManagedImageLinux.imageId
        $disVhd = New-AzImageBuilderDistributorObject -VhdDistributor -ArtifactTag @{tag='VHD'} -RunOutputName $env.Resources.RunOutputName.runOutputName25
        $customizerName = 'downloadBuildArtifacts'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $sourceUri = 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh'
        $customizer = New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName $customizerName -ScriptUri $sourceUri -Sha256Checksum  $sha256Checksum
        Write-Host -ForegroundColor Green "Start creating $($env.Resources.Template.templateName15) template image."

        New-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName15 -ResourceGroupName $env.ResourceGroup -Source $srcManagedImg -Distribute $disVhd -Customize $customizer -Location $env.Location -UserAssignedIdentityId $env.userAssignedIdentity
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName15 -ResourceGroupName $env.ResourceGroup
        #$template.ProvisioningState | Should -Be 'Succeeded'
        $template.Name | Should -Be $env.Resources.Template.templateName15
        #endregion OS:Linux
    }
    #6 Source: ManagedImage Distributor: SharedImage
    It 'managedimg-sharedimg' {
        #region OS:Linux
        $srcManagedImg = New-AzImageBuilderSourceObject -SourceTypeManagedImage -ImageId $env.Source.ManagedImageLinux.imageId
        $disSharedImg = New-AzImageBuilderDistributorObject -SharedImageDistributor -ArtifactTag @{tag='dis-share'} -GalleryImageId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Compute/galleries/testsharedgallery/images/imagedefinition-linux/versions/1.0.0)" -ReplicationRegion $env.RepLocation -RunOutputName $env.Resources.RunOutputName.runOutputName26 -ExcludeFromLatest $false
        $customizerName = 'CheckSumCompareShellScript'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $sourceUri = 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh'
        $customizer = New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName $customizerName -ScriptUri $sourceUri -Sha256Checksum $sha256Checksum
        Write-Host -ForegroundColor Green "Start creating $($env.Resources.Template.templateName16) template image."
       
        New-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName16 -ResourceGroupName $env.ResourceGroup -Source $srcManagedImg -Distribute $disSharedImg -Customize $customizer -Location $env.Location -UserAssignedIdentityId $env.userAssignedIdentity
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName16 -ResourceGroupName $env.ResourceGroup
        #$template.ProvisioningState | Should -Be 'Succeeded'
        $template.Name | Should -Be $env.Resources.Template.templateName16
        #endregion OS:Linux
    }
    #7 Source: SharedImage Distributor: ManagedImage
    It 'sharedimg-managedimg' {
        #region OS:Linux
        $srcSharedImg = New-AzImageBuilderSourceObject -SourceTypeSharedImageVersion -ImageVersionId $env.Source.SharedImageLinux.imageVersionId
        $disManagedImg = New-AzImageBuilderDistributorObject -ManagedImageDistributor -ArtifactTag @{source='azVmPlatform';baseofimg='UbuntuServer'} -ImageId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Compute/images/$($env.Resources.Distributor.distributorName07)" -Location $env.Location -RunOutputName $env.Resources.RunOutputName.runOutputName27
        $customizerName = 'downloadBuildArtifacts'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $sourceUri = 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh'
        $customizer = New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName $customizerName -ScriptUri $sourceUri -Sha256Checksum  $sha256Checksum
        Write-Host -ForegroundColor Green "Start creating $($env.Resources.Template.templateName17) template image."
        
        New-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName17 -ResourceGroupName $env.ResourceGroup -Source $srcSharedImg -Distribute $disManagedImg -Customize $customizer -Location $env.Location -UserAssignedIdentityId $env.userAssignedIdentity
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName17 -ResourceGroupName $env.ResourceGroup
        #$template.ProvisioningState | Should -Be 'Succeeded'
        $template.Name | Should -Be $env.Resources.Template.templateName17
        #endregion OS:Linux
    }
    #8 Source: SharedImage Distributor: VHD
    It 'sharedimg-vhd' {
        #region OS:Linux
        $srcSharedImg = New-AzImageBuilderSourceObject -SourceTypeSharedImageVersion -ImageVersionId $env.Source.SharedImageLinux.imageVersionId
        $disVhd = New-AzImageBuilderDistributorObject -VhdDistributor -ArtifactTag @{tag='VHD'} -RunOutputName $env.Resources.RunOutputName.runOutputName28
        $customizerName = 'downloadBuildArtifacts'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $sourceUri = 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh'
        $customizer = New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName $customizerName -ScriptUri $sourceUri -Sha256Checksum  $sha256Checksum
        Write-Host -ForegroundColor Green "Start creating $($env.Resources.Template.templateName18) template image."
        
        New-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName18 -ResourceGroupName $env.ResourceGroup -Source $srcSharedImg -Distribute $disVhd -Customize $customizer -Location $env.Location -UserAssignedIdentityId $env.userAssignedIdentity
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName18 -ResourceGroupName $env.ResourceGroup
        #$template.ProvisioningState | Should -Be 'Succeeded'
        $template.Name | Should -Be $env.Resources.Template.templateName18
        #endregion OS:Linux
    }

    #9 Source: SharedImage Distributor: SharedImage
    It 'sharedImage-sharedimg' { 
        #region OS:Linux
        $srcSharedImg = New-AzImageBuilderSourceObject -SourceTypeSharedImageVersion -ImageVersionId $env.Source.SharedImageLinux.imageVersionId
        $disSharedImg = New-AzImageBuilderDistributorObject -SharedImageDistributor -ArtifactTag @{tag='dis-share'} -GalleryImageId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Compute/galleries/testsharedgallery/images/imagedefinition-linux/versions/1.0.0" -ReplicationRegion $env.RepLocation -RunOutputName $env.Resources.RunOutputName.runOutputName29 -ExcludeFromLatest $false
        $customizerName = 'CheckSumCompareShellScript'
        $sha256Checksum = 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
        $sourceUri = 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh'
        $customizer = New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName $customizerName -ScriptUri $sourceUri -Sha256Checksum $sha256Checksum
        Write-Host -ForegroundColor Green "Start creating $($env.Resources.Template.templateName19) template image."
        
        New-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName19 -ResourceGroupName $env.ResourceGroup -Source $srcSharedImg -Distribute $disSharedImg -Customize $customizer -Location $env.Location -UserAssignedIdentityId $env.userAssignedIdentity
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName19 -ResourceGroupName $env.ResourceGroup
        #$template.ProvisioningState | Should -Be 'Succeeded'
        $template.Name | Should -Be $env.Resources.Template.templateName19
        #endregion OS:Linux
    }
}
