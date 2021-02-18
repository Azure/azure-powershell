$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzImportExport.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzImportExport' {
    It 'CreateExpanded' {
        { 
            $jobName = "new-job"
            $driveList = @( @{ DriveId = "9CA995BA"; BitLockerKey = "238810-662376-448998-450120-652806-203390-606320-483076"; ManifestFile = "\\DriveManifest.xml"; ManifestHash = "109B21108597EF36D5785F08303F3638"; DriveHeaderHash = "" }, 
                            @{ DriveId = "9CA995BX"; BitLockerKey = "238810-662376-448998-450120-652806-203390-606320-483079"; ManifestFile = "\\DriveManifest2.xml"; ManifestHash = "109B21108597EF36D5785F08303F3639"; DriverHeaderHash = ""})
            $job = New-AzImportExport -Name $jobName -ResourceGroupName $env.resourceGroup -Location $env.location -StorageAccountId "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.resourceGroup)/providers/Microsoft.Storage/storageAccounts/teststorageforimport" -JobType Import -ReturnAddressRecipientName "Some name" -ReturnAddressStreetAddress1 "Street1" -ReturnAddressCity "Redmond" -ReturnAddressStateOrProvince "WA" -ReturnAddressPostalCode "98008" -ReturnAddressCountryOrRegion "USA" -ReturnAddressPhone "4250000000" -ReturnAddressEmail test@contoso.com -DiagnosticsPath "waimportexport" -BackupDriveManifest -DriveList $driveList
        } | Should -Not -Throw
        $job.Name | Should -Be $jobName
    }
}