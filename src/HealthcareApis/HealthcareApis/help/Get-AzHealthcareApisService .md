---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApisService.dll-Help.xml
Module Name: Az.HealthcareApis
online version: https://docs.microsoft.com/en-us/powershell/module/az.healthcareApis/new-azhealthcareapisservice
schema: 2.0.0
---
# Get-AzHealthcareApisService

## SYNOPSIS
Get the metadata of a service instance.

## SYNTAX

### ListParameterSet (Default)
```
Get-AzHealthCareService -SubscriptionId <String[]> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ListParameterSet_1
```
Get-AzHealthCareService -ResourceGroupName <String> -SubscriptionId <String[]>[-DefaultProfile <IAzureContextContainer>][<CommonParameters>]
```

### ServiceNameParameterSet
```
Get-AzHealthCareService -Name <String> -ResourceGroupName <String> -SubscriptionId <String[]> [-DefaultProfile <IAzureContextContainer>][<CommonParameters>]
```

###ResourceIdParameterSet
```
Get-AzHealthcareApisFhirService -ResourceId <String>  [-DefaultProfile <IAzureContextContainer>][<CommonParameters>]
```


## DESCRIPTION
Gets existing healthcareApis fhir service accounts created within the specified subscription or a resource group.

## EXAMPLES

### Example 1
Gets the metadata for a provided HealthcareApis service in the provided Resource Group.

```powershell
PS C:\> Get-AzHealthcareApisFhirService -Name MyService -ResourceGroupName MyResourceGroup

ResourceGroupName Name 
----------------- ----------- 
MyResourceGroup   MyService
```

Example Output:

ResourceId        : /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/MyResourceGroup/providers/Microsoft
                    .HealthcareApis/services/MyService
Name              : MyService
Location          : westus
Type              : Microsoft.HealthcareApis/services
Kind              : fhir-R4
Etag              : val
Tags              : {[key, val]}
Properties        : Microsoft.Azure.Commands.HealthcareApisService.Models.PSHealthcareApisFhirServiceConfig
SubscriptionId    : XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
ResourceGroupName : MyResourceGroupName

### Example 2

Gets the metadata for all HealthcareApis services in the provided Resource Group.

```powershell
PS C:\> Get-AzHealthcareApisFhirService -ResourceGroupName MyResourceGroup

ResourceGroupName 
----------------- 
MyResourceGroup
```

Example Output:

ResourceId        : /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/MyResourceGroup/providers/Microsoft
                    .HealthcareApis/services/MyService1
Name              : MyService1
Location          : westus
Type              : Microsoft.HealthcareApis/services
Kind              : fhir-R4
Etag              : val
Tags              : {[key, val]}
Properties        : Microsoft.Azure.Commands.HealthcareApisService.Models.PSHealthcareApisFhirServiceConfig
SubscriptionId    : XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
ResourceGroupName : MyResourceGroupName

ResourceId        : /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/MyResourceGroup/providers/Microsoft
                    .HealthcareApis/services/MyService2
Name              : MyService2
Location          : westus
Type              : Microsoft.HealthcareApis/services
Kind              : fhir-R4
Etag              : val
Tags              : {[key, val]}
Properties        : Microsoft.Azure.Commands.HealthcareApisService.Models.PSHealthcareApisFhirServiceConfig
SubscriptionId    : XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
ResourceGroupName : MyResourceGroupName

### Example 3


Gets the metadata for all HealthcareApis services in the given subscription

```powershell
PS C:\> Get-AzHealthcareApisFhirService 

ResourceGroupName 
----------------- 
MyResourceGroup
```

Example Output:

ResourceId        : /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/MyResourceGroup/providers/Microsoft
                    .HealthcareApis/services/MyService1
Name              : MyService1
Location          : westus
Type              : Microsoft.HealthcareApis/services
Kind              : fhir-R4
Etag              : val
Tags              : {[key, val]}
Properties        : Microsoft.Azure.Commands.HealthcareApisService.Models.PSHealthcareApisFhirServiceConfig
SubscriptionId    : XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
ResourceGroupName : MyResourceGroupName

ResourceId        : /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/MyResourceGroup/providers/Microsoft
                    .HealthcareApis/services/MyService2
Name              : MyService2
Location          : westus
Type              : Microsoft.HealthcareApis/services
Kind              : fhir-R4
Etag              : val
Tags              : {[key, val]}
Properties        : Microsoft.Azure.Commands.HealthcareApisService.Models.PSHealthcareApisFhirServiceConfig
SubscriptionId    : XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
ResourceGroupName : MyResourceGroupName


## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```


### -Name
The name of the service instance.

```yaml
Type: System.String
Parameter Sets: ServiceNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group that contains the service instance.

```yaml
Type: System.String
Parameter Sets: ListParameterSet_1, GetServiceNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceId
The resourceID of the service instance.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.HealthcareApisService.Models.PSHealthcareApisService

## NOTES

## RELATED LINKS

