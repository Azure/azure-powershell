---
external help file: Az.DigitalTwins-help.xml
Module Name: Az.DigitalTwins
online version: https://learn.microsoft.com/powershell/module/az.digitaltwins/get-azdigitaltwinstimeseriesdatabaseconnection
schema: 2.0.0
---

# Get-AzDigitalTwinsTimeSeriesDatabaseConnection

## SYNOPSIS
Get the description of an existing time series database connection.

## SYNTAX

### List (Default)
```
Get-AzDigitalTwinsTimeSeriesDatabaseConnection -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzDigitalTwinsTimeSeriesDatabaseConnection -Name <String> -ResourceGroupName <String>
 -ResourceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDigitalTwinsTimeSeriesDatabaseConnection -InputObject <IDigitalTwinsIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get the description of an existing time series database connection.

## EXAMPLES

### Example 1: List description of an existing time series database connection.
```powershell
Get-AzDigitalTwinsTimeSeriesDatabaseConnection -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance
```

```output
Name      ConnectionType    ProvisioningState ResourceGroupName
----      --------------    ----------------- -----------------
azps-tsdc AzureDataExplorer Succeed            azps_test_group
```

List description of an existing time series database connection.

### Example 2: Get the description of an existing time series database connection.
```powershell
Get-AzDigitalTwinsTimeSeriesDatabaseConnection -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -Name azps-tsdc
```

```output
Name      ConnectionType    ProvisioningState ResourceGroupName
----      --------------    ----------------- -----------------
azps-tsdc AzureDataExplorer Succeed            azps_test_group
```

Get the description of an existing time series database connection.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of time series database connection.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: TimeSeriesDatabaseConnectionName

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
The name of the resource group that contains the DigitalTwinsInstance.

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

### -ResourceName
The name of the DigitalTwinsInstance.

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
The subscription identifier.

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

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20220531.ITimeSeriesDatabaseConnection

## NOTES

## RELATED LINKS
