---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/grant-azdiskaccess
schema: 2.0.0
---

# Grant-AzDiskAccess

## SYNOPSIS
Grants access to a disk.

## SYNTAX

### Grant (Default)
```
Grant-AzDiskAccess -DiskName <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-GrantAccessData <IGrantAccessData>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GrantExpanded
```
Grant-AzDiskAccess -DiskName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -Access <AccessLevel> -DurationInSecond <Int32> [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GrantViaIdentityExpanded
```
Grant-AzDiskAccess -InputObject <IComputeIdentity> -Access <AccessLevel> -DurationInSecond <Int32>
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GrantViaIdentity
```
Grant-AzDiskAccess -InputObject <IComputeIdentity> [-GrantAccessData <IGrantAccessData>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Grants access to a disk.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Access
HELP MESSAGE MISSING

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AccessLevel
Parameter Sets: GrantExpanded, GrantViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

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
Dynamic: False
```

### -DiskName
The name of the managed disk that is being created.
The name can't be changed after the disk is created.
Supported characters for the name are a-z, A-Z, 0-9 and _.
The maximum name length is 80 characters.

```yaml
Type: System.String
Parameter Sets: Grant, GrantExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DurationInSecond
Time duration in seconds until the SAS access expires.

```yaml
Type: System.Int32
Parameter Sets: GrantExpanded, GrantViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GrantAccessData
Data used for requesting a SAS.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.IGrantAccessData
Parameter Sets: Grant, GrantViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: GrantViaIdentityExpanded, GrantViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Grant, GrantExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Grant, GrantExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.IGrantAccessData

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### System.String

## ALIASES

## RELATED LINKS

