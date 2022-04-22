---
external help file:
Module Name: Az.DataBox
online version: https://docs.microsoft.com/en-us/powershell/module/az.databox/invoke-azdataboxmarkjobdeviceshipped
schema: 2.0.0
---

# Invoke-AzDataBoxMarkJobDeviceShipped

## SYNOPSIS
Request to mark devices for a given job as shipped

## SYNTAX

### MarkExpanded (Default)
```
Invoke-AzDataBoxMarkJobDeviceShipped -JobName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DeliverToDcPackageDetailCarrierName <String>] [-DeliverToDcPackageDetailTrackingId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Mark
```
Invoke-AzDataBoxMarkJobDeviceShipped -JobName <String> -ResourceGroupName <String>
 -MarkDevicesShippedRequest <IMarkDevicesShippedRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MarkViaIdentity
```
Invoke-AzDataBoxMarkJobDeviceShipped -InputObject <IDataBoxIdentity>
 -MarkDevicesShippedRequest <IMarkDevicesShippedRequest> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### MarkViaIdentityExpanded
```
Invoke-AzDataBoxMarkJobDeviceShipped -InputObject <IDataBoxIdentity>
 [-DeliverToDcPackageDetailCarrierName <String>] [-DeliverToDcPackageDetailTrackingId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Request to mark devices for a given job as shipped

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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

### -DeliverToDcPackageDetailCarrierName
Name of the carrier.

```yaml
Type: System.String
Parameter Sets: MarkExpanded, MarkViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeliverToDcPackageDetailTrackingId
Tracking Id of shipment.

```yaml
Type: System.String
Parameter Sets: MarkExpanded, MarkViaIdentityExpanded
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataBoxIdentity
Parameter Sets: MarkViaIdentity, MarkViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobName
The name of the job Resource within the specified resource group.
job names must be between 3 and 24 characters in length and use any alphanumeric and underscore only

```yaml
Type: System.String
Parameter Sets: Mark, MarkExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarkDevicesShippedRequest
The request body to provide the delivery package details of job
To construct, see NOTES section for MARKDEVICESSHIPPEDREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IMarkDevicesShippedRequest
Parameter Sets: Mark, MarkViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -ResourceGroupName
The Resource Group Name

```yaml
Type: System.String
Parameter Sets: Mark, MarkExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Subscription Id

```yaml
Type: System.String
Parameter Sets: Mark, MarkExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IMarkDevicesShippedRequest

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataBoxIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataBoxIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[JobName <String>]`: The name of the job Resource within the specified resource group. job names must be between 3 and 24 characters in length and use any alphanumeric and underscore only
  - `[Location <String>]`: The location of the resource
  - `[ResourceGroupName <String>]`: The Resource Group Name
  - `[SubscriptionId <String>]`: The Subscription Id

MARKDEVICESSHIPPEDREQUEST <IMarkDevicesShippedRequest>: The request body to provide the delivery package details of job
  - `[DeliverToDcPackageDetailCarrierName <String>]`: Name of the carrier.
  - `[DeliverToDcPackageDetailTrackingId <String>]`: Tracking Id of shipment.

## RELATED LINKS

