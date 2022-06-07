---
external help file:
Module Name: Az.HealthcareApis
online version: https://docs.microsoft.com/powershell/module/az.healthcareapis/update-azhealthcareiotconnector
schema: 2.0.0
---

# Update-AzHealthcareIotConnector

## SYNOPSIS
Patch an IoT Connector.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzHealthcareIotConnector -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-IdentityType <ServiceManagedIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzHealthcareIotConnector -InputObject <IHealthcareApisIdentity>
 [-IdentityType <ServiceManagedIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Patch an IoT Connector.

## EXAMPLES

### Example 1: Patch an IoT Connector.
```powershell
Update-AzHealthcareIotConnector -Name azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Tag @{"123"="abc"}
```

```output
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus2  azpshcws/azpsiotconnector azps_test_group
```

Patch an IoT Connector.

### Example 2: Patch an IoT Connector.
```powershell
Get-AzHealthcareIotConnector -Name azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Update-AzHealthcareIotConnector -Tag @{"123"="abc"}
```

```output
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus2  azpshcws/azpsiotconnector azps_test_group
```

Patch an IoT Connector.

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

### -IdentityType
Type of identity being specified, currently SystemAssigned and None are allowed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.ServiceManagedIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

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
The name of IoT Connector resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: IotConnectorName

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
Resource tags.

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

### -WorkspaceName
The name of workspace resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IIotConnector

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

