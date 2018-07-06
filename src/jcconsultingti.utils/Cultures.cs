using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.utils
{
    public static class Cultures
    {
        public static readonly CultureInfo UnitedKingdom =
            CultureInfo.GetCultureInfo("en-GB");

        public static readonly CultureInfo UnitedStates =
            CultureInfo.GetCultureInfo("en-US");

        public static readonly CultureInfo Brazil =
            CultureInfo.GetCultureInfo("pt-BR");
    }
}
