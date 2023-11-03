### Example 1: Lists eligible SKUs for Kusto resource provider by Azure region 
```powershell
Get-AzKustoSku -SubscriptionId xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -Location "East US"
```

```output
Location Name                        ResourceType Tier
-------- ----                        ------------ ----
         Dev(No SLA)_Standard_D11_v2 clusters     Basic
         Dev(No SLA)_Standard_E2a_v4 clusters     Basic
         Standard_D11_v2             clusters     Standard
         Standard_D12_v2             clusters     Standard
         Standard_D13_v2             clusters     Standard
         Standard_D14_v2             clusters     Standard
         Standard_D32d_v4            clusters     Standard
         Standard_DS13_v2+1TB_PS     clusters     Standard
         Standard_DS13_v2+2TB_PS     clusters     Standard
         Standard_DS14_v2+3TB_PS     clusters     Standard
         Standard_DS14_v2+4TB_PS     clusters     Standard
         Standard_L8s_v2             clusters     Standard
         Standard_L16s_v2            clusters     Standard
         Standard_E64i_v3            clusters     Standard
         Standard_E80ids_v4          clusters     Standard
         Standard_E2a_v4             clusters     Standard
         Standard_E4a_v4             clusters     Standard
         Standard_E8a_v4             clusters     Standard
         Standard_E16a_v4            clusters     Standard
         Standard_E8as_v4+1TB_PS     clusters     Standard
         Standard_E8as_v4+2TB_PS     clusters     Standard
         Standard_E16as_v4+3TB_PS    clusters     Standard
         Standard_E16as_v4+4TB_PS    clusters     Standard
         Standard_E8as_v5+1TB_PS     clusters     Standard
         Standard_E8as_v5+2TB_PS     clusters     Standard
         Standard_E16as_v5+3TB_PS    clusters     Standard
         Standard_E16as_v5+4TB_PS    clusters     Standard
         Standard_E2ads_v5           clusters     Standard
         Standard_E4ads_v5           clusters     Standard
         Standard_E8ads_v5           clusters     Standard
         Standard_E16ads_v5          clusters     Standard
         Standard_E8s_v4+1TB_PS      clusters     Standard
         Standard_E8s_v4+2TB_PS      clusters     Standard
         Standard_E16s_v4+3TB_PS     clusters     Standard
         Standard_E16s_v4+4TB_PS     clusters     Standard
         Standard_E2d_v4             clusters     Standard
         Standard_E4d_v4             clusters     Standard
         Standard_E8d_v4             clusters     Standard
         Standard_E16d_v4            clusters     Standard
         Standard_E2d_v5             clusters     Standard
         Standard_E4d_v5             clusters     Standard
         Standard_E8d_v5             clusters     Standard
         Standard_E16d_v5            clusters     Standard
```

Lists eligible SKUs for Kusto resource provider by Azure region 

