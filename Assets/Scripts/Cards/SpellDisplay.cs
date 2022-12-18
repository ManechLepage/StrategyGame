using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SpellDisplay : MonoBehaviour
{ 
    public Spell card;
    [Space]
    public GameObject image;
    [Space]
    public TextMeshProUGUI nameLabel;
    public TextMeshProUGUI descriptionLabel;
    [Space]
    public TextMeshProUGUI costLabel;

    private Sprite borderSprite;
    void Start()
    {
        SpriteRenderer cardImage = image.GetComponent<SpriteRenderer>();
        cardImage.sprite = card.cardImage;
        cardImage.transform.localScale = new Vector3(20, 19, 1);
        costLabel.text = card.cost.ToString();
        nameLabel.text = card.name;

        TMP_Text descriptionLabelTMP = descriptionLabel.GetComponent<TMP_Text>();
        gameObject.GetComponent<DisplayDescription>().DisplayCardDescription(card.description, descriptionLabelTMP);
    }
}
