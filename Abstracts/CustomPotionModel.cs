using HarmonyLib;
using BaseLib.Patches.Content;
using MegaCrit.Sts2.Core.Helpers;
using MegaCrit.Sts2.Core.Models;

namespace BaseLib.Abstracts;

public abstract class CustomPotionModel : PotionModel, ICustomModel
{
    public virtual bool AutoAdd => true;
    public CustomPotionModel()
    {
        if (AutoAdd) CustomContentDictionary.AddModel(GetType());
    }

    public virtual string PackedImagePath => ImageHelper.GetImagePath("atlases/potion_atlas.sprites/fire_potion.tres");
    public virtual string PackedOutlinePath => ImageHelper.GetImagePath("atlases/potion_outline_atlas.sprites/fire_potion.tres");
    
    [HarmonyPatch(typeof(PotionModel), nameof(CustomPotionModel.PackedImagePath), MethodType.Getter)]
    private static class ImagePatch {
        static bool Prefix(PotionModel __instance, ref string __result) {
            if (__instance is CustomPotionModel model) {
                __result = model.PackedImagePath;
                return false;
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(PotionModel), nameof(CustomPotionModel.PackedOutlinePath), MethodType.Getter)]
    private static class OutlinePatch {
        static bool Prefix(PotionModel __instance, ref string __result) {
            if (__instance is CustomPotionModel model) {
                __result = model.PackedOutlinePath;
                return false;
            }
            return true;
        }
    }
}
