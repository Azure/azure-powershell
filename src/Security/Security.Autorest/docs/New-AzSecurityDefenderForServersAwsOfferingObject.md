---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefenderforserversawsofferingobject
schema: 2.0.0
---

# New-AzSecurityDefenderForServersAwsOfferingObject

## SYNOPSIS
Create an in-memory object for DefenderForServersAwsOffering.

## SYNTAX

```
New-AzSecurityDefenderForServersAwsOfferingObject [-ArcAutoProvisioningCloudRoleArn <String>]
 [-ArcAutoProvisioningEnabled <Boolean>] [-ConfigurationCloudRoleArn <String>]
 [-ConfigurationExclusionTag <IDefenderForServersAwsOfferingVMScannersConfigurationExclusionTags>]
 [-ConfigurationPrivateLinkScope <String>] [-ConfigurationProxy <String>]
 [-ConfigurationScanningMode <String>] [-ConfigurationType <String>] [-DefenderForServerCloudRoleArn <String>]
 [-MdeAutoProvisioningConfiguration <IAny>] [-MdeAutoProvisioningEnabled <Boolean>] [-SubPlanType <String>]
 [-VaAutoProvisioningEnabled <Boolean>] [-VMScannerEnabled <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DefenderForServersAwsOffering.

## EXAMPLES

### Example 1: Create new DefenderForServersAwsOffering object
```powershell
$arnPrefix = "arn:aws:iam::123456789012:role"
New-AzSecurityDefenderForServersAwsOfferingObject `
    -DefenderForServerCloudRoleArn "$arnPrefix/DefenderForCloud-DefenderForServers" `
    -ArcAutoProvisioningEnabled $true -ArcAutoProvisioningCloudRoleArn "$arnPrefix/DefenderForCloud-ArcAutoProvisioning" `
    -MdeAutoProvisioningEnabled $true `
    -VaAutoProvisioningEnabled $true -ConfigurationType TVM `
    -VMScannerEnabled $true -ConfigurationCloudRoleArn "$arnPrefix/DefenderForCloud-AgentlessScanner" -ConfigurationScanningMode Default `
    -SubPlanType P2
```

```output
ArcAutoProvisioningCloudRoleArn  : arn:aws:iam::123456789012:role/DefenderForCloud-ArcAutoProvisioning
ArcAutoProvisioningEnabled       : True
ConfigurationCloudRoleArn        : arn:aws:iam::123456789012:role/DefenderForCloud-AgentlessScanner
ConfigurationExclusionTag        : {
                                   }
ConfigurationPrivateLinkScope    : 
ConfigurationProxy               : 
ConfigurationScanningMode        : Default
ConfigurationType                : TVM
DefenderForServerCloudRoleArn    : arn:aws:iam::123456789012:role/DefenderForCloud-DefenderForServers
Description                      : 
MdeAutoProvisioningConfiguration : {
                                   }
MdeAutoProvisioningEnabled       : True
OfferingType                     : DefenderForServersAws
SubPlanType                      : P2
VMScannerEnabled                 : True
VaAutoProvisioningEnabled        : True
```



## PARAMETERS

### -ArcAutoProvisioningCloudRoleArn
The cloud role ARN in AWS for this feature.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArcAutoProvisioningEnabled
Is arc auto provisioning enabled.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationCloudRoleArn
The cloud role ARN in AWS for this feature.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationExclusionTag
VM tags that indicates that VM should not be scanned.
To construct, see NOTES section for CONFIGURATIONEXCLUSIONTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IDefenderForServersAwsOfferingVMScannersConfigurationExclusionTags
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationPrivateLinkScope
Optional Arc private link scope resource id to link the Arc agent.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationProxy
Optional HTTP proxy endpoint to use for the Arc agent.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationScanningMode
The scanning mode for the VM scan.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationType
The Vulnerability Assessment solution to be provisioned.
Can be either 'TVM' or 'Qualys'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefenderForServerCloudRoleArn
The cloud role ARN in AWS for this feature.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MdeAutoProvisioningConfiguration
configuration for Microsoft Defender for Endpoint autoprovisioning.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAny
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MdeAutoProvisioningEnabled
Is Microsoft Defender for Endpoint auto provisioning enabled.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubPlanType
The available sub plans.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaAutoProvisioningEnabled
Is Vulnerability Assessment auto provisioning enabled.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMScannerEnabled
Is Microsoft Defender for Server VM scanning enabled.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.DefenderForServersAwsOffering

## NOTES

## RELATED LINKS

