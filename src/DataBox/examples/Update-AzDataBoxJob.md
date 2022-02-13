### Example 1: Update databox job encryption from microsoft managed to customer managed with user assigned identities 
```powershell
PS C:\>  $keyEncryptionDetails = New-AzDataBoxKeyEncryptionKeyObject -KekType "CustomerManaged" -IdentityProperty @{Type = "UserAssigned"; UserAssignedResourceId = "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName"} -KekUrl "keyIdentifier" -KekVaultResourceId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.KeyVault/vaults/keyVaultName"

PS C:\> $keyEncryptionDetails

KekType         KekUrl                                           KekVaultResourceId
-------         ------                                           ------------------
CustomerManaged keyIdentifier /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.KeyVault/vaults/keyVaultName
PS C:\> $DebugPreference = "Continue"
# You can use `$DebugPreference = "Continue"`, with any example/usecase to get exact details of error in below format when update command fails.
# {
#   "Error": {
#     "Code": "StaticValidationGenericCountryCodeHasInvalidLength",
#     "Message": "The attribute country code does not meet length constraints.\r\nEnter a value with 2 characters for country code.",
#     "Details": [
#       null
#     ],
#     "Target": null
#   }
# } 
PS C:\> Update-AzDataBoxJob -Name "powershell10" -ResourceGroupName "resourceGroupName" -KeyEncryptionKey $keyEncryptionDetails -ContactDetail $contactDetail -ShippingAddress $ShippingDetails  -IdentityType "UserAssigned" -UserAssignedIdentity @{"/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName" = @{}}

Name         Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----         -------- ------        ------------  ------- ------------ ------------ ------
Powershell10 WestUS   DeviceOrdered ImportToAzure DataBox UserAssigned NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

Update databox job encryption from microsoft managed to customer managed with user assigned identities.

### Example 2: Update databox job encryption from microsoft managed to customer managed with system identities in 2 updates
```powershell
PS C:\>   $databoxUpdate = Update-AzDataBoxJob -Name "pwshTestSAssigned" -ResourceGroupName "resourceGroupName" -ContactDetail $contactDetail -ShippingAddress $ShippingDetails  -IdentityType "SystemAssigned"

PS C:\> $databoxUpdate.Identity

PrincipalId                          TenantId                             Type
-----------                          --------                             ----
920850f5-9b6b-4017-a81a-3dcafe348be7 72f988bf-86f1-41af-91ab-2d7cd011db47 SystemAssigned

PS C:\> $keyEncryptionDetails = New-AzDataBoxKeyEncryptionKeyObject -KekType "CustomerManaged" -IdentityProperty @{Type = "SystemAssigned"} -KekUrl "keyIdentifier" -KekVaultResourceId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.KeyVault/vaults/keyVaultName"

PS C:\> $databoxUpdateWithCMK = Update-AzDataBoxJob -Name "pwshTestSAssigned" -ResourceGroupName "resourceGroupName" -ContactDetail $contactDetail -ShippingAddress $ShippingDetails  -KeyEncryptionKey $keyEncryptionDetails

PS C:\> $databoxUpdateWithCMK.Identity

PrincipalId                          TenantId                             Type
-----------                          --------                             ----
920850f5-9b6b-4017-a81a-3dcafe348be7 72f988bf-86f1-41af-91ab-2d7cd011db47 SystemAssigned

PS C:\> $databoxUpdateWithCMK.Detail.KeyEncryptionKey

KekType         KekUrl                                           KekVaultResourceId
-------         ------                                           ------------------
CustomerManaged keyIdentifier /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.KeyVault/vaults/keyVaultName
```

Update databox job encryption from microsoft managed to customer managed to customer managed with sytem assigned identity. For any failure re-run with $DebugPreference = "Continue" as mentioned in example 1

### Example 3: Update databox job from system assigned to user assigned with customer managed key encryption
```powershell
PS C:\>   $keyEncryptionDetails = New-AzDataBoxKeyEncryptionKeyObject -KekType "CustomerManaged" -IdentityProperty @{Type = "UserAssigned"; UserAssignedResourceId = "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName"} -KekUrl "keyIdentifier" -KekVaultResourceId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.KeyVault/vaults/keyVaultName"
PS C:\>   $updateSystemToUserAssigned = Update-AzDataBoxJob -Name "pwshTestSAssigned" -ResourceGroupName "resourceGroupName" -KeyEncryptionKey $keyEncryptionDetails -ContactDetail $contactDetail -ShippingAddress $ShippingDetails  -IdentityType "SystemAssigned,UserAssigned" -IdentityUserAssignedIdentity @{"/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identityName" = @{}}
```

Update databox job from system assigned to user assigned with customer managed key encryption. For any failure re-run with $DebugPreference = "Continue" as mentioned in example 1 

