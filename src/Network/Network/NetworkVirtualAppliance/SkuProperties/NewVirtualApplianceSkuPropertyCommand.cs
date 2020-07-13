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


using Microsoft.Azure.Commands.Common.Compute.Version2016_04_preview.Models;
using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualApplianceSkuProperty"), OutputType(typeof(PSVirtualApplianceSkuProperties))]
    public class NewVirtualApplianceSkuPropertyCommand : VirtualApplianceSkuPropertiesBaseCmdlet
    {
        [Alias("Name")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The name of the vendor.")]
        public virtual string VendorName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The bundled scale unit.")]
        public virtual string BundledScaleUnit { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The market place version.")]
        public virtual string MarketPlaceVersion { get; set; }

        public override void Execute()
        {
            base.Execute();
            var skuProperties = new PSVirtualApplianceSkuProperties();
            skuProperties.BundledScaleUnit = this.BundledScaleUnit;
            skuProperties.MarketPlaceVersion = this.MarketPlaceVersion;
            skuProperties.Vendor = this.VendorName;
            WriteObject(skuProperties);
        }
    }
}
