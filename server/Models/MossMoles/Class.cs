using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


//public class CustomStringLocalizer : IStringLocalizer
//{
//    private readonly CultureInfo _culture;

//    private readonly List<StringInfoData> _stringData;

//    public CustomStringLocalizer()
//    {
//        _stringData = new List<StringInfoData>();

//        InitializeLocalizedStrings(_stringData);
//    }

//    public CustomStringLocalizer(CultureInfo culture) : this()
//    {
//        _culture = culture;
//    }

//    public LocalizedString this[string name]
//    {
//        get
//        {
//            var culture = _culture ?? CultureInfo.CurrentUICulture;
//            var translation = _stringData.FirstOrDefault(x => x.CultureName == culture.Name && x.Name == name)?.Value;

//            return new LocalizedString(name, translation ?? name, translation != null);
//        }
//    }

//    public LocalizedString this[string name, params object[] arguments]
//    {
//        get
//        {
//            var culture = _culture ?? CultureInfo.CurrentUICulture;
//            var translation = _stringData.FirstOrDefault(x => x.CultureName == culture.Name && x.Name == name)?.Value;

//            if (translation != null)
//            {
//                translation = string.Format(translation, arguments);
//            }

//            return new LocalizedString(name, translation ?? name, translation != null);
//        }
//    }

//    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
//    {
//        return _stringData.Select(x => new LocalizedString(x.Name, x.Value, true)).ToList();
//    }

//    public IStringLocalizer WithCulture(CultureInfo culture)
//    {
//        return new CustomStringLocalizer(culture);
//    }

//    IEnumerable<LocalizedString> IStringLocalizer.GetAllStrings(bool includeParentCultures)
//    {
//        throw new System.NotImplementedException();
//    }

//    private void InitializeLocalizedStrings(List<StringInfoData> localizedStrings)
//    {
//        localizedStrings.Clear();

//        localizedStrings.Add(new StringInfoData("en-US", "Hello", "ezyak ya kamar!"));

//        localizedStrings.Add(new StringInfoData("ar-KW", "button21.Text", "مرحبا!"));

//        localizedStrings.Add(new StringInfoData("pt-BR", "Hello", "Oi!"));


//    }

//    private class StringInfoData
//    {
//        public StringInfoData(string cultureName, string name, string value)
//        {
//            CultureName = cultureName;
//            Name = name;
//            Value = value;
//        }

//        public string CultureName { get; private set; }

//        public string Name { get; private set; }

//        public string Value { get; private set; }
//    }
//}

////To use this implementation I needed create a Factory

//public class FactoryStringLocalizer : IStringLocalizerFactory
//{
//    public IStringLocalizer Create(Type resourceSource)
//    {
//        return new CustomStringLocalizer();
//    }

//    public IStringLocalizer Create(string baseName, string location) => null;


//}



