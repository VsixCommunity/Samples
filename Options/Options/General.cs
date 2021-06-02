using System.ComponentModel;
using Community.VisualStudio.Toolkit;

namespace Options
{
    internal partial class OptionsProvider
    {
        // Register the options with these attributes on your package class:
        // [ProvideOptionPage(typeof(OptionsProvider.GeneralOptions), "MyExtension", "General", 0, 0, true)]
        // [ProvideProfile(typeof(OptionsProvider.GeneralOptions), "MyExtension", "General", 0, 0, true)]
        public class GeneralOptions : BaseOptionPage<General> { }
    }

    public class General : BaseOptionModel<General>
    {
        [Category("My category")]
        [DisplayName("My Option")]
        [Description("An informative description.")]
        [DefaultValue(true)]
        public bool MyOption { get; set; } = true;

        [Category("My category")]
        [DisplayName("My Enum")]
        [Description("Select the value you want from the list.")]
        [DefaultValue(Numbers.First)]
        [TypeConverter(typeof(EnumConverter))]
        public Numbers MyEnum { get; set; } = Numbers.First;
    }

    public enum Numbers
    {
        First,
        Second,
        Third,
    }
}
