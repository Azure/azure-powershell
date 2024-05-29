---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringpredefinedaccelerator
schema: 2.0.0
---

# Get-AzSpringPredefinedAccelerator

## SYNOPSIS
Get the predefined accelerator.

## SYNTAX

### List (Default)
```
Get-AzSpringPredefinedAccelerator -ApplicationAcceleratorName <String> -ResourceGroupName <String>
 -ServiceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringPredefinedAccelerator -ApplicationAcceleratorName <String> -Name <String>
 -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringPredefinedAccelerator -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityApplicationAccelerator
```
Get-AzSpringPredefinedAccelerator -ApplicationAcceleratorInputObject <ISpringAppsIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringPredefinedAccelerator -ApplicationAcceleratorName <String> -Name <String>
 -SpringInputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the predefined accelerator.

## EXAMPLES

### Example 1: Get the predefined accelerator.
```powershell
Get-AzSpringPredefinedAccelerator -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -ApplicationAcceleratorName default
```

```output
Name                        DisplayName                ProvisioningState ResourceGroupName
----                        -----------                ----------------- -----------------
asa-acme-fitness-store      Acme Fitness Store         Succeeded         azps_test_group_spring
asa-java-rest-service       Tanzu Java Restful Web App Succeeded         azps_test_group_spring
asa-node-express            Node Express               Succeeded         azps_test_group_spring
asa-spring-cloud-serverless Spring Cloud Serverless    Succeeded         azps_test_group_spring
asa-weatherforecast-csharp  C# Weather Forecast        Succeeded         azps_test_group_spring
```

Get the predefined accelerator.

### Example 2: Get the predefined accelerator.
```powershell
Get-AzSpringPredefinedAccelerator -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -ApplicationAcceleratorName default -Name asa-node-express
```

```output
AcceleratorTag               :
Description                  :
DisplayName                  : Node Express
IconUrl                      :
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/applicationAccelerators/default/p
                               redefinedAccelerators/asa-node-express
Name                         : asa-node-express
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SkuCapacity                  :
SkuName                      :
SkuTier                      :
State                        : Enabled
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/applicationAccelerators/predefinedAccelerators
```

Get the predefined accelerator.

## PARAMETERS

### -ApplicationAcceleratorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: GetViaIdentityApplicationAccelerator
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ApplicationAcceleratorName
The name of the application accelerator.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentitySpring, List
Aliases:

Required: True
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
The name of the predefined accelerator.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityApplicationAccelerator, GetViaIdentitySpring
Aliases: PredefinedAcceleratorName

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IPredefinedAcceleratorResource

## NOTES

## RELATED LINKS

