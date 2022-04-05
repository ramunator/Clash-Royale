using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public Card card;

    public LayerMask groundLayer;

    public Vector3 defaultPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = transform.GetChild(0).position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.GetChild(0).position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        AddTroop(card.troopPf);
    }

    private void AddTroop(Transform troop)
    {
        Debug.DrawRay(Input.mousePosition, Vector3.down, Color.black, 100f);
        if (Physics.Raycast(transform.GetChild(0).position, Vector3.down, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {
            Instantiate(troop.gameObject, hit.point, Quaternion.identity);
        }
        else
        {
            transform.GetChild(0).position = defaultPos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = Vector3.zero;

        Image icon = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        TMP_Text elixrCountText = transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>();

        icon.sprite = card.icon;
        elixrCountText.text = card.elixrCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
