using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueEngine.Gameplay;

namespace RogueEngine
{
    /// <summary>
    /// Effect that directly causes hp loss, should not be buffed or debuffed from the value
    /// </summary>

    [CreateAssetMenu(fileName = "effect", menuName = "TcgEngine/Effect/LoseHP", order = 10)]
    public class EffectHPLoss : EffectData
    {
        public override void DoMapEventEffect(WorldLogic logic, EventEffect evt, Champion champion)
        {
            champion.damage += evt.value;
        }

        public override void DoMapEffect(WorldLogic logic, AbilityData ability, Champion champion, ChampionItem item, Champion target)
        {
            champion.damage += ability.GetValue();
        }

        public override void DoEffect(BattleLogic logic, AbilityData ability, BattleCharacter caster, Card card, BattleCharacter target)
        {
            target.damage += ability.GetValue();
            logic.TriggerOnCharacterDamaged(target, ability.GetValue());
        }

        public int GetDamage(AbilityData ability, BattleCharacter caster, Card card)
        {
            return ability.GetValue(caster, card);
        }
    }
}