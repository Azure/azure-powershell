---
external help file: Az.ImageBuilder-help.xml
Module Name: Az.ImageBuilder
online version: https://learn.microsoft.com/powershell/module/az.imagebuilder/get-azimagebuildertemplaterunoutput
schema: 2.0.0
---

# Get-AzImageBuilderTemplateRunOutput

## SYNOPSIS
Get the specified run output for the specified image template resource

## SYNTAX

### List (Default)
```
Get-AzImageBuilderTemplateRunOutput -ImageTemplateName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzImageBuilderTemplateRunOutput -ImageTemplateName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzImageBuilderTemplateRunOutput -InputObject <IImageBuilderIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get the specified run output for the specified image template resource

## EXAMPLES

### Example 1: List the specified run output for the specified image template resource by ImageTemplateName.
```powershell
Get-AzImageBuilderTemplateRunOutput -ImageTemplateName azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder
```

```output
Name         ProvisioningState ResourceGroupName
----         ----------------- -----------------
runoutput-01 Succeeded         azps_test_group_imagebuilder
```

List the specified run output for the specified image template resource by ImageTemplateName.

### Example 2: Get the specified run output for the specified image template resource by Name.
```powershell
Get-AzImageBuilderTemplateRunOutput -ImageTemplateName azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder -Name runoutput-01
```

```output
Name         ProvisioningState ResourceGroupName
----         ----------------- -----------------
runoutput-01 Succeeded         azps_test_group_imagebuilder
```

Get the specified run output for the specified image template resource by Name.

## PARAMETERS

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

### -ImageTemplateName
The name of the image Template

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IImageBuilderIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the run output

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RunOutputName

Required: True
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
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription Id forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IImageBuilderIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.IRunOutput

## NOTES

## RELATED LINKS
