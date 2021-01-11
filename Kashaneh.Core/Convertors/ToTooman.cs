using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Kashaneh.Core.Convertors
{
   public static class ToTooman
    {
        public static string Totooman(this int value)
        {
            return value.ToString("#,0 تومان");
        }
    }
}
