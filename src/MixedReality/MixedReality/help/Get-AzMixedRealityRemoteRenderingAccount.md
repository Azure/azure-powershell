---
external help file: Az.MixedReality-help.xml
Module Name: Az.MixedReality
online version: https://learn.microsoft.com/powershell/module/az.mixedreality/get-azmixedrealityremoterenderingaccount
schema: 2.0.0
---

# Get-AzMixedRealityRemoteRenderingAccount

## SYNOPSIS
Retrieve a Remote Rendering Account.

## SYNTAX

### List (Default)
```
Get-AzMixedRealityRemoteRenderingAccount [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzMixedRealityRemoteRenderingAccount -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### List1
```
Get-AzMixedRealityRemoteRenderingAccount -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMixedRealityRemoteRenderingAccount -InputObject <IMixedRealityIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Retrieve a Remote Rendering Account.

## EXAMPLES

### Example 1: List Remote Rendering Account by Subscription.
```powershell
Get-AzMixedRealityRemoteRenderingAccount
```

```output
Location Name                     ResourceGroupName
-------- ----                     -----------------
eastus   azpstestrenderingaccount azps_test_group
```

List Remote Rendering Account by Subscription.

### Example 2: List Remote Rendering Account by Resource Group.
```powershell
Get-AzMixedRealityRemoteRenderingAccount -ResourceGroupName azps_test_group
```

```output
Location Name                     ResourceGroupName
-------- ----                     -----------------
eastus   azpstestrenderingaccount azps_test_group
```

List Remote Rendering Account by Resource Group.

### Example 3: Get a Remote Rendering Account.
```powershell
Get-AzMixedRealityRemoteRenderingAccount -ResourceGroupName azps_test_group -Name azpstestrenderingaccount
```

```output
Location Name                     ResourceGroupName
-------- ----                     -----------------
eastus   azpstestrenderingaccount azps_test_group
```

Get a Remote Rendering Account.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.IMixedRealityIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of an Mixed Reality Account.

```yaml
Type: System.String
Parameter Sets: Get
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
Name of an Azure resource group.

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
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

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

### Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.IMixedRealityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IRemoteRenderingAccount

## NOTES

## RELATED LINKS
