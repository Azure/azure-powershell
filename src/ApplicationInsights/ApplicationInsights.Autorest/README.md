<!-- region Generated -->
# Az.ApplicationInsights
This directory contains the PowerShell module for the ApplicationInsights service.

---
## Status
[![Az.ApplicationInsights](https://img.shields.io/powershellgallery/v/Az.ApplicationInsights.svg?style=flat-square&label=Az.ApplicationInsights "Az.ApplicationInsights")](https://www.powershellgallery.com/packages/Az.ApplicationInsights/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.ApplicationInsights`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# lock the commit
branch: e1eca381eca8ec1f80b722e5dbf060fdeef48653
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/applicationinsights/resource-manager/Microsoft.Insights/preview/2018-05-01-preview/webTests_API.json

module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  #  Kind 'basic' is not supported on the server.
  - from: swagger-document
    where: $.definitions.WebTestProperties.properties.Kind.enum
    transform: >-
      return [
        "ping",
        "multistep",
        "standard"
      ]
  - from: swagger-document
    where: $.definitions.WebTestProperties.properties.Kind.description
    transform: return "The kind of web test this is, valid choices are ping, multistep, and standard."

  # microsoft.insights is the service response.
  - from: swagger-document
    where: $
    transform: return $.replace(/providers\/Microsoft.Insights\//g, "providers/microsoft.insights/")

  - where:
      verb: Set
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true

  # Hide the SyntheticMonitorId parameter because the default value is passed by the server.
  - where:
      verb: New
      subject: WebTest
      parameter-name: SyntheticMonitorId
    hide: true

  # Hide the Kind parameter because the WebKind override it.
  - where:
      verb: New
      subject: WebTest
      parameter-name: Kind
    set:
      parameter-name: HideKind
  - where:
      verb: New
      subject: WebTest
      parameter-name: HideKind
    hide: true
  # rename WebTestKind to Kind  
  - where:
      verb: New
      subject: WebTest
      parameter-name: WebTestKind
    set:
      parameter-name: Kind

  # Rename parameters
  - where:
      verb: Get
      subject: WebTest
      parameter-name: ComponentName
    set:
      parameter-name: AppInsightsName

  - where:
      verb: New
      subject: WebTest
      parameter-name: PropertiesLocations
    set:
      parameter-name: GeoLocation

  - where:
      verb: New
      subject: WebTest
      parameter-name: PropertiesWebTestName
    set:
      parameter-name: TestName

  - where:
      verb: New
      subject: WebTest
      parameter-name: ConfigurationWebTest
    set:
      parameter-name: Configuration

  - where:
      verb: New
      subject: WebTest
      parameter-name: ContentValidationContentMatch
    set:
      parameter-name: ContentMatch

  - where:
      verb: New
      subject: WebTest
      parameter-name: (.*)Validation(.*)
    set:
      parameter-name: $1$2
  - where:
      verb: New
      subject: WebTest
      parameter-name: RequestParseDependentRequest
    set:
      parameter-name: RequestParseDependent

  - where:
      verb: Update
      subject: WebTestTag
      parameter-name: WebTestName
    set:
      parameter-name: Name

  # Hide command for custom command.
  - where:
      verb: New
      subject: ^WebTest$
    hide: true

  - model-cmdlet:
    - WebTestGeolocation
    # Hide for custom modle cmdlet.
    # - HeaderField
  
  # format output table
  - where:
      model-name: WebTest
    set:
      format-table:
        properties:
          - Name
          - Location
          - WebTestKind
          - Enabled
```
