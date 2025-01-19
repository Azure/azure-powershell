---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringapp
schema: 2.0.0
---

# Get-AzSpringApp

## SYNOPSIS
Get an App and its properties.

## SYNTAX

### List (Default)
```
Get-AzSpringApp -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringApp -Name <String> -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-SyncStatus <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringApp -InputObject <ISpringAppsIdentity> [-SyncStatus <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringApp -Name <String> -SpringInputObject <ISpringAppsIdentity> [-SyncStatus <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get an App and its properties.

## EXAMPLES

### Example 1: List App and its properties.
```powershell
Get-AzSpringApp -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Location Name    ProvisioningState ResourceGroupName
-------- ----    ----------------- -----------------
eastus   tools01 Succeeded         azps_test_group_spring
eastus   tools   Succeeded         azps_test_group_spring
```

List App and its properties.

### Example 2: Get an App and its properties.
```powershell
Get-AzSpringApp -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name tools
```

```output
AddonConfig                       : {
                                      "applicationConfigurationService": {
                                      },
                                      "serviceRegistry": {
                                      }
                                    }
ClientAuthCertificate             :
CustomPersistentDisk              :
EnableEndToEndTl                  : False
Fqdn                              : azps-spring-01.azuremicroservices.io
HttpsOnly                         : False
Id                                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apps/tools
IdentityPrincipalId               :
IdentityTenantId                  :
IdentityType                      :
IdentityUserAssignedIdentity      : {
                                    }
IngressSettingBackendProtocol     : Default
IngressSettingReadTimeoutInSecond : 300
IngressSettingSendTimeoutInSecond : 60
IngressSettingSessionAffinity     : None
IngressSettingSessionCookieMaxAge : 0
LoadedCertificate                 :
Location                          : eastus
Name                              : tools
PersistentDiskMountPath           : /mypersistentdisk
PersistentDiskSizeInGb            : 0
PersistentDiskUsedInGb            :
ProvisioningState                 : Succeeded
Public                            : False
ResourceGroupName                 : azps_test_group_spring
SystemDataCreatedAt               : 2023-12-13 上午 09:12:11
SystemDataCreatedBy               : v-jinpel@microsoft.com
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 2023-12-13 上午 09:12:11
SystemDataLastModifiedBy          : v-jinpel@microsoft.com
SystemDataLastModifiedByType      : User
TemporaryDiskMountPath            : /mytemporarydisk
TemporaryDiskSizeInGb             : 2
Type                              : Microsoft.AppPlatform/Spring/apps
Url                               :
VnetAddonPublicEndpoint           :
VnetAddonPublicEndpointUrl        :
```

Get an App and its properties.

### Example 3: Get an App and its properties.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringApp -SpringInputObject $serviceObj -Name tools
```

```output
AddonConfig                       : {
                                      "applicationConfigurationService": {
                                      },
                                      "serviceRegistry": {
                                      }
                                    }
ClientAuthCertificate             :
CustomPersistentDisk              :
EnableEndToEndTl                  : False
Fqdn                              : azps-spring-01.azuremicroservices.io
HttpsOnly                         : False
Id                                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apps/tools
IdentityPrincipalId               :
IdentityTenantId                  :
IdentityType                      :
IdentityUserAssignedIdentity      : {
                                    }
IngressSettingBackendProtocol     : Default
IngressSettingReadTimeoutInSecond : 300
IngressSettingSendTimeoutInSecond : 60
IngressSettingSessionAffinity     : None
IngressSettingSessionCookieMaxAge : 0
LoadedCertificate                 :
Location                          : eastus
Name                              : tools
PersistentDiskMountPath           : /mypersistentdisk
PersistentDiskSizeInGb            : 0
PersistentDiskUsedInGb            :
ProvisioningState                 : Succeeded
Public                            : False
ResourceGroupName                 : azps_test_group_spring
SystemDataCreatedAt               : 2023-12-13 上午 09:12:11
SystemDataCreatedBy               : v-jinpel@microsoft.com
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 2023-12-13 上午 09:12:11
SystemDataLastModifiedBy          : v-jinpel@microsoft.com
SystemDataLastModifiedByType      : User
TemporaryDiskMountPath            : /mytemporarydisk
TemporaryDiskSizeInGb             : 2
Type                              : Microsoft.AppPlatform/Spring/apps
Url                               :
VnetAddonPublicEndpoint           :
VnetAddonPublicEndpointUrl        :
```

Get an App and its properties.

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
The name of the App resource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentitySpring
Aliases: AppName

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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the Service resource.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpringInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: GetViaIdentitySpring
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncStatus
Indicates whether sync status

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity, GetViaIdentitySpring
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IAppResource

## NOTES

## RELATED LINKS

