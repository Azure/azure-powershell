---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/deploy-azcdnedgeactionversioncode
schema: 2.0.0
---

# Deploy-AzCdnEdgeActionVersionCode

## SYNOPSIS
A long-running operation to deploy versioncode to EdgeActionVersion resource.

## SYNTAX

### DeployExpanded (Default)
```
Deploy-AzCdnEdgeActionVersionCode -EdgeActionName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Version <String> -Content <String> -Name <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeployViaJsonString
```
Deploy-AzCdnEdgeActionVersionCode -EdgeActionName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Version <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeployViaJsonFilePath
```
Deploy-AzCdnEdgeActionVersionCode -EdgeActionName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Version <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Deploy
```
Deploy-AzCdnEdgeActionVersionCode -EdgeActionName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Version <String> -Body <IVersionCode> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeployViaIdentityEdgeActionExpanded
```
Deploy-AzCdnEdgeActionVersionCode -Version <String> -EdgeActionInputObject <ICdnIdentity> -Content <String>
 -Name <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DeployViaIdentityEdgeAction
```
Deploy-AzCdnEdgeActionVersionCode -Version <String> -EdgeActionInputObject <ICdnIdentity> -Body <IVersionCode>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DeployViaIdentityExpanded
```
Deploy-AzCdnEdgeActionVersionCode -InputObject <ICdnIdentity> -Content <String> -Name <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DeployViaIdentity
```
Deploy-AzCdnEdgeActionVersionCode -InputObject <ICdnIdentity> -Body <IVersionCode> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
A long-running operation to deploy versioncode to EdgeActionVersion resource.

## EXAMPLES

### Example 1: Deploy Edge Action Version Code
```powershell
Deploy-AzCdnEdgeActionVersionCode -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Version "v1" -Content "console.log('Hello World');" -Name "main.js"
```

```output
DeploymentType        : zip
IsDefaultVersion      : True
ProvisioningState     : Succeeded
ValidationStatus      : Succeeded
LastPackageUpdateTime : 10/27/2025 10:30:45 AM
```

Deploy code for a specific Edge Action Version

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
EdgeAction version code deployment object

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IVersionCode
Parameter Sets: Deploy, DeployViaIdentityEdgeAction, DeployViaIdentity
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

### -EdgeActionInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: DeployViaIdentityEdgeActionExpanded, DeployViaIdentityEdgeAction
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
Parameter Sets: DeployExpanded, DeployViaJsonString, DeployViaJsonFilePath, Deploy
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: DeployViaIdentityExpanded, DeployViaIdentity
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
Parameter Sets: DeployExpanded, DeployViaIdentityEdgeActionExpanded, DeployViaIdentityExpanded
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
Parameter Sets: DeployExpanded, DeployViaJsonString, DeployViaJsonFilePath, Deploy
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
Parameter Sets: DeployExpanded, DeployViaJsonString, DeployViaJsonFilePath, Deploy
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
Parameter Sets: DeployExpanded, DeployViaJsonString, DeployViaJsonFilePath, Deploy, DeployViaIdentityEdgeActionExpanded, DeployViaIdentityEdgeAction
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IVersionCode

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IEdgeActionVersionProperties

## NOTES

## RELATED LINKS
