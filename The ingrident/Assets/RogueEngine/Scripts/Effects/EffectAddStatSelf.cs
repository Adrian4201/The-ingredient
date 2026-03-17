using RogueEngine;
using RogueEngine.Gameplay;
using UnityEngine;

namespace RogueEngine
{
    /// <summary>
    /// Effect that adds a status to the caster, regardless of the card's target
    /// </summary>
    
    [CreateAssetMenu(fileName = "effect", menuName = "TcgEngine/Effect/AddStatSelf", order = 10)]
    public class EffectAddStatSelf : EffectData
    {
        public StatusData add_status;

        public override void DoEffect(BattleLogic logic, AbilityData ability, BattleCharacter character, Card card)
        {
            character.AddStatus(add_status, ability.value);
        }

        public override void DoEffect(BattleLogic logic, AbilityData ability, BattleCharacter caster, Card card, BattleCharacter target)
        {
            Debug.Log(add_status.effect);
            caster.AddStatus(add_status, ability.value);
        }
    }
}