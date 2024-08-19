---
external help file: Az.Nginx-help.xml
Module Name: Az.Nginx
online version: https://learn.microsoft.com/powershell/module/az.nginx/get-aznginxcertificate
schema: 2.0.0
---

# Get-AzNginxCertificate

## SYNOPSIS
Get a certificate of given NGINX deployment

## SYNTAX

### List (Default)
```
Get-AzNginxCertificate -DeploymentName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNginxCertificate -DeploymentName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNginxCertificate -InputObject <INginxIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a certificate of given NGINX deployment

## EXAMPLES

### Example 1: List all certificates under a NGINX deployment
```powershell
Get-AzNginxCertificate -DeploymentName nginx-test -ResourceGroupName nginx-test-rg
```

```output
Location      Name
--------      ----
westcentralus cert
westcentralus cert1
```

This command lists all certificates under a NGINX deployment.

### Example 2: Get a certificate
```powershell
Get-AzNginxCertificate -DeploymentName nginx-test -Name cert -ResourceGroupName nginx-test-rg
```

```output
Location      Name
--------      ----
westcentralus cert
```

This command gets a certificate.

## PARAMETERS

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

### -DeploymentName
The name of targeted NGINX deployment

```yaml
Type: System.String
Parameter Sets: List, Get
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.INginxIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of certificate

```yaml
Type: System.String
Parameter Sets: Get
Aliases: CertificateName

Required: True
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
Parameter Sets: List, Get
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
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.INginxIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.INginxCertificate

## NOTES

## RELATED LINKS
