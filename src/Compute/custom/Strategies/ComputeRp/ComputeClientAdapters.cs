using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Compute.Strategies.ComputeRp;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Support;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Cmdlets.Compute.Strategies
{
    public static class ComputeClientAdapters
    {
        public static IAvailabilitySetOperations GetAvailabilitySetOperations(this IClient client)
        {
            return new AvailabilitySetOperations { SubscriptionId = client.SubscriptionId, Sender = client.Sender, Listener = client.Listener };
        }

        public static IImageOperations GetImageOperations(this IClient client)
        {
            return new ImageOperations { SubscriptionId = client.SubscriptionId, Sender = client.Sender, Listener = client.Listener };
        }

        public static IGalleryImageOperations GetGalleryImageOperations(this IClient client)
        {
            return new GalleryImageOperations { SubscriptionId = client.SubscriptionId, Sender = client.Sender, Listener = client.Listener };
        }

        public static IDiskOperations GetDiskOperations(this IClient client)
        {
            return new DiskOperations { SubscriptionId = client.SubscriptionId, Sender = client.Sender, Listener = client.Listener };
        }

        public static IProximityPlacementGroupOperations GetProximityPlacementGroupOperations(this IClient client)
        {
            return new ProximityGroupPlacementOperations { SubscriptionId = client.SubscriptionId, Sender = client.Sender, Listener = client.Listener };
        }

        public static IScaleSetOperations GetScaleSetOperations(this IClient client)
        {
            return new ScaleSetOperations { SubscriptionId = client.SubscriptionId, Sender = client.Sender, Listener = client.Listener };
        }

        public static IVMOperations GetVMOperations(this IClient client)
        {
            return new VMOperations { SubscriptionId = client.SubscriptionId, Sender = client.Sender, Listener = client.Listener };
        }

    }

    public interface IVMOperations
    {
        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.VirtualMachine> CreateOrUpdate(string resourceGroupName, string vmName, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachine body);
        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.VirtualMachine> Get(string resourceGroupName, string vmName, Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.InstanceViewTypes? Expand);
    }

    public class VMOperations : IVMOperations
    {
        public string SubscriptionId { get; set; }
        public PowerShell.Cmdlets.Compute.Runtime.ISendAsync Sender { get; set; }
        public PowerShell.Cmdlets.Compute.Runtime.IEventListener Listener { get; set; }

        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.VirtualMachine> CreateOrUpdate(string resourceGroupName, string vmName, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachine body)
        {
            var client = new ComputeManagementClient();
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachine> result1 = null;
            await client.VirtualMachinesCreateOrUpdate1(resourceGroupName, vmName, SubscriptionId, body,
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result1), Listener, Sender);
            return await result1 as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.VirtualMachine;
        }

        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.VirtualMachine> Get(string resourceGroupName, string vmName, Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.InstanceViewTypes? Expand)
        {
            var client = new ComputeManagementClient();
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachine> result1 = null;
            await client.VirtualMachinesGet1(resourceGroupName, vmName, Expand, SubscriptionId, 
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result1), Listener, Sender);
            return await result1 as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.VirtualMachine;
        }
    }

    public interface IScaleSetOperations
    {
        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.VirtualMachineScaleSet> CreateOrUpdate(string resourceGroupName, string vmScaleSetName, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSet body);

        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.VirtualMachineScaleSet> Get(string resourceGroupName, string vmScaleSetName);
    }

    public class ScaleSetOperations : IScaleSetOperations
    {
        public string SubscriptionId { get; set; }
        public PowerShell.Cmdlets.Compute.Runtime.ISendAsync Sender { get; set; }
        public PowerShell.Cmdlets.Compute.Runtime.IEventListener Listener { get; set; }

        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.VirtualMachineScaleSet> CreateOrUpdate(string resourceGroupName, string vmScaleSetName, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSet body)
        {
            var client = new ComputeManagementClient();
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSet> result1 = null;
            await client.VirtualMachineScaleSetsCreateOrUpdate1(resourceGroupName, vmScaleSetName, SubscriptionId, body,
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result1), Listener, Sender);
            return await result1 as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.VirtualMachineScaleSet;
        }

        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.VirtualMachineScaleSet> Get(string resourceGroupName, string vmScaleSetName)
        {
            var client = new ComputeManagementClient();
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IVirtualMachineScaleSet> result1 = null;
            await client.VirtualMachineScaleSetsGet1(resourceGroupName, vmScaleSetName, SubscriptionId,
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result1), Listener, Sender);
            return await result1 as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.VirtualMachineScaleSet;
        }

    }

    public interface IProximityPlacementGroupOperations
    {
        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.ProximityPlacementGroup> CreateOrUpdate(string resourceGroupName, string proximityPlacementGroupName, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IProximityPlacementGroup body);
        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.ProximityPlacementGroup> Get(string resourceGroupName, string proximityPlacementGroupName);
    }

    public class ProximityGroupPlacementOperations : IProximityPlacementGroupOperations
    {
        public string SubscriptionId { get; set; }
        public PowerShell.Cmdlets.Compute.Runtime.ISendAsync Sender { get; set; }
        public PowerShell.Cmdlets.Compute.Runtime.IEventListener Listener { get; set; }


        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.ProximityPlacementGroup> CreateOrUpdate(string resourceGroupName, string proximityPlacementGroupName, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IProximityPlacementGroup body)
        {
            var client = new ComputeManagementClient();
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IProximityPlacementGroup> result1 = null;
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IProximityPlacementGroup> result2 = null;
            await client.ProximityPlacementGroupsCreateOrUpdate(resourceGroupName, proximityPlacementGroupName, SubscriptionId, body,
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result1), 
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result2), 
                Listener, Sender);
            if (result1 != null)
                return await result1 as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.ProximityPlacementGroup;
            return await result2 as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.ProximityPlacementGroup;
        }

        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.ProximityPlacementGroup> Get(string resourceGroupName, string proximityPlacementGroupName)
        {
            var client = new ComputeManagementClient();
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IProximityPlacementGroup> result1 = null;
            await client.ProximityPlacementGroupsGet(resourceGroupName, proximityPlacementGroupName, SubscriptionId,
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result1), Listener, Sender);
            return await result1 as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.ProximityPlacementGroup;
        }

    }

    public interface IDiskOperations
    {
        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.Disk> CreateOrUpdate(string resourceGroupName, string diskName, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.IDisk body);
        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.Disk> Get(string resourceGroupName, string diskName);
    }

    public class DiskOperations : IDiskOperations
    {
        public string SubscriptionId { get; set; }
        public PowerShell.Cmdlets.Compute.Runtime.ISendAsync Sender { get; set; }

        public PowerShell.Cmdlets.Compute.Runtime.IEventListener Listener { get; set; }


        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.Disk> CreateOrUpdate(string resourceGroupName, string diskName, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.IDisk body)
        {
            var client = new ComputeManagementClient();
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.IDisk> result = null;
            await client.DisksCreateOrUpdate(SubscriptionId, resourceGroupName, diskName, body,
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result), Listener, Sender);
            return await result as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.Disk;
        }

        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.Disk> Get(string resourceGroupName, string diskName)
        {
            var client = new ComputeManagementClient();
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.IDisk> result = null;
            await client.DisksGet(SubscriptionId, resourceGroupName, diskName,
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result), Listener, Sender);
            return await result as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.Disk;
        }
    }
    public interface IGalleryImageOperations
    {
        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.GalleryImageVersion> VersionsGet(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, Support.ReplicationStatusTypes? Expand);
        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.GalleryImage> ImagesGet(string resourceGroupName, string galleryName, string galleryImageName);
    }

    public class GalleryImageOperations : IGalleryImageOperations
    {
        public string SubscriptionId { get; set; }
        public PowerShell.Cmdlets.Compute.Runtime.ISendAsync Sender { get; set; }

        public PowerShell.Cmdlets.Compute.Runtime.IEventListener Listener { get; set; }

        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.GalleryImageVersion> VersionsGet(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, ReplicationStatusTypes? Expand)
        {
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IGalleryImageVersion> result = null;
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.ICloudError> error = null;
            var client = new ComputeManagementClient();
            await client.GalleryImageVersionsGet(SubscriptionId, resourceGroupName, galleryName, galleryImageName, galleryImageVersionName, Expand,
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result), 
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out error),
                Listener, Sender);
            if (result != null)
                return await result as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.GalleryImageVersion;

            var message = "Error sending request, please try again";
            if (error != null)
            {
                var exception = await error;
                message = exception.ToString();
            }

            throw new HttpRequestException(message);

        }
        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.GalleryImage> ImagesGet(string resourceGroupName, string galleryName, string galleryImageName)
        {
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IGalleryImage> result = null;
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.ICloudError> error = null;
            var client = new ComputeManagementClient();
            await client.GalleryImagesGet(SubscriptionId, resourceGroupName, galleryName, galleryImageName,
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result),
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out error),
                Listener, Sender);
            if (result != null)
                return await result as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.GalleryImage;

            var message = "Error sending request, please try again";
            if (error != null)
            {
                var exception = await error;
                message = exception.ToString();
            }

            throw new HttpRequestException(message);
        }

    }

    public interface IImageOperations
    {
        Task<IEnumerable<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.VirtualMachineImageResource>> List(string location, string publisherName, string offer, string skus, string Filter, int? Top, string Orderby, string apiVersion);

        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.VirtualMachineImage> Get(string location, string publisherName, string offer, string skus, string version);

        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.Image> ImagesGet(string resourceGroupName, string imageName, string Expand);
    }

    public class ImageOperations : IImageOperations
    {
        public string SubscriptionId { get; set; }
        public PowerShell.Cmdlets.Compute.Runtime.ISendAsync Sender { get; set; }

        public PowerShell.Cmdlets.Compute.Runtime.IEventListener Listener { get; set; }

        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.VirtualMachineImage> Get(string location, string publisherName, string offer, string skus, string version)
        {
            var client = new ComputeManagementClient();
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineImage> result = null;
            await client.VirtualMachineImagesGet(location, publisherName, offer, skus, version, SubscriptionId, 
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result), Listener, Sender);
            return await result as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.VirtualMachineImage;
        }

        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.Image> ImagesGet(string resourceGroupName, string imageName, string Expand)
        {
            var client = new ComputeManagementClient();
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IImage> result = null;
            await client.ImagesGet(resourceGroupName, imageName, Expand, SubscriptionId,
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result), Listener, Sender);
            return await result as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.Image;
        }

        public async Task<IEnumerable<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.VirtualMachineImageResource>> List(string location, string publisherName, string offer, string skus, string Filter, int? Top, string Orderby, string apiVersion)
        {
            var client = new ComputeManagementClient();
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineImageResource[]> result = null;
            await client.VirtualMachineImagesList(location, publisherName, offer, skus, Filter, Top, Orderby, apiVersion, SubscriptionId,
            (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result), Listener, Sender);
            return (await result).Select(i => i as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.VirtualMachineImageResource);
        }
    }

    public interface IAvailabilitySetOperations
    {
        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.AvailabilitySet> Get(string resourceGroupName, string availabilitySetName);
        Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.AvailabilitySet> CreateOrUpdate(string resourceGroupName, string availabilitySetName, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IAvailabilitySet body);

    }

    public class AvailabilitySetOperations : IAvailabilitySetOperations
    {

        public string SubscriptionId { get; set; }
        public PowerShell.Cmdlets.Compute.Runtime.ISendAsync Sender { get; set; }

        public PowerShell.Cmdlets.Compute.Runtime.IEventListener Listener { get; set; }

        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.AvailabilitySet> CreateOrUpdate(string resourceGroupName, string availabilitySetName, Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IAvailabilitySet body)
        {
            var client = new ComputeManagementClient();
                Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IAvailabilitySet> result = null;
                await client.AvailabilitySetsCreateOrUpdate(resourceGroupName, availabilitySetName, SubscriptionId, 
                    body as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.AvailabilitySet, 
                    (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result), Listener, Sender);
                return (await result as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.AvailabilitySet);
        }

        public async Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.AvailabilitySet> Get(string resourceGroupName, string availabilitySetName)
        {
            var client = new ComputeManagementClient();
            Task<Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IAvailabilitySet> result = null;
            await client.AvailabilitySetsGet1(resourceGroupName, availabilitySetName, SubscriptionId, 
             (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out result), Listener, Sender);
            return (await result as Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.AvailabilitySet);
        }
    }

}
