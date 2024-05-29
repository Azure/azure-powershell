---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/update-azspringappactivedeployment
schema: 2.0.0
---

# Update-AzSpringAppActiveDeployment

## SYNOPSIS
Set existing Deployment under the app as active

## SYNTAX

### SetExpanded (Default)
```
Update-AzSpringAppActiveDeployment -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String>] [-DeploymentName <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Set
```
Update-AzSpringAppActiveDeployment -Name <String> -ResourceGroupName <String> -ServiceName <String>
 -ActiveDeploymentCollection <IActiveDeploymentCollection> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetViaIdentity
```
Update-AzSpringAppActiveDeployment -InputObject <ISpringAppsIdentity>
 -ActiveDeploymentCollection <IActiveDeploymentCollection> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetViaIdentityExpanded
```
Update-AzSpringAppActiveDeployment -InputObject <ISpringAppsIdentity> [-DeploymentName <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetViaIdentitySpring
```
Update-AzSpringAppActiveDeployment -Name <String> -SpringInputObject <ISpringAppsIdentity>
 -ActiveDeploymentCollection <IActiveDeploymentCollection> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetViaIdentitySpringExpanded
```
Update-AzSpringAppActiveDeployment -Name <String> -SpringInputObject <ISpringAppsIdentity>
 [-DeploymentName <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SetViaJsonFilePath
```
Update-AzSpringAppActiveDeployment -Name <String> -ResourceGroupName <String> -ServiceName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### SetViaJsonString
```
Update-AzSpringAppActiveDeployment -Name <String> -ResourceGroupName <String> -ServiceName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Set existing Deployment under the app as active

## EXAMPLES

### Example 1: Set existing Deployment under the app as active
```powershell
Update-AzSpringAppActiveDeployment -Name tools -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02 -DeploymentName green
```

```output
AddonConfig                       : {
                                      "applicationConfigurationService": {
                                      },
                                      "configServer": {
                                      },
                                      "serviceRegistry": {
                                      }
                                    }
ClientAuthCertificate             :
CustomPersistentDisk              :
EnableEndToEndTl                  : False
Fqdn                              : azps-spring-02.azuremicroservices.io
HttpsOnly                         : False
Id                                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02/apps/tools
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
SystemDataCreatedAt               : 2024-05-27 上午 03:29:23
SystemDataCreatedBy               : v-jinpel@microsoft.com
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 2024-05-28 下午 12:12:05
SystemDataLastModifiedBy          : v-jinpel@microsoft.com
SystemDataLastModifiedByType      : User
TemporaryDiskMountPath            : /mytemporarydisk
TemporaryDiskSizeInGb             : 2
Type                              : Microsoft.AppPlatform/Spring/apps
Url                               :
VnetAddonPublicEndpoint           :
VnetAddonPublicEndpointUrl        :
```

Set existing Deployment under the app as active

## PARAMETERS

### -ActiveDeploymentCollection
Object that includes an array of Deployment resource name and set them as active.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IActiveDeploymentCollection
Parameter Sets: Set, SetViaIdentity, SetViaIdentitySpring
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### -DeploymentName
Collection of Deployment name.

```yaml
Type: System.String[]
Parameter Sets: SetExpanded, SetViaIdentityExpanded, SetViaIdentitySpringExpanded
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
Parameter Sets: SetViaIdentity, SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Set operation

```yaml
Type: System.String
Parameter Sets: SetViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Set operation

```yaml
Type: System.String
Parameter Sets: SetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the App resource.

```yaml
Type: System.String
Parameter Sets: Set, SetExpanded, SetViaIdentitySpring, SetViaIdentitySpringExpanded, SetViaJsonFilePath, SetViaJsonString
Aliases:

Required: True
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
Parameter Sets: Set, SetExpanded, SetViaJsonFilePath, SetViaJsonString
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
Parameter Sets: Set, SetExpanded, SetViaJsonFilePath, SetViaJsonString
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
Parameter Sets: SetViaIdentitySpring, SetViaIdentitySpringExpanded
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
Type: System.String
Parameter Sets: Set, SetExpanded, SetViaJsonFilePath, SetViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IActiveDeploymentCollection

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IAppResource

## NOTES

## RELATED LINKS

