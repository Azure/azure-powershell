### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/preview/2021-12-01-preview/Tables.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/preview/2021-12-01-preview/Workspaces.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/preview/2021-12-01-preview/Operations.json

# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: OperationalInsights
subject-prefix: $(OperationalInsights)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

```