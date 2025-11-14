using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueEngine.Gameplay;
using Unity.VisualScripting;

namespace RogueEngine
{
    [CreateAssetMenu(fileName = "Event", menuName = "TcgEngine/MapEvent/Myster", order = 10)]
    public class EventMystery : EventData
    {

        //Have the player make a chioice  to grab stick had in barrel
        //if yes deal 10 damage and have the player gain item
        //if no then have player procced to next map event
        public override bool AreEventsConditionMet(World world, Champion triggerer)
        {
            return true;
        }

        public override void DoEvent(WorldLogic logic, Champion triggerer)
        {
            
            base.DoEvent(logic, triggerer);
        }
        //make a method for when the player chose

        //make a method for when player says no
    }
}
