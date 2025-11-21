using System.Collections;
using System.Collections.Generic;
using RogueEngine.Gameplay;
using RogueEngine.UI;
using UnityEngine;

namespace RogueEngine
{
    [CreateAssetMenu(fileName = "Battle", menuName = "TcgEngine/MapEvent/Cutscene", order = 10)]
    public class EventCutscene : EventData
    {
        [Header("Cutscene")]
        public Sprite SpriteRenderer;

        //optional text
        [Header("Text")]
        [TextArea(5, 8)]
        public string Text;
        
        [Header("Continue choice")]
        public ChoiceElement[] continues;
        public override bool AreEventsConditionMet(World world, Champion champion)
        {
            foreach (ChoiceElement choice in continues) 
            {
                if(choice.effect.AreEventsConditionMet(world, champion))
                
                    return true; 
            }
               return false;

        }
        //wait till player uses the continue button techniaclly choices
        public override void DoEvent(WorldLogic logic, Champion triggerer)
        {
            logic.WorldData.state = WorldState.EventChoice;
          
        }
        public override string GetText()
        {
            return Text;
        }
        public static new EventChoice Get(string id)
        {
            foreach (EventData evt in GetAll())
            {
                if (evt.id == id && evt is EventChoice)
                    return evt as EventChoice;
            }
            return null;
        }

    }
    [System.Serializable]
    public class ChoiceElemts
    {
        public string text;
        public string subtext;
        public EventData effect;
    }

}
