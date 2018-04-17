---
external help file: Azs.InfrastructureInsights.Admin-help.xml
Module Name: Azs.InfrastructureInsights.Admin
online version: 
schema: 2.0.0
---

# Get-AzsRegistrationHealth

## SYNOPSIS
Returns a list of each resource's health under a service.

## SYNTAX

### List (Default)
```
Get-AzsRegistrationHealth -ServiceRegistrationId <String> [-Location <String>] [-ResourceGroupName <String>]
 [-Filter <String>] [-Top <Int32>] [-Skip <Int32>] [<CommonParameters>]
```

### Get
```
Get-AzsRegistrationHealth -ServiceRegistrationId <String> -ResourceRegistrationId <String> [-Location <String>]
 [-ResourceGroupName <String>] [-Filter <String>] [<CommonParameters>]
```

### ResourceId
```
Get-AzsRegistrationHealth -ResourceId <String> [-Filter <String>] [<CommonParameters>]
```

## DESCRIPTION
Returns a list of each resource's health under a service.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsRegistrationHealth -ServiceRegistrationId e56bc7b8-c8b5-4e25-b00c-4f951effb22c
```

AlertSummary        : Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.AlertSummary
HealthState         : Healthy
NamespaceProperty   : Microsoft.Fabric.Admin
RegistrationId      : 0212cac8-242a-4133-8071-90467ac5b598
RoutePrefix         : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local
ResourceLocation    : local
ResourceName        : PortalUser
ResourceDisplayName : Portal (User)
ResourceType        : infraRoles
ResourceURI         : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local/infr
                      aRoles/PortalUser
RpRegistrationId    : e56bc7b8-c8b5-4e25-b00c-4f951effb22c
UsageMetrics        : {}
Id                  : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/resourceGroups/System.local/providers/Microsoft.InfrastructureInsights.Admin/regionHeal
                      ths/local/serviceHealths/e56bc7b8-c8b5-4e25-b00c-4f951effb22c/resourceHealths/0212cac8-242a-4133-8071-90467ac5b598
Name                : 0212cac8-242a-4133-8071-90467ac5b598
Type                : Microsoft.InfrastructureInsights.Admin/regionHealths/serviceHealths/resourceHealths
Location            : local
Tags                : {}
...

Returns a list of each resource's health under a service.

### -------------------------- EXAMPLE 2 --------------------------
```
Get-AzsRPHealth | Where {$_.NamespaceProperty -eq 'Microsoft.Fabric.Admin'} | Get-AzsRegistrationHealth | select ResourceName, HealthState
```

ResourceName                       HealthState
------------                       -----------
PortalUser                         Healthy
AzureResourceManagerUser           Unknown
SeedRing                           Unknown
UsageServiceAdmin                  Healthy
NetworkControllerRing              Healthy
AzureConsistentStorageRing         Healthy
GalleryServiceAdmin                Healthy
ApplicationGateway                 Healthy
ActiveDirectoryCertificateServices Unknown
NonPrivilegedApplicationGateway    Healthy
AzureResourceManagerAdmin          Unknown
RASGateway                         Healthy
StorageController                  Healthy
PortalAdmin                        Healthy
AzureBridge                        Healthy
KeyVaultNamingService              Healthy
KeyVaultDataPlane                  Healthy
ComputeController                  Healthy
ActiveDirectoryDomainServices      Healthy
FabricControllerRing               Healthy
ServicesController                 Healthy
InsightsServiceAdmin               Healthy
UsageBridge                        Healthy
SubscriptionsServices              Healthy
ActiveDirectoryFederationServices  Unknown
KeyVaultInternalDataPlane          Healthy
AuthorizationServiceAdmin          Healthy
SLBMultiplexer                     Healthy
KeyVaultInternalControlPlane       Healthy
EnterpriseCloudEngine              Healthy
UsageServiceUser                   Healthy
HealthMonitoring                   Healthy
AuthorizationServiceUser           Healthy
InsightsServiceUser                Healthy
BackupController                   Healthy
GalleryServiceUser                 Healthy
KeyVaultControlPlane               Healthy
MicrosoftSQLServer                 Unknown

Returns health status under a for Microsoft.Fabric.Admin.

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
Name of the region

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

### -ResourceRegistrationId
{{Fill ResourceRegistrationId Description}}

```yaml
Type: String
Parameter Sets: Get
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
Parameter Sets: List, Get
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

### Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.ResourceHealth

## NOTES

## RELATED LINKS

