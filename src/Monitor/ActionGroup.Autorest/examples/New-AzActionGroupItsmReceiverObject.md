### Example 1: create action group IT service management receiver
```powershell
New-AzActionGroupItsmReceiverObject -ConnectionId a3b9076c-ce8e-434e-85b4-aff10cb3c8f1 -Name "sample itsm" -Region "westcentralus" -TicketConfiguration "{ 'PayloadRevision':0, 'WorkItemType':'Incident', 'UseTemplate':false,'WorkItemData':'{}','CreateOneWIPerCI':false}" -WorkspaceId "5def922a-3ed4-49c1-b9fd-05ec533819a3|55dfd1f8-7e59-4f89-bf56-4c82f5ace23c"
```

```output
ConnectionId        : a3b9076c-ce8e-434e-85b4-aff10cb3c8f1
Name                : sample itsm
Region              : westcentralus
TicketConfiguration : { 'PayloadRevision':0, 'WorkItemType':'Incident', 'UseTemplate':false,'WorkItemData':'{}','CreateOneWIPerCI':false}
WorkspaceId         : 5def922a-3ed4-49c1-b9fd-05ec533819a3|55dfd1f8-7e59-4f89-bf56-4c82f5ace23c
```

This command creates action group IT Service Management receiver object.

