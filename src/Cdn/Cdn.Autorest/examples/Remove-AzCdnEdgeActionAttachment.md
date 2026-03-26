### Example 1: Remove an Edge Action Attachment
```powershell
Remove-AzCdnEdgeActionAttachment -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001" -AttachedResourceId "/subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/profiles/testprofile/endpoints/endpoint001"
```

Remove an Edge Action Attachment to unlink an edge action from a CDN resource
