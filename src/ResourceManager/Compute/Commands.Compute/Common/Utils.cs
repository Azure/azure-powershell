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

using Microsoft.Azure.Commands.Compute.Strategies;
using Microsoft.Azure.Commands.Compute.Strategies.ComputeRp;
using Microsoft.Azure.Management.Compute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Common
{
    class Utils
    {
        static readonly int MIN_NUMBER_CORES_FOR_ACCEL_NET = 8;

        static readonly string[] ValidSizesForAccelNet = {"Standard_D3_v2", "Standard_D12_v2", "Standard_D3_v2_Promo", "Standard_D12_v2_Promo",

                      "Standard_DS3_v2", "Standard_DS12_v2", "Standard_DS13-4_v2", "Standard_DS14-4_v2",

                      "Standard_DS3_v2_Promo", "Standard_DS12_v2_Promo", "Standard_DS13-4_v2_Promo",

                      "Standard_DS14-4_v2_Promo", "Standard_F4", "Standard_F4s", "Standard_D8_v3", "Standard_D8s_v3",

                      "Standard_D32-8s_v3", "Standard_E8_v3", "Standard_E8s_v3", "Standard_D3_v2_ABC",

                      "Standard_D12_v2_ABC", "Standard_F4_ABC", "Standard_F8s_v2", "Standard_D4_v2",

                      "Standard_D13_v2", "Standard_D4_v2_Promo", "Standard_D13_v2_Promo", "Standard_DS4_v2",

                      "Standard_DS13_v2", "Standard_DS14-8_v2", "Standard_DS4_v2_Promo", "Standard_DS13_v2_Promo",

                      "Standard_DS14-8_v2_Promo", "Standard_F8", "Standard_F8s", "Standard_M64-16ms",

                      "Standard_D16_v3", "Standard_D16s_v3", "Standard_D32-16s_v3", "Standard_D64-16s_v3",

                      "Standard_E16_v3", "Standard_E16s_v3", "Standard_E32-16s_v3", "Standard_D4_v2_ABC",

                      "Standard_D13_v2_ABC", "Standard_F8_ABC", "Standard_F16s_v2", "Standard_D5_v2",

                      "Standard_D14_v2", "Standard_D5_v2_Promo", "Standard_D14_v2_Promo", "Standard_DS5_v2",

                      "Standard_DS14_v2", "Standard_DS5_v2_Promo", "Standard_DS14_v2_Promo", "Standard_F16",

                      "Standard_F16s", "Standard_M64-32ms", "Standard_M128-32ms", "Standard_D32_v3",

                      "Standard_D32s_v3", "Standard_D64-32s_v3", "Standard_E32_v3", "Standard_E32s_v3",

                      "Standard_E32-8s_v3", "Standard_E32-16_v3", "Standard_D5_v2_ABC", "Standard_D14_v2_ABC",

                      "Standard_F16_ABC", "Standard_F32s_v2", "Standard_D15_v2", "Standard_D15_v2_Promo",

                      "Standard_D15_v2_Nested", "Standard_DS15_v2", "Standard_DS15_v2_Promo",

                      "Standard_DS15_v2_Nested", "Standard_D40_v3", "Standard_D40s_v3", "Standard_D15_v2_ABC",

                      "Standard_M64ms", "Standard_M64s", "Standard_M128-64ms", "Standard_D64_v3", "Standard_D64s_v3",

                      "Standard_E64_v3", "Standard_E64s_v3", "Standard_E64-16s_v3", "Standard_E64-32s_v3",

                      "Standard_F64s_v2", "Standard_F72s_v2", "Standard_M128s", "Standard_M128ms", "Standard_L8s_v2",

                      "Standard_L16s_v2", "Standard_L32s_v2", "Standard_L64s_v2", "Standard_L96s_v2", "SQLGL",

                      "SQLGLCore", "Standard_D4_v3", "Standard_D4s_v3", "Standard_D2_v2", "Standard_DS2_v2",

                      "Standard_E4_v3", "Standard_E4s_v3", "Standard_F2", "Standard_F2s", "Standard_F4s_v2",

                      "Standard_D11_v2", "Standard_DS11_v2", "AZAP_Performance_ComputeV17C",

                      "AZAP_Performance_ComputeV17C_DDA", "Standard_PB6s", "Standard_PB12s", "Standard_PB24s",

                      "Standard_L80s_v2", "Standard_M8ms", "Standard_M8-4ms", "Standard_M8-2ms", "Standard_M16ms",

                      "Standard_M16-8ms", "Standard_M16-4ms", "Standard_M32ms", "Standard_M32-8ms",

                      "Standard_M32-16ms", "Standard_M32ls", "Standard_M32ts", "Standard_M64ls", "Standard_E64i_v3",

                      "Standard_E64is_v3", "Standard_E4-2s_v3", "Standard_E8-4s_v3", "Standard_E8-2s_v3",

                      "Standard_E16-4s_v3", "Standard_E16-8s_v3", "Standard_E20s_v3", "Standard_E20_v3"};

        static readonly string[] FourCoreSizesForAccelNet = { "Standard_D3_v2", "Standard_D3_v2_Promo", "Standard_D3_v2_ABC", "Standard_DS3_v2",

                           "Standard_DS3_v2_Promo", "Standard_D12_v2", "Standard_D12_v2_Promo", "Standard_D12_v2_ABC",

                           "Standard_DS12_v2", "Standard_DS12_v2_Promo", "Standard_F8s_v2", "Standard_F4",

                           "Standard_F4_ABC", "Standard_F4s", "Standard_E8_v3", "Standard_E8s_v3", "Standard_D8_v3",

                           "Standard_D8s_v3"};

        sealed class ImageTypeForAccelNet
        {
            public string Publisher { get; }
            public string Offer { get; }
            public string SkuPattern { get; }

            public ImageTypeForAccelNet(string publisher, string offer, string skuPattern)
            {
                Publisher = publisher;
                Offer = offer;
                SkuPattern = skuPattern;
            }

            public bool Matches(string publisher, string offer, string sku)
            {
                return (Publisher.Equals(publisher) && (offer == null || offer.Equals(Offer)) && (sku == null || SkuPattern == null || (new Regex(SkuPattern)).IsMatch(sku)));
            }
        }

        static readonly ImageTypeForAccelNet[]DistributionsForAccelNet = { new ImageTypeForAccelNet("canonical", "UbuntuServer", "^16.04"), new ImageTypeForAccelNet("suse", "sles", "^12-sp3"),
                   new ImageTypeForAccelNet("redhat", "rhel", "^7.4"), new ImageTypeForAccelNet("openlogic", "centos", "^7.4"), new ImageTypeForAccelNet("coreos", "coreos", null),
                   new ImageTypeForAccelNet("credativ", "debian", "-backports"), new ImageTypeForAccelNet("oracle", "oracle-linux", "^7.4"),
                   new ImageTypeForAccelNet("MicrosoftWindowsServer", "WindowsServer", "^2016"), new ImageTypeForAccelNet("MicrosoftWindowsServer", "WindowsServer", "^2012-R2") };

        public static bool DoesConfigSupportAcceleratedNetwork(Client client, ImageAndOsType imageInfo, string size, string location, string defaultLocation)
        {
            if (imageInfo?.Image?.Publisher == null)
            {
                return false;
            }

            var sizeFound = ValidSizesForAccelNet.Where(x => x.ToLower().Equals(size.ToLower()));
            if (sizeFound == null || sizeFound.Count() <= 0)
            {
                return false;
            }

            var fourCoreSize = FourCoreSizesForAccelNet.Where(x => x.ToLower().Equals(size.ToLower()));

            if (fourCoreSize == null || fourCoreSize.Count() == 0)
            {
                var locationToUse = String.IsNullOrWhiteSpace(location)? defaultLocation : location;
                //Check if the vm has enough cores
                var sizes = client.GetClient<ComputeManagementClient>().VirtualMachineSizes.List(locationToUse);
                if (sizes == null)
                {
                    return false;
                }

                var sizeInfo = sizes.Where(s => s.Name.ToLower().Equals(size.ToLower()));
                if (sizeInfo == null || sizeInfo.FirstOrDefault() == null || sizeInfo.FirstOrDefault().NumberOfCores < MIN_NUMBER_CORES_FOR_ACCEL_NET)
                {
                    return false;
                }
            }

            var distribuition = DistributionsForAccelNet.Where(d => d.Matches(imageInfo.Image.Publisher, imageInfo.Image.Offer, imageInfo.Image.Sku));
            if (distribuition == null || distribuition.FirstOrDefault() == null)
            {
                return false;
            }

            //This one is all set to use Accel Net
            return true;
        }
    }
}
