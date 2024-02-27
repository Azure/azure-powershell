---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefenderforserversgcpofferingobject
schema: 2.0.0
---

# New-AzSecurityDefenderForServersGcpOfferingObject

## SYNOPSIS
Create an in-memory object for DefenderForServersGcpOffering.

## SYNTAX

```
New-AzSecurityDefenderForServersGcpOfferingObject [-ArcAutoProvisioningEnabled <Boolean>]
 [-ConfigurationExclusionTag <IDefenderForServersGcpOfferingVMScannersConfigurationExclusionTags>]
 [-ConfigurationPrivateLinkScope <String>] [-ConfigurationProxy <String>] [-ConfigurationScanningMode <String>]
 [-ConfigurationType <String>] [-DefenderForServerServiceAccountEmailAddress <String>]
 [-DefenderForServerWorkloadIdentityProviderId <String>] [-MdeAutoProvisioningConfiguration <IAny>]
 [-MdeAutoProvisioningEnabled <Boolean>] [-SubPlanType <String>] [-VMScannerEnabled <Boolean>]
 [-VaAutoProvisioningEnabled <Boolean>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DefenderForServersGcpOffering.

## EXAMPLES

### EXAMPLE 1
```
$emailSuffix = "myproject.iam.gserviceaccount.com"
New-AzSecurityDefenderForServersGcpOfferingObject `
    -DefenderForServerServiceAccountEmailAddress "microsoft-defender-for-servers@$emailSuffix" -DefenderForServerWorkloadIdentityProviderId "defender-for-servers" `
    -ArcAutoProvisioningEnabled $true -MdeAutoProvisioningEnabled $true -VaAutoProvisioningEnabled $true -ConfigurationType TVM `
    -VMScannerEnabled $true -ConfigurationScanningMode Default `
    -SubPlanType P2
```

## PARAMETERS

### -ArcAutoProvisioningEnabled
Is arc auto provisioning enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationExclusionTag
VM tags that indicate that VM should not be scanned.
.

```yaml
Type: IDefenderForServersGcpOfferingVMScannersConfigurationExclusionTags
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
Type: String
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
Type: String
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
Type: String
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
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefenderForServerServiceAccountEmailAddress
The service account email address in GCP for this feature.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefenderForServerWorkloadIdentityProviderId
The workload identity provider id in GCP for this feature.

```yaml
Type: String
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
Type: IAny
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
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubPlanType
The available sub plans.

```yaml
Type: String
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
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMScannerEnabled
Is Microsoft Defender for Server VM scanning enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.DefenderForServersGcpOffering
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

CONFIGURATIONEXCLUSIONTAG \<IDefenderForServersGcpOfferingVMScannersConfigurationExclusionTags\>: VM tags that indicate that VM should not be scanned.
  \[(Any) \<String\>\]: This indicates any property can be added to this object.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefenderforserversgcpofferingobject](https://learn.microsoft.com/powershell/module/Az.Security/new-azsecuritydefenderforserversgcpofferingobject)

