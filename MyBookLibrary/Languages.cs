using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MyBookLibrary
{
    public enum Languages
    {
        English,
        French,
        Russian,
        Deutch,
        Lithuanian
    }

    public class LanguageHelper
    {
        public List<string> LanguageList
        {
            get
            {
                List<string> languages = new List<string>();
                Type languageType = typeof(Languages);

                //var fields = from c in languageType.GetFields()
                //             where c.IsLiteral
                //             select c;

                //foreach (var f in fields)
                //{
                //    var value = f.GetValue(languageType);
                //    languges.Add(value.ToString());
                //}
                return languages;
            }
        }
    }
}
