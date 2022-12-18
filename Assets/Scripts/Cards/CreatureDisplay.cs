using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CreatureDisplay : MonoBehaviour
{
    public Creature card;
    [Space]
    public GameObject image;
    [Space]
    public TextMeshProUGUI nameLabel;
    public TextMeshProUGUI creatureClass;
    public TextMeshProUGUI descriptionLabel;
    [Space]
    public TextMeshProUGUI cost;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI health;

    private Sprite borderSprite;
    void Start()
    {
        SpriteRenderer cardImage = image.GetComponent<SpriteRenderer>();
        cardImage.sprite = card.cardImage;
        cardImage.transform.localScale = new Vector3(20, 19, 1);
        
        creatureClass.text = card.creatureClass;
        nameLabel.text = card.name;

        cost.text = card.cost.ToString();
        attack.text = card.attack.ToString();
        health.text = card.health.ToString();

        TMP_Text descriptionLabelTMP = descriptionLabel.GetComponent<TMP_Text>();
        gameObject.GetComponent<DisplayDescription>().DisplayCardDescription(card.description, descriptionLabelTMP);
    }
}
