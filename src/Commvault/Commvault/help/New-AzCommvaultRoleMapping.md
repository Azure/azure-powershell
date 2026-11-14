---
external help file: Az.Commvault-help.xml
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/new-azcommvaultrolemapping
schema: 2.0.0
---

# New-AzCommvaultRoleMapping

## SYNOPSIS
Create a RoleMapping

## SYNTAX

### CreateExpanded (Default)
```
New-AzCommvaultRoleMapping -CloudAccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Role <IRoleAssignment[]>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzCommvaultRoleMapping -CloudAccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzCommvaultRoleMapping -CloudAccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a RoleMapping

## EXAMPLES

### Example 1: Create the role mapping of a cloud account
```powershell
$roles = @(
    @{ RoleName = 'BackupAdmin'; Entity = @(@{ Id = 'a1b2c3d4-e5f6-7890-abcd-ef1234567890'; DisplayName = 'Backup Admins Group'; EntityType = 'Group' }) },
    @{ RoleName = 'BackupUser'; Entity = @(@{ Id = '22222222-3333-4444-5555-666666666666'; DisplayName = 'Jane Doe'; EntityType = 'User' }) }
)
New-AzCommvaultRoleMapping -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Role $roles
```

Maps the BackupAdmin and BackupUser roles to a Microsoft Entra group and user.

### Example 2: Create the role mapping by using a JSON file
```powershell
New-AzCommvaultRoleMapping -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -JsonFilePath '.\role-mapping.json'
```

Creates the role mapping from the request body in the JSON file.

## PARAMETERS

### -CloudAccountName
Name of the Cloud Account resource

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -Role
The list of role assignments mapping roles to Entra entities (users and groups)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IRoleAssignment[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IRoleMapping

## NOTES

## RELATED LINKS
