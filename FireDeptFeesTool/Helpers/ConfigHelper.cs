using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace FireDeptFeesTool.Helpers
{
    public enum ConfigFields
    {
        NAZIV_DRUSTVA,
        IBAN_PREJEMNIKA,
        BIC_BANKE,
        ZNESEK,
        LASER_XOFFSET,
        LASER_YOFFSET,
        ENDLESS_XOFFSET,
        ENDLESS_YOFFSET,
        DEBTS_TEMPLATE
    }

    public class ConfigHelper
    {
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private static readonly Dictionary<ConfigFields, string> configFieldsMapper = new Dictionary
            <ConfigFields, string>
                                                                                          {
                                                                                              {
                                                                                                  ConfigFields.
                                                                                                  NAZIV_DRUSTVA,
                                                                                                  "NazivDrustva"
                                                                                              },
                                                                                              {
                                                                                                  ConfigFields.
                                                                                                  IBAN_PREJEMNIKA,
                                                                                                  "IBANPrejemnika"
                                                                                              },
                                                                                              {
                                                                                                  ConfigFields.BIC_BANKE,
                                                                                                  "BICBanke"
                                                                                              },
                                                                                              {
                                                                                                  ConfigFields.ZNESEK,
                                                                                                  "Znesek"
                                                                                              },
                                                                                              {
                                                                                                  ConfigFields.
                                                                                                  LASER_XOFFSET,
                                                                                                  "Laser_XOffset"
                                                                                              },
                                                                                              {
                                                                                                  ConfigFields.
                                                                                                  LASER_YOFFSET,
                                                                                                  "Laser_YOffset"
                                                                                              },
                                                                                              {
                                                                                                  ConfigFields.
                                                                                                  ENDLESS_XOFFSET,
                                                                                                  "Endless_XOffset"
                                                                                              },
                                                                                              {
                                                                                                  ConfigFields.
                                                                                                  ENDLESS_YOFFSET,
                                                                                                  "Endless_YOffset"
                                                                                              },
                                                                                              {
                                                                                                  ConfigFields.
                                                                                                  DEBTS_TEMPLATE,
                                                                                                  "DebtsTemplate"
                                                                                              }
                                                                                          };

        public static T GetConfigValue<T>(ConfigFields field) where T : IConvertible
        {
            switch (field)
            {
                case ConfigFields.NAZIV_DRUSTVA:
                case ConfigFields.IBAN_PREJEMNIKA:
                case ConfigFields.BIC_BANKE:
                    return (T) Convert.ChangeType(GetStringValue(configFieldsMapper[field]), typeof (T));

                case ConfigFields.ZNESEK:
                    return (T) Convert.ChangeType(GetDecimalValue(configFieldsMapper[field]), typeof (T));

                case ConfigFields.LASER_XOFFSET:
                case ConfigFields.LASER_YOFFSET:
                case ConfigFields.ENDLESS_XOFFSET:
                case ConfigFields.ENDLESS_YOFFSET:
                    return (T) Convert.ChangeType(GetFloatValue(configFieldsMapper[field]), typeof (T));

                case ConfigFields.DEBTS_TEMPLATE:
                    return (T) Convert.ChangeType(GetStringValueFromFile(configFieldsMapper[field]), typeof (T));
            }

            return default(T);
        }

        private static float GetFloatValue(string property)
        {
            float retVal = float.Parse(ConfigurationManager.AppSettings[property].Replace(',', '.'),
                                       CultureInfo.InvariantCulture);
            return retVal;
        }

        private static string GetStringValue(string property)
        {
            return ConfigurationManager.AppSettings[property];
        }

        private static decimal GetDecimalValue(string property)
        {
            decimal retVal;
            decimal.TryParse(ConfigurationManager.AppSettings[property], out retVal);
            return retVal;
        }

        private static string GetStringValueFromFile(string property)
        {
            string path = ConfigurationManager.AppSettings[property];
            return File.ReadAllText(Path.GetFullPath(path));
        }
    }
}