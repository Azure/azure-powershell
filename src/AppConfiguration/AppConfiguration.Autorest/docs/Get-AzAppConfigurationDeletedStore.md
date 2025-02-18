---
external help file:
Module Name: Az.AppConfiguration
online version: https://learn.microsoft.com/powershell/module/az.appconfiguration/get-azappconfigurationdeletedstore
schema: 2.0.0
---

# Get-AzAppConfigurationDeletedStore

## SYNOPSIS
Gets a deleted Azure app configuration store.

## SYNTAX

### List (Default)
```
Get-AzAppConfigurationDeletedStore [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzAppConfigurationDeletedStore -Location <String> -Name <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAppConfigurationDeletedStore -InputObject <IAppConfigurationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a deleted Azure app configuration store.

## EXAMPLES

### Example 1: Gets a deleted Azure app configuration store.
```powershell
Remove-AzAppConfigurationStore -Name azpstestappstore -ResourceGroupName azpstest-gp
Get-AzAppConfigurationDeletedStore
```

```output
Name             ResourceGroupName
----             -----------------
azpstestappstore
```

Gets a deleted Azure app configuration store.

### Example 2: Gets a deleted Azure app configuration store.
```powershell
Remove-AzAppConfigurationStore -Name azpstestappstore -ResourceGroupName azpstest-gp
Get-AzAppConfigurationDeletedStore -Location eastus -Name azpstestappstore
```

```output
Name             ResourceGroupName
----             -----------------
azpstestappstore
```

Gets a deleted Azure app configuration store.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IAppConfigurationIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The location in which uniqueness will be verified.

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

### -Name
The name of the configuration store.

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

### -SubscriptionId
The Microsoft Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IAppConfigurationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20220501.IDeletedConfigurationStore

## NOTES

## RELATED LINKS

