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

    # Create the test group
    write-host "start to create test group."
    $resourceGroup = "ImportExportTest"
    $location = "eastus"
    $env.Add("resourceGroup", $resourceGroup)
    $env.Add("location", $location)
    New-AzResourceGroup -Name $resourceGroup -Location $location

    # Create the test storageaccount
    write-host "Deploy StorageAccount template"
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\storage-account\template.json -TemplateParameterFile .\test\deployment-templates\storage-account\parameters.json -Name sa -ResourceGroupName $resourceGroup

    $jobName = "test-job"
    $driveList = @( @{ DriveId = "9CA995BB"; BitLockerKey = "238810-662376-448998-450120-652806-203390-606320-483076"; ManifestFile = "\\DriveManifest.xml"; ManifestHash = "109B21108597EF36D5785F08303F3638"; DriveHeaderHash = "" })
    $env.Add("jobName", $jobName)
    $env.Add("driveList", $driveList)

    write-host (Get-AzContext | Out-String)

    write-host "New a test import job"
    New-AzImportExport -Name $jobName -ResourceGroupName $resourceGroup -Location $location -StorageAccountId "/subscriptions/$($env.SubscriptionId)/resourcegroups/$resourceGroup/providers/Microsoft.Storage/storageAccounts/teststorageforimport" -JobType Import -ReturnAddressRecipientName "Some name" -ReturnAddressStreetAddress1 "Street1" -ReturnAddressCity "Redmond" -ReturnAddressStateOrProvince "WA" -ReturnAddressPostalCode "98008" -ReturnAddressCountryOrRegion "USA" -ReturnAddressPhone "4250000000" -ReturnAddressEmail test@contoso.com -DiagnosticsPath "waimportexport" -BackupDriveManifest -DriveList $driveList

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Removing resourcegroup will clean all the resources created for testing.
    write-host "Clean resources you create for testing."
    Remove-AzResourceGroup -Name $env.resourceGroup
}

