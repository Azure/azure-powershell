# Comments

- Local objects.
- Smart cmdlets for
    - P2. Resource Group.
    - P2. Virtual Network.
    - P2. Security Group.
- P2. Resource Ids, a tree structure
- P1. Output for smart commands. In particular, information about (PS information stream ?)
    - Resource Group!!!
    - Virtual Network!
    - Security Group!
    - ...!
- Security Rules:
    - DefaultSecurityRulesText - can/should we use it?
- P2. information stream
- P3. show progress
- P1. return PowerShell Job (async)

## Tasks

P0 is 09/05/2017

- [ ] P0 output
- [X] P0 create a package (PSM1, PSD1...)
  - [X] P0 Manifest with dependencies
- image list
  - [X] P0: json file or PSObject
  - [ ] P1: json
  - [ ] P2: source of image names. CDN, Azure... ???
- names:
  - P0: based on VM name specified by user (see also CLI, Portal).
    - [X] P0: always fail if exist
    - P1: can we reuse it? ???
    - P1: fallback: throw (suggests...) or reuse?
  - P1: default shared name for Network (something else?!). CLI?? Portal??
- P2 optional VM name.
- P1 Create Or Update scenario.
- P2 Rollback

## Tasks

- [X] P0: required modules
- [ ] replace Write-Host
  - [X]: P0: remove Write-Host
  - [ ]: P1: add progress
- [X] P0: parameter attributes
- [ ] P0: Linux image
- [ ] P0: more default parameters
- [X] P0: having a package.
- [ ] P1: Project build.

## Graph

1. `Location`
1. `ResourceGroup`
   - depends on `Location`
   - children
     1. `VirtualNetwork`
        - depends on `Location`
        - children
          1. `Subnet`
     1. `PublicIpAddress`
        - depends on `Location`
     1. `SecurityGroup`
        - depends on `Location`
        - children
          1. `SecurityRule`
     1. `NetworkInterface`
        - depends on `PublicIpAddress`, `Subnet`, `SecurityGroup`, `Location`
     1. `Vm`
        - depends on `NetworkInterface`, `Location`

## Levels

1. Resources:
   - `Location` (shared),
   - `ResourceGroup` (shared) <- `Location`
1. Resources:
   - `SecurityGroup` -> `SecurityRule`
   - `Subnet` <- `VirtualNetwork` (shared?)
   - `PublicIpAddress`
1. Resources:
   - `NetworkInterface` (unique) ?
1. Resources:
   - `VM`

## Behavior

a parameter value:
  - undefined
  - user's value

if a resource exists
  - then
  - else

resource name:
1. undefined
   1. resource exists - reuse|with validation (fail? or workaround or interactive)
   1. resource doesn't exist - create
1. user's value
   1. resource exist - reuse
   1. resource doesn't exist - fail (create?)

smart location. Should it depends on a resource group location?

default parameters - work backward

## Resource Acquisition Matrix

1. A resource name is
   - undefined
   - user's specified name
   - user's specified id
1. A resource
   - exists
   - doesn't exist
1. A resource is
   - shared
   - unique

## C# vs PowerShell

### Proposal 1

- use C# to implement logic and type descriptions (no PowerShell dependencies, only .Net Standard and Azure SDK dependencies).
- use PowerShell to make a facade.

### Proposal 2

- use C# to implement logic and type descriptions (with PowerShell dependencies)
- probably, no need for PSM1 files.

### C# advantages

- type/contract validations at compile time.
- much more feature to express logic, relations etc.
- testing is easier and, probably, faster.
- performance ?.
- customers may use the C# library for .Net programs (C#/VB/F#/...).
- C# type system is much more mature and well documented compare to PowerShell v5 classes.

## Tasks

- changelog
- remove warnings (-WarningAction=SilentContinue)
- help
- linux
- e2e manual test (Windows, Linux).
- feedback
- (-Auto)
- tab-completion
- VMSS
- rolling back
- output object

## 9/15

- [X] [P-1] help (in doc, example)
- - signing (9/14)
- output format (Get-AzureRmVm)
  - talk to Aaron
    - how to use (connect to VM etc).
- output
  - information stream (Write-Information)
- proper cmdlet + parameter attributes + struct
  - [X] positional parameters (PR) (position 0 for name)
- [X] [P-1] shouldprocess (example)

- [P0.5] validation (PSScript analyser)
