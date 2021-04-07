using System;
using System.Collections.Generic;

namespace DeviceV2.Util
{
    public static class ListUtil
    {
        public static string ConvertListToString<T>(this List<T> list, string delemetry)
        {
            return string.Join(delemetry, list);
        }
    }
}
