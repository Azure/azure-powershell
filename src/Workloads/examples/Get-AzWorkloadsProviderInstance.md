### Example 1: {{ Add title here }}
```powershell
Get-AzWorkloadsProviderInstance -ResourceGroupName ad-ams-rg -MonitorName ad-ams
```

```output
Name              ResourceGroupName ProvisioningState ProviderSettingProviderType IdentityType
----              ----------------- ----------------- --------------------------- ------------
Hana-1-test       ad-ams-rg         Failed            SapHana
hana-test-2       ad-ams-rg         Succeeded         SapHana
prov-1            ad-ams-rg         Failed            PrometheusOS
hana-test         ad-ams-rg         Failed            SapHana
SAP-NETWEAVER     ad-ams-rg         Failed            SapNetWeaver
HA3-HANA-HighAvl  ad-ams-rg         Succeeded         SapHana
lh-28022023-host  ad-ams-rg         Failed            SapHana
blahblah-28020223 ad-ams-rg         Succeeded         SapHana
as1-sysdb         ad-ams-rg         Succeeded         SapHana
h2-test           ad-ams-rg         Failed            SapHana
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
Get-AzWorkloadsProviderInstance -ResourceGroupName ad-ams-rg -MonitorName ad-ams -Name hana-test-2
```

```output
Name        ResourceGroupName ProvisioningState ProviderSettingProviderType IdentityType
----        ----------------- ----------------- --------------------------- ------------
hana-test-2 ad-ams-rg         Succeeded         SapHana
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}