using BaseLib.Patches.Content;
using MegaCrit.Sts2.Core.Models;

namespace BaseLib.Abstracts;

public abstract class CustomRelicModel : RelicModel, ICustomModel, ILocalizationProvider
{
    public CustomRelicModel(bool autoAdd = true)
    {
        if (autoAdd) CustomContentDictionary.AddModel(GetType());
    }

    public virtual RelicModel? GetUpgradeReplacement() => null;
    
    /// <summary>
    /// Override this to define localization directly in your class.
    /// You are recommended to return a RelicLoc<seealso cref="RelicLoc"/>.
    /// </summary>
    public virtual List<(string, string)>? Localization => null;
}
