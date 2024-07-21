using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Infrastructure.DataConstants
{
    public static class Constants
    {

        public const int DescriptionMaxLength = 250;
        public const int DescriptionMinLength = 10;

        public const double MinimumAmount = 0.0;
        public const double MaximumAmount = 1000000.0;

        public const int NameMaxLength = 50;
        public const int NameMinLength = 3;

        public const int CategoryNameMaxLength = 50;
        public const int CategoryNameMinLength = 3;

        public const int TransactionNameMaxLength = 50;
        public const int TransactionNameMinLength = 3;
    }
}
