using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireDeptFeesTool.Common.Helpers
{
    public class ControlsHelper
    {
        public static object GetValue(Control control)
        {
            if (control.GetType() == typeof(TextBox))
            {
                return ((TextBox) control).Text;
            }

            if (control.GetType() == typeof(DateTimePicker))
            {
                return ((DateTimePicker) control).Value;
            }

            if (control.GetType() == typeof(CheckBox))
            {
                return ((CheckBox) control).Checked;
            }

            return null;
        }

        public static DateTimePicker CreateCustomFormatDateTimePicker(string format)
        {
            return
                new DateTimePicker
                    {
                        Format = DateTimePickerFormat.Custom,
                        CustomFormat = format
                    };
        }

        public static DateTimePicker CreateCustomFormatDateTimePicker(string format, DateTime defaultValue)
        {
            return
                new DateTimePicker
                {
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = format,
                    Value = defaultValue
                };
        }
    }
}
