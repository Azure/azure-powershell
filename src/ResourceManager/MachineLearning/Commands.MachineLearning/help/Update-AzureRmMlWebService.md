---
external help file: Microsoft.Azure.Commands.MachineLearning.dll-Help.xml
online version: 
schema: 2.0.0
---

# Update-AzureRmMlWebService

## SYNOPSIS
Updates properties of an existing web service resource.

## SYNTAX

### Update specific properties of the .
```
Update-AzureRmMlWebService -ResourceGroupName <String> -Name <String> [-Title <String>] [-Description <String>]
 [-IsReadOnly] [-Keys <WebServiceKeys>] [-StorageAccountKey <String>] [-Diagnostics <DiagnosticsConfiguration>]
 [-RealtimeConfiguration <RealtimeConfiguration>] [-Assets <Hashtable>]
 [-Input <ServiceInputOutputSpecification>] [-Output <ServiceInputOutputSpecification>]
 [-Parameters <Hashtable>] [-Package <GraphPackage>] [-Force] [-WhatIf] [-Confirm]
```

### Create a new Azure ML webservice from a WebService instance definition.
```
Update-AzureRmMlWebService -ResourceGroupName <String> -Name <String> -ServiceUpdates <WebService> [-Force]
 [-WhatIf] [-Confirm]
```

## DESCRIPTION
The Update-AzureRmMlWebService cmdlet allows you to update the non-static properties of a web service.
The cmdlet works as a patch operation.
Pass only the properties that you want modified.

## EXAMPLES

### --------------------------  Example 1: Selective update arguments  --------------------------
@{paragraph=PS C:\\\>}

```
Update-AzureRmMlWebService -ResourceGroupName "myresourcegroup" -Name "mywebservicename" -Description "new update to description" -Keys @{Primary='changed primary key'} -Diagnostics @{Level='All'}
```

Here, we change the description, primary access key and enable the diagnostics collection for all traces during runtime for the web service.

### --------------------------  Example 2: Update based on a web service instance  --------------------------
@{paragraph=PS C:\\\>}

```
$updates = @{ Properties = @{ Title="New Title"; RealtimeConfiguration = @{ MaxConcurrentCalls=25 }}}

Update-AzureRmMlWebService -ResourceGroupName "myresourcegroup" -Name "mywebservicename" -ServiceUpdates $updates
```

The example first creates a web service definition, that only contains the fields to be updated, and then calls the Update-AzureRmMlWebService to apply them using the ServiceUpdates parameter.

## PARAMETERS

### -Assets
The set of assets (e.g. modules, datasets) that make up the web service.

```yaml
Type: Hashtable
Parameter Sets: Update specific properties of the web service.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The new value for the web service's description.
This is visible in the service's Swagger API schema.

```yaml
Type: String
Parameter Sets: Update specific properties of the web service.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Diagnostics
The settings that control the diagnostics traces collection for the web service.

```yaml
Type: DiagnosticsConfiguration
Parameter Sets: Update specific properties of the web service.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Input
The definition for the web service's input(s), provided as a Swagger schema construct.

```yaml
Type: ServiceInputOutputSpecification
Parameter Sets: Update specific properties of the .
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsReadOnly
Specifies that this web serviceis readonly.
Once set, the web service can longer be updated, including changing the value of this property, and can only be deleted.

```yaml
Type: SwitchParameter
Parameter Sets: Update specific properties of the .
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Keys
Updates one or both of the access keys used to authenticate calls to the service's runtime APIs.

```yaml
Type: WebServiceKeys
Parameter Sets: Update specific properties of the .
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the web service resource to be updated.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Output
The definition for the web service's output(s), provided as a Swagger schema construct.

```yaml
Type: ServiceInputOutputSpecification
Parameter Sets: Update specific properties of the .
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Package
The definition of the graph package that defines this web service.

```yaml
Type: GraphPackage
Parameter Sets: Update specific properties of the .
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameters
The set of global parameters values defined for the web service, given as a global parameter name -\> default value collection.
If no default value is specified, the parameter is considered to be required.

```yaml
Type: Hashtable
Parameter Sets: Update specific properties of the .
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RealtimeConfiguration
Updates for the configuration of the service's realtime endpoint.

```yaml
Type: RealtimeConfiguration
Parameter Sets: Update specific properties of the .
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group that contains the web service to be updated.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceUpdates
A set of updates to apply to the web service provided as a web service definition instance.
Only non-static fields are modified.

```yaml
Type: WebService
Parameter Sets: Create a new Azure ML webservice from a WebService instance definition.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageAccountKey
Rotates the access key for the storage account associated with the web service.

```yaml
Type: String
Parameter Sets: Update specific properties of the .
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Title
The new value for the web service's title.
This is visible in the service's Swagger API schema.

```yaml
Type: String
Parameter Sets: Update specific properties of the .
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
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

## OUTPUTS

### Microsoft.Azure.Management.MachineLearning.WebServices.Models.WebService
A summary description of the Azure Machine Learning web service.
Similar to the description returned by calling the Get-AzureRmMlWebService cmdlet on an existing web service.
This description does not contain sensitive properties such as storage account's credentials and the service's access keys.

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, machine, machine learning, azureml

## RELATED LINKS

