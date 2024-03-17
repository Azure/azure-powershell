---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/new-azvmwareprivatecloud
schema: 2.0.0
---

# New-AzVMwarePrivateCloud

## SYNOPSIS
Create a private cloud

## SYNTAX

```
New-AzVMwarePrivateCloud -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -NetworkBlock <String> -Sku <String> -Location <String> -ManagementClusterSize <Int32>
 [-AvailabilitySecondaryZone <Int32>] [-AvailabilityStrategy <String>] [-AvailabilityZone <Int32>]
 [-EncryptionStatus <String>] [-ExtendedNetworkBlock <String[]>] [-IdentitySource <IIdentitySource[]>]
 [-IdentityType <String>] [-Internet <String>] [-KeyVaultPropertyKeyName <String>]
 [-KeyVaultPropertyKeyVaultUrl <String>] [-KeyVaultPropertyKeyVersion <String>]
 [-ManagementClusterHost <String[]>] [-NsxtPassword <String>] [-Tag <Hashtable>] [-VcenterPassword <String>]
 [-AcceptEULA] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a private cloud

## EXAMPLES

### Example 1: Create a private cloud
```powershell
New-AzVMwarePrivateCloud -Name azps_test_cloud -ResourceGroupName azps_test_group -NetworkBlock 192.168.48.0/22 -Sku av36 -ManagementClusterSize 3 -Location australiaeast
```

```output
Location      Name            Type                        ResourceGroupName
--------      ----            ----                        -----------------
australiaeast azps_test_cloud Microsoft.AVS/privateClouds azps_test_group
```

Create a private cloud

## PARAMETERS

### -AcceptEULA
AcceptEULAofAVS,legaltermwillpopupwithoutthisparameterprovided

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

### -AsJob
Runthecommandasajob

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

### -AvailabilitySecondaryZone
Thesecondaryavailabilityzonefortheprivatecloud

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityStrategy
Theavailabilitystrategyfortheprivatecloud

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityZone
Theprimaryavailabilityzonefortheprivatecloud

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
TheDefaultProfileparameterisnotfunctional.UsetheSubscriptionIdparameterwhenavailableifexecutingthecmdletagainstadifferentsubscription.

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

### -EncryptionStatus
Statusofcustomermanagedencryptionkey

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedNetworkBlock
ArrayofadditionalnetworksnoncontiguouswithnetworkBlock.Networksmustbeuniqueandnon-overlappingacrossVNetinyoursubscription,on-premise,andthisprivateCloudnetworkBlockattribute.MakesuretheCIDRformatconformsto(A.B.C.D/X).

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentitySource
vCenterSingleSignOnIdentitySourcesToconstruct,seeNOTESsectionforIDENTITYSOURCEpropertiesandcreateahashtable.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IIdentitySource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Thetypeofidentityusedfortheprivatecloud.Thetype'SystemAssigned'referstoanimplicitlycreatedidentity.Thetype'None'willremoveanyidentitiesfromthePrivateCloud.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Internet
Connectivitytointernetisenabledordisabled

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultPropertyKeyName
Thenameofthekey.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultPropertyKeyVaultUrl
TheURLofthevault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultPropertyKeyVersion
Theversionofthekey.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resourcelocation

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

### -ManagementClusterHost
Thehosts

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementClusterSize
Theclustersize

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

### -Name
Nameoftheprivatecloud

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PrivateCloudName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkBlock
TheblockofaddressesshouldbeuniqueacrossVNetinyoursubscriptionaswellason-premise.MakesuretheCIDRformatisconformedto(A.B.C.D/X)whereA,B,C,Darebetween0and255,andXisbetween0and22

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

### -NoWait
Runthecommandasynchronously

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

### -NsxtPassword
Optionally,settheNSX-TManagerpasswordwhentheprivatecloudiscreated

```yaml
Type: System.String
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
Thenameoftheresourcegroup.Thenameiscaseinsensitive.

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

### -Sku
ThenameoftheSKU.

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
TheIDofthetargetsubscription.

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

### -Tag
Resourcetags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VcenterPassword
Optionally,setthevCenteradminpasswordwhentheprivatecloudiscreated

```yaml
Type: System.String
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IPrivateCloud

## NOTES

## RELATED LINKS
