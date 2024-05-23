<!-- region Generated -->
# Az.Support
This directory contains the PowerShell module for the Support service.

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
For information on how to develop for `Az.Support`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 791ef5476e10bb15ab9ad46e2c2d8835ac24ac24
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md
input-file:
  - $(repo)/specification/support/resource-manager/Microsoft.Support/stable/2024-04-01/support.json

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Support
subject-prefix: $(service-name)

# The next three configurations are exclusive to v3, and in v4, they are activated by default. If you are still using v3, please uncomment them.
# identity-correction-for-post: true
# resourcegroup-append: true
# nested-object-to-string: true

directive:
  - where:
      model-name: ProblemClassification
    set:
      format-table:
        properties:
          - DisplayName
          - Name
          - SecondaryConsentEnabled
  - where:
      model-name: Service
    set:
      format-table:
        properties:
          - DisplayName
          - Name
          - ResourceType
  - where:
      model-name: FileDetails
    set:
      format-table:
        properties:
          - Name
          - CreatedOn
          - ChunkSize
          - FileSize
          - NumberOfChunks 
  - where:
      model-name: SupportTicketDetails
    set:
      format-table:
        properties:
          - Name
          - Title
          - SupportTicketId
          - Severity
          - ServiceDisplayName
          - CreatedDate
  - where:
      model-name: CommunicationDetails
    set:
      format-table:
        properties:
          - Name
          - Sender
          - Subject
          - CreatedDate
  - where:
      model-name: ChatTranscriptDetails
    set:
      format-table:
        properties:
          - Name
          - StartTime
  - where:
      subject: CommunicationsNoSubscription
      parameter-name: CommunicationName
    set:
      alias: Name
  - where:
      subject: SupportTicketsNoSubscription
      parameter-name: SupportTicketName
    set:
      alias: Name
  - where:
      subject: ChatTranscriptsNoSubscription
      parameter-name: ChatTranscriptName
    set:
      alias: Name
  - where:
      subject: UploadFile
      parameter-name: FileWorkspaceName
    set:
      alias: WorkspaceName
  - where:
      subject: UploadFilesNoSubscription
      parameter-name: FileWorkspaceName
    set:
      alias: WorkspaceName
  - where:
      subject: FileWorkspacesNoSubscription
      parameter-name: FileWorkspaceName
    set:
      alias: Name
  - where:
      subject: FilesNoSubscription
      parameter-name: FileName
    set:
      alias: Name
  - where:
      subject: FilesNoSubscription
      parameter-name: FileWorkspaceName
    set:
      alias: WorkspaceName
  - where: 
      parameter-name: ContactDetailPreferredTimeZone
    set:
      completer:
        name: Time Zone Completer
        description: Gets the list of valid time zones
        script: "'\"Afghanistan Standard Time\"', '\"Alaskan Standard Time\"', '\"Arab Standard Time\"', '\"Arabian Standard Time\"', '\"Arabic Standard Time\"', '\"Argentina Standard Time\"', '\"Atlantic Standard Time\"', '\"AUS Central Standard Time\"', '\"AUS Eastern Standard Time\"', '\"Azerbaijan Standard Time\"', '\"Azores Standard Time\"','\"Canada Central Standard Time\"','\"Cape Verde Standard Time\"','\"Caucasus Standard Time\"','\"Cen. Australia Standard Time\"','\"Central America Standard Time\"','\"Central Asia Standard Time\"','\"Central Brazilian Standard Time\"','\"Central Europe Standard Time\"','\"Central European Standard Time\"','\"Central Pacific Standard Time\"','\"Central Standard Time\"','\"Central Standard Time (Mexico)\"','\"China Standard Time\"','\"Dateline Standard Time\"','\"E. Africa Standard Time\"','\"E. Australia Standard Time\"','\"E. Europe Standard Time\"','\"E. South America Standard Time\"','\"Eastern Standard Time\"','\"Eastern Standard Time (Mexico)\"','\"Egypt Standard Time\"','\"Ekaterinburg Standard Time\"','\"Fiji Standard Time\"','\"FLE Standard Time\"','\"Georgian Standard Time\"','\"GMT Standard Time\"','\"Greenland Standard Time\"','\"Greenwich Standard Time\"','\"GTB Standard Time\"','\"Hawaiian Standard Time\"','\"India Standard Time\"','\"Iran Standard Time\"','\"Israel Standard Time\"','\"Jordan Standard Time\"','\"Korea Standard Time\"','\"Mauritius Standard Time\"','\"Mid-Atlantic Standard Time\"','\"Middle East Standard Time\"','\"Montevideo Standard Time\"','\"Morocco Standard Time\"','\"Mountain Standard Time\"','\"Mountain Standard Time (Mexico)\"','\"Myanmar Standard Time\"','\"N. Central Asia Standard Time\"','\"Namibia Standard Time\"','\"Nepal Standard Time\"','\"New Zealand Standard Time\"','\"Newfoundland Standard Time\"','\"North Asia East Standard Time\"','\"North Asia Standard Time\"','\"Pacific SA Standard Time\"','\"Pacific Standard Time\"','\"Pacific Standard Time (Mexico)\"','\"Pakistan Standard Time\"','\"Romance Standard Time\"','\"Russian Standard Time\"','\"SA Eastern Standard Time\"','\"SA Pacific Standard Time\"','\"SA Western Standard Time\"','\"Samoa Standard Time\"','\"SE Asia Standard Time\"','\"Singapore Standard Time\"','\"South Africa Standard Time\"','\"Sri Lanka Standard Time\"','\"Taipei Standard Time\"','\"Tasmania Standard Time\"','\"Tokyo Standard Time\"','\"Tonga Standard Time\"','\"Turkey Standard Time\"','\"US Eastern Standard Time\"','\"US Mountain Standard Time\"','\"UTC\"','\"Venezuela Standard Time\"','\"Vladivostok Standard Time\"','\"W. Australia Standard Time\"','\"W. Central Africa Standard Time\"','\"W. Europe Standard Time\"','\"West Asia Standard Time\"','\"West Pacific Standard Time\"','\"Yakutsk Standard Time\"'"
  - where:
      parameter-name: ContactDetailPreferredSupportLanguage
    set:
      completer:
        name: Support Language Completer
        description: Gets the list of valid support languages
        script: "'\"en-us\"','\"es-es\"','\"fr-fr\"','\"de-de\"','\"it-it\"','\"ja-jp\"','\"ko-kr\"','\"ru-ru\"','\"pt-br\"','\"zh-tw\"','\"zh-hans\"'"
  - where:
      verb: New
      subject: File
    hide: true
  - where:
      verb: New
      subject: FilesNoSubscription
    hide: true
  - where:
      verb: Get
      subject: SupportTicket
    hide: true
  - where:
      verb: Get
      subject: SupportTicketsNoSubscription
    hide: true
  - where:
      verb: Update
      subject: File
    remove: true
  - where:
      verb: Update
      subject: FilesNoSubscription
    remove: true
  - where:
      verb: Invoke
      subject: UploadFile
    hide: true
  - where:
      verb: Invoke
      subject: UploadFilesNoSubscription
    hide: true
  - where:
      verb: Update
      subject: Communication
    remove: true
  - where:
      verb: Update
      subject: CommunicationsNoSubscription
    remove: true
  - from: GetAzSupportTicket_List.cs
    where: $
    transform: $ = $.replace("!String.IsNullOrEmpty(_nextLink)" ,"!String.IsNullOrEmpty(_nextLink) && this._top <= 0");
  - from: GetAzSupportTicketsNoSubscription_List.cs
    where: $
    transform: $ = $.replace("!String.IsNullOrEmpty(_nextLink)" ,"!String.IsNullOrEmpty(_nextLink) && this._top <= 0");
  - from: GetAzSupportCommunication_List.cs
    where: $
    transform: $ = $.replace("!String.IsNullOrEmpty(_nextLink)" ,"!String.IsNullOrEmpty(_nextLink) && this._top <= 0");
  - from: GetAzSupportCommunicationsNoSubscription_List.cs
    where: $
    transform: $ = $.replace("!String.IsNullOrEmpty(_nextLink)" ,"!String.IsNullOrEmpty(_nextLink) && this._top <= 0");
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  # Following two directives are v4 specific
  - where:
      variant: ^(Create|Update)(?!.*?Expanded|JsonFilePath|JsonString)
      subject: ^(?!FileWorkspace|FileWorkspacesNoSubscription$).*
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  # Follow directive is v3 specific. If you are using v3, uncomment following directive and comments out two directives above
  #- where:
  #    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
  #  remove: true

  # Remove the set-* cmdlet
#   - where:
#       verb: Set
#     remove: true
```
