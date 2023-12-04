namespace Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Extensions;

    /// <summary>
    /// The resource model definition for a ARM proxy resource. It will have everything other than required location and tags
    /// </summary>
    public partial class ProxyResource :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IProxyResource,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IProxyResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.Resource();

        /// <summary>Fully qualified resource Id for the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Type = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Name; }

        /// <summary>The type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="ProxyResource" /> instance.</summary>
        public ProxyResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// The resource model definition for a ARM proxy resource. It will have everything other than required location and tags
    public partial interface IProxyResource :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResource
    {

    }
    /// The resource model definition for a ARM proxy resource. It will have everything other than required location and tags
    internal partial interface IProxyResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal
    {

    }
}