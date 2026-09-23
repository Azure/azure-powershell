<!-- region Generated -->
# Az.Nginx
This directory contains the PowerShell module for the Nginx service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Nginx`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
commit: d1027c6d6d0994ef3a656a561b0cce8378ac58a4
tag: package-2024-01-01-preview
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/nginx/resource-manager/NGINX.NGINXPLUS/preview/2024-01-01-preview/swagger.json
root-module-name: $(prefix).Nginx
title: Nginx
module-version: 0.1.0
subject-prefix: Nginx
flatten-userassignedidentity: false
disable-transform-identity-type: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^(Create|Update|Analysis)(?!.*?(Expanded|JsonFilePath|JsonString))|^CreateViaIdentityExpanded$
    remove: true
  - where:
      subject: Configuration|Certificate|Deployment
      verb: Set
    remove: true
  - where:
      subject: Deployment
      variant: CreateExpanded|UpdateExpanded|UpdateViaIdentityExpanded
    hide: true
  # Required properties for deployment
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}"].put.parameters[4]
    transform: >-
      return {
        "in": "body",
        "name": "body",
        "required": true,
        "schema": {
          "$ref": "#/definitions/NginxDeployment"
        }
      }
  - from: swagger-document
    where: $.definitions.NginxDeploymentProperties
    transform: $['required']= ['networkProfile']
  - from: swagger-document
    where: $.definitions.NginxDeployment
    transform: $['required'] = ['properties','location','sku']
  # Required properties for Certificates
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/certificates/{certificateName}"].put.parameters[5]
    transform: >-
      return {
        "in": "body",
        "name": "body",
        "required": true,
        "description": "The certificate",
        "schema": {
          "$ref": "#/definitions/NginxCertificate"
        }
      }
  - from: swagger-document
    where: $.definitions.NginxCertificate
    transform: $['required'] = ['properties']
  - from: swagger-document
    where: $.definitions.NginxCertificateProperties
    transform: $['required'] = ['keyVirtualPath', 'certificateVirtualPath', 'keyVaultSecretId']
  - model-cmdlet:
    - model-name: NginxConfigurationFile
    - model-name: NginxPrivateIPAddress
    - model-name: NginxPublicIPAddress
    - model-name: NginxNetworkProfile
  - no-inline:
    - NginxNetworkProfile
```
