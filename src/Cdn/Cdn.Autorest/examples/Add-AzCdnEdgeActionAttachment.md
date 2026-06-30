### Example 1: Add an Edge Action Attachment
```powershell
Add-AzCdnEdgeActionAttachment -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -AttachedResourceId "/subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/profiles/testprofile/endpoints/endpoint001"
```

```output
EdgeActionId : 12345678-1234-1234-1234-123456789012
```

Add an Edge Action Attachment to link an edge action with a CDN resource using its full resource ID