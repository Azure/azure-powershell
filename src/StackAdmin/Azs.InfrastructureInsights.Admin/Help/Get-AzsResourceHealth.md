---
external help file: Azs.InfrastructureInsights.Admin-help.xml
Module Name: Azs.InfrastructureInsights.Admin
online version: 
schema: 2.0.0
---

# Get-AzsResourceHealth

## SYNOPSIS
Get the health for resources under a service.

## SYNTAX

### ResourceHealths_List (Default)
```
Get-AzsResourceHealth -ServiceRegistrationId <String> [-Filter <String>] [-Skip <Int32>] -Location <String>
 [-Top <Int32>] [<CommonParameters>]
```

### ResourceHealths_Get
```
Get-AzsResourceHealth -ServiceRegistrationId <String> [-Filter <String>] -ResourceRegistrationId <String>
 -Location <String> [<CommonParameters>]
```

## DESCRIPTION
Get a list of resources?.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsResourceHealth -Location local -ServiceRegistrationId e56bc7b8-c8b5-4e25-b00c-4f951effb22c

ResourceType HealthState Type                                                                                RpRegistrationId                     Name
------------ ----------- ----                                                                                ----------------                     ----
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 0414499b-2f9a-486d-88bb-d8573e1510ec
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 184b3d84-68c9-46b3-81e6-bab21b92c1c5
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 2df06d73-895e-4b34-86ba-2ed9996de5b9
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 2f44b781-4af4-4c8c-97e0-219c4ed9984f
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 31fbecbf-4d5b-4d1e-8b57-f904f95ca4cb
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 396f261b-06f9-4532-b060-bda463de8e93
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 3ba3d302-5cb0-4cf2-bbf0-d78b86441bc8
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 3dfbcdda-fba8-45ec-a8a5-c4c2f955ee69
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 4153b36c-e574-4f4e-af81-d2d3f2e46cb4
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 4d28f77a-5fb1-4e49-bc68-fad4a703b1da
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 5492ed3b-f8ca-4e6d-85c6-428337ae02a4
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 5e53a6eb-3797-4c4e-bd1c-325a89c881e1
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 5f392616-929f-48d4-a561-4004c1723d26
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 5f93ed37-95a3-4bb7-ae66-9b8a6fef79ad
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 637b5b8b-37c9-494c-9a08-60a8170afe9f
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 644e453a-5dcb-48b0-ba8d-b67a798400cc
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 66cace75-f1a0-46d9-a3f9-79f355f02ed4
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 6ba0cf59-21e0-4493-8636-d4c0a0f63f57
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 7b201ea5-0539-49c3-9478-aaadecdaca3c
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 830841e0-0388-45c0-b641-c01c6a202145
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 86b0371c-8dc1-4923-9461-103642e4a418
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 8944c315-446f-465d-a5b7-38dbf78436fb
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 90519aa6-9042-437b-affe-1dd5a1122e62
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 9983690e-1252-47d3-90f8-9292b9d90cfe
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c 9a8e1cef-3337-49c6-97ec-4e2da70e2357
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c a9da3e57-6ade-42fd-975a-19db789c2ae0
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c b9097d6f-e3b2-4dfc-a0bc-8ad66e76488a
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c c4c065c2-b43a-43a9-be86-43fadb5f2b98
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c c53f33bc-28ae-451b-a982-723f85cf39ac
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c ca96c335-e545-4563-9d65-058db3a8ef15
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c d706dddc-7c69-46b6-8033-a5540a2322b3
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c d8484c12-9008-420c-91a8-e69d1754c95b
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c d911feeb-88f2-480b-a488-c642665f776b
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c dac03a22-b857-412c-8c51-db1dae484fe8
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c e101540a-6d95-4c0c-9c3a-1eb92d06e461
infraRoles   Healthy     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c e42ef826-07d7-4cea-9db0-dc831a05d05e
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c f1af7248-0883-4d9b-9c01-45f5d86a109c
```

Get a list of all resource health objects under a service.

### Example 2
```
PS C:\> Get-AzsResourceHealth -Location local -ServiceRegistrationId e56bc7b8-c8b5-4e25-b00c-4f951effb22c -ResourceRegistrationId f1af7248-0883-4d9b-9c01-45f5d86a109c

ResourceType HealthState Type                                                                                RpRegistrationId                     Name
------------ ----------- ----                                                                                ----------------                     ----
infraRoles   Unknown     Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths e56bc7b8-c8b5-4e25-b00c-4f951effb22c f1af7248-0883-4d9b-9c01-45f5d86a109c
```

Get a a resource health objects under a service.

## PARAMETERS

### -Filter
OData filter parameter.

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

### -ResourceRegistrationId
Resource registration id.

```yaml
Type: String
Parameter Sets: ResourceHealths_Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceRegistrationId
Service registration id.

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

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: ResourceHealths_List
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
Parameter Sets: ResourceHealths_List
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

### Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.ResourceHealth

## NOTES

## RELATED LINKS
