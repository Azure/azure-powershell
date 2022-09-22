---
external help file:
Module Name: Az.HealthcareApis
online version: https://docs.microsoft.com/powershell/module/az.healthcareapis/get-azhealthcareapisservice
schema: 2.0.0
---

# Get-AzHealthcareApisService

## SYNOPSIS
Get the metadata of a service instance.

## SYNTAX

### List (Default)
```
Get-AzHealthcareApisService [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzHealthcareApisService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHealthcareApisService -InputObject <IHealthcareApisIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzHealthcareApisService -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the metadata of a service instance.

## EXAMPLES

### Example 1: List the metadata of service instance.
```powershell
Get-AzHealthcareApisService
```

```output
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

List the metadata of service instance.

### Example 2: List the metadata of service instance by resource group.
```powershell
Get-AzHealthcareApisService -ResourceGroupName azps_test_group
```

```output
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

List the metadata of service instance by resource group.

### Example 3: Get the metadata of a service instance.
```powershell
Get-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice
```

```output
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Get the metadata of a service instance.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IHealthcareApisIdentity
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the service instance.

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
The subscription identifier.

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

### Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IHealthcareApisIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IServicesDescription

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IHealthcareApisIdentity>: Identity Parameter
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

