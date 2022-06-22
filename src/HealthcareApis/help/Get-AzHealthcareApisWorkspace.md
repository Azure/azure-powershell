---
external help file:
Module Name: Az.HealthcareApis
online version: https://docs.microsoft.com/powershell/module/az.healthcareapis/get-azhealthcareapisworkspace
schema: 2.0.0
---

# Get-AzHealthcareApisWorkspace

## SYNOPSIS
Gets the properties of the specified workspace.

## SYNTAX

### List (Default)
```
Get-AzHealthcareApisWorkspace [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzHealthcareApisWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHealthcareApisWorkspace -InputObject <IHealthcareApisIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzHealthcareApisWorkspace -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the properties of the specified workspace.

## EXAMPLES

### Example 1: List the properties.
```powershell
Get-AzHealthcareApisWorkspace
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus2  azpshcws   azps_test_group
eastus2  azpshcws02 azps_test_group
```

List the properties.

### Example 2: Gets the properties of the specified workspace.
```powershell
Get-AzHealthcareApisWorkspace -Name azpshcws -ResourceGroupName azps_test_group
```

```output
Location Name     ResourceGroupName
-------- ----     -----------------
eastus2  azpshcws azps_test_group
```

Gets the properties of the specified workspace.

### Example 3: List the properties of the resource group.
```powershell
Get-AzHealthcareApisWorkspace -ResourceGroupName azps_test_group
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus2  azpshcws   azps_test_group
eastus2  azpshcws02 azps_test_group
```

List the properties of the specified resource group.

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
The name of workspace resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: WorkspaceName

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

### Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IWorkspace

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

