---
external help file: Az.Alb-help.xml
Module Name: Az.Alb
online version: https://learn.microsoft.com/powershell/module/az.alb/get-azalbfrontend
schema: 2.0.0
---

# Get-AzAlbFrontend

## SYNOPSIS
Get a Frontend

## SYNTAX

### List (Default)
```
Get-AzAlbFrontend -AlbName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzAlbFrontend -AlbName <String> -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityTrafficController
```
Get-AzAlbFrontend -Name <String> -TrafficControllerInputObject <IAlbIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAlbFrontend -InputObject <IAlbIdentity> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Frontend

## EXAMPLES

### Example 1: Get a specified Application Gateway for Containers frontend resource
```powershell
Get-AzAlbFrontend -Name test-frontend -AlbName test-alb -ResourceGroupName test-rg
```

```output
Name          ResourceGroupName Location       Fqdn                                                ProvisioningState
----          ----------------- --------       ----                                                -----------------
test-frontend test-rg           northcentralus c70d8be2a2d358417f901f8264d4bc32.fz54.alb.azure.com Succeeded
```

This command shows a specific Application Gateway for Containers frontend resource.

### Example 2: List frontends for a given Application Gateway for Containers resource
```powershell
Get-AzAlbFrontend -AlbName test-alb -ResourceGroupName test-rg
```

```output
Name           ResourceGroupName Location       Fqdn                                                ProvisioningState
----           ----------------- --------       ----                                                -----------------
test-frontend2 test-rg           northcentralus e853d603ee81f4af13e83a6df300045d.fz85.alb.azure.com Succeeded
test-frontend  test-rg           northcentralus c70d8be2a2d358417f901f8264d4bc32.fz54.alb.azure.com Succeeded
```

This command lists all Application Gateway for Containers frontend resources belonging to a specific Application Gateway for Containers resource.

## PARAMETERS

### -AlbName
traffic controller name for path

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAlbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Frontends

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityTrafficController
Aliases:

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
The name is case insensitive.

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
The ID of the target subscription.

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

### -TrafficControllerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAlbIdentity
Parameter Sets: GetViaIdentityTrafficController
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAlbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IFrontend

## NOTES

## RELATED LINKS
