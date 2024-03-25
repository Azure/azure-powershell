---
external help file: Az.MobileNetwork-help.xml
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/update-azmobilenetworkbulksimuploadencrypted
schema: 2.0.0
---

# Update-AzMobileNetworkBulkSimUploadEncrypted

## SYNOPSIS
Bulk upload SIMs in encrypted form to a SIM group.
The SIM credentials must be encrypted.

## SYNTAX

### BulkViaIdentityExpanded (Default)
```
Update-AzMobileNetworkBulkSimUploadEncrypted -InputObject <IMobileNetworkIdentity> -AzureKeyIdentifier <Int32>
 -EncryptedTransportKey <String> -SignedTransportKey <String> -Sim <ISimNameAndEncryptedProperties[]>
 -VendorKeyFingerprint <String> -Version <Int32> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BulkExpanded
```
Update-AzMobileNetworkBulkSimUploadEncrypted -ResourceGroupName <String> -SimGroupName <String>
 [-SubscriptionId <String>] -AzureKeyIdentifier <Int32> -EncryptedTransportKey <String>
 -SignedTransportKey <String> -Sim <ISimNameAndEncryptedProperties[]> -VendorKeyFingerprint <String>
 -Version <Int32> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Bulk upload SIMs in encrypted form to a SIM group.
The SIM credentials must be encrypted.

## EXAMPLES

### Example 1: Bulk uploading Sims using vendor specific keys
```powershell
$sim1 = @{Name = "BulkSim01"; InternationalMobileSubscriberIdentity = "0000000001"; AuthenticationKey = "00000000000000000000000000000001"; OperatorKeyCode = "00000000000000000000000000000001"}
$sim2 = @{Name = "BulkSim02"; InternationalMobileSubscriberIdentity = "0000000002"; AuthenticationKey = "00000000000000000000000000000002"; OperatorKeyCode = "00000000000000000000000000000002"}
$sims = @($sim1,$sim2)
Update-AzMobileNetworkBulkSimUploadEncrypted -ResourceGroupName rf4-pctt-env-1 -SimGroupName SimGroup01 -Sim $sims -AzureKeyIdentifier 123 -EncryptedTransportKey 123 -SignedTransportKey 456 -VendorKeyFingerprint 123 -Version 1
```

Bulk upload SIMs in encrypted form to a SIM group using the Vendor specific keys.

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

### -AzureKeyIdentifier
An identifier for the Azure SIM onboarding public key used for encrypted upload.

```yaml
Type: System.Int32
Parameter Sets: (All)
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

### -EncryptedTransportKey
The transport key used for encrypting SIM credentials, encrypted using the SIM onboarding public key.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity
Parameter Sets: BulkViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: BulkExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SignedTransportKey
The encrypted transport key, signed using the SIM vendor private key.

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

### -Sim
A list of SIMs to upload, with encrypted properties.
To construct, see NOTES section for SIM properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.ISimNameAndEncryptedProperties[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SimGroupName
The name of the SIM Group.

```yaml
Type: System.String
Parameter Sets: BulkExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: BulkExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VendorKeyFingerprint
The fingerprint of the SIM vendor public key.
The private counterpart is used for signing the encrypted transport key.

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

### -Version
The upload file format version.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.IAsyncOperationStatus

## NOTES

## RELATED LINKS
