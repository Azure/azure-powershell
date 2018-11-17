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
        private readonly IList<string> _validOsVersions;
        private readonly IList<uint> _validOsSkus;
        private readonly string _supportedVersionsString;
        private readonly string _supportedEditionsStrings;
        #endregion

        #region Constructors
        public OSVersionValidation(IConfiguration configuration) : base(configuration, "OS version check", ValidationType.OsVersion)
        {
            this._osversions = new Dictionary<string, string>();
            this._osversions["10.0"] = "Windows Server 2016";
            this._osversions["6.3"] = "Windows Server 2012 R2";

            this._editions = new Dictionary<uint, string>();
            this._editions[0] = "Undefined";
            this._editions[1] = "Ultimate Edition";
            this._editions[2] = "Home Basic Edition";
            this._editions[3] = "Home Premium Edition";
            this._editions[4] = "Enterprise Edition";
            this._editions[5] = "Home Basic N Edition";
            this._editions[6] = "Business Edition";
            this._editions[7] = "Standard Server Edition";
            this._editions[8] = "Datacenter Server Edition";
            this._editions[9] = "Small Business Server Edition";
            this._editions[10] = "Enterprise Server Edition";
            this._editions[11] = "Starter Edition";
            this._editions[12] = "Datacenter Server Core Edition";
            this._editions[13] = "Standard Server Core Edition";
            this._editions[14] = "Enterprise Server Core Edition";
            this._editions[15] = "Enterprise Server Edition for Itanium-Based Systems";
            this._editions[16] = "Business N Edition";
            this._editions[17] = "Web Server Edition";
            this._editions[18] = "Cluster Server Edition";
            this._editions[19] = "Home Server Edition";
            this._editions[20] = "Storage Express Server Edition";
            this._editions[21] = "Storage Standard Server Edition";
            this._editions[22] = "Storage Workgroup Server Edition";
            this._editions[23] = "Storage Enterprise Server Edition";
            this._editions[24] = "Server For Small Business Edition";
            this._editions[25] = "Small Business Server Premium Edition";
            this._editions[29] = "Web Server, Server Core";
            this._editions[39] = "Datacenter Edition without Hyper-V, Server Core";
            this._editions[40] = "Standard Edition without Hyper-V, Server Core";
            this._editions[41] = "Enterprise Edition without Hyper-V, Server Core";
            this._editions[42] = "Hyper-V Server";

            this._validOsVersions = configuration.ValidOsVersions().ToList();
            this._validOsSkus = configuration.ValidOsSKU().ToList();
            this._supportedVersionsString = String.Join(", ", this._validOsVersions.Where(o => this._osversions.ContainsKey(o)).Select(o => this._osversions[o]));
            this._supportedEditionsStrings = String.Join(", ", this._validOsSkus.Where(o => this._editions.ContainsKey(o)).Select(o => this._editions[o]));

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
                return new ValidationResult()
                {
                    Description = $"OS version {osVersion} is not supported. Supported versions are: {this._supportedVersionsString}",
                    Level = ResultLevel.Error,
                    Type = this.ValidationType,
                    Result = Result.Fail
                };
            }

            if (!this.IsValidSKU(sku))
            {
                string skuEdition = this._editions.ContainsKey(sku) ? this._editions[sku] : sku.ToString();
                return new ValidationResult()
                {
                    Description = $"OS edition '{skuEdition}' is not supported. Supported editions are: {this._supportedEditionsStrings}",
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
            foreach (string supportedOsVersion in this._validOsVersions)
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
            return this._validOsSkus.Contains(sku);
        }
        #endregion
    }
}