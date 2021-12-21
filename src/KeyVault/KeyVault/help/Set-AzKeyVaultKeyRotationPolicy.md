---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version:
schema: 2.0.0
---

# Set-AzKeyVaultKeyRotationPolicy

## SYNOPSIS
Sets the key rotation policy for the specified key in Key Vault.

## SYNTAX

### ByVaultName (Default)
```
Set-AzKeyVaultKeyRotationPolicy [-ExpiresIn <TimeSpan>]
 [-KeyRotationLifetimeAction <PSKeyRotationLifetimeAction[]>] [-VaultName] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

###  ByKeyRotationPolicyInputObject
```
Set-AzKeyVaultKeyRotationPolicy [-KeyRotationPolicy] <PSKeyRotationPolicy>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByKeyInputObject
```
Set-AzKeyVaultKeyRotationPolicy [-ExpiresIn <TimeSpan>]
 [-KeyRotationLifetimeAction <PSKeyRotationLifetimeAction[]>] [-InputObject] <PSKeyVaultKeyIdentityItem>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet requires the key update permission. It returns a key rotation policy for the specified key.

## EXAMPLES

### Example 1: Sets key rotation policy expiry time
```powershell
$t = New-TimeSpan -Days 50
Set-AzKeyVaultKeyRotationPolicy -VaultName test-kv -Name test-key -ExpiresIn $t
```

```output
Id              : https://test-kv.vault.azure.net/keys/test-key/rotationpolicy
VaultName       : test-kv
KeyName         : test-key
LifetimeActions : {[Action: Notify, TimeAfterCreate: , TimeBeforeExpiry: 30.00:00:00]}
ExpiresIn       : 50.00:00:00
CreatedOn       : 12/10/2021 3:21:51 AM +00:00
UpdatedOn       : 12/10/2021 3:22:14 AM +00:00
```

These cmdlets set the key rotation policy expiry time of test-key as 50 days.

### Example 2: Sets key rotation policy by InputObject
```powershell
$key = Get-AzKeyVaultKey -VaultName test-kv -Name test-key
$action = [Microsoft.Azure.Commands.KeyVault.Models.PSKeyRotationLifetimeAction]::new()
$action.Action = "Rotate"
$action.TimeBeforeExpiry = New-TimeSpan -Days 30
Set-AzKeyVaultKeyRotationPolicy -InputObject $key -KeyRotationLifetimeAction $action
```

```output
Id              : https://test-kv.vault.azure.net/keys/test-key/rotationpolicy
VaultName       : test-kv
KeyName         : test-key
LifetimeActions : {[Action: Rotate, TimeAfterCreate: , TimeBeforeExpiry: 30.00:00:00], [Action: Notify,
                  TimeAfterCreate: , TimeBeforeExpiry: 30.00:00:00]}
ExpiresIn       : 50.00:00:00
CreatedOn       : 12/10/2021 3:21:51 AM +00:00
UpdatedOn       : 12/14/2021 5:26:28 AM +00:00
```

These cmdlets set the key rotation policy expiry time of test-key as 50 days.

### Example 3: Sets key rotation policy by PSKeyRotationPolicy object
```powershell
$key = Get-AzKeyVaultKey -VaultName test-kv -Name test-key
$policy = Get-AzKeyVaultKeyRotationPolicy $key
$policy.ExpiresIn = New-TimeSpan -Days 60
Set-AzKeyVaultKeyRotationPolicy -KeyRotationPolicy $policy
```

```output
LifetimeActions : {[Action: Rotate, TimeAfterCreate: , TimeBeforeExpiry: 30.00:00:00], [Action: Notify,
                  TimeAfterCreate: , TimeBeforeExpiry: 30.00:00:00]}
ExpiresIn       : 60.00:00:00
CreatedOn       : 12/10/2021 3:21:51 AM +00:00
UpdatedOn       : 12/14/2021 5:34:00 AM +00:00
```

These cmdlets set the key rotation policy expiry time of test-key as 50 days.

## PARAMETERS

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpiresIn
The time span when the key rotation policy will expire.
It should be at least 28 days.

```yaml
Type: TimeSpan
Parameter Sets: ByVaultName, ByKeyInputObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Key object

```yaml
Type: PSKeyVaultKeyIdentityItem
Parameter Sets: ByKeyInputObject
Aliases: Key

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyRotationLifetimeAction
PSKeyRotationLifetimeAction object.

```yaml
Type: PSKeyRotationLifetimeAction[]
Parameter Sets: ByVaultName, ByKeyInputObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyRotationPolicy
PSKeyRotationPolicy object.

```yaml
Type: PSKeyRotationPolicy
Parameter Sets:  ByKeyRotationPolicyInputObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Key name.

```yaml
Type: String
Parameter Sets: ByVaultName
Aliases: KeyName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
Vault name.

```yaml
Type: String
Parameter Sets: ByVaultName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
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

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyRotationPolicy

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKeyIdentityItem

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyRotationPolicy

## NOTES

## RELATED LINKS

[Get-AzKeyVaultKeyRotationPolicy.md](./Get-AzKeyVaultKeyRotationPolicy.md)

[Invoke-AzKeyVaultKeyRotation.md](./Invoke-AzKeyVaultKeyRotation.md)