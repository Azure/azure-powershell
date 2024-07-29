---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringconfigserver
schema: 2.0.0
---

# Get-AzSpringConfigServer

## SYNOPSIS
Get the config server and its properties.

## SYNTAX

### Get (Default)
```
Get-AzSpringConfigServer -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringConfigServer -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the config server and its properties.

## EXAMPLES

### Example 1: Get the config server and its properties.
```powershell
Get-AzSpringConfigServer -ResourceGroupName azps_test_group_spring -Name azps-spring-02
```

```output
Code                             :
GitPropertyHostKey               :
GitPropertyHostKeyAlgorithm      :
GitPropertyLabel                 :
GitPropertyPassword              :
GitPropertyPrivateKey            :
GitPropertyRepository            :
GitPropertySearchPath            :
GitPropertyStrictHostKeyChecking :
GitPropertyUri                   :
GitPropertyUsername              :
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02/configServers/default
Message                          :
Name                             : default
ProvisioningState                : Succeeded
ResourceGroupName                : azps_test_group_spring
SystemDataCreatedAt              :
SystemDataCreatedBy              :
SystemDataCreatedByType          :
SystemDataLastModifiedAt         :
SystemDataLastModifiedBy         :
SystemDataLastModifiedByType     :
Type                             : Microsoft.AppPlatform/Spring/configServers
```

Get the config server and its properties.

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
Aliases:

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
Parameter Sets: Get
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
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IConfigServerResource

## NOTES

## RELATED LINKS

