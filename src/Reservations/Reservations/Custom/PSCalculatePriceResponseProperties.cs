using System.Collections.Generic;
using Microsoft.Azure.Management.Reservations.Models;

namespace Microsoft.Azure.Commands.Reservations.Custom
{
    public class PSCalculatePriceResponseProperties
    {
        public string BillingCurrencyTotal { get; set; }

        public bool? IsBillingPartnerManaged { get; set; }

        public string ReservationOrderId { get; set; }

        public string SkuTitle { get; set; }

        public string SkuDescription { get; set; }

        public string PricingCurrencyTotal { get; set; }

        public string PaymentSchedule { get; set; }

        public PSCalculatePriceResponseProperties()
        {
        }

        public PSCalculatePriceResponseProperties(CalculatePriceResponseProperties properties)
        {
            if (properties != null)
            {
                BillingCurrencyTotal = PrintBillingCurrencyTotal(properties.BillingCurrencyTotal);
                IsBillingPartnerManaged = properties.IsBillingPartnerManaged;
                SkuTitle = properties.SkuTitle;
                SkuDescription = properties.SkuDescription;
                PricingCurrencyTotal = PrintPricingCurrencyTotal(properties.PricingCurrencyTotal);
                PaymentSchedule = PrintPaymentSchedule(properties.PaymentSchedule);
                ReservationOrderId = properties.ReservationOrderId;
            }
        }

        public string PrintBillingCurrencyTotal(CalculatePriceResponsePropertiesBillingCurrencyTotal billingCurrencyTotal)
        {
            string builder = "";
            if (billingCurrencyTotal != null)
            {
                builder += "CurrencyCode: " + billingCurrencyTotal.CurrencyCode;
                builder += "\n" + "Amount: " + billingCurrencyTotal.Amount;
            }
            return builder;
        }

        public string PrintPricingCurrencyTotal(CalculatePriceResponsePropertiesPricingCurrencyTotal pricingCurrencyTotal)
        {
            string builder = "";
            if (pricingCurrencyTotal != null)
            {
                builder += "CurrencyCode: " + pricingCurrencyTotal.CurrencyCode;
                builder += "\n" + "Amount: " + pricingCurrencyTotal.Amount;
            }
            return builder;
        }

        public string PrintPaymentSchedule(IList<PaymentDetail> details)
        {
            string builder = "";
            string billingPlanSpace = "                ";
            if (details != null)
            {
                foreach (PaymentDetail detail in details)
                {                    
                    string PriceTotal = PrintPrice(detail.PricingCurrencyTotal);
                    string BillingTotal = PrintPrice(detail.BillingCurrencyTotal);
                    builder += "\n" + billingPlanSpace;
                    builder += "\n" + "DueDate: " + detail.DueDate;
                    builder += "\n" + "PaymentDate: " + detail.PaymentDate;
                    builder += "\n" + "PricingCurrencyTotal: " + PriceTotal;
                    builder += "\n" + "BillingCurrencyTotal: " + BillingTotal;
                    builder += "\n" + "BillingAccount: " + detail.BillingAccount;
                    builder += "\n" + "Status: " + detail.Status;
                    builder += "\n" + "ExtendedStatusInfo: " + detail.ExtendedStatusInfo;
                }
            }
            return builder;
        }

        private string PrintPrice(Price price)
        {
            string builder = "";
            string currencyTotalSpaces = "                      ";
            if (price != null)
            {
                builder += "CurrencyCode: " + price.CurrencyCode;
                builder += "\n" + currencyTotalSpaces + "Amount: " + price.Amount;
            }
            return builder;
        }
    }
}
