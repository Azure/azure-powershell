$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDataBoxJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDataBoxJob' {
    It 'Microsoft managed to customer managed system assigned' {
        $updateDetail = [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.UpdateJobDetails]::New()
        $updateDetail.ContactDetailsContactName = $env.ContactName
        $updateDetail.ContactDetailEmailList = $env.EmailList
        $updateDetail.ContactDetailsPhone = $env.Phone
        $updateDetail.StreetAddress1 = $env.StreetAddress1
        $updateDetail.StateOrProvince = $env.StateOrProvince
        $updateDetail.Country = $env.Country
        $updateDetail.City = $env.City
        $updateDetail.PostalCode = $env.PostalCode
        Update-AzDataBoxJob -Name $env.JobName -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId -Detail $updateDetail -IdentityType "SystemAssigned"

        $updateDetail2 = [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.UpdateJobDetails]::New()
        $updateDetail2.ContactDetailsContactName = $env.ContactName
        $updateDetail2.ContactDetailEmailList = $env.EmailList
        $updateDetail2.ContactDetailsPhone = $env.Phone
        $updateDetail2.StreetAddress1 = $env.StreetAddress1
        $updateDetail2.StateOrProvince = $env.StateOrProvince
        $updateDetail2.Country = $env.Country
        $updateDetail2.City = $env.City
        $updateDetail2.PostalCode = $env.PostalCode
        $updateDetail2.KeyEncryptionKeyKekType = "CustomerManaged"
        $updateDetail2.IdentityPropertyType = "SystemAssigned"
        $updateDetail2.KeyEncryptionKeyKekUrl = $env.KekUrl
        $updateDetail2.KeyEncryptionKeyKekVaultResourceId = $env.KekVaultResourceId
        Update-AzDataBoxJob -Name $env.JobName -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId -Detail $updateDetail2 -IdentityType "SystemAssigned"
    }
    It 'System assigned to user assigned' {
        $updateDetail = [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.UpdateJobDetails]::New()
        $updateDetail.KeyEncryptionKeyKekType = "CustomerManaged"
        $updateDetail.IdentityPropertyType = "UserAssigned"
        $updateDetail.KeyEncryptionKeyKekUrl = $env.KekUrl
        $updateDetail.KeyEncryptionKeyKekVaultResourceId = $env.KekVaultResourceId
        Update-AzDataBoxJob -Name $env.JobName -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId -Detail $updateDetail -IdentityType "UserAssigned" -UserAssignedIdentity @($env.UserAssignedResourceId)
    }
}