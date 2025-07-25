### Example 1: Disable MUA on backup vault (remove resource guard mapping)
```powershell
$token = (Get-AzAccessToken -AsSecureString -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").Token
$proxy = Get-AzDataProtectionResourceGuardMapping -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId
$unlock = Unlock-AzDataProtectionResourceGuardOperation -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName -ResourceGuardOperationRequest DisableMUA -ResourceToBeDeleted $proxy.Id -SecureToken $token
Remove-AzDataProtectionResourceGuardMapping -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName
```

The first command fetch the access token for cross tenant resource guard. pass the access token for cross tenant scenario for authorizing critical operation. 
The second command fetches the resource guard mapping which need to be deleted to disable MUA. 
The third command unlocks the critical operation to disable the MUA. 
The fourth command removes the mapping between resource guard and backup vault.
To understand more on the unlock-azdataprotectionresourceguardoperation command, check https://learn.microsoft.com/powershell/module/az.dataprotection/unlock-azdataprotectionresourceguardoperation
