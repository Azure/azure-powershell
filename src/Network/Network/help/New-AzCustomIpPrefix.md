---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azcustomipprefix
schema: 2.0.0
---

# New-AzCustomIpPrefix

## SYNOPSIS
Creates a CustomIpPrefix resource

## SYNTAX

```
New-AzCustomIpPrefix -Name <String> -ResourceGroupName <String> -Location <String> -Cidr <String>
 [-Asn <String>] [-Geo <String>] [-SignedMessage <String>] [-AuthorizationMessage <String>]
 [-ExpressRouteAdvertise] [-CustomIpPrefixParent <PSCustomIpPrefix>] [-IsParent] [-Zone <String[]>]
 [-Tag <Hashtable>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzCustomIpPrefix** cmdlet creates a CustomIpPrefix resource.

## EXAMPLES

### Example 1
```powershell
$myCustomIpPrefix = New-AzCustomIpPrefix -Name $prefixName -ResourceGroupName $rgName -Cidr "40.40.40.0/24" -Location westus2 -Zone 1,2,3 -AuthorizationMessage $authorizationMessage -SignedMessage $signedMessage
```

This command kicks off the provisioning process for a new zone-redundant IPv4 Custom IP Prefix resource with name $prefixName in resource group $rgName with a CIDR of 40.40.40.0/24 in West US 2 region.  Note the AuthorizationMessage is a contactenated string (containing the subscription ID, CIDR, and Route Origin Authorization expiration date) and the SignedMessage is the same string signed by X509 certificate offline. 

### Example 2
```powershell
$myV4ParentPrefix = New-AzCustomIpPrefix -Name $prefixName -ResourceGroupName $rgName -Cidr "40.40.40.0/24" -Location westus2 -IsParent -AuthorizationMessage $authorizationMessage -SignedMessage $signedMessage
```

This command kicks off the provisioning process for a new Parent IPv4 Custom IP Prefix resource with name $prefixName in resource group $rgName with a CIDR of 40.40.40.0/24.

### Example 3
```powershell
$myV4ChildIpPrefix = New-AzCustomIpPrefix -Name $prefixName -ResourceGroupName $rgName -Cidr "40.40.40.0/25" -Location westus2 -CustomIpPrefixParent $myV4ParentPrefix
```

This command kicks off the provisioning process for a new Child IPv4 Custom IP Prefix resource with name $prefixName in resource group $rgName with a CIDR of 40.40.40.0/25. Its parent prefix is $myV4ParentPrefix.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -Asn
The customIpPrefix ASN code.

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

### -AuthorizationMessage
Authorization message for WAN validation.

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

### -Cidr
The CustomIpPrefix CIDR.

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

### -CustomIpPrefixParent
Parent CustomIpPrefix of resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSCustomIpPrefix
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -ExpressRouteAdvertise
Using expressRoute advertise.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Geo
The customIpPrefix GEO code.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: AFRI, APAC, AQ, EURO, LATAM, ME, NAM, OCEANIA

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IsParent
Denotes that resource is being created as a Parent CustomIpPrefix

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

### -Location
The CustomIpPrefix location.

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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

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

### -SignedMessage
Signed message for WAN validation.

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

### -Tag
A hashtable which represents resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Zone
A list of availability zones denoting the IP allocated for the resource needs to come from.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
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

### System.String

### System.String[]

### System.Collections.Hashtable

### Microsoft.Azure.Commands.Network.Models.PSCustomIpPrefix

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSCustomIpPrefix

## NOTES

## RELATED LINKS

[Get-AzCustomIpPrefix](./Get-AzCustomIpPrefix.md)

[Remove-AzCustomIpPrefix](./Remove-AzCustomIpPrefix.md)

[Update-AzCustomIpPrefix](./Update-AzCustomIpPrefix.md)
