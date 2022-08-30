---
external help file:
Module Name: Az.SpringCloud
online version: https://docs.microsoft.com/powershell/module/az.springcloud/get-azspringcloud
schema: 2.0.0
---

# Get-AzSpringCloud

## SYNOPSIS
Get a Service and its properties.

## SYNTAX

### List (Default)
```
Get-AzSpringCloud [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringCloud -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringCloud -InputObject <ISpringCloudIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzSpringCloud -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Service and its properties.

## EXAMPLES

### Example 1: Get Spring Cloud Service by name
```powershell
Get-AzSpringCloud -ResourceGroupName springcloudrg -Name spring-portal02
```

```output
Location Name            SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----            -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus   spring-portal02 7/21/2022 3:02:40 AM v-diya@microsoft.com User                    7/21/2022 3:02:40 AM     v-diya@microsoft.com     User                         springcloudrg                                  : Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.Error
```

Get Spring Cloud Service by name.

### Example 2: List all the spring cloud service under the resource group
```powershell
Get-AzSpringCloud -ResourceGroupName spring-cloud-rg
```

```output
Location Name                Type
-------- ----                ----
eastus   spring-cloud-rg Microsoft.AppPlatform/Spring
```

List all the spring cloud service under the resource group.

### Example 3: List all the spring cloud service under the subscription
```powershell
Get-AzSpringCloud
```

```output
Location Name                Type
-------- ----                ----
eastus   spring-cloud-rg Microsoft.AppPlatform/Spring
```

List all the spring cloud service under the subscription.

### Example 4: Get Spring Cloud Service by pipeline
```powershell
New-AzSpringCloud -ResourceGroupName springcloudrg -Name spring-pwsh01 -Location eastus | Get-AzSpringCloud
```

```output
Location Name                Type
-------- ----                ----
eastus   spring-cloud-rg Microsoft.AppPlatform/Spring
```

Get Spring Cloud Service by pipeline.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.IServiceResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ISpringCloudIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the build service agent pool resource.
  - `[AppName <String>]`: The name of the App resource.
  - `[BindingName <String>]`: The name of the Binding resource.
  - `[BuildName <String>]`: The name of the build resource.
  - `[BuildResultName <String>]`: The name of the build result resource.
  - `[BuildServiceName <String>]`: The name of the build service resource.
  - `[BuilderName <String>]`: The name of the builder resource.
  - `[BuildpackBindingName <String>]`: The name of the Buildpack Binding Name
  - `[BuildpackName <String>]`: The name of the buildpack resource.
  - `[CertificateName <String>]`: The name of the certificate resource.
  - `[ConfigurationServiceName <String>]`: The name of Application Configuration Service.
  - `[DeploymentName <String>]`: The name of the Deployment resource.
  - `[DomainName <String>]`: The name of the custom domain resource.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: the region
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[ServiceName <String>]`: The name of the Service resource.
  - `[ServiceRegistryName <String>]`: The name of Service Registry.
  - `[StackName <String>]`: The name of the stack resource.
  - `[SubscriptionId <String>]`: Gets subscription ID which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

