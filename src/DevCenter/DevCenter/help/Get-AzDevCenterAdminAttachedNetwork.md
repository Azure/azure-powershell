---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteradminattachednetwork
schema: 2.0.0
---

# Get-AzDevCenterAdminAttachedNetwork

## SYNOPSIS
Gets an attached NetworkConnection.

## SYNTAX

### List (Default)
```
Get-AzDevCenterAdminAttachedNetwork -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get1
```
Get-AzDevCenterAdminAttachedNetwork -ConnectionName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -DevCenterName <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterAdminAttachedNetwork -ConnectionName <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### List1
```
Get-AzDevCenterAdminAttachedNetwork -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -DevCenterName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterAdminAttachedNetwork -InputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets an attached NetworkConnection.

## EXAMPLES

### Example 1: List attached networks in a dev center
```powershell
Get-AzDevCenterAdminAttachedNetwork -ResourceGroupName testRg -DevCenterName Contoso
```

This command lists the attached networks in the dev center "Contoso" under the resource group "testRg".

### Example 2: List attached networks in a project
```powershell
Get-AzDevCenterAdminAttachedNetwork -ProjectName DevProject -ResourceGroupName testRg
```

This command lists the attached networks in the project "DevProject" under the resource group "testRg".

### Example 3: Get a dev center attached network
```powershell
Get-AzDevCenterAdminAttachedNetwork -ConnectionName network-uswest3 -ResourceGroupName testRg -DevCenterName Contoso
```

This command gets the attached network named "network-uswest3" in the dev center "Contoso" under the resource group "testRg".

### Example 4: Get a project attached network
```powershell
Get-AzDevCenterAdminAttachedNetwork -ConnectionName network-uswest3 -ProjectName DevProject -ResourceGroupName testRg
```

This command gets the attached network named "network-uswest3" in the project "DevProject" under the resource group "testRg".

## PARAMETERS

### -ConnectionName
The name of the attached NetworkConnection.

```yaml
Type: System.String
Parameter Sets: Get1, Get
Aliases: AttachedNetworkConnectionName

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

### -DevCenterName
The name of the devcenter.

```yaml
Type: System.String
Parameter Sets: Get1, List1
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ProjectName
The name of the project.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get1, Get, List1
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
Parameter Sets: List, Get1, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20231001Preview.IAttachedNetworkConnection

## NOTES

## RELATED LINKS
