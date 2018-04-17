---
external help file: Azs.InfrastructureInsights.Admin-help.xml
Module Name: Azs.InfrastructureInsights.Admin
online version: 
schema: 2.0.0
---

# Close-AzsAlert

## SYNOPSIS
Closes the given alert.

## SYNTAX

### Close
```
Close-AzsAlert -AlertId <String> [-User <String>] [-Location <String>] [-ResourceGroupName <String>]
 [<CommonParameters>]
```

### InputObject
```
Close-AzsAlert [-User <String>] -InputObject <Alert> [<CommonParameters>]
```

### ResourceId
```
Close-AzsAlert [-User <String>] -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Closes the given alert.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Close-AzsAlert -AlertId f2147f3d-42ac-4316-8cbc-f0f9c18888b0
```

ClosedTimestamp                : 03/08/2018 23:27:40
CreatedTimestamp               : 03/04/2018 05:21:00
Description                    : {System.Collections.Generic.Dictionary\`2\[System.String,System.String\]}
FaultId                        :
AlertId                        : f2147f3d-42ac-4316-8cbc-f0f9c18888b0
FaultTypeId                    : CertificateExpiration.ExternalCert.Critical
LastUpdatedTimestamp           : 03/08/2018 23:27:40
AlertProperties                : {}
Remediation                    : {System.Collections.Generic.Dictionary\`2\[System.String,System.String\],
                                 System.Collections.Generic.Dictionary\`2\[System.String,System.String\],
                                 System.Collections.Generic.Dictionary\`2\[System.String,System.String\],
                                 System.Collections.Generic.Dictionary\`2\[System.String,System.String\]...}
ResourceRegistrationId         :
ResourceProviderRegistrationId : e56bc7b8-c8b5-4e25-b00c-4f951effb22c
Severity                       : Critical
State                          : Closed
Title                          : Pending external certificate expiration
ImpactedResourceId             : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local/i
                                 nfraRoleInstances/AZS-GWY01
ImpactedResourceDisplayName    : AZS-GWY01
ClosedByUserAlias              : user@domain.onmicrosoft.com
Id                             : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/System.local/providers/Microsoft.InfrastructureInsights.Admin/regionH
                                 ealths/local/alerts/f2147f3d-42ac-4316-8cbc-f0f9c18888b0
Name                           : f2147f3d-42ac-4316-8cbc-f0f9c18888b0
Type                           : Microsoft.InfrastructureInsights.Admin/regionHealths/alerts
Location                       : local
Tags                           : {}

Close an alert by AlertId.

### -------------------------- EXAMPLE 2 --------------------------
```
Get-AzsAlert -Name f2147f3d-42ac-4316-8cbc-f0f9c18888b0 | Close-AzsAlert
```

ClosedTimestamp                : 03/08/2018 23:27:40
CreatedTimestamp               : 03/04/2018 05:21:00
Description                    : {System.Collections.Generic.Dictionary\`2\[System.String,System.String\]}
FaultId                        :
AlertId                        : f2147f3d-42ac-4316-8cbc-f0f9c18888b0
FaultTypeId                    : CertificateExpiration.ExternalCert.Critical
LastUpdatedTimestamp           : 03/08/2018 23:27:40
AlertProperties                : {}
Remediation                    : {System.Collections.Generic.Dictionary\`2\[System.String,System.String\],
                                 System.Collections.Generic.Dictionary\`2\[System.String,System.String\],
                                 System.Collections.Generic.Dictionary\`2\[System.String,System.String\],
                                 System.Collections.Generic.Dictionary\`2\[System.String,System.String\]...}
ResourceRegistrationId         :
ResourceProviderRegistrationId : e56bc7b8-c8b5-4e25-b00c-4f951effb22c
Severity                       : Critical
State                          : Closed
Title                          : Pending external certificate expiration
ImpactedResourceId             : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local/i
                                 nfraRoleInstances/AZS-GWY01
ImpactedResourceDisplayName    : AZS-GWY01
ClosedByUserAlias              : user@domain.onmicrosoft.com
Id                             : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/System.local/providers/Microsoft.InfrastructureInsights.Admin/regionH
                                 ealths/local/alerts/f2147f3d-42ac-4316-8cbc-f0f9c18888b0
Name                           : f2147f3d-42ac-4316-8cbc-f0f9c18888b0
Type                           : Microsoft.InfrastructureInsights.Admin/regionHealths/alerts
Location                       : local
Tags                           : {}

Close an alert through piping.

## PARAMETERS

### -AlertId
The alert identifier.

```yaml
Type: String
Parameter Sets: Close
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The input object of type Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.Alert.

```yaml
Type: Alert
Parameter Sets: InputObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Name of the location.

```yaml
Type: String
Parameter Sets: Close
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
{{Fill ResourceGroupName Description}}

```yaml
Type: String
Parameter Sets: Close
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -User
The username used to perform the operation.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.Alert

## NOTES

## RELATED LINKS

