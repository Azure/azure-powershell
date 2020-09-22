namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Hybrid Compute Machine properties</summary>
    public partial class MachineProperties1 :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineProperties1,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineProperties1Internal,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineProperties __machineProperties = new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.MachineProperties();

        /// <summary>Specifies the AD fully qualified display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string AdFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).AdFqdn; }

        /// <summary>The hybrid machine agent full version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string AgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).AgentVersion; }

        /// <summary>
        /// Public Key that the client provides to be used during initial resource onboarding
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string ClientPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).ClientPublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).ClientPublicKey = value; }

        /// <summary>Specifies the hybrid machine display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).DisplayName; }

        /// <summary>Specifies the DNS fully qualified display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string DnsFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).DnsFqdn; }

        /// <summary>Specifies the Windows domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string DomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).DomainName; }

        /// <summary>Details about the error state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IErrorDetail[] ErrorDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).ErrorDetail; }

        /// <summary>Machine Extensions information</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceView[] Extension { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).Extension; }

        /// <summary>The time of the last status change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public global::System.DateTime? LastStatusChange { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).LastStatusChange; }

        /// <summary>Metadata pertaining to the geographic location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationData LocationData { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).LocationData; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).LocationData = value; }

        /// <summary>The city or locality where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string LocationDataCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).LocationDataCity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).LocationDataCity = value; }

        /// <summary>The country or region where the resource is located</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string LocationDataCountryOrRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).LocationDataCountryOrRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).LocationDataCountryOrRegion = value; }

        /// <summary>The district, state, or province where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string LocationDataDistrict { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).LocationDataDistrict; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).LocationDataDistrict = value; }

        /// <summary>A canonical name for the geographic or physical location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string LocationDataName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).LocationDataName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).LocationDataName = value; }

        /// <summary>Specifies the hybrid machine FQDN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string MachineFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).MachineFqdn; }

        /// <summary>Internal Acessors for AdFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.AdFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).AdFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).AdFqdn = value; }

        /// <summary>Internal Acessors for AgentVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.AgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).AgentVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).AgentVersion = value; }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).DisplayName = value; }

        /// <summary>Internal Acessors for DnsFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.DnsFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).DnsFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).DnsFqdn = value; }

        /// <summary>Internal Acessors for DomainName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.DomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).DomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).DomainName = value; }

        /// <summary>Internal Acessors for ErrorDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IErrorDetail[] Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.ErrorDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).ErrorDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).ErrorDetail = value; }

        /// <summary>Internal Acessors for Extension</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionInstanceView[] Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.Extension { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).Extension; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).Extension = value; }

        /// <summary>Internal Acessors for LastStatusChange</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.LastStatusChange { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).LastStatusChange; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).LastStatusChange = value; }

        /// <summary>Internal Acessors for MachineFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.MachineFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).MachineFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).MachineFqdn = value; }

        /// <summary>Internal Acessors for OSName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.OSName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSName = value; }

        /// <summary>Internal Acessors for OSProfileComputerName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.OSProfileComputerName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSProfileComputerName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSProfileComputerName = value; }

        /// <summary>Internal Acessors for OSSku</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.OSSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSSku = value; }

        /// <summary>Internal Acessors for OSVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.OSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSVersion = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).ProvisioningState = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes? Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).Status = value; }

        /// <summary>Internal Acessors for VMUuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal.VMUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).VMUuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).VMUuid = value; }

        /// <summary>The Operating System running on the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string OSName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSName; }

        /// <summary>Specifies the operating system settings for the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesOSProfile OSProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSProfile = value; }

        /// <summary>Specifies the host OS name of the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string OSProfileComputerName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSProfileComputerName; }

        /// <summary>Specifies the Operating System product SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string OSSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSSku; }

        /// <summary>The version of Operating System running on the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string OSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).OSVersion; }

        /// <summary>The provisioning state, which only appears in the response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).ProvisioningState; }

        /// <summary>The status of the hybrid machine agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).Status; }

        /// <summary>Specifies the hybrid machine unique ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string VMId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).VMId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).VMId = value; }

        /// <summary>Specifies the Arc Machine's unique SMBIOS ID</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string VMUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal)__machineProperties).VMUuid; }

        /// <summary>Creates an new <see cref="MachineProperties1" /> instance.</summary>
        public MachineProperties1()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__machineProperties), __machineProperties);
            await eventListener.AssertObjectIsValid(nameof(__machineProperties), __machineProperties);
        }
    }
    /// Hybrid Compute Machine properties
    public partial interface IMachineProperties1 :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineProperties
    {

    }
    /// Hybrid Compute Machine properties
    internal partial interface IMachineProperties1Internal :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachinePropertiesInternal
    {

    }
}