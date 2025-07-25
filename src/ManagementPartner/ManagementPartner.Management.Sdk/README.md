# Overall
This directory contains management plane service clients of Az.Storage module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
regenerate-manager: true
generate-interface: true
title: ACEProvisioningManagementPartnerAPIClient

commit: 7d5d1db0c45d6fe0934c97b6a6f9bb34112d42d1
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/managementpartner/resource-manager/Microsoft.ManagementPartner/preview/2018-02-01/ManagementPartner.json

output-folder: Generated

namespace: Microsoft.Azure.Management.ManagementPartner


# format-by-name-rules:
#   'tenantId': 'uuid'
#   'ETag': 'etag'
#   'location': 'azure-location'
#   '*Uri': 'Uri'
#   '*Uris': 'Uri'

# rename-rules:
#   CPU: Cpu
#   CPUs: Cpus
#   Os: OS
#   Ip: IP
#   Ips: IPs|ips
#   ID: Id
#   IDs: Ids
#   VM: Vm
#   VMs: Vms
#   Vmos: VmOS
#   VMScaleSet: VmScaleSet
#   DNS: Dns
#   VPN: Vpn
#   NAT: Nat
#   WAN: Wan
#   Ipv4: IPv4|ipv4
#   Ipv6: IPv6|ipv6
#   Ipsec: IPsec|ipsec
#   SSO: Sso
#   URI: Uri
#   Etag: ETag|etag

# list-exception:
#   - /providers/Microsoft.ManagementPartner/partners/{partnerId}

# directive:
#   # This definistion of this operation is wrong
#   - from: ManagementPartner.json
#     where: $.paths
#     transform: >
#       delete $['/providers/Microsoft.ManagementPartner/partners'];
```