using System.Collections;
using System.Collections.Generic;
using System.Net;
using RogueEngine.Gameplay;
using RogueEngine.UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace RogueEngine
{
    [CreateAssetMenu(fileName = "Event", menuName = "TcgEngine/MapEvent/Cutscene", order = 10)]
    public class EventCutscene : EventData
    {
        [Header("Cutscene")]
        public GameObject cutscene;
        private GameObject continueObject;
        private Button continueButton;
        private CanvasGroup continueCG;

        //optional text
        [Header("Text")]
        [TextArea(5, 8)]
        public string Text;

        public Continue[] Continue_C;
 
        
        public override bool AreEventsConditionMet(World world, Champion champion)
        {
            foreach(Continue Con in Continue_C)
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
                GameObject cutsceneObject = Instantiate(cutscene);

                continueObject = GameObject.Find("ContinueButton");

                continueButton = continueObject.GetComponent<Button>();
                continueCG = continueButton.GetComponent<CanvasGroup>();
                continueCG.alpha = 1;
                continueCG.interactable = true;

                continueButton.onClick.AddListener(() =>
                {
                    logic.CompleteAction(0);
                    Destroy(cutsceneObject);
                    continueCG.alpha = 0;
                    continueCG.interactable = false;
                });
            }
        }
        public override string GetText()
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
    public class Continue
    {
        public string text;
        public EventData Effect;
    }
}
