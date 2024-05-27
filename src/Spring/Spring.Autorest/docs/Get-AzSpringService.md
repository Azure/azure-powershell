---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringservice
schema: 2.0.0
---

# Get-AzSpringService

## SYNOPSIS
Get a Service and its properties.

## SYNTAX

### List (Default)
```
Get-AzSpringService [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringService -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzSpringService -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Service and its properties.

## EXAMPLES

### Example 1: List Service and its properties.
```powershell
Get-AzSpringService
```

```output
Location Name           ProvisioningState SkuName SkuTier    ResourceGroupName
-------- ----           ----------------- ------- -------    -----------------
eastus   azps-spring-01 Succeeded         E0      Enterprise azps_test_group_spring
eastus   azps-spring-02 Succeeded         S0      Standard   azps_test_group_spring
```

List Service and its properties.

### Example 2: List Service and its properties.
```powershell
Get-AzSpringService -ResourceGroupName azps_test_group_spring
```

```output
Location Name           ProvisioningState SkuName SkuTier    ResourceGroupName
-------- ----           ----------------- ------- -------    -----------------
eastus   azps-spring-01 Succeeded         E0      Enterprise azps_test_group_spring
eastus   azps-spring-02 Succeeded         S0      Standard   azps_test_group_spring
```

List Service and its properties.

### Example 3: Get a Service and its properties.
```powershell
Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
```

```output
Fqdn                                             : azps-spring-01.azuremicroservices.io
Id                                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01
IngressConfigReadTimeoutInSecond                 :
Location                                         : eastus
Name                                             : azps-spring-01
NetworkProfileAppNetworkResourceGroup            :
NetworkProfileAppSubnetId                        :
NetworkProfileOutboundType                       : loadBalancer
NetworkProfileRequiredTraffic                    :
NetworkProfileServiceCidr                        :
NetworkProfileServiceRuntimeNetworkResourceGroup :
NetworkProfileServiceRuntimeSubnetId             :
OutboundIPPublicIP                               : {4.255.75.210, 4.255.75.214}
PowerState                                       : Running
ProvisioningState                                : Succeeded
ResourceGroupName                                : azps_test_group_spring
ServiceId                                        : 0c6aeadde5dd43cfa31ee4e078381260
SkuCapacity                                      :
SkuName                                          : E0
SkuTier                                          : Enterprise
SystemDataCreatedAt                              : 2023-12-13 上午 08:24:54
SystemDataCreatedBy                              : v-jinpel@microsoft.com
SystemDataCreatedByType                          : User
SystemDataLastModifiedAt                         : 2023-12-13 上午 08:24:54
SystemDataLastModifiedBy                         : v-jinpel@microsoft.com
SystemDataLastModifiedByType                     : User
Tag                                              : {
                                                   }
Type                                             : Microsoft.AppPlatform/Spring
Version                                          : 3
VnetAddonLogStreamPublicEndpoint                 :
ZoneRedundant                                    : False
```

Get a Service and its properties.

## PARAMETERS

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Service resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ServiceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IServiceResource

## NOTES

## RELATED LINKS

