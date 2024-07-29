---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/new-azspringservice
schema: 2.0.0
---

# New-AzSpringService

## SYNOPSIS
Create a new Service or Create an exiting Service.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSpringService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IngressConfigReadTimeoutInSecond <Int32>] [-Location <String>] [-MarketplaceResourcePlan <String>]
 [-MarketplaceResourceProduct <String>] [-MarketplaceResourcePublisher <String>]
 [-NetworkProfileOutboundType <String>] [-NetworkProfileResourceGroup <String>]
 [-NetworkProfileServiceCidr <String>] [-NetworkProfileServiceResourceGroup <String>]
 [-NetworkProfileServiceSubnetId <String>] [-NetworkProfileSubnetId <String>] [-SkuCapacity <Int32>]
 [-SkuName <String>] [-SkuTier <String>] [-Tag <Hashtable>] [-VnetAddonDataPlanePublicEndpoint]
 [-VnetAddonLogStreamPublicEndpoint] [-ZoneRedundant] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzSpringService -InputObject <ISpringAppsIdentity> [-IngressConfigReadTimeoutInSecond <Int32>]
 [-Location <String>] [-MarketplaceResourcePlan <String>] [-MarketplaceResourceProduct <String>]
 [-MarketplaceResourcePublisher <String>] [-NetworkProfileOutboundType <String>]
 [-NetworkProfileResourceGroup <String>] [-NetworkProfileServiceCidr <String>]
 [-NetworkProfileServiceResourceGroup <String>] [-NetworkProfileServiceSubnetId <String>]
 [-NetworkProfileSubnetId <String>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>]
 [-Tag <Hashtable>] [-VnetAddonDataPlanePublicEndpoint] [-VnetAddonLogStreamPublicEndpoint] [-ZoneRedundant]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzSpringService -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzSpringService -Name <String> -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new Service or Create an exiting Service.

## EXAMPLES

### Example 1: Create a new Service or Create an exiting Service.
```powershell
New-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01 -Location eastus -SkuTier "Enterprise" -SkuName "E0"
```

```output
Fqdn                                             : azps-spring-01.azuremicroservices.io
Id                                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01
IngressConfigReadTimeoutInSecond                 :
Location                                         : eastus
MarketplaceResourcePlan                          : asa-ent-hr-mtr
MarketplaceResourceProduct                       : azure-spring-cloud-vmware-tanzu-2
MarketplaceResourcePublisher                     : vmware-inc
Name                                             : azps-spring-01
NetworkProfileAppNetworkResourceGroup            :
NetworkProfileAppSubnetId                        :
NetworkProfileOutboundType                       : loadBalancer
NetworkProfileRequiredTraffic                    :
NetworkProfileServiceCidr                        :
NetworkProfileServiceRuntimeNetworkResourceGroup :
NetworkProfileServiceRuntimeSubnetId             :
OutboundIPPublicIP                               : {20.253.92.83, 20.253.92.97}
PowerState                                       : Running
ProvisioningState                                : Succeeded
ResourceGroupName                                : azps_test_group_spring
ServiceId                                        : 0871555f28044a46bdc0f31682b862ef
SkuCapacity                                      :
SkuName                                          : E0
SkuTier                                          : Enterprise
SystemDataCreatedAt                              : 2024-04-24 上午 05:49:39
SystemDataCreatedBy                              : v-jinpel@microsoft.com
SystemDataCreatedByType                          : User
SystemDataLastModifiedAt                         : 2024-04-24 上午 05:49:39
SystemDataLastModifiedBy                         : v-jinpel@microsoft.com
SystemDataLastModifiedByType                     : User
Tag                                              : {
                                                   }
Type                                             : Microsoft.AppPlatform/Spring
Version                                          : 3
VnetAddonDataPlanePublicEndpoint                 :
VnetAddonLogStreamPublicEndpoint                 :
ZoneRedundant                                    : False
```

Create a new Service or Create an exiting Service.

### Example 2: Create a new Service or Create an exiting Service.
```powershell
New-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-02 -Location eastus
```

```output
Fqdn                                             : azps-spring-02.azuremicroservices.io
Id                                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02
IngressConfigReadTimeoutInSecond                 :
Location                                         : eastus
Name                                             : azps-spring-02
NetworkProfileAppNetworkResourceGroup            :
NetworkProfileAppSubnetId                        :
NetworkProfileOutboundType                       : loadBalancer
NetworkProfileRequiredTraffic                    :
NetworkProfileServiceCidr                        :
NetworkProfileServiceRuntimeNetworkResourceGroup :
NetworkProfileServiceRuntimeSubnetId             :
OutboundIPPublicIP                               : {20.237.102.222, 20.237.103.29}
PowerState                                       : Running
ProvisioningState                                : Succeeded
ResourceGroupName                                : azps_test_group_spring
ServiceId                                        : 59fd2d8c82144a129a682a631d39a4f8
SkuCapacity                                      :
SkuName                                          : S0
SkuTier                                          : Standard
SystemDataCreatedAt                              : 2023-12-13 上午 08:41:49
SystemDataCreatedBy                              : v-jinpel@microsoft.com
SystemDataCreatedByType                          : User
SystemDataLastModifiedAt                         : 2023-12-13 上午 08:41:49
SystemDataLastModifiedBy                         : v-jinpel@microsoft.com
SystemDataLastModifiedByType                     : User
Tag                                              : {
                                                   }
Type                                             : Microsoft.AppPlatform/Spring
Version                                          : 3
VnetAddonLogStreamPublicEndpoint                 :
ZoneRedundant                                    : False
```

Create a new Service or Create an exiting Service.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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

### -IngressConfigReadTimeoutInSecond
Ingress read time out in seconds.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

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
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The GEO location of the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceResourcePlan
The plan id of the 3rd Party Artifact that is being procured.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceResourceProduct
The 3rd Party artifact that is being procured.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceResourcePublisher
The publisher id of the 3rd Party Artifact that is being bought.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Service resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: ServiceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfileOutboundType
The egress traffic type of Azure Spring Apps VNet instances.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfileResourceGroup
Name of the resource group containing network resources for customer apps in Azure Spring Apps

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfileServiceCidr
Azure Spring Apps service reserved CIDR

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfileServiceResourceGroup
Name of the resource group containing network resources of Azure Spring Apps Service Runtime

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfileServiceSubnetId
Fully qualified resource Id of the subnet to host Azure Spring Apps Service Runtime

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfileSubnetId
Fully qualified resource Id of the subnet to host customer apps in Azure Spring Apps

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
Current capacity of the target resource

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the Sku

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
Tier of the Sku

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tags of the service which is a list of key value pairs that describe the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VnetAddonDataPlanePublicEndpoint
Indicates whether the data plane components(log stream, app connect, remote debugging) in vnet injection instance could be accessed from internet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VnetAddonLogStreamPublicEndpoint
Indicates whether the log stream in vnet injection instance could be accessed from internet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ZoneRedundant
.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IServiceResource

## NOTES

## RELATED LINKS

