---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azaddressprefixset
schema: 2.0.0
---

# New-AzAddressPrefixSet

## SYNOPSIS
Creates an address prefix set under an application security group.

## SYNTAX

### ByApplicationSecurityGroupName (Default)
```
New-AzAddressPrefixSet -ResourceGroupName <String> -ApplicationSecurityGroupName <String> -Name <String>
 -AddressPrefix <String[]> [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

### ByApplicationSecurityGroupObject
```
New-AzAddressPrefixSet -ApplicationSecurityGroup <PSApplicationSecurityGroup> -Name <String>
 -AddressPrefix <String[]> [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

### ByApplicationSecurityGroupResourceId
```
New-AzAddressPrefixSet -ApplicationSecurityGroupResourceId <String> -Name <String> -AddressPrefix <String[]>
 [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
Creates an address prefix set containing one or more IPv4 or IPv6 prefixes in Classless Inter-Domain Routing (CIDR) notation.

## EXAMPLES

### Example 1: Create an address prefix set
```powershell
New-AzAddressPrefixSet -ResourceGroupName "test-rg" -ApplicationSecurityGroupName "test-asg" -Name "test-prefix-set" -AddressPrefix "10.0.0.0/16", "2001:db8::/32"
```

Creates an address prefix set with IPv4 and IPv6 prefixes under the specified application security group.

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

### -ApplicationSecurityGroup
The application security group.

```yaml
Type: PSApplicationSecurityGroup
Parameter Sets: ByApplicationSecurityGroupObject
Aliases: ParentObject

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ApplicationSecurityGroupResourceId
The application security group resource ID.

```yaml
Type: String
Parameter Sets: ByApplicationSecurityGroupResourceId
Aliases: ParentResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -Force
Overwrites an existing address prefix set with the same name without prompting for confirmation.

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

### -Name
The address prefix set name.

```yaml
Type: String
Parameter Sets: (All)
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

### Microsoft.Azure.Commands.Network.Models.PSApplicationSecurityGroup

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAddressPrefixSet

## NOTES

## RELATED LINKS
