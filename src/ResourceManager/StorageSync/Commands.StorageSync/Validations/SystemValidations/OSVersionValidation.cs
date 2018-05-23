namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Interfaces;

    public class OSVersionValidation : BaseSystemValidation
    {
        #region Fields and Properties
        private readonly Dictionary<string, string> _osversions;
        private readonly Dictionary<uint, string> _editions;
        #endregion

        #region Constructors
        public OSVersionValidation(IConfiguration configuration) : base(configuration, "OS version check", ValidationType.OsVersion)
        {
            _osversions = new Dictionary<string, string>();
            _osversions["10.0"] = "Windows Server 2016";
            _osversions["6.3"] = "Windows Server 2012 R2";

            _editions = new Dictionary<uint, string>();
            _editions[0] = "Undefined";
            _editions[1] = "Ultimate Edition";
            _editions[2] = "Home Basic Edition";
            _editions[3] = "Home Premium Edition";
            _editions[4] = "Enterprise Edition";
            _editions[5] = "Home Basic N Edition";
            _editions[6] = "Business Edition";
            _editions[7] = "Standard Server Edition";
            _editions[8] = "Datacenter Server Edition";
            _editions[9] = "Small Business Server Edition";
            _editions[10] = "Enterprise Server Edition";
            _editions[11] = "Starter Edition";
            _editions[12] = "Datacenter Server Core Edition";
            _editions[13] = "Standard Server Core Edition";
            _editions[14] = "Enterprise Server Core Edition";
            _editions[15] = "Enterprise Server Edition for Itanium-Based Systems";
            _editions[16] = "Business N Edition";
            _editions[17] = "Web Server Edition";
            _editions[18] = "Cluster Server Edition";
            _editions[19] = "Home Server Edition";
            _editions[20] = "Storage Express Server Edition";
            _editions[21] = "Storage Standard Server Edition";
            _editions[22] = "Storage Workgroup Server Edition";
            _editions[23] = "Storage Enterprise Server Edition";
            _editions[24] = "Server For Small Business Edition";
            _editions[25] = "Small Business Server Premium Edition";
            _editions[29] = "Web Server, Server Core";
            _editions[39] = "Datacenter Edition without Hyper-V, Server Core";
            _editions[40] = "Standard Edition without Hyper-V, Server Core";
            _editions[41] = "Enterprise Edition without Hyper-V, Server Core";
            _editions[42] = "Hyper-V Server";
        }
        #endregion

        #region Protected methods
        protected override IValidationResult DoValidateUsing(IPowershellCommandRunner commandRunner)
        {
            string osVersion;
            UInt32 sku;
            try
            {
                commandRunner.AddScript("Get-CimInstance Win32_OperatingSystem");
                PSObject resultPSObject = commandRunner.Invoke().First();
                osVersion = (string)resultPSObject.Members["Version"].Value;
                sku = (UInt32)resultPSObject.Members["OperatingSystemSKU"].Value;
            }
            catch (Exception e)
            {
                return ValidationResult.UnavailableValidation(this.ValidationType,
                    $"The OS Version validation was not able to complete. Cause: {e.Message}");
            }


            if (!IsValidVersion(osVersion))
            {
                string supportedVersions = String.Join(", ", this.Configuration.ValidOsVersions().Where(o => _osversions.ContainsKey(o)).Select(o => _osversions[o]));

                return new ValidationResult()
                {
                    Description = $"OS version {osVersion} is not supported. Supported versions are: {supportedVersions}",
                    Level = ResultLevel.Error,
                    Type = this.ValidationType,
                    Result = Result.Fail
                };
            }

            if (!IsValidSKU(sku))
            {
                string skuEdition = _editions.ContainsKey(sku) ? _editions[sku] : sku.ToString();
                string supportedSKU = String.Join(", ", this.Configuration.ValidOsSKU().Where(o => _editions.ContainsKey(o)).Select(o => _editions[o]));

                return new ValidationResult()
                {
                    Description = $"OS edition '{skuEdition}' is not supported. Supported editions are: {supportedSKU}",
                    Level = ResultLevel.Error,
                    Type = this.ValidationType,
                    Result = Result.Fail
                };
            }

            return this.SuccessfulResult;
        }
        #endregion

        #region Private methods
        private bool IsValidVersion(string osVersion)
        {
            foreach (string supportedOsVersion in this.Configuration.ValidOsVersions())
            {
                if (osVersion.StartsWith($"{supportedOsVersion}."))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsValidSKU(uint sku)
        {
            return this.Configuration.ValidOsSKU().Contains(sku);
        }
        #endregion
    }
}