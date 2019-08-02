---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.dll-Help.xml
Module Name: Az.HealthcareApis
online version: https://docs.microsoft.com/en-us/powershell/module/az.healthcareApis/new-azhealthcareapisfhirservice
schema: 2.0.0
---
# New-AzHealthCaresFhirService

## SYNOPSIS
Creates the metadata of a service instance.

## SYNTAX

###FhirParameterSet
```
New-AzHealthCareApisService -Name <String> -ResourceGroupName <String> -Location <String> [-CosmosOfferThroughput <Integer>][-Authority <String>] [-Audience <String>] [-EnableSmartProxy][-CorsOrigin <String []>] [-CorsHeader <String[]>] [-CorsMethod <String[]>] [-CorsMaxAge <Integer>] [-AllowCorsCredentials][-AccessPolicyObjectId <String[]>][-Tag <Hashtable>] [-FhirVersion <String>] [-DefaultProfile <IAzureContextContainer>][-AsJob] [-NoWait][-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the metadata of a service instance.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzHealthCareApisService -Name MyService -ResourceGroupName MyResourceGroup -Location MyLocation -CosmosOfferThroughput  MyOfferThroughput

ResourceGroupName Name Location       CosmosOfferThroughput
----------------- ----------- -------------------------------
MyResourceGroup   MyService   westus2       400
```

Creates a new Azure healthcareapis fhir service named MyService in the resource group MyResourceGroup in a location westus2 with cosmosdb offer throughput = 400

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


## PARAMETERS

### -AccessPolicy
The access policies of the service instance.
To construct, see NOTES section for ACCESSPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthCare.Models.IServiceAccessPolicyEntry[]
Parameter Sets:(All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AllowCorsCredentials
If credentials are allowed via CORS.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Audience
The audience url for the service

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Authority
The authority url for the service

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -CorsHeader
The headers to be allowed via CORS.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CorsMaxAge
The max age to be allowed via CORS.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CorsMethod
The methods to be allowed via CORS.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CorsOrigin
The origins to be allowed via CORS.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CosmoDbOfferThroughput
The provisioned throughput for the backing database.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```


### -Fhir-Version
Version of HealthcareApis Fhir Service. Valid values are Stu3, R4.
```yaml
Type: system.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of HealthcareApis Service. Valid values are fhir, fhir-Stu3. fhir-R4
```yaml
Type: system.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```


### -Location
The resource location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group that contains the service instance.

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

### -Tag
The resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).
## INPUTS

### System.String
### Microsoft.Azure.PowerShell.Cmdlets.HealthCare.Models.PSHealthcareApisService

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HealthCare.Models.PSHealthcareApisService

## NOTES

## RELATED LINKS

