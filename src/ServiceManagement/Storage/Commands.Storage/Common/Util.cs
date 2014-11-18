﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{

    internal static class Util
    {
        /// <summary>
        /// Size formats
        /// </summary>
        private static string[] sizeFormats =
        {
            Resources.HumanReadableSizeFormat_Bytes,
            Resources.HumanReadableSizeFormat_KiloBytes,
            Resources.HumanReadableSizeFormat_MegaBytes,
            Resources.HumanReadableSizeFormat_GigaBytes,
            Resources.HumanReadableSizeFormat_TeraBytes,
            Resources.HumanReadableSizeFormat_PetaBytes,
            Resources.HumanReadableSizeFormat_ExaBytes
        };

        /// <summary>
        /// Translate a size in bytes to human readable form.
        /// </summary>
        /// <param name="size">Size in bytes.</param>
        /// <returns>Human readable form string.</returns>
        public static string BytesToHumanReadableSize(double size)
        {
            int order = 0;

            while (size >= 1024 && order + 1 < sizeFormats.Length)
            {
                ++order;
                size /= 1024;
            }

            return string.Format(sizeFormats[order], size);
        }
    }
}
