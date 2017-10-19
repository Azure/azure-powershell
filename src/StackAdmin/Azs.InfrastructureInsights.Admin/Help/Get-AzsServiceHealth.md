---
external help file: Azs.InfrastructureInsights.Admin-help.xml
Module Name: Azs.InfrastructureInsights.Admin
online version: 
schema: 2.0.0
---

# Get-AzsServiceHealth

## SYNOPSIS
Get the health of services.

## SYNTAX

### ServiceHealths_List (Default)
```
Get-AzsServiceHealth [-Filter <String>] [-Skip <Int32>] -Location <String> [-Top <Int32>] [<CommonParameters>]
```

### ServiceHealths_Get
```
Get-AzsServiceHealth -Location <String> -ServiceHealth <String> [<CommonParameters>]
```

## DESCRIPTION
Get a list of all services health

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsServiceHealth -Location "local"

HealthState Type                                                                Name                                 InfraURI
----------- ----                                                                ----                                 --------
Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths 0a2df6d8-4570-4cf5-8c8f-8d96dc1fd2a9 /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.KeyVault.Admin/locations/local/infraRoles/Key Vault
Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths 12bf0da4-e310-4767-bc5f-5d31c0414062 /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Storage.Admin/farms/f1031738-a8c7-4528-99f2-b712b7...
Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths 2f2fc564-8714-41c3-89ea-ab7f9bf8483b /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Update.Admin/updateLocations/local/infraRoles/Updates
Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths 423f8608-0c64-4d87-8c07-811adfb7cc41 /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Compute.Admin/infraRoles/Compute
Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths 98751379-f9fe-4791-bc6f-f77eb1de3440 /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Network.Admin/infraRoles/Network
Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths bb58377f-3d7d-4d7f-b3b3-d433d422bf9e /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.InfrastructureInsights.Admin/regionHealths/local/i...
Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local/infraRoles/Capa...
```

Get all alerts at a location.

### Example 2
```
Get-AzsServiceHealth -Location local -ServiceHealth 98751379-f9fe-4791-bc6f-f77eb1de3440

HealthState Type                                                                Name                                 InfraURI                                                                                                                             RegistrationId
----------- ----                                                                ----                                 --------                                                                                                                             --------------
Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths 98751379-f9fe-4791-bc6f-f77eb1de3440 /subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Network.Admin/infraRoles/Network 98751379-f9fe-479...
```

Get an alert by name at a location.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: ServiceHealths_List
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location name.

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

### -ServiceHealth
Service Health name.

```yaml
Type: String
Parameter Sets: ServiceHealths_Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: ServiceHealths_List
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
Parameter Sets: ServiceHealths_List
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

### Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.ServiceHealth

## NOTES

## RELATED LINKS

