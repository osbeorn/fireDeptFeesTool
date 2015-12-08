using System.Reflection;
using System.Windows.Forms;

namespace FireDeptFeesTool.Common.Helpers
{
    public class DrawHelper
    {
        public static void EnableControlDoubleBuffering(string controlType, object control)
        {
            switch (controlType)
            {
                case "DataGridView":
                    typeof (DataGridView).InvokeMember(
                        "DoubleBuffered",
                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                        null,
                        control,
                        new object[] {true});
                    break;
            }
        }
    }
}