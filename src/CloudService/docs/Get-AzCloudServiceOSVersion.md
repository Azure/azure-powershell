---
external help file:
Module Name: Az.CloudService
online version: https://learn.microsoft.com/powershell/module/az.cloudservice/get-azcloudserviceosversion
schema: 2.0.0
---

# Get-AzCloudServiceOSVersion

## SYNOPSIS
Gets properties of a guest operating system version that can be specified in the XML service configuration (.cscfg) for a cloud service.

## SYNTAX

### List (Default)
```
Get-AzCloudServiceOSVersion -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzCloudServiceOSVersion -Location <String> -OSVersionName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCloudServiceOSVersion -InputObject <ICloudServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets properties of a guest operating system version that can be specified in the XML service configuration (.cscfg) for a cloud service.

## EXAMPLES

### Example 1: Get all OS versions in a location
```powershell
Get-AzCloudServiceOSVersion -location 'westus2'
```

```output
Name                        Label                                            IsDefault IsActive Family FamilyLabel
----                        -----                                            --------- -------- ------ -----------
WA-GUEST-OS-6.7_201905-01   Windows Azure Guest OS 6.7 (Release 201905-01)   False     False    6      Windows Server 2019
WA-GUEST-OS-3.21_201411-01  Windows Azure Guest OS 3.21 (Release 201411-01)  False     False    3      Windows Server 2012
WA-GUEST-OS-3.34_201512-01  Windows Azure Guest OS 3.34 (Release 201512-01)  False     False    3      Windows Server 2012
WA-GUEST-OS-3.26_201504-01  Windows Azure Guest OS 3.26 (Release 201504-01)  False     False    3      Windows Server 2012
WA-GUEST-OS-2.46_201512-01  Windows Azure Guest OS 2.46 (Release 201512-01)  False     False    2      Windows Server 2008 R2
```

This command gets all OS versions in location westus2

### Example 2: Get OS version
```powershell
Get-AzCloudServiceOSVersion -location 'westus2' -OSVersionName 'WA-GUEST-OS-6.7_201905-01'
```

```output
Name                      Label                                          IsDefault IsActive Family FamilyLabel
----                      -----                                          --------- -------- ------ -----------
WA-GUEST-OS-6.7_201905-01 Windows Azure Guest OS 6.7 (Release 201905-01) False     False    6      Windows Server 2019
```

This command gets OS version named WA-GUEST-OS-6.7_201905-01 that is located in westus2.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Name of the location that the OS version pertains to.

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

### -OSVersionName
Name of the OS version.

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
Subscription credentials which uniquely identify Microsoft Azure subscription.
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.IOSVersion

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ICloudServiceIdentity>`: Identity Parameter
  - `[CloudServiceName <String>]`: Name of the cloud service.
  - `[IPConfigurationName <String>]`: The IP configuration name.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: Name of the location that the OS version pertains to.
  - `[NetworkInterfaceName <String>]`: The name of the network interface.
  - `[OSFamilyName <String>]`: Name of the OS family.
  - `[OSVersionName <String>]`: Name of the OS version.
  - `[PublicIPAddressName <String>]`: The name of the public IP Address.
  - `[ResourceGroupName <String>]`: Name of the resource group.
  - `[RoleInstanceName <String>]`: Name of the role instance.
  - `[RoleName <String>]`: Name of the role.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[UpdateDomain <Int32?>]`: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.

## RELATED LINKS

