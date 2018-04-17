---
external help file: Azs.InfrastructureInsights.Admin-help.xml
Module Name: Azs.InfrastructureInsights.Admin
online version: 
schema: 2.0.0
---

# Get-AzsAlert

## SYNOPSIS
Returns the list of all alerts in a given location.

## SYNTAX

### List (Default)
```
Get-AzsAlert [-Location <String>] [-ResourceGroupName <String>] [-Filter <String>] [-Top <Int32>]
 [-Skip <Int32>] [<CommonParameters>]
```

### Get
```
Get-AzsAlert [-AlertId] <String> [-Location <String>] [-ResourceGroupName <String>] [<CommonParameters>]
```

### ResourceId
```
Get-AzsAlert -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Returns the list of all alerts in a given location.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsAlert -Name 7f58eb8b-e39f-45d0-8ae7-9920b8f22f5f
```

ClosedTimestamp                :
CreatedTimestamp               : 03/04/2018 05:22:22
Description                    : {System.Collections.Generic.Dictionary\`2\[System.String,System.String\]}
FaultId                        :
AlertId                        : 7f58eb8b-e39f-45d0-8ae7-9920b8f22f5f
FaultTypeId                    : CertificateExpiration.ExternalCert.Critical
LastUpdatedTimestamp           : 03/08/2018 05:22:33
AlertProperties                : {}
Remediation                    : {System.Collections.Generic.Dictionary\`2\[System.String,System.String\],
                                 System.Collections.Generic.Dictionary\`2\[System.String,System.String\],
                                 System.Collections.Generic.Dictionary\`2\[System.String,System.String\],
                                 System.Collections.Generic.Dictionary\`2\[System.String,System.String\]...}
ResourceRegistrationId         :
ResourceProviderRegistrationId : e56bc7b8-c8b5-4e25-b00c-4f951effb22c
Severity                       : Critical
State                          : Active
Title                          : Pending external certificate expiration
ImpactedResourceId             : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local/i
                                 nfraRoleInstances/AZS-CA01
ImpactedResourceDisplayName    : AZS-CA01
ClosedByUserAlias              :
Id                             : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/System.local/providers/Microsoft.InfrastructureInsights.Admin/regionH
                                 ealths/local/alerts/7f58eb8b-e39f-45d0-8ae7-9920b8f22f5f
Name                           : 7f58eb8b-e39f-45d0-8ae7-9920b8f22f5f
Type                           : Microsoft.InfrastructureInsights.Admin/regionHealths/alerts
Location                       : local
Tags                           : {}

Get an alert by name.

### -------------------------- EXAMPLE 2 --------------------------
```
Get-AzsAlert | Where State -EQ 'active' | select FaultTypeId, Title
```

FaultTypeId                                 Title
-----------                                 -----
CertificateExpiration.ExternalCert.Critical Pending external certificate expiration
CertificateExpiration.ExternalCert.Critical Pending external certificate expiration

Get all active alerts and display their fault and title.

## PARAMETERS

### -AlertId
The alert identifier.

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Name of the location.

```yaml
Type: String
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: -1
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

