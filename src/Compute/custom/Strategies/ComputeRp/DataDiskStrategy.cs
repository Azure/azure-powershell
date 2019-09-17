// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Support;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class DataDiskStrategy
    {
        static IList<T> CreateDataDisks<T>(
            IEnumerable<int> imageDataDiskLuns,
            IEnumerable<int> dataDiskSizes,
            Func<string, int, int?, T> createDataDisk)
        {
            if (dataDiskSizes == null)
            {
                return null;
            }
            imageDataDiskLuns = imageDataDiskLuns.EmptyIfNull();
            var firstLun = imageDataDiskLuns
                .Select(v => v + 1)
                .Concat(new[] { 0 })
                .Max();
            return imageDataDiskLuns
                .Select(lun => createDataDisk(DiskCreateOptionTypes.FromImage, lun, null))
                .Concat(dataDiskSizes.Select((size, i) => createDataDisk(
                    DiskCreateOptionTypes.Empty,
                    i + firstLun,
                    size)))
                .ToList();
        }

        public static IList<IDataDisk> CreateDataDisks(
            IEnumerable<int> imageDataDiskLuns,
            IEnumerable<int> dataDiskSizes)
            => CreateDataDisks(
                imageDataDiskLuns,
                dataDiskSizes,
                (createOption, lun, size) => new DataDisk
                {
                    CreateOption = createOption,
                    Lun = lun,
                    SizeInGb = size,
                } as IDataDisk);

        public static IList<VirtualMachineScaleSetDataDisk> CreateVmssDataDisks(
            IEnumerable<int> dataDisks,
            IEnumerable<int> dataDiskSizes)
            => CreateDataDisks(
                dataDisks,
                dataDiskSizes,
                (createOption, lun, size) => new VirtualMachineScaleSetDataDisk
                {
                    CreateOption = createOption,
                    Lun = lun,
                    SizeInGb = size,
                });
    }
}
