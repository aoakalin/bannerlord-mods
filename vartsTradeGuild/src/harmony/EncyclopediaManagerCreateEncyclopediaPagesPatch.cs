using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using TaleWorlds.CampaignSystem.Encyclopedia;
using vartsTradeGuild.dto;
using vartsTradeGuild.encyclopedia;

namespace vartsTradeGuild.harmony
{
    [HarmonyPatch(typeof(EncyclopediaManager), "CreateEncyclopediaPages")]
    public class EncyclopediaManagerCreateEncyclopediaPagesPatch
    {
        private static void Postfix(EncyclopediaManager __instance)
        {
            var defaultEncyclopediaVartsPage = new DefaultEncyclopediaVartsPage();

            var pagesField = typeof(EncyclopediaManager).GetField("_pages",
                BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
            var pages = pagesField.GetValue(__instance);
            ((Dictionary<Type, EncyclopediaPage>) pages).Add(typeof(VillageDto), defaultEncyclopediaVartsPage);
            pagesField.SetValue(__instance, pages);
        }
    }
}