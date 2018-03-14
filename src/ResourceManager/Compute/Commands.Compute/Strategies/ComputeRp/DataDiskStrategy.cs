using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class DataDiskStrategy
    {
        static IList<T> CreateDataDisks<T>(
            int? offset,
            IEnumerable<int> dataDiskSizes,
            Func<DiskCreateOptionTypes, int, int, T> createDataDisk)
        {
            var firstDisk = offset == null ? 0 : (int)offset;
            return dataDiskSizes
                ?.Select((size, i) => createDataDisk(
                    DiskCreateOptionTypes.Empty,
                    i + firstDisk,
                    size))
                .ToList();
        }

        public static IList<DataDisk> CreateDataDisks(
            int? offset,
            IEnumerable<int> dataDiskSizes)
            => CreateDataDisks(
                offset,
                dataDiskSizes,
                (createOption, lun, size) => new DataDisk
                {
                    CreateOption = createOption,
                    Lun = lun,
                    DiskSizeGB = size,
                });

        public static IList<VirtualMachineScaleSetDataDisk> CreateVmssDataDisks(
            int? offset,
            IEnumerable<int> dataDiskSizes)
            => CreateDataDisks(
                offset,
                dataDiskSizes,
                (createOption, lun, size) => new VirtualMachineScaleSetDataDisk
                {
                    CreateOption = createOption,
                    Lun = lun,
                    DiskSizeGB = size,
                });
    }
}
