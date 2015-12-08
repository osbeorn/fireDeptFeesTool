using FireDeptFeesTool.Model.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDeptFeesTool.Common.Helpers
{
    public class PaymentStatusHelper
    {
        #region Payment status text

        public const string PLACAL_TEXT = "Plačal";
        public const string NI_PLACAL_TEXT = "Ni plačal";
        public const string VETERAN_TEXT = "Veteran";
        public const string MLADOLETNIK_TEXT = "Mladoletnik";
        public const string NI_PODATKA_TEXT = "Ni podatka";

        #endregion

        #region Payment status descriptions

        public const string PLACAL_DESC = "";
        public const string NI_PLACAL_DESC = "";
        public const string VETERAN_DESC = "Starost člana >= 60 let.";
        public const string MLADOLETNIK_DESC = "Starost člana <= 18 let.";
        public const string NI_PODATKA_DESC = "";

        #endregion

        public static PaymentStatus GetPaymentStatus(int value)
        {
            return new PaymentStatus
            {
                Status = (PaymentStatusEnum) value,
                Text = PaymentStatusHelper.GetPaymentStatusText((PaymentStatusEnum) value),
                Description = PaymentStatusHelper.GetPaymentStatusDesc((PaymentStatusEnum) value)
            };
        }

        public static PaymentStatus GetPaymentStatus(PaymentStatusEnum value)
        {
            return new PaymentStatus
            {
                Status = value,
                Text = PaymentStatusHelper.GetPaymentStatusText(value),
                Description = PaymentStatusHelper.GetPaymentStatusDesc(value)
            };
        }

        public static string GetPaymentStatusText(int value)
        {
            return GetPaymentStatusText((PaymentStatusEnum) value);
        }

        public static string GetPaymentStatusText(PaymentStatusEnum value)
        {
            switch (value)
            {
                case PaymentStatusEnum.PLACAL:
                    return PLACAL_TEXT;
                case PaymentStatusEnum.NI_PLACAL:
                    return NI_PLACAL_TEXT;
                case PaymentStatusEnum.VETERAN:
                    return VETERAN_TEXT;
                case PaymentStatusEnum.MLADOLETNIK:
                    return MLADOLETNIK_TEXT;
                case PaymentStatusEnum.NI_PODATKA:
                    return NI_PODATKA_TEXT;
                default:
                    return "";
            }
        }

        public static string GetPaymentStatusDesc(int value)
        {
            return GetPaymentStatusDesc((PaymentStatusEnum)value);
        }

        public static string GetPaymentStatusDesc(PaymentStatusEnum value)
        {
            switch (value)
            {
                case PaymentStatusEnum.PLACAL:
                    return PLACAL_DESC;
                case PaymentStatusEnum.NI_PLACAL:
                    return NI_PLACAL_DESC;
                case PaymentStatusEnum.VETERAN:
                    return VETERAN_DESC;
                case PaymentStatusEnum.MLADOLETNIK:
                    return MLADOLETNIK_DESC;
                case PaymentStatusEnum.NI_PODATKA:
                    return NI_PODATKA_DESC;
                default:
                    return "";
            }
        }

        public static List<PaymentStatus> GetPaymentStatusList()
        {
            var list = new List<PaymentStatus>();
            var values = Enum.GetValues(typeof(PaymentStatusEnum));

            foreach (var value in values) {
                list.Add(PaymentStatusHelper.GetPaymentStatus((PaymentStatusEnum) value));
            }

            return list;
        }
    }
}
