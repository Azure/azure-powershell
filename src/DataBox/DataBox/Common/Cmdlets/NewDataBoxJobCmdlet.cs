using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.DataBox.Common;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models;
using Microsoft.Azure.PowerShell.Cmdlets.DataBox.Resources;
using Microsoft.Azure.Management.DataBox;
using System.Reflection;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Threading;
using Resource = Microsoft.Azure.PowerShell.Cmdlets.DataBox.Resources.Resource;

namespace Microsoft.Azure.Commands.DataBox.Common
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataBoxJob" , SupportsShouldProcess = true), OutputType(typeof(PSDataBoxJob))]
    public class NewDataBoxJob : AzureDataBoxCmdletBase
    {

        [Parameter(Mandatory = true)]
        public string Location;

        [Parameter(Mandatory = false)]
        public AddressType AddressType = AddressType.None;

        [Parameter(Mandatory = false)]
        public string CompanyName;

        [Parameter(Mandatory = true)]
        public string StreetAddress1;

        [Parameter(Mandatory = false)]
        public string StreetAddress2;

        [Parameter(Mandatory = false)]
        public string StreetAddress3;

        [Parameter(Mandatory = true)]
        public string PostalCode;

        [Parameter(Mandatory = true)]
        public string City;

        [Parameter(Mandatory = true, HelpMessage = "Input the state or province code. Like CA - California; FL - Florida; NY - New York")]
        public string StateOrProvinceCode;

        [Parameter(Mandatory = true)]
        public string CountryCode;

        [Parameter(Mandatory = true)]
        public string[] EmailId;

        [Parameter(Mandatory = true)]
        public string PhoneNumber;

        [Parameter(Mandatory = true)]
        public string ContactName;

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Id")]
        public String[] StorageAccountResourceId;

        [Parameter(Mandatory = true)]
        [ValidateSet("DataBoxDisk", "DataBox", "DataBoxHeavy")]
        public string DataBoxType;

        [Parameter(Mandatory = false)]
        public int ExpectedDataSizeInTeraBytes;

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (DataBoxType == "DataBoxDisk" && ExpectedDataSizeInTeraBytes.Equals(0))
            {
                throw new PSArgumentNullException("ExpectedDataSizeInTeraBytes");
            }

            ShippingAddress shippingAddress = new ShippingAddress()
            {
                AddressType = this.AddressType,
                CompanyName = this.CompanyName,
                StreetAddress1 = this.StreetAddress1,
                StreetAddress2 = this.StreetAddress2,
                StreetAddress3 = this.StreetAddress3,
                City = this.City,
                StateOrProvince = this.StateOrProvinceCode,
                Country = this.CountryCode,
                PostalCode = this.PostalCode
            };

            ContactDetails contactDetails = new ContactDetails()
            {
                Phone = this.PhoneNumber,
                EmailList = EmailId,
                ContactName = this.ContactName
            };

            List<DestinationAccountDetails> destinationAccountDetails = new List<DestinationAccountDetails>();

            foreach (var storageAccount in StorageAccountResourceId)
            {
                destinationAccountDetails.Add(
                new DestinationAccountDetails(storageAccount));
            }
            
            DataBoxDiskJobDetails diskDetails;
            DataBoxJobDetails databoxDetails;
            DataBoxHeavyJobDetails heavyDetails;

            JobResource newJobResource = new JobResource();

            Sku sku = new Sku();
            switch (DataBoxType)
            {
                case "DataBoxDisk":
                    diskDetails = new DataBoxDiskJobDetails(contactDetails, shippingAddress, destinationAccountDetails, expectedDataSizeInTeraBytes: ExpectedDataSizeInTeraBytes);
                    sku.Name = SkuName.DataBoxDisk;
                    newJobResource = new JobResource(Location, sku, details: diskDetails);
                    break;
                case "DataBox":
                    databoxDetails = new DataBoxJobDetails(contactDetails, shippingAddress, destinationAccountDetails);
                    sku.Name = SkuName.DataBox;
                    newJobResource = new JobResource(Location, sku, details: databoxDetails);
                    break;
                case "DataBoxHeavy":
                    heavyDetails = new DataBoxHeavyJobDetails(contactDetails, shippingAddress, destinationAccountDetails);
                    sku.Name = SkuName.DataBoxHeavy;
                    newJobResource = new JobResource(Location, sku, details: heavyDetails);
                    break;
                default: break;
            }
            
            AddressValidationOutput addressValidationResult = ServiceOperationsExtensions.ValidateAddressMethod(
                DataBoxManagementClient.Service, Location, shippingAddress, newJobResource.Sku.Name);
            
            if (addressValidationResult.ValidationStatus != AddressValidationStatus.Valid)
            {
                
                WriteVerbose(Resource.AddressValidationStatus + addressValidationResult.ValidationStatus + "\n");

                //print alternate address
                if (addressValidationResult.ValidationStatus == AddressValidationStatus.Ambiguous)
                {
                    WriteVerbose(Resource.SupportAddresses + "\n\n");
                    foreach (ShippingAddress address in addressValidationResult.AlternateAddresses)
                    {
                        WriteVerbose(Resource.AddressType + address.AddressType + "\n");
                        if (!(string.IsNullOrEmpty(address.CompanyName)))
                            WriteVerbose(Resource.CompanyName + address.CompanyName);
                        if (!(string.IsNullOrEmpty(address.StreetAddress1)))
                            WriteVerbose(Resource.StreetAddress1 + address.StreetAddress1);
                        if (!(string.IsNullOrEmpty(address.StreetAddress2)))
                            WriteVerbose(Resource.StreetAddress2 + address.StreetAddress2);
                        if (!(string.IsNullOrEmpty(address.StreetAddress3)))
                            WriteVerbose(Resource.StreetAddress3 + address.StreetAddress3);
                        if (!(string.IsNullOrEmpty(address.City)))
                            WriteVerbose(Resource.City + address.City);
                        if (!(string.IsNullOrEmpty(address.StateOrProvince)))
                            WriteVerbose(Resource.StateOrProvince + address.StateOrProvince);
                        if (!(string.IsNullOrEmpty(address.Country)))
                            WriteVerbose(Resource.Country + address.Country);
                        if (!(string.IsNullOrEmpty(address.PostalCode)))
                            WriteVerbose(Resource.PostalCode + address.PostalCode);
                        if (!(string.IsNullOrEmpty(address.ZipExtendedCode)))
                            WriteVerbose(Resource.ZipExtendedCode + address.ZipExtendedCode);
                        WriteVerbose("\n\n");
                    }
                    throw new PSNotSupportedException(Resource.AmbiguousAddressMessage);
                }
                throw new PSNotSupportedException(Resource.InvalidAddressMessage);
            }

            if (ShouldProcess(this.Name, string.Format(Resource.CreatingDataboxJob + this.Name + Resource.InResourceGroup + this.ResourceGroupName)))
            {
                JobResource finalJobResource = JobsOperationsExtensions.Create(
                            DataBoxManagementClient.Jobs,
                            ResourceGroupName,
                            Name,
                            newJobResource);

                WriteObject(new PSDataBoxJob(finalJobResource));
            }   
        }
    }
}
