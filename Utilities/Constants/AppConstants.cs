using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Utilities.Constants
{
    public class AppConstants
    {
        public const string SolutionName = "Burak.Application.Inveon";
        public const string DataStorageSection = "DataStorageSection";
        public const string AcceptedLanguageHeaderKey = "Accept-Language";
        public static CultureInfo DefaultCultureInfo = new CultureInfo("en-US");
        public const int DefaultPageNumber = 1;
        public const int DefaultPageSize = 25;
        public const string JWTSecretKey = "This is a secret key, it should not be shared with others!";
    }
}
