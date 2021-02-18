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

using ApiAddressDetails = Microsoft.Azure.Management.Billing.Models.AddressDetails;

namespace Microsoft.Azure.Commands.Billing.Models
{
    public class PSAddressDetails
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string District { get; set; }

        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string PostalCode { get; set; }

        public string Region { get; set; }

        public PSAddressDetails()
        {
        }

        public PSAddressDetails(ApiAddressDetails addressDetails)
        {
            if (addressDetails != null)
            {
                this.FirstName = addressDetails.FirstName;
                this.LastName = addressDetails.LastName;
                this.CompanyName = addressDetails.CompanyName;
                this.AddressLine1 = addressDetails.AddressLine1;
                this.AddressLine2 = addressDetails.AddressLine2;
                this.AddressLine3 = addressDetails.AddressLine3;
                this.City = addressDetails.City;
                this.Country = addressDetails.Country;
                this.District = addressDetails.District;
                this.Email = addressDetails.Email;
                this.PhoneNumber = addressDetails.PhoneNumber;
                this.PostalCode = addressDetails.PostalCode;
                this.Region = addressDetails.Region;
            }
        }
    }
}
