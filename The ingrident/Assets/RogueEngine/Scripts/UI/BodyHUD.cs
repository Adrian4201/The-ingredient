using RogueEngine;
using System.Linq;
using UnityEngine;

public class BodyHUD : MonoBehaviour
{
    public GameObject bodyFill;
    public GameObject bodyOutline;

    private static SpriteRenderer[] bodyFillParts;
    private static SpriteRenderer[] bodyOutlineParts;
    private static CardColor[] cardColors = { CardColor.Red, CardColor.Orange, CardColor.Yellow, CardColor.Green, CardColor.Blue, CardColor.Purple };
    private static Color[] colors = { new Color(1, 0, 0), new Color(1, 0.38431f, 0), new Color(1, 0.86667f, 0), new Color(0, 0.60784f, 0.062745f), new Color(0, 0.24706f, 0.70588f), new Color(0.64314f, 0, 0.92157f) };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bodyFillParts = bodyFill.GetComponentsInChildren<SpriteRenderer>();
        bodyOutlineParts = bodyOutline.GetComponentsInChildren<SpriteRenderer>();
    }

    public static void FillColors(BattleCharacter character)
    {
        for(int i = 0; i < 6; i++)
        {
            if(character.cards_discard.Any(item => item.CardData.cardColor == cardColors[i]))
            {
                bodyOutlineParts[i].color = new Color(0, 0, 0, 0);
                bodyFillParts[i].color = Color.gray;
            }

            if (character.cards_hand.Any(item => item.CardData.cardColor == cardColors[i]))
            {
                bodyOutlineParts[i].color = colors[i];
                bodyFillParts[i].color = colors[i] / 1.5f;
            }

            if (character.cards_deck.Any(item => item.CardData.cardColor == cardColors[i]))
            {
                bodyOutlineParts[i].color = new Color(0, 0, 0, 0);
                bodyFillParts[i].color = colors[i];
            }
        }
    }
}