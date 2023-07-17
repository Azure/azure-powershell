---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.spring/get-azspringmonitoringsetting
schema: 2.0.0
---

# Get-AzSpringMonitoringSetting

## SYNOPSIS
Get the Monitoring Setting and its properties.

## SYNTAX

### Get (Default)
```
Get-AzSpringMonitoringSetting -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringMonitoringSetting -InputObject <ISpringIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the Monitoring Setting and its properties.

## EXAMPLES

### Example 1: Get the Monitoring Setting and its properties
```powershell
Get-AzSpringMonitoringSetting -ResourceGroupName Spring-gp-junxi -Name Spring-service
```

```output
Name    ResourceGroupName ProvisioningState TraceEnabled
----    ----------------- ----------------- ------------
default azurespringrg     Succeeded         True
```

Get the Monitoring Setting and its properties.

### Example 2: Get the Monitoring Setting and its properties by pipeline
```powershell
 Update-AzSpringMonitoringSetting -AppInsightsInstrumentationKey "InstrumentationKey=xxxxxxxxxxxxxxxxxxx;IngestionEndpoint=https://xxxxxx.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/" | Get-AzSpringMonitoringSetting
```

```output
Name    ResourceGroupName ProvisioningState TraceEnabled
----    ----------------- ----------------- ------------
default azurespringrg     Succeeded         True
```

Get the Monitoring Setting and its properties by pipeline.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Service resource.

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
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

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
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IMonitoringSettingResource

## NOTES

## RELATED LINKS

