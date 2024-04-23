---
external help file: Az.ImageBuilder-help.xml
Module Name: Az.ImageBuilder
online version: https://learn.microsoft.com/powershell/module/az.imagebuilder/get-azimagebuildertemplate
schema: 2.0.0
---

# Get-AzImageBuilderTemplate

## SYNOPSIS
Get information about a virtual machine image template

## SYNTAX

### List (Default)
```
Get-AzImageBuilderTemplate [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzImageBuilderTemplate -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzImageBuilderTemplate -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzImageBuilderTemplate -InputObject <IImageBuilderIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get information about a virtual machine image template

## EXAMPLES

### Example 1: List information about virtual machine image template by SubscriptionId.
```powershell
Get-AzImageBuilderTemplate
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   azps-ibt-1 azps_test_group_imagebuilder
eastus   azps-ibt-2 azps_test_group_imagebuilder
eastus   azps-ibt-3 azps_test_group_imagebuilder
```

List information about virtual machine image template by SubscriptionId.

### Example 2: List information about virtual machine image template by ResourceGroupName.
```powershell
Get-AzImageBuilderTemplate -resourceGroupName azps_test_group_imagebuilder
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   azps-ibt-1 azps_test_group_imagebuilder
eastus   azps-ibt-2 azps_test_group_imagebuilder
eastus   azps-ibt-3 azps_test_group_imagebuilder
```

List information about virtual machine image template by ResourceGroupName.

### Example 3: Get information about a virtual machine image template by Name.
```powershell
Get-AzImageBuilderTemplate -resourceGroupName azps_test_group_imagebuilder -Name azps-ibt-1
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   azps-ibt-1 azps_test_group_imagebuilder
```

Get information about a virtual machine image template by Name.

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
The name of the image Template

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ImageTemplateName

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
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.IImageTemplate

## NOTES

## RELATED LINKS
