---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azrestorepoint
schema: 2.0.0
---

# New-AzRestorePoint

## SYNOPSIS
This cmdlet can create a New Restore Point

## SYNTAX

```
New-AzRestorePoint [-ResourceGroupName] <String> [-RestorePointCollectionName] <String> [-Name] <String>
 [[-Location] <String>] [-RestorePointId <String>] [-DisksToExclude <String[]>] [-ConsistencyMode <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create's a new Restore Point

## EXAMPLES

### Example 1
```powershell
New-AzRestorePoint -ResourceGroupName "myRG" -RestorePointCollectionName "myCollection" -Name "myRestorePoint" -ConsistencyMode "CrashConsistent"
```

Creates a new Restore Point

## PARAMETERS

### -ConsistencyMode
ConsistencyMode of the restore point. Can be specified in the input while creating a restore point. For now, only CrashConsistent is accepted as a valid input. Please refer to https://aka.ms/RestorePoints for more details.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -DisksToExclude
List of disk resource Id values that the customer wishes to exclude from the restore point. If no disks are specified, all disks will be included.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Set the region of the restore point

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the restore point

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RestorePointName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name this resource belongs to

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RestorePointCollectionName
Name of the restore point collection this restore point is part of

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RestorePointId
ARM Id of the source restore point

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSRestorePoint

## NOTES

## RELATED LINKS
