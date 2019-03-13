using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class ImageDataDiskStrategy
    {
        static IList<int> GetLuns<T>(this IEnumerable<T> imageDataDisks, Func<T, int?> getLun)
            => imageDataDisks.Select(idd => getLun(idd) ?? 0).ToList();

        public static IList<int> GetLuns(this IEnumerable<ImageDataDisk> imageDataDisks)
            => imageDataDisks.GetLuns(idd => idd.Lun);

        public static IList<int> GetLuns(this IEnumerable<DataDiskImage> imageDataDisks)
            => imageDataDisks.GetLuns(idd => idd.Lun);
    }
}
