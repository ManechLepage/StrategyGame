using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> hand = new List<Card>();
    public List<GameObject> handObjects = new List<GameObject>();
    public List<Card> discard = new List<Card>();
    public UnityEngine.Object[] allCards;

    public Canvas canvas;

    private float handMargin = 350f;

    private void Start() {
        // Get all the creatures and spells in the game
        allCards = Resources.LoadAll("Cards", typeof(Card));
        // Create a new deck
        deck = CreateDeck();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DrawCard();
        }
    }

    public List<Card> CreateDeck() {
        List<Card> newDeck = new List<Card>();
        for (int i = 0; i < 30; i++) {
            int randomIndex = UnityEngine.Random.Range(0, allCards.Length);
            newDeck.Add((Card)allCards[randomIndex]);
        }
        return newDeck;
    }
    
    public void DrawCard() {
        if (deck.Count > 0 && hand.Count < 6) {
            hand.Add(deck[0]);
            deck.RemoveAt(0);

            if (deck[0].type == "Creature") 
            {
                GameObject card = Instantiate(Resources.Load("Cards/Template/Creature"), canvas.transform) as GameObject;
                card.transform.localScale *= 0.5f;
                Canvas cardCanvas = card.GetComponent<Canvas>();
                cardCanvas.overrideSorting = true;
                cardCanvas.sortingOrder = handObjects.Count;
                cardCanvas.sortingLayerName = "UI";
                card.name = "Creature:" + hand[hand.Count - 1].name;
                card.GetComponent<CreatureDisplay>().card = deck[0] as Creature;
                handObjects.Add(card);
            }
            else if (deck[0].type == "Spell") 
            {
                GameObject card = Instantiate(Resources.Load("Cards/Template/Spell"), canvas.transform) as GameObject;
                card.transform.localScale *= 0.5f;
                Canvas cardCanvas = card.GetComponent<Canvas>();
                cardCanvas.overrideSorting = true;
                cardCanvas.sortingOrder = handObjects.Count;
                cardCanvas.sortingLayerName = "UI";
                card.name = "Spell:" + hand[hand.Count - 1].name;
                card.GetComponent<SpellDisplay>().card = deck[0] as Spell;
                handObjects.Add(card);
            }


            //Move all cards back
            foreach (GameObject card in handObjects) {
                int index = handObjects.IndexOf(card);
                
                float step = handMargin * 3f / handObjects.Count;
                card.GetComponent<RectTransform>().localPosition = new Vector3(-handMargin + step * index, -300, 0);
                card.GetComponent<Canvas>().sortingOrder = (int)card.transform.position.y;

            }

        }
    }

}