<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->
## Upcoming Release
* Allowed update of attestation information (e.g. keys, certificates) for exsting device enrollments and enrollment groups

## Version 0.9.0
* Allow tags in IoT Device Provisioning Service create cmdlet.

## Version 0.8.0
* Update devices provisioning service sdk

## Version 0.7.4
* Fixed debug: Enrollment does not retain/assign linked IotHubs while choosing Custom allocation policy. [#12154]

## Version 0.7.3
* Manage Device Enrollments. New cmdlets are:
    - `Add-AzIoTDeviceProvisioningServiceEnrollment`
    - `Get-AzIoTDeviceProvisioningServiceEnrollment`
    - `Remove-AzIoTDeviceProvisioningServiceEnrollment`
    - `Set-AzIoTDeviceProvisioningServiceEnrollment`
* Manage Enrollment Groups. New cmdlets are:
    - `Add-AzIoTDeviceProvisioningServiceEnrollmentGroup`
    - `Get-AzIoTDeviceProvisioningServiceEnrollmentGroup`
    - `Remove-AzIoTDeviceProvisioningServiceEnrollmentGroup`
    - `Set-AzIoTDeviceProvisioningServiceEnrollmentGroup`
* Manage Device Registration State. New cmdlets are:
    - `Get-AzIoTDeviceProvisioningServiceRegistration`
    - `Remove-AzIoTDeviceProvisioningServiceRegistration`
## Version 0.7.2
* Update references in .psd1 to use relative path
