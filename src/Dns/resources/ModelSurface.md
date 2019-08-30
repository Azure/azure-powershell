### AaaaRecord [Api20150504Preview]
  - Ipv6Address `String`

### ARecord [Api20150504Preview]
  - Ipv4Address `String`

### AzureEntityResource [Api10]
  - Etag `String`
  - Id `String`
  - Name `String`
  - Type `String`

### CaaRecord [Api20180501]
  - Flag `Int32?`
  - Tag `String`
  - Value `String`

### CloudError [Api20160401, Api20180501]
  - Code `String`
  - Detail `ICloudErrorBody[]`
  - Message `String`
  - Target `String`

### CloudErrorBody [Api20160401, Api20180501]
  - Code `String`
  - Detail `ICloudErrorBody[]`
  - Message `String`
  - Target `String`

### CnameRecord [Api20150504Preview]
  - Cname `String`

### DnsIdentity [Models]
  - Id `String`
  - RecordType `RecordType?` **{A, Aaaa, Caa, Cname, Mx, Ns, Ptr, Soa, Srv, Txt}**
  - RelativeRecordSetName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - ZoneName `String`

### DnsResourceReference [Api20180501]
  - DnsResource `ISubResource[]`
  - TargetResourceId `String`

### DnsResourceReferenceRequest [Api20180501]
  - TargetResource `ISubResource[]`

### DnsResourceReferenceRequestProperties [Api20180501]
  - TargetResource `ISubResource[]`

### DnsResourceReferenceResult [Api20180501]
  - DnsResourceReference `IDnsResourceReference[]`

### DnsResourceReferenceResultProperties [Api20180501]
  - DnsResourceReference `IDnsResourceReference[]`

### MxRecord [Api20150504Preview]
  - Exchange `String`
  - Preference `Int32?`

### NsRecord [Api20150504Preview]
  - Nsdname `String`

### ProxyResource [Api10]
  - Id `String`
  - Name `String`
  - Type `String`

### PtrRecord [Api20150504Preview]
  - Ptrdname `String`

### RecordSet [Api20150504Preview, Api20160401, Api20180501]
  - AaaaRecord `IAaaaRecord[]`
  - ARecord `IARecord[]`
  - CaaRecord `ICaaRecord[]`
  - CnameRecordCname `String`
  - Etag `String`
  - Fqdn `String`
  - Id `String`
  - Location `String`
  - Metadata `IRecordSetPropertiesMetadata <String>`
  - MxRecord `IMxRecord[]`
  - Name `String`
  - NsRecord `INsRecord[]`
  - ProvisioningState `String`
  - PtrRecord `IPtrRecord[]`
  - SoaRecordEmail `String`
  - SoaRecordExpireTime `Int64?`
  - SoaRecordHost `String`
  - SoaRecordMinimumTtl `Int64?`
  - SoaRecordRefreshTime `Int64?`
  - SoaRecordRetryTime `Int64?`
  - SoaRecordSerialNumber `Int64?`
  - SrvRecord `ISrvRecord[]`
  - Tag `ITrackedResourceTags <String>`
  - TargetResourceId `String`
  - Ttl `Int64?`
  - TxtRecord `ITxtRecord[]`
  - Type `String`

### RecordSetListResult [Api20160401, Api20180501]
  - NextLink `String`
  - Value `IRecordSet[]`

### RecordSetProperties [Api20150504Preview, Api20160401, Api20180501]
  - AaaaRecord `IAaaaRecord[]`
  - ARecord `IARecord[]`
  - CaaRecord `ICaaRecord[]`
  - CnameRecord `ICnameRecord`
  - CnameRecordCname `String`
  - Fqdn `String`
  - Metadata `IRecordSetPropertiesMetadata <String>`
  - MxRecord `IMxRecord[]`
  - NsRecord `INsRecord[]`
  - ProvisioningState `String`
  - PtrRecord `IPtrRecord[]`
  - SoaRecord `ISoaRecord`
  - SoaRecordEmail `String`
  - SoaRecordExpireTime `Int64?`
  - SoaRecordHost `String`
  - SoaRecordMinimumTtl `Int64?`
  - SoaRecordRefreshTime `Int64?`
  - SoaRecordRetryTime `Int64?`
  - SoaRecordSerialNumber `Int64?`
  - SrvRecord `ISrvRecord[]`
  - TargetResourceId `String`
  - Ttl `Int64?`
  - TxtRecord `ITxtRecord[]`

### Resource [Api10, Api20180501]
  - Id `String`
  - Location `String`
  - Name `String`
  - Tag `IResourceTags <String>`
  - Type `String`

### SoaRecord [Api20150504Preview, Api20160401]
  - Email `String`
  - ExpireTime `Int64?`
  - Host `String`
  - MinimumTtl `Int64?`
  - RefreshTime `Int64?`
  - RetryTime `Int64?`
  - SerialNumber `Int64?`

### SrvRecord [Api20150504Preview]
  - Port `Int32?`
  - Priority `Int32?`
  - Target `String`
  - Weight `Int32?`

### SubResource [Api20180301Preview]
  - Id `String`

### TrackedResource [Api10]
  - Id `String`
  - Location `String`
  - Name `String`
  - Tag `ITrackedResourceTags <String>`
  - Type `String`

### TxtRecord [Api20150504Preview]
  - Value `String[]`

### Zone [Api20150504Preview, Api20160401, Api20170901, Api20180301Preview, Api20180501]
  - Etag `String`
  - Id `String`
  - Location `String`
  - MaxNumberOfRecordSet `Int64?`
  - Name `String`
  - NameServer `String[]`
  - NumberOfRecordSet `Int64?`
  - RegistrationVirtualNetwork `ISubResource[]`
  - ResolutionVirtualNetwork `ISubResource[]`
  - Tag `IResourceTags <String>`
  - Type `String`
  - ZoneType `ZoneType?` **{Private, Public}**

### ZoneDeleteResult [Api20160401]
  - AzureAsyncOperation `String`
  - RequestId `String`
  - Status `OperationStatus?` **{Failed, InProgress, Succeeded}**
  - StatusCode `HttpStatusCode?` **{Accepted, Ambiguous, BadGateway, BadRequest, Conflict, Continue, Created, ExpectationFailed, Forbidden, Found, GatewayTimeout, Gone, HttpVersionNotSupported, InternalServerError, LengthRequired, MethodNotAllowed, Moved, MovedPermanently, MultipleChoices, NoContent, NonAuthoritativeInformation, NotAcceptable, NotFound, NotImplemented, NotModified, Ok, PartialContent, PaymentRequired, PreconditionFailed, ProxyAuthenticationRequired, Redirect, RedirectKeepVerb, RedirectMethod, RequestEntityTooLarge, RequestTimeout, RequestUriTooLong, RequestedRangeNotSatisfiable, ResetContent, SeeOther, ServiceUnavailable, SwitchingProtocols, TemporaryRedirect, Unauthorized, UnsupportedMediaType, Unused, UpgradeRequired, UseProxy}**

### ZoneListResult [Api20160401, Api20180501]
  - NextLink `String`
  - Value `IZone[]`

### ZoneProperties [Api20150504Preview, Api20160401, Api20170901, Api20180301Preview]
  - MaxNumberOfRecordSet `Int64?`
  - NameServer `String[]`
  - NumberOfRecordSet `Int64?`
  - RegistrationVirtualNetwork `ISubResource[]`
  - ResolutionVirtualNetwork `ISubResource[]`
  - ZoneType `ZoneType?` **{Private, Public}**

### ZoneUpdate [Api20180501]
  - Tag `IZoneUpdateTags <String>`

