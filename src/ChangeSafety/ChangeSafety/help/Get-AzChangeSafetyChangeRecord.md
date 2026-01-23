---
external help file: Az.ChangeSafety-help.xml
Module Name: Az.ChangeSafety
online version: https://learn.microsoft.com/powershell/module/az.changesafety/get-azchangesafetychangerecord
schema: 2.0.0
---

# Get-AzChangeSafetyChangeRecord

## SYNOPSIS
Get a ChangeRecord

## SYNTAX

### List (Default)
```
Get-AzChangeSafetyChangeRecord [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get1
```
Get-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String[]>] -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzChangeSafetyChangeRecord -Name <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzChangeSafetyChangeRecord [-SubscriptionId <String[]>] -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzChangeSafetyChangeRecord -InputObject <IChangeSafetyIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzChangeSafetyChangeRecord -InputObject <IChangeSafetyIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a ChangeRecord

## EXAMPLES

### Example 1: Get a specific ChangeRecord by name
```powershell
Get-AzChangeSafetyChangeRecord -Name "storageAccountCleanup" -ResourceGroupName "rg-changeops"
```

```output
Name                  ResourceGroupName ChangeType  RolloutType Status      ProvisioningState
----                  ----------------- ----------  ----------- ------      -----------------
storageAccountCleanup rg-changeops      ManualTouch Hotfix      Initialized Succeeded
```

Retrieves a specific ChangeRecord by its name from the specified resource group.

### Example 2: List all ChangeRecords in a resource group
```powershell
Get-AzChangeSafetyChangeRecord -ResourceGroupName "rg-changeops"
```

```output
Name                  ResourceGroupName ChangeType    RolloutType Status      ProvisioningState
----                  ----------------- ----------    ----------- ------      -----------------
storageAccountCleanup rg-changeops      ManualTouch   Hotfix      Initialized Succeeded
appDeploymentV2       rg-changeops      AppDeployment Normal      InProgress  Succeeded
```

Lists all ChangeRecords in the specified resource group.

### Example 3: List all ChangeRecords in the current subscription
```powershell
Get-AzChangeSafetyChangeRecord
```

Lists all ChangeRecords across all resource groups in the current subscription.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity
Parameter Sets: GetViaIdentity1, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the ChangeRecord resource.

```yaml
Type: System.String
Parameter Sets: Get1, Get
Aliases: ChangeRecordName

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
Parameter Sets: Get1, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeSafetyIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ChangeSafety.Models.IChangeRecord

## NOTES

## RELATED LINKS
