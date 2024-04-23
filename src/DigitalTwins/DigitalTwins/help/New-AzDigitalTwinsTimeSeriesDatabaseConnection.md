---
external help file: Az.DigitalTwins-help.xml
Module Name: Az.DigitalTwins
online version: https://learn.microsoft.com/powershell/module/az.digitaltwins/new-azdigitaltwinstimeseriesdatabaseconnection
schema: 2.0.0
---

# New-AzDigitalTwinsTimeSeriesDatabaseConnection

## SYNOPSIS
Create or update a time series database connection.

## SYNTAX

### Create (Default)
```
New-AzDigitalTwinsTimeSeriesDatabaseConnection -Name <String> -ResourceGroupName <String>
 -ResourceName <String> [-SubscriptionId <String>] -AdxDatabaseName <String> -AdxEndpointUri <String>
 -AdxResourceId <String> -AdxTableName <String> -EventHubEndpointUri <String> -EventHubEntityPath <String>
 -EventHubNamespaceResourceId <String>
 [-TimeSeriesDatabaseConnectionDescription <ITimeSeriesDatabaseConnection>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzDigitalTwinsTimeSeriesDatabaseConnection -InputObject <IDigitalTwinsIdentity> -AdxDatabaseName <String>
 -AdxEndpointUri <String> -AdxResourceId <String> -AdxTableName <String> -EventHubEndpointUri <String>
 -EventHubEntityPath <String> -EventHubNamespaceResourceId <String>
 [-TimeSeriesDatabaseConnectionDescription <ITimeSeriesDatabaseConnection>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create or update a time series database connection.

## EXAMPLES

### Example 1: Create or update a time series database connection.
```powershell
New-AzDigitalTwinsTimeSeriesDatabaseConnection -Name azps-tsdc -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -AdxDatabaseName "azpsadec1database" -AdxEndpointUri "https://azpsdataexplorer.eastus.kusto.windows.net" -AdxResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group/providers/Microsoft.Kusto/clusters/azpsdataexplorer" -AdxTableName "azpsadec1database-table" -EventHubEndpointUri "sb://azps-eventhubs.servicebus.windows.net/" -EventHubEntityPath "azps-eventhubs" -EventHubNamespaceResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group/providers/Microsoft.EventHub/namespaces/azps-eventhubs"
```

```output
Name      ConnectionType    ProvisioningState ResourceGroupName
----      --------------    ----------------- -----------------
azps-tsdc AzureDataExplorer Succeed            azps_test_group
```

Create or update a time series database connection.

## PARAMETERS

### -AdxDatabaseName
The name of the Azure Data Explorer database.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdxEndpointUri
The URI of the Azure Data Explorer endpoint.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdxResourceId
The resource ID of the Azure Data Explorer cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdxTableName
The name of the Azure Data Explorer table.
Defaults to AdtPropertyEvents.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -EventHubEndpointUri
The URL of the EventHub namespace for identity-based authentication.
It must include the protocol sb://

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventHubEntityPath
The EventHub name in the EventHub namespace for identity-based authentication.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventHubNamespaceResourceId
The resource ID of the EventHub namespace.

```yaml
Type: System.String
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity
Parameter Sets: CreateViaIdentity
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
Parameter Sets: Create
Aliases: TimeSeriesDatabaseConnectionName

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
Parameter Sets: Create
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
Parameter Sets: Create
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
Type: System.String
Parameter Sets: Create
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeSeriesDatabaseConnectionDescription
Describes a time series database connection resource.
To construct, see NOTES section for TIMESERIESDATABASECONNECTIONDESCRIPTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20220531.ITimeSeriesDatabaseConnection
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20220531.ITimeSeriesDatabaseConnection

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20220531.ITimeSeriesDatabaseConnection

## NOTES

## RELATED LINKS
