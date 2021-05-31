---
external help file:
Module Name: DataDog
online version: https://docs.microsoft.com/powershell/module/datadog/get-azdatadogsinglesignonconfiguration
schema: 2.0.0
---

# Get-AzDataDogSingleSignOnConfiguration

## SYNOPSIS
Gets the datadog single sign-on resource for the given Monitor.

## SYNTAX

### List (Default)
```
Get-AzDataDogSingleSignOnConfiguration -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDataDogSingleSignOnConfiguration -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataDogSingleSignOnConfiguration -InputObject <IDataDogIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the datadog single sign-on resource for the given Monitor.

## EXAMPLES

### Example 1: List the datadog single sign-on resource for the given Monitor
```powershell
PS C:\> Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName lucas-dog -MonitorName lucasdatadog

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

This command lists the datadog single sign-on resource for the given Monitor.

### Example 2: Gets the datadog single sign-on resource for the given Monitor
```powershell
PS C:\> Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName lucas-dog -MonitorName lucasdatadog -Name 'default'

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

This command gets the datadog single sign-on resource for the given Monitor.

### Example 3: Gets the datadog single sign-on resource for the given Monitor by pipeline
```powershell
PS C:\> Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName lucas-dog -MonitorName lucasdatadog -Name 'default' | Get-AzDataDogSingleSignOnConfiguration

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

This command gets the datadog single sign-on resource for the given Monitor by pipeline.

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

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Configuration name

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.IDataDogIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301.IDatadogSingleSignOnResource

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

