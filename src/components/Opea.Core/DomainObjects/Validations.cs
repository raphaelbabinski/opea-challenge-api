using System;

namespace Opea.Core.DomainObjects
{
    public class Validations
    {
        public static void ValidateIsEmpty(string value, string message)
        {
            if (value == null || value.Trim().Length == 0) throw new Exception(message);
        }

        public static void ValidateIsEmpty(long value, string message)
        {
            if (value == 0) throw new Exception(message);
        }
    }
}
