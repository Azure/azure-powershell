---
external help file: Az.EdgeAction-help.xml
Module Name: Az.EdgeAction
online version: https://learn.microsoft.com/powershell/module/az.edgeaction/update-azedgeactionversion
schema: 2.0.0
---

# Update-AzEdgeActionVersion

## SYNOPSIS
Update a EdgeActionVersion

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzEdgeActionVersion -EdgeActionName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Version <String> [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzEdgeActionVersion -EdgeActionName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Version <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzEdgeActionVersion -EdgeActionName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Version <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityEdgeActionExpanded
```
Update-AzEdgeActionVersion -Version <String> -EdgeActionInputObject <IEdgeActionIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityEdgeAction
```
Update-AzEdgeActionVersion -Version <String> -EdgeActionInputObject <IEdgeActionIdentity>
 -Property <IEdgeActionVersionUpdate> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzEdgeActionVersion -InputObject <IEdgeActionIdentity> [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a EdgeActionVersion

## EXAMPLES

### Example 1: Update an edge action version with tags
```powershell
Update-AzEdgeActionVersion -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -Tag @{ Environment = "Production"; Team = "Platform" }
```

```output
Name Location ProvisioningState
---- -------- -----------------
v1   global   Succeeded
```

Updates the specified edge action version with the provided tags.

### Example 2: Update an edge action version using JSON file
```powershell
Update-AzEdgeActionVersion -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -JsonFilePath "C:\config\version-update.json"
```

```output
Name Location ProvisioningState
---- -------- -----------------
v1   global   Succeeded
```

Updates the edge action version using configuration from a JSON file.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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

### -EdgeActionInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionIdentity
Parameter Sets: UpdateViaIdentityEdgeActionExpanded, UpdateViaIdentityEdgeAction
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EdgeActionName
The name of the Edge Action

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Property
Concrete tracked resource types can be created by aliasing this type using a specific property type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionVersionUpdate
Parameter Sets: UpdateViaIdentityEdgeAction
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityEdgeActionExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
The name of the Edge Action version

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityEdgeActionExpanded, UpdateViaIdentityEdgeAction
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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionIdentity

### Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionVersionUpdate

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionVersion

## NOTES

## RELATED LINKS
