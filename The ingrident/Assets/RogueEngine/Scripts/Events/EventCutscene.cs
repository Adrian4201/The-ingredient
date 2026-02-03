using System.Collections;
using System.Collections.Generic;
using System.Net;
using RogueEngine.Gameplay;
using RogueEngine.UI;
using UnityEngine;

namespace RogueEngine
{
    [CreateAssetMenu(fileName = "Event", menuName = "TcgEngine/MapEvent/Cutscene", order = 10)]
    public class EventCutscene : EventData
    {
        [Header("Cutscene")]
        public GameObject cutscene;

        //optional text
        [Header("Text")]
        [TextArea(5, 8)]
        public string Text;

        public Countinue[] Continue_C;
 
        
        public override bool AreEventsConditionMet(World world, Champion champion)
        {
            foreach(Countinue Con in Continue_C)
            {
                Debug.Log("Working");
                if (Con.Effect.AreEventsConditionMet(world,champion))
                return true;
            }
            return false;
        }
        public override void DoEvent(WorldLogic logic, Champion triggerer)
        {
            logic.WorldData.state = WorldState.Cutscene;
            if(cutscene)
            {
                Instantiate(cutscene);
            }
        }
        public  string CutsceneText()
        {
            return Text;
        }
        public static new EventCutscene Get(string id)
        {
            foreach (EventData evt in GetAll())
            {
                if (evt.id == id && evt is EventCutscene)
                    return evt as EventCutscene;
            }
            return null;
        }

       
    }
    [System.Serializable]
    public class Countinue
    {
        public string text;
        public EventData Effect;
    }
}
