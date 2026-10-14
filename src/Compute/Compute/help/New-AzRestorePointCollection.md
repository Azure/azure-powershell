---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azrestorepointcollection
schema: 2.0.0
---

# New-AzRestorePointCollection

## SYNOPSIS
Creates a New Restore Point Collection

## SYNTAX

### DefaultParameter (Default)
```
New-AzRestorePointCollection [-ResourceGroupName] <String> [-Name] <String> [-SourceId] <String>
 [-Location <String>] [-InstantAccess <Boolean>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RestorePointCollectionId
```
New-AzRestorePointCollection [-ResourceGroupName] <String> [-Name] <String> [[-SourceId] <String>]
 [-RestorePointCollectionId] <String> -Location <String> [-InstantAccess <Boolean>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a New Restore Point Collection

## EXAMPLES

### Example 1
```powershell
New-AzRestorePointCollection -ResourceGroupName <String> -Name <String> -VmId <String>
```

Create a new Restore Point Collection using a VM Id.

### Example 2
```powershell
New-AzRestorePointCollection -ResourceGroupName "MyResourceGroup" -Name "MyRPCollection" -VmId <String> -Location "eastus2euap" -InstantAccess $true
```

Create a new Restore Point Collection with Instant Access enabled for Premium SSD v2 and Ultra disk restore points.

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

### -InstantAccess
Enables or disables instant access snapshot for restore points created under this restore point collection for Premium SSD v2 or Ultra disk. When set to $true, instant access snapshots are instantaneously available for disk restore with fast restore performance.

This parameter is supported only when the Compute API version is `2025-04-01` or later and the `AppConsistentInstantAccessSnapshotForDirectDriveDisks` feature flag is enabled for the subscription. In unsupported subscriptions or regions, this parameter may be ignored or the request may be rejected.
```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
location of the source resource used to create this restore point collection.

```yaml
Type: System.String
Parameter Sets: DefaultParameter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: RestorePointCollectionId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Resource Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RestorePointCollectionName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

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

### -RestorePointCollectionId
ARM Id of Source RestorePoint Collection

```yaml
Type: System.String
Parameter Sets: RestorePointCollectionId
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SourceId
Resource ID of the source resource used to create this restore point collection.

```yaml
Type: System.String
Parameter Sets: DefaultParameter
Aliases: VmId

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: RestorePointCollectionId
Aliases: VmId

Required: False
Position: 2
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

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSRestorePointCollection

## NOTES

## RELATED LINKS
