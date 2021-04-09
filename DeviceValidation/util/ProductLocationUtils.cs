using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceValidation.util
{
    public static class ProductLocationUtils
    {
        public const decimal AccuracyMaxLevel = 500.0M;
        public const decimal AccuracyMaxLevelOfTracker = 100.0M;
        public const string TrackerProductName = "TRACKER";
        public const decimal AccuracyMaxLevelOfProd2 = 200.0M;
        public const string Prod2ProductName = "Product2";

        // Right now we have single product as a exception, but it can be multiple in future so used KVT here.
        private static List<KeyValue<decimal>> ProductAccuracies = new List<KeyValue<decimal>>() {
                    new KeyValue<decimal>
                    {
                        KeyName = TrackerProductName,
                        value = AccuracyMaxLevelOfTracker
                    },
                    new KeyValue<decimal>
                    {
                        KeyName = Prod2ProductName,
                        value = AccuracyMaxLevelOfProd2
                    },
                };

        public static decimal GetAccuracyMaxLevelByProduct(string productId)
        {
            return ProductAccuracies.Where(c => c.KeyName == productId)?.FirstOrDefault()?.value ?? AccuracyMaxLevel;
        }
    }
}
