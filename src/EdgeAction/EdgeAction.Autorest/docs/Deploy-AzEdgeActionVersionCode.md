---
external help file:
Module Name: Az.EdgeAction
online version: https://learn.microsoft.com/powershell/module/az.edgeaction/deploy-azedgeactionversioncode
schema: 2.0.0
---

# Deploy-AzEdgeActionVersionCode

## SYNOPSIS
A long-running resource action.

## SYNTAX

### DeployFromFile (Default)
```
Deploy-AzEdgeActionVersionCode -EdgeActionName <String> -ResourceGroupName <String> -Version <String>
 -FilePath <String> [-SubscriptionId <String>] [-DeploymentType <String>] [-Name <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Deploy
```
Deploy-AzEdgeActionVersionCode -EdgeActionName <String> -ResourceGroupName <String> -Version <String>
 -Body <IVersionCode> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### DeployExpanded
```
Deploy-AzEdgeActionVersionCode -EdgeActionName <String> -ResourceGroupName <String> -Version <String>
 -Content <String> -Name <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeployViaIdentity
```
Deploy-AzEdgeActionVersionCode -InputObject <IEdgeActionIdentity> -Body <IVersionCode>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeployViaIdentityEdgeAction
```
Deploy-AzEdgeActionVersionCode -EdgeActionInputObject <IEdgeActionIdentity> -Version <String>
 -Body <IVersionCode> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DeployViaIdentityEdgeActionExpanded
```
Deploy-AzEdgeActionVersionCode -EdgeActionInputObject <IEdgeActionIdentity> -Version <String>
 -Content <String> -Name <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DeployViaIdentityExpanded
```
Deploy-AzEdgeActionVersionCode -InputObject <IEdgeActionIdentity> -Content <String> -Name <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeployViaJsonFilePath
```
Deploy-AzEdgeActionVersionCode -EdgeActionName <String> -ResourceGroupName <String> -Version <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### DeployViaJsonString
```
Deploy-AzEdgeActionVersionCode -EdgeActionName <String> -ResourceGroupName <String> -Version <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
A long-running resource action.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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

### -Body
Version code information for edge action

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IVersionCode
Parameter Sets: Deploy, DeployViaIdentity, DeployViaIdentityEdgeAction
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Content
The version code deployment content

```yaml
Type: System.String
Parameter Sets: DeployExpanded, DeployViaIdentityEdgeActionExpanded, DeployViaIdentityExpanded
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

### -DeploymentType
Deployment type: 'file' for JavaScript files, 'zip' for zip archives.
Auto-detected if not specified.

```yaml
Type: System.String
Parameter Sets: DeployFromFile
Aliases:

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
Parameter Sets: DeployViaIdentityEdgeAction, DeployViaIdentityEdgeActionExpanded
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
Parameter Sets: Deploy, DeployExpanded, DeployFromFile, DeployViaJsonFilePath, DeployViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilePath
Path to JavaScript (.js) or zip (.zip) file

```yaml
Type: System.String
Parameter Sets: DeployFromFile
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
Parameter Sets: DeployViaIdentity, DeployViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Deploy operation

```yaml
Type: System.String
Parameter Sets: DeployViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Deploy operation

```yaml
Type: System.String
Parameter Sets: DeployViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The version code name

```yaml
Type: System.String
Parameter Sets: DeployExpanded, DeployFromFile, DeployViaIdentityEdgeActionExpanded, DeployViaIdentityExpanded
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Deploy, DeployExpanded, DeployFromFile, DeployViaJsonFilePath, DeployViaJsonString
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
Parameter Sets: Deploy, DeployExpanded, DeployFromFile, DeployViaJsonFilePath, DeployViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
The name of the Edge Action version

```yaml
Type: System.String
Parameter Sets: Deploy, DeployExpanded, DeployFromFile, DeployViaIdentityEdgeAction, DeployViaIdentityEdgeActionExpanded, DeployViaJsonFilePath, DeployViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IVersionCode

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IEdgeActionVersionProperties

### System.Object

## NOTES

## RELATED LINKS

