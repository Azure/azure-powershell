---
external help file:
Module Name: Az.OracleDatabase
online version: https://learn.microsoft.com/powershell/module/az.oracledatabase/get-azoracledatabasednsprivateview
schema: 2.0.0
---

# Get-AzOracleDatabaseDnsPrivateView

## SYNOPSIS
Get a DnsPrivateView

## SYNTAX

### List (Default)
```
Get-AzOracleDatabaseDnsPrivateView -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOracleDatabaseDnsPrivateView -Location <String> -Ocid <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleDatabaseDnsPrivateView -InputObject <IOracleDatabaseIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzOracleDatabaseDnsPrivateView -LocationInputObject <IOracleDatabaseIdentity> -Ocid <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a DnsPrivateView

## EXAMPLES

### Example 1: Gets a list of the DNS Private Views by location
```powershell
Get-AzOracleDatabaseDnsPrivateView -Location "eastus"
```

```output
Name                                                                               SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                                                               ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
ocid1.dnsview.oc1.iad.aaaaaaaaytqscqgo3vowvligvkeaiqozwywcbkm336keyzz34xiorgfximza                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaalf3jpv4bmwdg6nxw7ciudrb3smln6a46h7asgrwoironcxuoslea                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaags4sek6p7ocgs5sjarfm26dgmz23yegxxwqk4aowebismrbbgm6q                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaazmyd4s4uwgqfccdrhldyei7gdwvmckqe2gcf7rqyzx5745rqcz7a                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaarnrvhq52proqtx2dxwmkktnelvh37dfplek7rfvba2eoasl5ljla                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaaamjmgxzpu5phmeukw2awzkomljqewcnc3xia47hwq7vwzizb3vyq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaasfkjzbc3yfkh7iefqp5wgo3rw7waujjh4thx6c63bcjxsr7xgunq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaahh7hn6igc2h3hjb7yzbp6qvxdlueuptw3tqsevgd6sqmck2t67xq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaa4d4te57r5kd2uiwz3nrsrupyxoq4ld6qe7llj4thyqryh4ptt7ta                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaan3zpjnyy7hzjbsw4am75qb4r56twlyhzdachelvnvfo4t2gmg3nq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaa3jibcq6frlsxtfsgvncilhpn655j6wrj3dhbvfstot2eufmjlh6q                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaae33wuskmomxnyus5ih3dvcp5vzocs7rjmwyjy3ob5nroyltk3n4a                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaaa7u7luleugifyox5x6wxfcox6pqhqh7m4arfddastzhcby7ywela                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaazbo3ppu46obfuvioi3ktwjzlg2d2fmnbkx7vcvpcxxxyzccsg7cq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaaebd3s6zefr26dbsvxtbwnaf6ryi5sm7jwhfw7l2xcczut67pp6zq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaadqjwjdlyrljtif3tzqeuhljlt7hiitedjobr2zf2oac2amylboyq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaao3gw7b3xroaixkhbhjq5eoppwc243vd3hl66wjkiizpohtiylrta                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaam6mulme3e6ib2oewncnm7ziwiegzvmqprk3aphxr7hfzvotcojea                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaa2fm5l2pzpuj53f6xwsbno5kh2ozthcibmwwlz4r44l6ds4oirjvq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaakdvcobjg63flojxhajg6frjuulzvm3ujwvlq5md72aioxwhztp4a                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaadnfesiej4lwha3bqamzc5c5jbc52fviao5dsz5t7gymd2dhbf5xa                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaacnlnbnfwl4yqjmc6duyff24oarf53rx4t45gmxebo5dd3bo2spmq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaasnob6ag6wg6pmacj43cenkffel4ufxi7c2zk2s2rm47wu4zhmzjq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaacl3b74znruhwqzliqny3kh522bc2v3kx4j6egx7gpz3jj6prmq7a                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaawwky4j2igeyhsiiymg4ck3asdtbdtodasiwmix5gpmtz6tdsk2sa                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaabshazqhwh6pfue2t7x4wnvmu333ug7kv7goccwy76ek2fdhw7frq                                                                                                                                                
ocid1.dnsview.oc1.iad.amaaaaaanirvylqavprecsjhqzozhzhubrv5zh2zkc7rbzebv5htjaowyhpq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaacn72hqgq74txfgtuwo3ddlgkspw2vz4eldxrme7texgsugxp5x3a                                                                                                                                                
ocid1.dnsview.oc1.iad.amaaaaaanirvylqahnekoidsqbfml7bpjcujxtreo24uesvwahbixqcvrdwa                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaahjczll6evlberotb4inm7yihkpj2nzie3zcicxidot3wucc634eq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaa6ewmoocgnxx526ixpfx6vtkf6rn247zkfdrsfyvesicigspdkona                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaalambtijdib5a3nldvzzxet67vbvdynj3uzsffm23vej25vidgtqq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaaar3sf4g3t5n37ak7jdfjdlgkxon7vqxrantbh66a5zdaf4pmsj3q                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaa7zpfwvaipbz6jhjlkr5rpm2pmwdjckigattvcv2bblnhbi6wbfca                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaae42p4btkcvdoe7q44zq5og6wvw7bpse2mpkiancqpdvtjf6zibtq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaai6hsw24kp35c2nln6za6n2p5co4nibufpa2l4uooanlnjqalmglq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaaaajoznx7ifv4jvbadj3ccja7yiahyl4jocliuuyddkin2gbp5nua                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaa63j2mvogwykcxu4jnjlfcwxqlunu3ceiby3izafruyosv4j4ghpa                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaaboxvqwa65555p7u4g3yr55kamhj5hzd676w53c4xrokwfvdh25sq                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaainzhp3afn4raviq24b6x3hkzzokn2cpqthig7iat2uh3zya72o2a                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaahd6rc62hisdbgprchfc3oyt5x3vrvu6acaejhi6zxr2os6viwhbq
```

Gets a list of the DNS Private Views by location.
For more information, execute `Get-Help Get-AzOracleDatabaseDnsPrivateView`

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Ocid
DnsPrivateView OCID

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
Aliases: Dnsprivateviewocid

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
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IDnsPrivateView

## NOTES

## RELATED LINKS

