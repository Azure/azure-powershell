---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/unlock-azdataprotectionresourceguardoperation
schema: 2.0.0
---

# Unlock-AzDataProtectionResourceGuardOperation

## SYNOPSIS
Unlocks the critical operation which is protected by the resource guard

## SYNTAX

```
Unlock-AzDataProtectionResourceGuardOperation -ResourceGroupName <String> -VaultName <String>
 [-SubscriptionId <String>] [-ResourceGuardOperationRequest <String[]>] [-ResourceToBeDeleted <String>]
 [-Token <String>] [-SecureToken <SecureString>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Unlocks the critical operation which is protected by the resource guard

## EXAMPLES

### Example 1: Unlock critical operation protected by resource guard - delete backup instance
```powershell
$proxy = Get-AzDataProtectionResourceGuardMapping -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId
$operationRequests = $proxy.ResourceGuardOperationDetail.DefaultResourceRequest
$resourceGuardOperationRequest = $operationRequests | Where-Object { $_ -match "deleteBackupInstanceRequests" }

$token = (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").Token
$instances = Get-AzDataProtectionBackupInstance -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName

$unlock = Unlock-AzDataProtectionResourceGuardOperation -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vault.Name -ResourceGuardOperationRequest $resourceGuardOperationRequest -ResourceToBeDeleted $instances[0].Id -Token $token
$unlock | fl 

Remove-AzDataProtectionBackupInstance -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName  -Name $instances[0].Name
```

```output
2023-08-28T14:29:17.3982762Z
```

Ensure you have a contributor access over resource guard before doing unlock.

Fetch and pass the cross tenant authorization token in case the resource guard is present in a different tenant.

The first command fetches the resource guard mapping between backup vault and the resource guard.
The second command fetches the operation requests corresponding to all critical operations protected by resource guard.
The third command fetch the operation request corresponding to the operation we want to unlock.
The fourth command fetches the access token corresponding to resource guard tenant.
The fifth command fetches the backup instance we want to stop protection.
The sixth command unlocks the delete backup operation which is protected by the resource guard.
Ensure to have contributor access over resource guard before unlock.
Finally, we remove the backup instance for which we want to disable protection.

### Example 2: Unlock delete backup instance operation with short hand
```powershell
$token = (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").Token
$instances = Get-AzDataProtectionBackupInstance -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName

$unlock = Unlock-AzDataProtectionResourceGuardOperation -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vault.Name -ResourceGuardOperationRequest DeleteBackupInstance -ResourceToBeDeleted $instances[0].Id -Token $token
$unlock | fl 

Remove-AzDataProtectionBackupInstance -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName  -Name $instances[0].Name
```

```output
2023-08-28T14:29:17.3982762Z
```

This example is faster way (short hand) for Example 1.
In this example we show that by just passing the DeleteBackupInstance to ResourceGuardOperationRequest we can perform unlock.
we pass the instance ARM Id as the resource to be deleted.
Pass access token in case of cross tenant resource guard.

### Example 3: Unlock disable MUA operation with short hand
```powershell
$token = (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").Token
$proxy = Get-AzDataProtectionResourceGuardMapping -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId

$unlock = Unlock-AzDataProtectionResourceGuardOperation -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vault.Name -ResourceGuardOperationRequest DisableMUA -ResourceToBeDeleted $proxy.Id -Token $token
$unlock | fl 

Remove-AzDataProtectionResourceGuardMapping -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName
```

```output
2023-08-28T14:29:17.3982762Z
```

This example is faster way (short hand) for Example 1.
In this example we show that by just passing the DisableMUA to ResourceGuardOperationRequest we can perform unlock.
we pass the resource guard mapping ARM Id as the resource to be deleted, this will disable MUA on the backup vault.
Pass access token in case of cross tenant resource guard.

## PARAMETERS

### -DefaultProfile

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group name of the backup vault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGuardOperationRequest
List of critical operations which are protected by the resourceGuard and need to be unlocked.
Supported values are DeleteBackupInstance, DisableMUA

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceToBeDeleted
ARM Id of the resource that need to be unlocked for performing critical operation

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecureToken
Parameter to authorize operations protected by cross tenant resource guard.
Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -AsSecureString").Token to fetch authorization token for different tenant.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription Id of the backup vault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Token
Parameter to authorize operations protected by cross tenant resource guard.
Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -AsSecureString").Token to fetch secure authorization token for different tenant and then convert to string using ConvertFrom-SecureString cmdlet.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
Name of the backup vault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
