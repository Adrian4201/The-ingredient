using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueEngine.AI;

namespace RogueEngine
{
    /// <summary>
    /// Condition that compares the target category of an ability to the actual target (card, player or slot)
    /// </summary>

    [CreateAssetMenu(fileName = "condition", menuName = "TcgEngine/Condition/ShuffleDeck", order = 10)]
    public class ConditionShuffleDeck : ConditionData
    {
        
        public override bool IsTargetConditionMet(Battle data, AbilityData ability, BattleCharacter character, Card card, CardData target)
        {
            return base.IsTargetConditionMet(data, ability, character, card, target);
        }
    }
    
}