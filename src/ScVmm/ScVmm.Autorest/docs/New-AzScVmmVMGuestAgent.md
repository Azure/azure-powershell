---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/new-azscvmmvmguestagent
schema: 2.0.0
---

# New-AzScVmmVMGuestAgent

## SYNOPSIS
Installs Azure Arc agent on the Virtual Machine.

## SYNTAX

### CreateExpanded (Default)
```
New-AzScVmmVMGuestAgent -Name <String> -ResourceGroupName <String> -CredentialsPassword <SecureString>
 -CredentialsUsername <String> [-SubscriptionId <String>] [-HttpProxyConfigHttpsProxy <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzScVmmVMGuestAgent -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzScVmmVMGuestAgent -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Installs Azure Arc agent on the Virtual Machine

## EXAMPLES

### Example 1: Enable Guest Management
```powershell
$securePassword = ConvertTo-SecureString "*****" -AsPlainText -Force
New-AzScVmmVMGuestAgent -Name "test-vm" -ResourceGroupName "test-rg-01" -CredentialsPassword $securePassword -CredentialsUsername 'testUser'
```

```output
CredentialsPassword          :
CredentialsUsername          : testUser
CustomResourceName           :
HttpProxyConfigHttpsProxy    :
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/M
                               icrosoft.HybridCompute/machines/test-vm/providers/Microsoft.ScVmm/virtualMachineIn
                               stances/default/guestAgents/default
Name                         : default
ProvisioningAction           : install
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
Status                       : Enabled
SystemDataCreatedAt          : 08-01-2024 10:04:20
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 13:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Type                         : microsoft.scvmm/virtualmachineinstances/guestagents
Uuid                         : 
```

Enables Guest Management capability on the virtual machine.

### Example 2: Enable Guest Management
```powershell
$JsonStringInput='{
    "credentials": {
      "username": "testUser",
      "password": "*****"
    },
    "provisioningAction": "install"
}'
New-AzScVmmVMGuestAgent -Name "test-vm" -ResourceGroupName "test-rg-01" -JsonString $JsonStringInput
```

```output
CredentialsPassword          :
CredentialsUsername          : testUser
CustomResourceName           :
HttpProxyConfigHttpsProxy    :
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/M
                               icrosoft.HybridCompute/machines/test-vm/providers/Microsoft.ScVmm/virtualMachineIn
                               stances/default/guestAgents/default
Name                         : default
ProvisioningAction           : install
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
Status                       : Enabled
SystemDataCreatedAt          : 08-01-2024 10:04:20
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 13:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Type                         : microsoft.scvmm/virtualmachineinstances/guestagents
Uuid                         : 
```

Enables Guest Management capability on the virtual machine.

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

### -CredentialsPassword
Gets or sets the password to connect with the guest.

```yaml
Type: System.Security.SecureString
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CredentialsUsername
Gets or sets username to connect with the guest.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -HttpProxyConfigHttpsProxy
Gets or sets httpsProxy url.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -Name
The name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VMName

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
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IGuestAgent

## NOTES

## RELATED LINKS

