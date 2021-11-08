using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApp2
{
    public static class Extension
    {
        public static string CamelCaseExchangeUnderLine(this string strItem)
        {
            string strItemTarget = "";
            for (int j = 0; j < strItem.Length; j++)
            {
                string temp = strItem[j].ToString();
                if (Regex.IsMatch(temp, "[A-Z]"))
                {
                    if (j == 0)
                    {
                        temp = temp.ToLower();
                    }
                    else
                    {
                        temp = "_" + temp.ToLower();
                    }
                }
                strItemTarget += temp;
            }
            return strItemTarget;
        }

        public static string WebDtoNameExchangeMapperName(this string strItem)
        {
            string strItemTarget = "WebDto";
            int n2 = strItem.IndexOf(strItemTarget, 0, StringComparison.Ordinal);
            return strItem.Substring(0, n2);
        }


        public static string TypeExchangeTypeString(this string type)
        {
            string typeString = "";
            switch (type)
            {
                case "string":
                    typeString = "ToStringValue";
                    break;
                // default type
                case "DateTime":
                    typeString = "ToDateValue";
                    break;
                case "decimal":
                    typeString = "ToDecimalValue";
                    break;
                case "bool":
                    typeString = "ToBoolValue";
                    break;
                case "int":
                    typeString = "ToIntValue";
                    break;
                default:
                    typeString = "NotFound";
                    break;
            }

            return typeString;
        }

        

    }
}
