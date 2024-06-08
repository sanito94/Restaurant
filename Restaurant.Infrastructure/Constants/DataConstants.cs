using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const int CategoryNameLength = 50;

        public const int ItemNameMaxLength = 100;
        public const int ItemNameMinLength = 3;

        public const int ItemDescriptionMaxLength = 150;
        public const int ItemDescriptionMinLength = 6;

        public const string ItemPriceMaxLength = "10000";
        public const string ItemPriceMinLength = "1";


        public const int SenderEmailMaxLength = 100;
        public const int SenderEmailMinLength = 5;

        public const int SenderNameMaxLength = 50;
        public const int SenderNameMinLength = 5;

        public const int SubjectMaxLength = 30;
        public const int SubjectMinLength = 2;

        public const int MessageMaxLength = 250;
        public const int MessageMinLength = 10;

        public const int PhoneNumberMaxLength = 250;
        public const int PhoneNumberMinLength = 9;
    }
}
