---
external help file:
Module Name: Az.HealthcareApis
online version: https://docs.microsoft.com/powershell/module/az.healthcareapis/update-azhealthcareapisservice
schema: 2.0.0
---

# Update-AzHealthcareApisService

## SYNOPSIS
Update the metadata of a service instance.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzHealthcareApisService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzHealthcareApisService -InputObject <IHealthcareApisIdentity>
 [-PublicNetworkAccess <PublicNetworkAccess>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the metadata of a service instance.

## EXAMPLES

### Example 1: Update the metadata of a service instance.
```powershell
Update-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice -Tag @{"abc"="123"}
```

```output
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Update the metadata of a service instance.

### Example 2: Update the metadata of a service instance.
```powershell
Get-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice | Update-AzHealthcareApisService -Tag @{"abc"="123"}
```

```output
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Update the metadata of a service instance.

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IHealthcareApisIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the service instance.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

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

### -PublicNetworkAccess
Control permission for data plane traffic coming from public networks while private endpoint is enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.PublicNetworkAccess
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the service instance.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Instance tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IHealthcareApisIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IServicesDescription

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IHealthcareApisIdentity>`: Identity Parameter
  - `[DicomServiceName <String>]`: The name of DICOM Service resource.
  - `[FhirDestinationName <String>]`: The name of IoT Connector FHIR destination resource.
  - `[FhirServiceName <String>]`: The name of FHIR Service resource.
  - `[GroupName <String>]`: The name of the private link resource group.
  - `[Id <String>]`: Resource identity path
  - `[IotConnectorName <String>]`: The name of IoT Connector resource.
  - `[LocationName <String>]`: The location of the operation.
  - `[OperationResultId <String>]`: The ID of the operation result to get.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection associated with the Azure resource
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the service instance.
  - `[ResourceName <String>]`: The name of the service instance.
  - `[SubscriptionId <String>]`: The subscription identifier.
  - `[WorkspaceName <String>]`: The name of workspace resource.

## RELATED LINKS

