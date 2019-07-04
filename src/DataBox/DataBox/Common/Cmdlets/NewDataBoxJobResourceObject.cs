using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.DataBox.Common;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Threading;

namespace Microsoft.Azure.Commands.DataBox.Common
{
    [Cmdlet(VerbsCommon.New, "AzDataBoxJobResourceObject"), OutputType(typeof(String))]
    public class NewDataBoxJobResourceObject : AzureDataBoxCmdletBase
    {

        [Parameter(Mandatory = true)]
        [ValidateSet("West Europe","West Central US","WestUS")]
        public string Location;

        [Parameter(Mandatory = false)]
        //[Valida(AddressType.Commercial, AddressType.None)]
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

        [Parameter(Mandatory = true,
            HelpMessage = "Input a semicolon(;) seperated string of email ids. Eg : \"abc@outlook.com;xyz@outlook.com\"")]
        public string EmailId;

        [Parameter(Mandatory = true)]
        public string PhoneNumber;

        [Parameter(Mandatory = true)]
        public string ContactName;

        //[Parameter(Mandatory = true)]
        //[ValidateSet("Microsoft.Storage","Microsoft.ClassicStorage")]
        //public string StorageAccountProviderType;

        //[Parameter(Mandatory = true,
        //    HelpMessage ="Storage account's resource group name")]
        //public string StorageAccountResourceGroupName;

        //[Parameter(Mandatory = true)]
        //public string StorageAccountName;

        [Parameter(Mandatory = true)]
        public PSStorageAccount[] StorageAccount;

        [Parameter(Mandatory = true)]
        [ValidateSet("DataBoxDisk","Databox","DataBoxHeavy")]
        public string DataBoxType;

        [Parameter(Mandatory = false)]
        public int ExpectedDataSizeInTeraBytes;

        public override void ExecuteCmdlet()
        {
            if(DataBoxType == "DataBoxDisk" && ExpectedDataSizeInTeraBytes.Equals(0))
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

            List<string> emailList;
            emailList = EmailId.Split(new char[';'], StringSplitOptions.RemoveEmptyEntries).ToList();

            ContactDetails contactDetails = new ContactDetails()
            {
                Phone = this.PhoneNumber,
                EmailList = emailList,
                ContactName = this.ContactName
            };

            List<DestinationAccountDetails> destinationAccountDetails = new List<DestinationAccountDetails>();

            foreach(var storageAccount in StorageAccount)
            {
                destinationAccountDetails.Add(
                new DestinationAccountDetails(
                    string.Concat("/subscriptions/", DataBoxManagementClient.SubscriptionId.ToLower(),
                        "/resourceGroups/", storageAccount.ResourceGroupName.ToLower(),
                        "/providers/Microsoft.", storageAccount.Kind.ToLower(),
                        "/storageAccounts/", storageAccount.StorageAccountName.ToLower())));
            }
            


            DataBoxDiskJobDetails diskDetails;
            DataBoxJobDetails databoxDetails;
            DataBoxHeavyJobDetails heavyDetails;

            //JobDetails jobDetails = new JobDetails(contactDetails, shippingAddress, destinationAccountDetails);
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
                Console.WriteLine("Address validation status: {0}", addressValidationResult.ValidationStatus);

                //print alternate address
                if(addressValidationResult.ValidationStatus == AddressValidationStatus.Ambiguous)
                {
                    Console.WriteLine("\nSUPPORT ADDRESSES: ");
                    foreach(ShippingAddress address in addressValidationResult.AlternateAddresses)
                    {
                        Console.WriteLine("\nAddress type: {0}", address.AddressType);
                        if (!(string.IsNullOrEmpty(address.CompanyName)))
                            Console.WriteLine("Company name: {0}", address.CompanyName);
                        if (!(string.IsNullOrEmpty(address.StreetAddress1)))
                            Console.WriteLine("Street address1: {0}", address.StreetAddress1);
                        if (!(string.IsNullOrEmpty(address.StreetAddress2)))
                            Console.WriteLine("Street address2: {0}", address.StreetAddress2);
                        if (!(string.IsNullOrEmpty(address.StreetAddress3)))
                            Console.WriteLine("Street address3: {0}", address.StreetAddress3);
                        if (!(string.IsNullOrEmpty(address.City)))
                            Console.WriteLine("City: {0}", address.City);
                        if (!(string.IsNullOrEmpty(address.StateOrProvince)))
                            Console.WriteLine("State/Province: {0}", address.StateOrProvince);
                        if (!(string.IsNullOrEmpty(address.Country)))
                            Console.WriteLine("Country: {0}", address.Country);
                        if (!(string.IsNullOrEmpty(address.PostalCode)))
                            Console.WriteLine("Postal code: {0}", address.PostalCode);
                        if (!(string.IsNullOrEmpty(address.ZipExtendedCode)))
                            Console.WriteLine("Zip extended code: {0}", address.ZipExtendedCode);
                        Console.WriteLine("\n\n");
                    }
                    throw new PSNotSupportedException("\nThe Shipping Address is ambiguous. Please select any address from the ones provided above.");
                }
                throw new PSNotSupportedException("The Shipping Address is not Valid.");
            }
            else
            {
                WriteObject(newJobResource);
            }
            
        }


    }


}
