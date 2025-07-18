---
external help file: Az.PureStorageBlock-help.xml
Module Name: Az.PureStorageBlock
online version: https://learn.microsoft.com/powershell/module/az.purestorageblock/invoke-azpurestorageblockfinalizestoragepoolavconnection
schema: 2.0.0
---

# Invoke-AzPureStorageBlockFinalizeStoragePoolAvConnection

## SYNOPSIS
Finalize an already started AVS connection to a specific AVS SDDC

## SYNTAX

### FinalizeExpanded (Default)
```
Invoke-AzPureStorageBlockFinalizeStoragePoolAvConnection -ResourceGroupName <String> -StoragePoolName <String>
 [-SubscriptionId <String>] [-ServiceInitializationDataEnc <String>]
 [-ServiceInitializationDataServiceAccountPassword <SecureString>]
 [-ServiceInitializationDataServiceAccountUsername <String>]
 [-ServiceInitializationDataVSphereCertificate <String>] [-ServiceInitializationDataVSphereIP <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### FinalizeViaJsonString
```
Invoke-AzPureStorageBlockFinalizeStoragePoolAvConnection -ResourceGroupName <String> -StoragePoolName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### FinalizeViaJsonFilePath
```
Invoke-AzPureStorageBlockFinalizeStoragePoolAvConnection -ResourceGroupName <String> -StoragePoolName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Finalize
```
Invoke-AzPureStorageBlockFinalizeStoragePoolAvConnection -ResourceGroupName <String> -StoragePoolName <String>
 [-SubscriptionId <String>] -Property <IStoragePoolFinalizeAvsConnectionPost> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### FinalizeViaIdentityExpanded
```
Invoke-AzPureStorageBlockFinalizeStoragePoolAvConnection -InputObject <IPureStorageBlockIdentity>
 [-ServiceInitializationDataEnc <String>] [-ServiceInitializationDataServiceAccountPassword <SecureString>]
 [-ServiceInitializationDataServiceAccountUsername <String>]
 [-ServiceInitializationDataVSphereCertificate <String>] [-ServiceInitializationDataVSphereIP <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### FinalizeViaIdentity
```
Invoke-AzPureStorageBlockFinalizeStoragePoolAvConnection -InputObject <IPureStorageBlockIdentity>
 -Property <IStoragePoolFinalizeAvsConnectionPost> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Finalize an already started AVS connection to a specific AVS SDDC

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IPureStorageBlockIdentity
Parameter Sets: FinalizeViaIdentityExpanded, FinalizeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Finalize operation

```yaml
Type: System.String
Parameter Sets: FinalizeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Finalize operation

```yaml
Type: System.String
Parameter Sets: FinalizeViaJsonString
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

### -PassThru
Returns true when the command succeeds

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

### -Property
FinalizeAvsConnection payload information, either encoded or explicit

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IStoragePoolFinalizeAvsConnectionPost
Parameter Sets: Finalize, FinalizeViaIdentity
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
Parameter Sets: FinalizeExpanded, FinalizeViaJsonString, FinalizeViaJsonFilePath, Finalize
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceInitializationDataEnc
Encoded AVS connection information

```yaml
Type: System.String
Parameter Sets: FinalizeExpanded, FinalizeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceInitializationDataServiceAccountPassword
Service account password

```yaml
Type: System.Security.SecureString
Parameter Sets: FinalizeExpanded, FinalizeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceInitializationDataServiceAccountUsername
Service account username

```yaml
Type: System.String
Parameter Sets: FinalizeExpanded, FinalizeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceInitializationDataVSphereCertificate
AVS instance's vSphere certificate

```yaml
Type: System.String
Parameter Sets: FinalizeExpanded, FinalizeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceInitializationDataVSphereIP
AVS instance's vSphere IP address

```yaml
Type: System.String
Parameter Sets: FinalizeExpanded, FinalizeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StoragePoolName
Name of the storage pool

```yaml
Type: System.String
Parameter Sets: FinalizeExpanded, FinalizeViaJsonString, FinalizeViaJsonFilePath, Finalize
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
Parameter Sets: FinalizeExpanded, FinalizeViaJsonString, FinalizeViaJsonFilePath, Finalize
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

### Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IPureStorageBlockIdentity

### Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IStoragePoolFinalizeAvsConnectionPost

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
