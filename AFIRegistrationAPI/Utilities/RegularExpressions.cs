using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFIRegistrationAPI.Utilities
{
    public static class RegularExpressions
    {
        public const string EmailRegex = @"^[\w\-.]+@([\w -]+\.)+(com|co.uk)$";

        public const string PolicyNumberRegex = @"^([A-Z]){2}([\-]){1}([0-9]){6}$";
    }
}
