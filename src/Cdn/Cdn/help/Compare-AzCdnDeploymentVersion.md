---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/compare-azcdndeploymentversion
schema: 2.0.0
---

# Compare-AzCdnDeploymentVersion

## SYNOPSIS
Compare the deployment version to another deployment version

## SYNTAX

### CompareExpanded (Default)
```
Compare-AzCdnDeploymentVersion -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -VersionName <String> -CompareTo <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompareViaJsonString
```
Compare-AzCdnDeploymentVersion -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -VersionName <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompareViaJsonFilePath
```
Compare-AzCdnDeploymentVersion -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -VersionName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Compare
```
Compare-AzCdnDeploymentVersion -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -VersionName <String> -CompareDeploymentVersionsParameter <ICompareDeploymentVersionsParameter>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompareViaIdentityProfileExpanded
```
Compare-AzCdnDeploymentVersion -VersionName <String> -ProfileInputObject <ICdnIdentity> -CompareTo <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompareViaIdentityProfile
```
Compare-AzCdnDeploymentVersion -VersionName <String> -ProfileInputObject <ICdnIdentity>
 -CompareDeploymentVersionsParameter <ICompareDeploymentVersionsParameter> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompareViaIdentityExpanded
```
Compare-AzCdnDeploymentVersion -InputObject <ICdnIdentity> -CompareTo <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompareViaIdentity
```
Compare-AzCdnDeploymentVersion -InputObject <ICdnIdentity>
 -CompareDeploymentVersionsParameter <ICompareDeploymentVersionsParameter> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Compare the deployment version to another deployment version

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -CompareDeploymentVersionsParameter
compare deployment versions request parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICompareDeploymentVersionsParameter
Parameter Sets: Compare, CompareViaIdentityProfile, CompareViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CompareTo
the deployment version name to be compared to

```yaml
Type: System.String
Parameter Sets: CompareExpanded, CompareViaIdentityProfileExpanded, CompareViaIdentityExpanded
Aliases:

Required: True
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: CompareViaIdentityExpanded, CompareViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Compare operation

```yaml
Type: System.String
Parameter Sets: CompareViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Compare operation

```yaml
Type: System.String
Parameter Sets: CompareViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: CompareViaIdentityProfileExpanded, CompareViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium or CDN profile which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: CompareExpanded, CompareViaJsonString, CompareViaJsonFilePath, Compare
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CompareExpanded, CompareViaJsonString, CompareViaJsonFilePath, Compare
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: CompareExpanded, CompareViaJsonString, CompareViaJsonFilePath, Compare
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VersionName
Name of the DeploymentVersion under the profile.

```yaml
Type: System.String
Parameter Sets: CompareExpanded, CompareViaJsonString, CompareViaJsonFilePath, Compare, CompareViaIdentityProfileExpanded, CompareViaIdentityProfile
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICompareDeploymentVersionsParameter

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICompareDeploymentVersionsResponse

## NOTES

## RELATED LINKS
