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
Set-AzKeyVaultKeyRotationPolicy [-VaultName] <String> [-Name] <String> [-ExpiresIn <String>]
 [-KeyRotationLifetimeAction <PSKeyRotationLifetimeAction[]>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByRotationPolicyFileViaVaultName
```
Set-AzKeyVaultKeyRotationPolicy [-VaultName] <String> [-Name] <String> -PolicyPath <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByKeyInputObject
```
Set-AzKeyVaultKeyRotationPolicy [-InputObject] <PSKeyVaultKeyIdentityItem> [-ExpiresIn <String>]
 [-KeyRotationLifetimeAction <PSKeyRotationLifetimeAction[]>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByRotationPolicyFileViaKeyInputObject
```
Set-AzKeyVaultKeyRotationPolicy [-InputObject] <PSKeyVaultKeyIdentityItem> -PolicyPath <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByKeyRotationPolicyInputObject
```
Set-AzKeyVaultKeyRotationPolicy [-KeyRotationPolicy] <PSKeyRotationPolicy>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet requires the key update permission. It returns a key rotation policy for the specified key.

## EXAMPLES

### Example 1: Sets key rotation policy by JSON file
```powershell
<# 
rotation_policy.json
{
    "lifetimeActions": [
      {
        "trigger": {
          "timeAfterCreate": "P18M",
          "timeBeforeExpiry": null
        },
        "action": {
          "type": "Rotate"
        }
      },
      {
        "trigger": {
          "timeBeforeExpiry": "P30D"
        },
        "action": {
          "type": "Notify"
        }
      }
    ],
    "attributes": {
      "expiryTime": "P2Y"
    }
  }
#>
Set-AzKeyVaultKeyRotationPolicy -VaultName test-kv -Name test-key -PolicyPath rotation_policy.json
```

```output
Id              : https://test-kv.vault.azure.net/keys/test-key/rotationpolicy
VaultName       : test-kv
KeyName         : test-keyAM +00:00
LifetimeActions : {[Action: Notify, TimeAfterCreate: , TimeBeforeExpiry: P30D]}
ExpiresIn       : P2Y
CreatedOn       : 12/10/2021 3:21:51 AM +00:00
UpdatedOn       : 6/9/2022 7:43:27 
```

These commands set the rotation policy of key `test-key` by JSON file.

### Example 2: Sets key rotation policy expiry time
```powershell
Set-AzKeyVaultKeyRotationPolicy -VaultName test-kv -Name test-key -ExpiresIn P2Y
```

```output
Id              : https://test-kv.vault.azure.net/keys/test-key/rotationpolicy
VaultName       : test-kv
KeyName         : test-keyAM +00:00
LifetimeActions : {[Action: Notify, TimeAfterCreate: , TimeBeforeExpiry: P30D]}
ExpiresIn       : P2Y
CreatedOn       : 12/10/2021 3:21:51 AM +00:00
UpdatedOn       : 6/9/2022 7:43:27 
```

These commands set the expiry time will be applied on the new key version of `test-key` as 2 years.

### Example 3: Sets key rotation policy via piping
```powershell
Get-AzKeyVaultKey -VaultName test-kv -Name test-key | Set-AzKeyVaultKeyRotationPolicy -KeyRotationLifetimeAction @{Action = "Rotate"; TimeBeforeExpiry = "P18M"}
```

```output
Id              : https://test-kv.vault.azure.net/keys/test-key/rotationpolicy
VaultName       : test-kv
KeyName         : test-key
LifetimeActions : {[Action: Rotate, TimeAfterCreate: , TimeBeforeExpiry: P18M], [Action: Notify, TimeAfterCreate: ,
                  TimeBeforeExpiry: P30D]}
ExpiresIn       : P2Y
CreatedOn       : 12/10/2021 3:21:51 AM +00:00
UpdatedOn       : 6/9/2022 8:10:43 AM +00:00
```

These commands set the duration before expiry to attempt to rotate `test-key` as 18 months.

### Example 4: Copy key rotation policy to another key via PSKeyRotationPolicy object
```powershell
$policy = Get-AzKeyVaultKeyRotationPolicy -VaultName test-kv -Name test-key1
$policy.KeyName = "test-key2"
$policy | Set-AzKeyVaultKeyRotationPolicy 
```

```output
Id              : https://test-kv.vault.azure.net/keys/test-key2/rotationpolicy
VaultName       : test-kv
KeyName         : test-key2
LifetimeActions : {[Action: Rotate, TimeAfterCreate: , TimeBeforeExpiry: P18M], [Action: Notify, TimeAfterCreate: ,
                  TimeBeforeExpiry: P30D]}
ExpiresIn       : P2Y
CreatedOn       : 6/9/2022 8:26:35 AM +00:00
UpdatedOn       : 6/9/2022 8:26:35 AM +00:00
```

These commands copy the key rotation policy `test-key1` to key `test-key2`.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpiresIn
The expiryTime will be applied on the new key version. It should be at least 28 days. It will be in ISO 8601 Format. Examples: 90 days: P90D, 3 months: P3M, 48 hours: PT48H, 1 year and 10 days: P1Y10D.

```yaml
Type: System.String
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
Type: Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKeyIdentityItem
Parameter Sets: ByKeyInputObject, SetByRotationPolicyFileViaKeyInputObject
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
Type: Microsoft.Azure.Commands.KeyVault.Models.PSKeyRotationLifetimeAction[]
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
Type: Microsoft.Azure.Commands.KeyVault.Models.PSKeyRotationPolicy
Parameter Sets: ByKeyRotationPolicyInputObject
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
Type: System.String
Parameter Sets: ByVaultName, SetByRotationPolicyFileViaVaultName
Aliases: KeyName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyPath
A path to the rotation policy file that contains JSON policy definition.

```yaml
Type: System.String
Parameter Sets: SetByRotationPolicyFileViaVaultName, SetByRotationPolicyFileViaKeyInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
Vault name.

```yaml
Type: System.String
Parameter Sets: ByVaultName, SetByRotationPolicyFileViaVaultName
Aliases:

Required: True
Position: 0
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

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyRotationPolicy

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKeyIdentityItem

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyRotationPolicy

## NOTES

## RELATED LINKS

[Get-AzKeyVaultKeyRotationPolicy](./Get-AzKeyVaultKeyRotationPolicy.md)

[Invoke-AzKeyVaultKeyRotation](./Invoke-AzKeyVaultKeyRotation.md)