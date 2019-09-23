---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Websites.dll-Help.xml
Module Name: Az.Websites
schema: 2.0.0
---

# Add-AzWebAppAccessRestriction

## SYNOPSIS
Adds Access Restiction settings to an Azure Web App.

## SYNTAX

### IpAddressParameterSet
```
Add-AzWebAppAccessRestriction [-ResourceGroupName] <String> [-Name] <String> -RuleName <String>
 [-Description <String>] -Priority <Int32> -Action <String> [-SlotName <String>] [-TargetScmSite]
 -IpAddress <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SubnetParameterSet
```
Add-AzWebAppAccessRestriction [-ResourceGroupName] <String> [-Name] <String> -RuleName <String>
 [-Description <String>] -Priority <Int32> -Action <String> [-SlotName <String>] [-TargetScmSite]
 -Subnet <String> [-VirtualNetworkName <String>] [-IgnoreMissingServiceEndpoint]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzWebAppAccessRestriction** cmdlet add Access Restriction settings to an Azure Web App.

## EXAMPLES

### Example 1: Add IpAddress Access Restriction to a Web App from a resource group
```
PS C:\>Add-AzWebAppAccessRestriction -ResourceGroupName "Default-Web-WestUS" -Name "ContosoSite" 
-RuleName IpRule -Priority 200 -Action Allow -IpAddress 10.10.0.0/8
```

This command adds an access restriction setting with priority 200 and ip range to a Web App named ContosoSite that belongs to the resource group Default-Web-WestUS.

### Example 2: Add Subnet Service Endpoint Access Restriction to a Web App from a resource group
```
PS C:\>Add-AzWebAppAccessRestriction -ResourceGroupName "Default-Web-WestUS" -Name "ContosoSite" 
-RuleName SubnetRule -Priority 300 -Action Allow -Subnet appgw-subnet -VirtualNetworkName corp-vnet
```

This command adds an access restriction setting with priority 300 and with subnet appgw-subnet in corp-vnet to a Web App named ContosoSite that belongs to the resource group Default-Web-WestUS.


## PARAMETERS

### -Action
Allow or Deny rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Allow, Deny

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -Description
Access Restriction description.

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

### -IgnoreMissingServiceEndpoint
Specify if Service Endpoint registration at Subnet should be validated.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SubnetParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpAddress
Ip Address v4 or v6 CIDR range. E.g.: 192.168.0.0/24

```yaml
Type: System.String
Parameter Sets: IpAddressParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
WebApp Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Priority
Access Restriction priority. E.g.: 500.

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

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RuleName
Access Restriction rule name. E.g.: DeveloperWorkstation.

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

### -SlotName
Deployment Slot name.

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

### -Subnet
Name of Subnet (requires Virtual Network Name) or ResourceId of Subnet.

```yaml
Type: System.String
Parameter Sets: SubnetParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetScmSite
Rule is aimed for Main site or Scm site.

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

### -VirtualNetworkName
Name of Virtual Network.

```yaml
Type: System.String
Parameter Sets: SubnetParameterSet
Aliases:

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

## OUTPUTS

### Microsoft.Azure.Commands.WebApps.Models.PSAccessRestrictionSettings

## NOTES

## RELATED LINKS

[Set-AzWebAppAccessRestriction](./Set-AzWebAppAccessRestriction.md)

[Get-AzWebAppAccessRestriction](./Get-AzWebAppAccessRestriction.md)

[Remove-AzWebAppAccessRestriction](./Remove-AzWebAppAccessRestriction.md)
