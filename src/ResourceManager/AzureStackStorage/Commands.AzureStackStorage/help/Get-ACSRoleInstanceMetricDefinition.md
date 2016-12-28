---
external help file: Microsoft.AzureStack.Commands.StorageAdmin.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: F9338256-609C-4564-87D1-0D85AB2723BC
---

# Get-ACSRoleInstanceMetricDefinition

## SYNOPSIS
Gets metric definitions for a storage role instance.

## SYNTAX

```
Get-ACSRoleInstanceMetricDefinition [-FarmName] <String> [-RoleType] <RoleType> [-InstanceId] <String>
 [-MetricNames <String[]>] [-DetailedOutput] [[-SubscriptionId] <String>] [[-Token] <String>]
 [[-AdminUri] <Uri>] [-ResourceGroupName] <String> [-SkipCertificateValidation] [<CommonParameters>]
```

## DESCRIPTION
The **Get-ACSRoleInstanceMetricDefinition** cmdlet returns metric definitions for a storage role instance.
Metrics are usage information for a storage service component.
For example, you can retrieve information about the total number of requests made to a storage service component as well as information about the percentage of requests that were successfully filled.
Metric definitions provide you with information about the metrics available to you.

**Get-ACSRoleInstanceMetricDefinition** returns information about the metrics available for use with a storage service role instance, including such things as the metric name, the metric data type, and a brief definition of what the metric actually does.
For example, the definition for the TotalRequests metric tells you that the metric represents the total number of requests made to a storage service component.

**Get-ACSRoleInstanceMetricDefinition** only returns information about the metrics available for use.
To return the actual values, use the Get-ACSRoleInstanceMetric cmdlet.

## EXAMPLES

### Example 1: Get role instance metric definitions
```
PS C:\> Get-ACSRoleInstanceMetricDefinition -FarmName "ContosoFarm" -ResourceGroupName "ContosoResourceGroup" -InstanceID "TM_01" -RoleType "TableMaster"
```

This command returns metric definitions for the Table Master role associated with the storage farm ContosoFarm.

## PARAMETERS

### -FarmName
Specifies the name of the storage farm associated with the target role type.
For example:

`-FarmName "ContosoFarm01"`

A storage farm is a collection of storage resources that provides load balancing and redundancy.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RoleType
Specifies the storage service role type metric definitions are being returned for.

The acceptable values for this parameter are:

- TableServer 
- BlobServer 
- TableMaster 
- AccountContainerserver 
- TableFrontend 
- BlobFrontend 
- MetricsServer 
- HealthMonitoringserver

For example:

`-RoleType "TableFrontend"`

```yaml
Type: RoleType
Parameter Sets: (All)
Aliases: 

Required: True
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InstanceId
Specifies the role instance to be returned.
The InstanceId is required because it is possible for more than one VM to hold the same role: your deployment might have multiple table servers or multiple blob frontend servers.

For example:

`-InstanceId "TM_01"`

You can return InstanceIDs for all your storage server roles by using the Get-ACSRoleInstance cmdlet:

`Get-ACSRoleInstance`

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 6
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MetricNames
Specifies the names of the metric definitions to be returned.
For example:

`-MetricNames "TotalRequests"`

To specify multiple metrics, separate the metric names by using commas:

`-MetricNames "TotalRequests", "PercentSuccess"`

If this parameter is not included definitions are returned for all the available metrics.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
Specifies the Azure subscription ID.
For example:

`-SubscriptionID "81c87063-04a3-4abf-8e4c-736569bc1f60"`

This parameter is not required if you have configured your environment by using the **Set-AzureRmEnvironment** cmdlet.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Token
Specifies the authentication token for the service administrator.
This parameter is not required if you have configured your environment by using the **Set-AzureRmEnvironment** cmdlet.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AdminUri
Specifies the location of the Resource Manager endpoint.
If you configured your environment by using the Set-AzureRMEnvironment cmdlet, you do not have to specify this parameter.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group associated with the target storage role instance.
For example:

`-ResourceGroupName "ContosoResourceGroup"`

Resource groups categorize items to help simplify inventory management and overall Azure administration.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkipCertificateValidation
Indicates that the command proceeds without validating the Secure Sockets Layer (SSL) certificate.
By default, storage service commands require certification validation.

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

### -DetailedOutput
Indicates that complete information, including all the available metadata, is returned for each metric.
By default, **Get-ACSRoleInstanceDefinition** returns only a partial definition for each metric.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-ACSRoleInstance](./Get-ACSRoleInstance.md)

[Get-ACSRoleInstanceMetric](./Get-ACSRoleInstanceMetric.md)


