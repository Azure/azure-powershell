---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-azaddressprefixset
schema: 2.0.0
---

# Set-AzAddressPrefixSet

## SYNOPSIS
Updates the prefixes in an address prefix set.

## SYNTAX

### ByApplicationSecurityGroupName (Default)
```
Set-AzAddressPrefixSet -ResourceGroupName <String> -ApplicationSecurityGroupName <String> -Name <String>
 -AddressPrefix <String[]> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

### ByAddressPrefixSetObject
```
Set-AzAddressPrefixSet -InputObject <PSAddressPrefixSet> -AddressPrefix <String[]> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByAddressPrefixSetResourceId
```
Set-AzAddressPrefixSet -ResourceId <String> -AddressPrefix <String[]> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
Replaces the IPv4 or IPv6 prefixes in an existing address prefix set.

## EXAMPLES

### Example 1: Update an address prefix set by resource ID
```powershell
$prefixSet = Get-AzAddressPrefixSet -ResourceGroupName "test-rg" -ApplicationSecurityGroupName "test-asg" -Name "test-prefix-set"
Set-AzAddressPrefixSet -ResourceId $prefixSet.Id -AddressPrefix "10.1.0.0/16"
```

Replaces the current prefixes with `10.1.0.0/16`.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddressPrefix
The IPv4 or IPv6 prefixes in CIDR notation.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationSecurityGroupName
The application security group name.

```yaml
Type: String
Parameter Sets: ByApplicationSecurityGroupName
Aliases: ParentName, ParentResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeReference
The change reference resource ID for this resource operation.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The address prefix set to update.

```yaml
Type: PSAddressPrefixSet
Parameter Sets: ByAddressPrefixSetObject
Aliases: AddressPrefixSet

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The address prefix set name.

```yaml
Type: String
Parameter Sets: ByApplicationSecurityGroupName
Aliases: ResourceName, AddressPrefixSetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: ByApplicationSecurityGroupName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The address prefix set resource ID.

```yaml
Type: String
Parameter Sets: ByAddressPrefixSetResourceId
Aliases: AddressPrefixSetId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.Commands.Network.Models.PSAddressPrefixSet

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAddressPrefixSet

## NOTES

## RELATED LINKS
