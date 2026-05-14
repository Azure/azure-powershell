---
external help file:
Module Name: Az.HealthcareApis
online version: https://learn.microsoft.com/powershell/module/az.healthcareapis/new-azhealthcareiotconnectorfhirdestination
schema: 2.0.0
---

# New-AzHealthcareIotConnectorFhirDestination

## SYNOPSIS
Creates or updates an IoT Connector FHIR destination resource with the specified parameters.

## SYNTAX

### CreateExpanded (Default)
```
New-AzHealthcareIotConnectorFhirDestination -FhirDestinationName <String> -IotConnectorName <String>
 -ResourceGroupName <String> -WorkspaceName <String> -FhirMappingContent <Hashtable>
 -FhirServiceResourceId <String> -Location <String> -ResourceIdentityResolutionType <String>
 [-SubscriptionId <String>] [-Etag <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityIotconnectorExpanded
```
New-AzHealthcareIotConnectorFhirDestination -FhirDestinationName <String>
 -IotconnectorInputObject <IHealthcareApisIdentity> -FhirMappingContent <Hashtable>
 -FhirServiceResourceId <String> -Location <String> -ResourceIdentityResolutionType <String> [-Etag <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityWorkspaceExpanded
```
New-AzHealthcareIotConnectorFhirDestination -FhirDestinationName <String> -IotConnectorName <String>
 -WorkspaceInputObject <IHealthcareApisIdentity> -FhirMappingContent <Hashtable>
 -FhirServiceResourceId <String> -Location <String> -ResourceIdentityResolutionType <String> [-Etag <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzHealthcareIotConnectorFhirDestination -FhirDestinationName <String> -IotConnectorName <String>
 -ResourceGroupName <String> -WorkspaceName <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzHealthcareIotConnectorFhirDestination -FhirDestinationName <String> -IotConnectorName <String>
 -ResourceGroupName <String> -WorkspaceName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an IoT Connector FHIR destination resource with the specified parameters.

## EXAMPLES

### Example 1: Creates or updates an IoT Connector FHIR destination resource with the specified parameters.
```powershell
$arr = @()
New-AzHealthcareIotConnectorFhirDestination -FhirDestinationName azpsfhirdestination -IotConnectorName azpsiotconnector -ResourceGroupName azps_test_group -WorkspaceName azpshcws -FhirServiceResourceId "/subscriptions/{SubscriptionId}/resourceGroups/azps_test_group/providers/Microsoft.HealthcareApis/workspaces/azpshcws/fhirservices/azpsfhirservice" -ResourceIdentityResolutionType 'Create' -Location eastus2 -FhirMappingContent @{"templateType"="CollectionFhirTemplate";"template"=$arr}
```

```output
Location Name                                          ResourceGroupName
-------- ----                                          -----------------
eastus2  azpshcws/azpsiotconnector/azpsfhirdestination azps_test_group
```

Creates or updates an IoT Connector FHIR destination resource with the specified parameters.

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

### -Etag
An etag associated with the resource, used for optimistic concurrency when editing it.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityIotconnectorExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FhirDestinationName
The name of IoT Connector FHIR destination resource.

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

### -FhirMappingContent
The mapping.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityIotconnectorExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FhirServiceResourceId
Fully qualified resource id of the FHIR service to connect to.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityIotconnectorExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IotconnectorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IHealthcareApisIdentity
Parameter Sets: CreateViaIdentityIotconnectorExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IotConnectorName
The name of IoT Connector resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityIotconnectorExpanded, CreateViaIdentityWorkspaceExpanded
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

### -ResourceGroupName
The name of the resource group that contains the service instance.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceIdentityResolutionType
Determines how resource identity is resolved on the destination.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityIotconnectorExpanded, CreateViaIdentityWorkspaceExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IHealthcareApisIdentity
Parameter Sets: CreateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
The name of workspace resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IIotFhirDestination

## NOTES

## RELATED LINKS

