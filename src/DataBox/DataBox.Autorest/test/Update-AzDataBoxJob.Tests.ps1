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
    It 'Microsoft managed to customer managed system assigned' -Skip {
        $contactDetail = New-AzDataBoxContactDetailsObject -ContactName $env.ContactName -EmailList $env.EmailList -Phone $env.Phone
        $ShippingDetails = New-AzDataBoxShippingAddressObject -StreetAddress1 $env.StreetAddress1 -StateOrProvince $env.StateOrProvince -Country $env.Country -City $env.City -PostalCode $env.PostalCode -AddressType $env.AddressType       
        Update-AzDataBoxJob -Name $env.JobName -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -EnableSystemAssignedIdentity:$true
        $keyEncryptionDetails = New-AzDataBoxKeyEncryptionKeyObject -KekType "CustomerManaged" -IdentityProperty @{Type = "SystemAssigned"} -KekUrl $env.KekUrl -KekVaultResourceId $env.KekVaultResourceId
        Update-AzDataBoxJob -Name $env.JobName -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId -KeyEncryptionKey $keyEncryptionDetails -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -EnableSystemAssignedIdentity:$true
        
    }
    It 'System assigned to user assigned' -Skip {
        $keyEncryptionDetails = New-AzDataBoxKeyEncryptionKeyObject -KekType "CustomerManaged" -IdentityProperty @{Type = "UserAssigned"; UserAssignedResourceId = $env.UserAssignedResourceId} -KekUrl $env.KekUrl -KekVaultResourceId $env.KekVaultResourceId
        Update-AzDataBoxJob -Name $env.JobName -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId -KeyEncryptionKey $keyEncryptionDetails -ContactDetail $contactDetail -ShippingAddress $ShippingDetails -EnableSystemAssignedIdentity:$true -UserAssignedIdentity $env.UserAssignedResourceId
    }
}
