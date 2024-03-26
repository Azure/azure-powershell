---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/get-azkeyvaultroledefinition
schema: 2.0.0
---

# Get-AzKeyVaultRoleDefinition

## SYNOPSIS
List role definitions of a given managed HSM at a given scope.

## SYNTAX

### Interactive (Default)
```
Get-AzKeyVaultRoleDefinition [-HsmName] <String> [-Scope <String>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### CustomOnly
```
Get-AzKeyVaultRoleDefinition [-HsmName] <String> [-Scope <String>] [-Custom]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByName
```
Get-AzKeyVaultRoleDefinition [-HsmName] <String> [-Scope <String>] -RoleDefinitionName <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
List role definitions of a given managed HSM at a given scope.

## EXAMPLES

### Example 1
```powershell
Get-AzKeyVaultRoleDefinition -HsmName myHsm -Scope "/keys"
```

```output
RoleName                              Description Permissions
--------                              ----------- -----------
Managed HSM Administrator                         1 permission(s)
Managed HSM Crypto Officer                        1 permission(s)
Managed HSM Crypto User                           1 permission(s)
Managed HSM Policy Administrator                  1 permission(s)
Managed HSM Crypto Auditor                        1 permission(s)
Managed HSM Crypto Service Encryption             1 permission(s)
Managed HSM Backup                                1 permission(s)
```

The example lists all the roles at "/keys" scope.

### Example 2
<!-- Skip: Output cannot be splitted from code -->


```powershell
$backupRole = Get-AzKeyVaultRoleDefinition -HsmName myHsm -RoleDefinitionName "Managed HSM Backup User"

$backupRole.Permissions

Actions     NotActions  DataActions NotDataActions
-------     ----------  ----------- --------------
0 action(s) 0 action(s) 3 action(s) 0 action(s)

$backupRole.Permissions.DataActions

Microsoft.KeyVault/managedHsm/backup/start/action
Microsoft.KeyVault/managedHsm/backup/status/action
Microsoft.KeyVault/managedHsm/keys/backup/action
```

The example gets the "Managed HSM Backup" role and inspects its permissions.

### Example 3
```powershell
Get-AzKeyVaultRoleDefinition -HsmName myHsm -Custom
```

This example lists all the custom role definitions belong to "myHsm".

## PARAMETERS

### -Custom
If specified, only displays the custom created roles in the directory.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CustomOnly
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -HsmName
Name of the HSM.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
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

### -RoleDefinitionName
Name of the role definition to get.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: RoleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Scope at which the role assignment or definition applies to, e.g., '/' or '/keys' or '/keys/{keyName}'.
'/' is used when omitted.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultRoleDefinition

## NOTES

## RELATED LINKS
