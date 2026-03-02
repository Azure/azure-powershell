---
external help file:
Module Name: Az.DisconnectedOperations
online version: https://learn.microsoft.com/powershell/module/az.disconnectedoperations/new-azdisconnectedoperationshardwaresetting
schema: 2.0.0
---

# New-AzDisconnectedOperationsHardwareSetting

## SYNOPSIS
Create hardware settings

## SYNTAX

### CreateExpanded (Default)
```
New-AzDisconnectedOperationsHardwareSetting -HardwareSettingName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DeviceId <String>] [-DiskSpaceInGb <Int32>]
 [-HardwareSku <String>] [-MemoryInGb <Int32>] [-Node <Int32>] [-Oem <String>]
 [-SolutionBuilderExtension <String>] [-TotalCore <Int32>] [-VersionAtRegistration <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityDisconnectedOperationExpanded
```
New-AzDisconnectedOperationsHardwareSetting
 -DisconnectedOperationInputObject <IDisconnectedOperationsIdentity> -HardwareSettingName <String>
 [-DeviceId <String>] [-DiskSpaceInGb <Int32>] [-HardwareSku <String>] [-MemoryInGb <Int32>] [-Node <Int32>]
 [-Oem <String>] [-SolutionBuilderExtension <String>] [-TotalCore <Int32>] [-VersionAtRegistration <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDisconnectedOperationsHardwareSetting -HardwareSettingName <String> -Name <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDisconnectedOperationsHardwareSetting -HardwareSettingName <String> -Name <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create hardware settings

## EXAMPLES

### Example 1: Crete a new hardware setting for a specific resource with expanded parameters
```powershell
New-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default" -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -DeviceId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -DiskSpaceInGb 1024 -HardwareSku "MC-760" -MemoryInGb 64 -Node 3 -Oem "contoso" -SolutionBuilderExtension "xyz" -TotalCore 200 -VersionAtRegistration "xxxx.x"
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

This command creates a new hardware setting named "default" for the resource "winfield-ps-test" in the resource group "winfield-demo-rg-2" with specified parameters such as device ID, disk space, hardware SKU, memory, node count, OEM, solution builder extension, total cores, and version at registration.

### Example 2: Create a new hardware setting for a specific resource using DisconnectedOperation identity
```powershell
$disconnectedOperation = @{
  "ResourceGroupName" = "winfield-demo-rg-2";
  "Name" = "winfield-ps-test";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
New-AzDisconnectedOperationsHardwareSetting -DisconnectedOperationInputObject $disconnectedOperation -HardwareSettingName "default" -DeviceId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx" -DiskSpaceInGb 1024 -HardwareSku "MC-760" -MemoryInGb 64 -Node 3 -Oem "contoso" -SolutionBuilderExtension "xyz" -TotalCore 200 -VersionAtRegistration "xxxx.x"
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

This command creates a new hardware setting named "default" for the resource "winfield-ps-test" in the resource group "winfield-demo-rg-2" using the DisconnectedOperation identity with specified parameters such as device ID, disk space, hardware SKU, memory, node count, OEM, solution builder extension, total cores, and version at registration.

### Example 3: Create a new hardware setting for a specific resource using a JSON file path
```powershell
New-AzDisconnectedOperationsHardwareSetting -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -HardwareSettingName "default" -JsonFilePath "path/to/jsonFiles/CreateHardwareSetting.json"
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

This command creates a new hardware setting named "default" for the resource "winfield-ps-test" in the resource group "winfield-demo-rg-2" using the configuration specified in the JSON file located at "path/to/jsonFiles/CreateHardwareSetting.json".

### Example 4: Creates a new hardware setting for a specific resource using a JSON string
```powershell
New-AzDisconnectedOperationsHardwareSetting -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -HardwareSettingName "default" -JsonString '{"properties":{"totalCores":200,"diskSpaceInGb":1024,"memoryInGb":64,"oem":"Contoso","hardwareSku":"MC-760","nodes":3,"versionAtRegistration":"xxxx.x","solutionBuilderExtension":"xyz","deviceId":"xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"}}'
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

This command creates a new hardware setting named "default" for the resource "winfield-ps-test" in the resource group "winfield-demo-rg-2" using the configuration specified in the JSON string.

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

### -DeviceId
The unique Id of the device

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityDisconnectedOperationExpanded
Aliases:

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
Parameter Sets: CreateViaIdentityDisconnectedOperationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DiskSpaceInGb
The disk space in GB

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityDisconnectedOperationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HardwareSettingName
The name of the HardwareSetting

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HardwareSku
The hardware SKU

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityDisconnectedOperationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -MemoryInGb
The memory in GB

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityDisconnectedOperationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the resource

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

### -Node
The number of nodes

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityDisconnectedOperationExpanded
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

### -Oem
The OEM

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityDisconnectedOperationExpanded
Aliases:

Required: False
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SolutionBuilderExtension
The solution builder extension at registration

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityDisconnectedOperationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -TotalCore
The total number of cores

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityDisconnectedOperationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VersionAtRegistration
The active version at registration

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityDisconnectedOperationExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting

## NOTES

## RELATED LINKS

