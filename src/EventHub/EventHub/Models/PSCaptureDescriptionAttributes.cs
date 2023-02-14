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

using Microsoft.Azure;
using Microsoft.Azure.Management;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Rest;
using System.Linq;

namespace Microsoft.Azure.Commands.EventHub.Models
{
   

    /// <summary>
    /// Properties to configure capture description for eventhub
    /// </summary>
    public class PSCaptureDescriptionAttributes
    {

        public PSCaptureDescriptionAttributes()
        {
            Destination = new PSDestinationAttributes();
        }

        /// <summary>
        /// Initializes a new instance of the CaptureDescription class.
        /// </summary>
        /// <param name="captureDescResource"></param>
        public PSCaptureDescriptionAttributes(Microsoft.Azure.Management.EventHub.Models.CaptureDescription captureDescResource)
        {
            Enabled = captureDescResource.Enabled;
            Encoding = (EnumEncodingCaptureDescription)captureDescResource.Encoding;
            IntervalInSeconds = captureDescResource.IntervalInSeconds;
            SizeLimitInBytes = captureDescResource.SizeLimitInBytes;
            if (captureDescResource.Destination != null)
                Destination = new PSDestinationAttributes(captureDescResource.Destination);
            else
                Destination = null;
            SkipEmptyArchives = captureDescResource.SkipEmptyArchives;
        }
        
        /// <summary>
        /// Gets or sets a value that indicates whether capture description is
        /// enabled.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets enumerates the possible values for the encoding format
        /// of capture description. Possible values include: 'Avro',
        /// 'AvroDeflate'
        /// </summary>
        public EnumEncodingCaptureDescription? Encoding { get; set; }

        /// <summary>
        /// Gets or sets the time window allows you to set the frequency with
        /// which the capture to Azure Blobs will happen, value should between
        /// 60 to 900 seconds
        /// </summary>
        public int? IntervalInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the size window defines the amount of data built up in
        /// your Event Hub before an capture operation, value should be between
        /// 10485760 to 524288000 bytes
        /// </summary>
        public int? SizeLimitInBytes { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether to Skip Empty Archives is
        /// enabled.
        /// </summary>
        public bool? SkipEmptyArchives { get; set; }

        /// <summary>
        /// Gets or sets properties of Destination where capture will be
        /// stored. (Storage Account, Blob Names)
        /// </summary>
        public PSDestinationAttributes Destination { get; set; }
        
    }
}
