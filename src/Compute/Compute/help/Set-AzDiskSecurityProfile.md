---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/set-azdisksecurityprofile
schema: 2.0.0
---

# Set-AzDiskSecurityProfile

## SYNOPSIS
Set SecurityProfile on managed disk

## SYNTAX

```
Set-AzDiskSecurityProfile [-Disk] <PSDisk> -SecurityType <String> [-SecureVMDiskEncryptionSet <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Set the SecurityProfile on managed disks.

## EXAMPLES

### Example 1
```powershell
$diskconfig = New-AzDiskConfig -DiskSizeGB 10 -AccountType PremiumLRS -OsType Windows -CreateOption FromImage;
$image = '/subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.Compute/images/TestImage123';
$diskconfig = Set-AzDiskImageReference -Disk $diskconfig -Id $image -Lun 0;
$diskconfig = Set-AzDiskSecurityProfile -Disk $diskconfig -SecurityType "TrustedLaunch";
$disk = New-AzDisk -ResourceGroupName 'ResourceGroup01' -DiskName 'Disk01' -Disk $diskconfig;
# $disk.Properties.SecurityProfile.SecurityType == "TrustedLaunch";
```

Customers can set the SecurityType of managed Disks.

### Example 2: Create a Disk with a Disk Encrption Set with the encryption type of ConfidentialVM_DiskEncryptedWithCustomerKey
```powershell
$Location = "northeurope";
$KeyVaultName = "val" + $rgname;
$KeyName = "key" + $rgname;
$DesName= "des" + $rgname;
$KeySize = 3072;

$SecurePassword = "Password" | ConvertTo-SecureString -AsPlainText -Force;
$User = "Username";
$Cred = New-Object System.Management.Automation.PSCredential ($User, $SecurePassword);

New-AzKeyVault -Name $KeyVaultName -Location $Location -ResourceGroupName $ResourceGroupName -Sku Premium -EnablePurgeProtection -EnabledForDiskEncryption;

# Add Key vault Key
Add-AzKeyVaultKey -VaultName $KeyVaultName -Name $KeyName -Size $KeySize -KeyOps wrapKey,unwrapKey -KeyType RSA -Destination HSM -Exportable -UseDefaultCVMPolicy;

# Capture Keyvault and key details
$KeyVaultId = (Get-AzKeyVault -VaultName $KeyVaultName -ResourceGroupName $ResourceGroupName).ResourceId;
$KeyUrl = (Get-AzKeyVaultKey -VaultName $KeyVaultName -KeyName $KeyName).Key.Kid;

# Create new DES Config and DES
$diskEncryptionType = "ConfidentialVmEncryptedWithCustomerKey";
$desConfig = New-AzDiskEncryptionSetConfig -Location $Location -SourceVaultId $keyvaultId -KeyUrl $keyUrl -IdentityType SystemAssigned -EncryptionType $diskEncryptionType;
New-AzDiskEncryptionSet -ResourceGroupName $ResourceGroupName -Name $DesName -DiskEncryptionSet $desConfig;
$diskencset = Get-AzDiskEncryptionSet -ResourceGroupName $ResourceGroupName -Name $desName;

# Assign DES Access Policy to key vault
$desIdentity = (Get-AzDiskEncryptionSet -Name $DesName -ResourceGroupName $ResourceGroupName).Identity.PrincipalId;
Set-AzKeyVaultAccessPolicy -VaultName $KeyVaultName -ResourceGroupName $ResourceGroupName -ObjectId $desIdentity -PermissionsToKeys wrapKey,unwrapKey,get -BypassObjectIdValidation;

$diskSecurityType = "ConfidentialVM_DiskEncryptedWithCustomerKey";
$diskName = "diskname";
$diskconfig = New-AzDiskConfig -AccountType Premium_LRS -OsType Windows -CreateOption FromImage -Location $Location;
$diskconfig = Set-AzDiskImageReference -Disk $diskconfig -Id "/Subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/Providers/Microsoft.Compute/Locations/northeurope/Publishers/MicrosoftWindowsServer/ArtifactTypes/VMImage/Offers/windows-cvm/Skus/2019-datacenter-cvm/Versions/latest";
$diskconfig = Set-AzDiskSecurityProfile -Disk $diskconfig -SecurityType $diskSecurityType -SecureVMDiskEncryptionSet $diskencset.id;
New-AzDisk -ResourceGroupName $ResourceGroupName -DiskName $diskName -Disk $diskconfig;
$disk = Get-AzDisk -ResourceGroupName $ResourceGroupName -DiskName $diskName;
# Verify the SecurityType value.
# $disk.Properties.SecurityProfile.SecurityType returns "ConfidentialVM";
```

### Example 3: Set the SecurityType to Standard to avoid TrustedLaunch defaulting.
```powershell
$rgname = <Resource Group Name>;
$loc = <Azure Region>;
New-AzResourceGroup -Name $rgname -Location $loc -Force;
$securityTypeStnd = "Standard";

# Standard SecurityType
$diskconfig = New-AzDiskConfig -Location $loc -DiskSizeGB 1 -AccountType "Premium_LRS" -OsType "Windows" -CreateOption "Empty" -HyperVGeneration "V1";
$diskname = "diskstnd" + $rgname;
$diskconfig = Set-AzDiskSecurityProfile -Disk $diskconfig -SecurityType $securityTypeStnd;
$diskPr = New-AzDisk -ResourceGroupName $rgname -DiskName $diskname -Disk $diskconfig;
$disk = Get-AzDisk -ResourceGroupName $rgname -DiskName $diskname;
# Verify $disk.SecurityProfile is null;
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Disk
Disk Security Profile

```yaml
Type: Microsoft.Azure.Commands.Compute.Automation.Models.PSDisk
Parameter Sets: (All)
Aliases: DiskSecurityProfile

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -SecureVMDiskEncryptionSet
ResourceId of the disk encryption set to use for enabling encryption at rest.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SecurityType
Security Type of Disk

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Compute.Automation.Models.PSDisk

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSDisk

## NOTES

## RELATED LINKS
