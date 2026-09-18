---
external help file:
Module Name: Az.DisconnectedOperations
online version: https://learn.microsoft.com/powershell/module/az.disconnectedoperations/get-azdisconnectedoperationshardwaresetting
schema: 2.0.0
---

# Get-AzDisconnectedOperationsHardwareSetting

## SYNOPSIS
Get the hardware settings resource

## SYNTAX

### List (Default)
```
Get-AzDisconnectedOperationsHardwareSetting -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDisconnectedOperationsHardwareSetting -HardwareSettingName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDisconnectedOperationsHardwareSetting -InputObject <IDisconnectedOperationsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityDisconnectedOperation
```
Get-AzDisconnectedOperationsHardwareSetting
 -DisconnectedOperationInputObject <IDisconnectedOperationsIdentity> -HardwareSettingName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the hardware settings resource

## EXAMPLES

### Example 1: Get hardware settings for a specific resource
```powershell
Get-AzDisconnectedOperationsHardwareSetting -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -HardwareSettingName "default"
```

```output
DeviceId                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
DiskSpaceInGb                : 1024
HardwareSku                  : MC-760
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test/hardwareSettings/default
MemoryInGb                   : 64
Name                         : default
Node                         : 3
Oem                          : contoso
ProvisioningState            : Succeeded
ResourceGroupName            : winfield-demo-rg-2
SolutionBuilderExtension     : xyz
SystemDataCreatedAt          : 03/02/2026 10:55:32
SystemDataCreatedBy          : user1@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 03/02/2026 10:55:32
SystemDataLastModifiedBy     : user1@outlook.com
SystemDataLastModifiedByType : User
TotalCore                    : 200
Type                         : microsoft.edge/disconnectedoperations/hardwaresettings
VersionAtRegistration        : xxxx.x
```

This command retrieves the hardware setting named "default" for the resource "winfield-ps-test" in the resource group "winfield-demo-rg-2".

### Example 2: Get hardware settings for a specific resource using input object.
```powershell
$inputObject = @{
  "HardwareSettingName" = "default";
  "Name" = "disconnected-operation-name";
  "ResourceGroupName" = "my-resource-group";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsHardwareSetting -InputObject $inputObject
```

```output
DeviceId                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
DiskSpaceInGb                : 1024
HardwareSku                  : MC-760
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test/hardwareSettings/default
MemoryInGb                   : 64
Name                         : default
Node                         : 3
Oem                          : contoso
ProvisioningState            : Succeeded
ResourceGroupName            : winfield-demo-rg-2
SolutionBuilderExtension     : xyz
SystemDataCreatedAt          : 03/02/2026 10:55:32
SystemDataCreatedBy          : user1@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 03/02/2026 10:55:32
SystemDataLastModifiedBy     : user1@outlook.com
SystemDataLastModifiedByType : User
TotalCore                    : 200
Type                         : microsoft.edge/disconnectedoperations/hardwaresettings
VersionAtRegistration        : xxxx.x
```

This command retrieves the hardware setting named "default" for the resource "winfield-ps-test" in the resource group "winfield-demo-rg-2".

### Example 3: Get hardware setting for a specific resource using disconnected operation identity
```powershell
$disconnectedOperation = @{
  "ResourceGroupName" = "winfield-demo-rg-2";
  "Name" = "winfield-ps-test";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsHardwareSetting -DisconnectedOperationInputObject $disconnectedOperation -HardwareSettingName "default"
```

```output
DeviceId                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
DiskSpaceInGb                : 1024
HardwareSku                  : MC-760
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test/hardwareSettings/default
MemoryInGb                   : 64
Name                         : default
Node                         : 3
Oem                          : contoso
ProvisioningState            : Succeeded
ResourceGroupName            : winfield-demo-rg-2
SolutionBuilderExtension     : xyz
SystemDataCreatedAt          : 03/02/2026 10:55:32
SystemDataCreatedBy          : user1@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 03/02/2026 10:55:32
SystemDataLastModifiedBy     : user1@outlook.com
SystemDataLastModifiedByType : User
TotalCore                    : 200
Type                         : microsoft.edge/disconnectedoperations/hardwaresettings
VersionAtRegistration        : xxxx.x
```

This command retrieves the hardware setting named "default" for the resource "winfield-ps-test" in the resource group "winfield-demo-rg-2".

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

### -DisconnectedOperationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity
Parameter Sets: GetViaIdentityDisconnectedOperation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -HardwareSettingName
The name of the HardwareSetting

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityDisconnectedOperation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the resource

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting

## NOTES

## RELATED LINKS

