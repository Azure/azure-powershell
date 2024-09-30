---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/get-azsecurityconnectordevopsconfiguration
schema: 2.0.0
---

# Get-AzSecurityConnectorDevOpsConfiguration

## SYNOPSIS
Gets a DevOps Configuration.

## SYNTAX

### Get (Default)
```
Get-AzSecurityConnectorDevOpsConfiguration -ResourceGroupName <String> -SecurityConnectorName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSecurityConnectorDevOpsConfiguration -InputObject <ISecurityIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzSecurityConnectorDevOpsConfiguration -ResourceGroupName <String> -SecurityConnectorName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a DevOps Configuration.

## EXAMPLES

### Example 1: Get Security Connector DevOps Configuration
```powershell
Get-AzSecurityConnectorDevOpsConfiguration -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-azdo-01
```

```output
AuthorizationCode               : 
AutoDiscovery                   : Disabled
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-azdo-01/devops/default
Name                            : default
ProvisioningState               : Succeeded
ProvisioningStatusMessage       : Resource creation successful.
ProvisioningStatusUpdateTimeUtc : 
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
TopLevelInventoryList           : 
Type                            : Microsoft.Security/securityConnectors/devops
```



### Example 2: Try to get non existing Security Connector DevOps Configuration 
```powershell
Get-AzSecurityConnectorDevOpsConfiguration -ResourceGroupName securityconnectors-tests -SecurityConnectorName aws-sdktest01
```

```output
Get-AzSecurityConnectorDevOpsConfiguration_Get: DevOps configuration was not found
```



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
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SecurityConnectorName
The security connector name.

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

### -SubscriptionId
Azure subscription ID

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IDevOpsConfiguration

## NOTES

## RELATED LINKS

