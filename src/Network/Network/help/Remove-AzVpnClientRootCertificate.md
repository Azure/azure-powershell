---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
ms.assetid: 5D857FF6-A27D-4031-948D-8A69D24B4AD4
online version: https://docs.microsoft.com/powershell/module/az.network/remove-azvpnclientrootcertificate
schema: 2.0.0
---

# Remove-AzVpnClientRootCertificate

## SYNOPSIS
Removes an existing VPN client root certificate.

## SYNTAX

```
Remove-AzVpnClientRootCertificate -VpnClientRootCertificateName <String> -VirtualNetworkGatewayName <String>
 -ResourceGroupName <String> -PublicCertData <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzVpnClientRootCertificate** cmdlet removes the specified root certificate from a virtual network gateway.
Root certificates are X.509 certificates that identify your Root Certification Authority: all other certificates used on the gateway trust the root certificate.
If you remove a root certificate computers that use the certificate for authentication purposes will no longer be able to connect to the gateway.
When you use **Remove-AzVpnClientRootCertificate**, you must supply both the certificate name and a text representation of the certificate data.
For more information about the text representation of a certificate see the *PublicCertData* parameter description.

## EXAMPLES

### Example 1: Remove a client root certificate from a virtual network gateway
```powershell
PS C:\>$Text = Get-Content -Path "C:\Azure\Certificates\ExportedCertificate.cer"
PS C:\> $CertificateText = for ($i=1; $i -lt $Text.Length -1 ; $i++){$Text[$i]}
PS C:\> Remove-AzVpnClientRootCertificate -PublicCertData $CertificateText -ResourceGroupName "ContosoResourceGroup" -VirtualNetworkGatewayName "ContosoVirtualGateway" -VpnClientRootCertificateName "ContosoRootCertificate"
```

This example removes a client root certificate named ContosoRootCertificate from the virtual network gateway ContosoVirtualGateway.
The first command uses the **Get-Content** cmdlet to get a previously-exported text representation of the certificate; this text representation is stored in a variable named $Text.
The second command then uses a for loop to extract all the text in $Text except for the first line and the last line.
This extracted text is stored in a variable named $CertificateText.
The third command uses the information stored in the $CertificateText variable along with the **Remove-AzVpnClientRootCertificate** cmdlet to remove the certificate from the gateway.

## PARAMETERS

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

### -PublicCertData
Specifies the text representation of the root certificate to be removed.
To obtain the text representation, export your certificate in .cer format (using Base64) encoding, then open the resulting file in a text editor.
You should see output similar to the following (note that the actual output will contain many more lines of text than the abbreviated sample shown here):
----- BEGIN CERTIFICATE -----
MIIC13FAAXC3671Auij9HHgUNEW8343NMJklo09982CVVFAw8w
----- END CERTIFICATE -----
The PublicCertData is made up of all the lines between the first line (----- BEGIN CERTIFICATE -----) and the last line (----- END CERTIFICATE -----) in the file.
You can retrieve the PublicCertData using Windows PowerShell commands similar to this:
$Text = Get-Content -Path "C:\Azure\Certificates\ExportedCertificate.cer"
$CertificateText = for ($i=1; $i -lt $Text.Length -1 ; $i++){$Text\[$i\]}

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

### -ResourceGroupName
Specifies the name of the resource group that the virtual network gateway is assigned to.
Resource groups categorize items to help simplify inventory management and general Azure administration.

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

### -VirtualNetworkGatewayName
Specifies the name of the virtual network gateway that the certificate is removed from.

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

### -VpnClientRootCertificateName
Specifies the name of the client root certificate that this cmdlet removes.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Add-AzVpnClientRootCertificate](./Add-AzVpnClientRootCertificate.md)

[Get-AzVpnClientRootCertificate](./Get-AzVpnClientRootCertificate.md)

[New-AzVpnClientRootCertificate](./New-AzVpnClientRootCertificate.md)


