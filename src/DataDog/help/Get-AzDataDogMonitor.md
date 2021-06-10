---
external help file:
Module Name: Az.DataDog
online version: https://docs.microsoft.com/powershell/module/az.datadog/get-azdatadogmonitor
schema: 2.0.0
---

# Get-AzDataDogMonitor

## SYNOPSIS
Get the properties of a specific monitor resource.

## SYNTAX

### List (Default)
```
Get-AzDataDogMonitor [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDataDogMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataDogMonitor -InputObject <IDataDogIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzDataDogMonitor -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the properties of a specific monitor resource.

## EXAMPLES

### Example 1: List all monitor resources under a subscription
```powershell
PS C:\> Get-AzDataDogMonitor

Location    Name         Type
--------    ----         ----
eastus2euap datadog microsoft.datadog/monitors
```

This command lists all monitor resources under a subscription.

### Example 2: List monitor resources under a resource group
```powershell
PS C:\> Get-AzDataDogMonitor -ResourceGroupName azure-rg-datadog

Location    Name         Type
--------    ----         ----
eastus2euap datadog microsoft.datadog/monitors
```

This command lists all monitor resources under a resource group.

### Example 3: Get the properties of a specific monitor resource
```powershell
PS C:\> Get-AzDataDogMonitor -ResourceGroupName azure-rg-datadog -Name datadog

Location    Name         Type
--------    ----         ----
eastus2euap datadog microsoft.datadog/monitors
```

This command gets the properties of a specific monitor resource.

### Example 4: Get the properties of a specific monitor resource by pipeline
```powershell
PS C:\> Get-AzDataDogMonitor -ResourceGroupName azure-rg-datadog -Name datadog | Get-AzDataDogMonitor

Location    Name         Type
--------    ----         ----
eastus2euap datadog microsoft.datadog/monitors
```

This command gets the properties of a specific monitor resource by pipeline.

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.IDataDogIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Monitor resource name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: MonitorName

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
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.IDataDogIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301.IDatadogMonitorResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataDogIdentity>: Identity Parameter
  - `[ConfigurationName <String>]`: Configuration name
  - `[Id <String>]`: Resource identity path
  - `[MonitorName <String>]`: Monitor resource name
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RuleSetName <String>]`: Rule set name
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

