---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringapplicationaccelerator
schema: 2.0.0
---

# Get-AzSpringApplicationAccelerator

## SYNOPSIS
Get the application accelerator.

## SYNTAX

### List (Default)
```
Get-AzSpringApplicationAccelerator -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringApplicationAccelerator -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringApplicationAccelerator -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringApplicationAccelerator -Name <String> -SpringInputObject <ISpringAppsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the application accelerator.

## EXAMPLES

### Example 1: Get the application accelerator.
```powershell
Get-AzSpringApplicationAccelerator -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Component                    : {{
                                 "resourceRequests": {
                                   "cpu": "200m",
                                   "memory": "256Mi",
                                   "instanceCount": 2
                                 },
                                 "name": "accelerator-server",
                                 "instances": [
                                   {
                                     "name": "acc-server-669746f695-cmpcc",
                                     "status": "Running"
                                   },
                                   {
                                     "name": "acc-server-669746f695-r4lfv",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "1000m",
                                   "memory": "3Gi",
                                   "instanceCount": 1
                                 },
                                 "name": "accelerator-engine",
                                 "instances": [
                                   {
                                     "name": "acc-engine-757f5bbb88-7hm6k",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "200m",
                                   "memory": "256Mi",
                                   "instanceCount": 1
                                 },
                                 "name": "accelerator-controller",
                                 "instances": [
                                   {
                                     "name": "accelerator-controller-manager-6d469cd8d-2f52h",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "200m",
                                   "memory": "256Mi",
                                   "instanceCount": 1
                                 },
                                 "name": "source-controller",
                                 "instances": [
                                   {
                                     "name": "source-controller-manager-868df855db-p97pm",
                                     "status": "Running"
                                   }
                                 ]
                               }…}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/applicationAccelerators/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SkuCapacity                  :
SkuName                      :
SkuTier                      :
SystemDataCreatedAt          : 2024-05-24 上午 07:01:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-24 上午 07:01:38
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/applicationAccelerators
```

Get the application accelerator.

### Example 2: Get the application accelerator.
```powershell
Get-AzSpringApplicationAccelerator -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default
```

```output
Component                    : {{
                                 "resourceRequests": {
                                   "cpu": "200m",
                                   "memory": "256Mi",
                                   "instanceCount": 2
                                 },
                                 "name": "accelerator-server",
                                 "instances": [
                                   {
                                     "name": "acc-server-669746f695-cmpcc",
                                     "status": "Running"
                                   },
                                   {
                                     "name": "acc-server-669746f695-r4lfv",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "1000m",
                                   "memory": "3Gi",
                                   "instanceCount": 1
                                 },
                                 "name": "accelerator-engine",
                                 "instances": [
                                   {
                                     "name": "acc-engine-757f5bbb88-7hm6k",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "200m",
                                   "memory": "256Mi",
                                   "instanceCount": 1
                                 },
                                 "name": "accelerator-controller",
                                 "instances": [
                                   {
                                     "name": "accelerator-controller-manager-6d469cd8d-2f52h",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "200m",
                                   "memory": "256Mi",
                                   "instanceCount": 1
                                 },
                                 "name": "source-controller",
                                 "instances": [
                                   {
                                     "name": "source-controller-manager-868df855db-p97pm",
                                     "status": "Running"
                                   }
                                 ]
                               }…}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/applicationAccelerators/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SkuCapacity                  :
SkuName                      :
SkuTier                      :
SystemDataCreatedAt          : 2024-05-24 上午 07:01:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-24 上午 07:01:38
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/applicationAccelerators
```

Get the application accelerator.

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
The name of the application accelerator.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentitySpring
Aliases: ApplicationAcceleratorName

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IApplicationAcceleratorResource

## NOTES

## RELATED LINKS

