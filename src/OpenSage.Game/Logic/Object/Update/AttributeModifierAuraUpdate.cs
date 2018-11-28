﻿using OpenSage.Data.Ini;
using OpenSage.Data.Ini.Parser;

namespace OpenSage.Logic.Object
{
    [AddedIn(SageGame.Bfme)]
    public sealed class AttributeModifierAuraUpdateModuleData : UpdateModuleData
    {
        internal static AttributeModifierAuraUpdateModuleData Parse(IniParser parser) => parser.ParseBlock(FieldParseTable);

        private static readonly IniParseTable<AttributeModifierAuraUpdateModuleData> FieldParseTable = new IniParseTable<AttributeModifierAuraUpdateModuleData>
        {
            { "StartsActive", (parser, x) => x.StartsActive = parser.ParseBoolean() },
            { "BonusName", (parser, x) => x.BonusName = parser.ParseString() },
            { "TriggeredBy", (parser, x) => x.TriggeredBy = parser.ParseAssetReference() },
            { "RefreshDelay", (parser, x) => x.RefreshDelay = parser.ParseInteger() },
            { "Range", (parser, x) => x.Range = parser.ParseInteger() },
            { "TargetEnemy", (parser, x) => x.TargetEnemy = parser.ParseBoolean() },
            { "ObjectFilter", (parser, x) => x.ObjectFilter = ObjectFilter.Parse(parser) },
            { "ConflictsWith", (parser, x) => x.ConflictsWith = parser.ParseAssetReferenceArray() },
            { "RunWhileDead", (parser, x) => x.RunWhileDead = parser.ParseBoolean() },
            { "RequiredConditions", (parser, x) => x.RequiredConditions = parser.ParseEnumBitArray<ModelConditionFlag>() },
            { "AntiCategory", (parser, x) => x.AntiCategory = parser.ParseEnum<ModifierCategory>() },
            { "AntiFX", (parser, x) => x.AntiFX = parser.ParseAssetReference() }
        };

        public bool StartsActive { get; private set; }
        public string BonusName	{ get; private set; }
        public string TriggeredBy { get; private set; }
        public int RefreshDelay	{ get; private set; }
        public int Range { get; private set; }
        public bool TargetEnemy	{ get; private set; }
        public ObjectFilter ObjectFilter { get; private set; }
        public string[] ConflictsWith { get; private set; }
        public bool RunWhileDead { get; private set; }
        public BitArray<ModelConditionFlag> RequiredConditions { get; private set; }
        public ModifierCategory AntiCategory { get; private set; }
		public string AntiFX { get; private set; }
    }
}