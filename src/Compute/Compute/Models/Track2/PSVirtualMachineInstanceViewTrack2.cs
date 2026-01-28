// PSVirtualMachineInstanceViewTrack2.cs
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models.Track2
{
    public class PSVirtualMachineInstanceView
    {
        public int? PlatformUpdateDomain { get; set; }
        public int? PlatformFaultDomain { get; set; }
        public string ComputerName { get; set; }
        public string OsName { get; set; }
        public string OsVersion { get; set; }
        public string HyperVGeneration { get; set; }
        public string RdpThumbPrint { get; set; }
        public PSVirtualMachineAgentInstanceView VmAgent { get; set; }
        public PSMaintenanceRedeployStatus MaintenanceRedeployStatus { get; set; }
        public IList<PSDiskInstanceView> Disks { get; set; }
        public IList<PSVirtualMachineExtensionInstanceView> Extensions { get; set; }
        public PSVirtualMachineHealthStatus VmHealth { get; set; }
        public PSBootDiagnosticsInstanceView BootDiagnostics { get; set; }
        public string AssignedHost { get; set; }
        public IList<PSInstanceViewStatus> Statuses { get; set; }
        public PSPatchStatus PatchStatus { get; set; }
        public bool? IsVMInStandbyPool { get; set; }
    }
    
    public class PSVirtualMachineAgentInstanceView
    {
        public string VmAgentVersion { get; set; }
        public IList<PSVirtualMachineExtensionHandlerInstanceView> ExtensionHandlers { get; set; }
        public IList<PSInstanceViewStatus> Statuses { get; set; }
    }
    
    public class PSVirtualMachineExtensionHandlerInstanceView
    {
        public string Type { get; set; }
        public string TypeHandlerVersion { get; set; }
        public PSInstanceViewStatus Status { get; set; }
    }
    
    public class PSInstanceViewStatus
    {
        public string Code { get; set; }
        public string Level { get; set; }
        public string DisplayStatus { get; set; }
        public string Message { get; set; }
        public DateTimeOffset? Time { get; set; }
    }
    
    public class PSMaintenanceRedeployStatus
    {
        public bool? IsCustomerInitiatedMaintenanceAllowed { get; set; }
        public DateTimeOffset? PreMaintenanceWindowStartTime { get; set; }
        public DateTimeOffset? PreMaintenanceWindowEndTime { get; set; }
        public DateTimeOffset? MaintenanceWindowStartTime { get; set; }
        public DateTimeOffset? MaintenanceWindowEndTime { get; set; }
        public string LastOperationResultCode { get; set; }
        public string LastOperationMessage { get; set; }
    }
    
    public class PSDiskInstanceView
    {
        public string Name { get; set; }
        public IList<PSDiskEncryptionSettings> EncryptionSettings { get; set; }
        public IList<PSInstanceViewStatus> Statuses { get; set; }
    }
    
    public class PSVirtualMachineExtensionInstanceView
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string TypeHandlerVersion { get; set; }
        public IList<PSInstanceViewStatus> Substatuses { get; set; }
        public IList<PSInstanceViewStatus> Statuses { get; set; }
    }
    
    public class PSVirtualMachineHealthStatus
    {
        public PSInstanceViewStatus Status { get; set; }
    }
    
    public class PSBootDiagnosticsInstanceView
    {
        public string ConsoleScreenshotBlobUri { get; set; }
        public string SerialConsoleLogBlobUri { get; set; }
        public PSInstanceViewStatus Status { get; set; }
    }
    
    public class PSPatchStatus
    {
        public PSAvailablePatchSummary AvailablePatchSummary { get; set; }
        public PSLastPatchInstallationSummary LastPatchInstallationSummary { get; set; }
        public IList<PSInstanceViewStatus> ConfigurationStatuses { get; set; }
    }
    
    public class PSAvailablePatchSummary
    {
        public string Status { get; set; }
        public string AssessmentActivityId { get; set; }
        public bool? RebootPending { get; set; }
        public int? CriticalAndSecurityPatchCount { get; set; }
        public int? OtherPatchCount { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? LastModifiedTime { get; set; }
        public PSApiError Error { get; set; }
    }
    
    public class PSLastPatchInstallationSummary
    {
        public string Status { get; set; }
        public string InstallationActivityId { get; set; }
        public bool? MaintenanceWindowExceeded { get; set; }
        public bool? RebootStatus { get; set; }
        public int? NotSelectedPatchCount { get; set; }
        public int? ExcludedPatchCount { get; set; }
        public int? PendingPatchCount { get; set; }
        public int? InstalledPatchCount { get; set; }
        public int? FailedPatchCount { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? LastModifiedTime { get; set; }
        public PSApiError Error { get; set; }
    }
    
    public class PSApiError
    {
        public IList<PSApiErrorBase> Details { get; set; }
        public PSInnerError Innererror { get; set; }
        public string Code { get; set; }
        public string Target { get; set; }
        public string Message { get; set; }
    }
    
    public class PSApiErrorBase
    {
        public string Code { get; set; }
        public string Target { get; set; }
        public string Message { get; set; }
    }
    
    public class PSInnerError
    {
        public string Exceptiontype { get; set; }
        public string Errordetail { get; set; }
    }
}