using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectBlocker : MonoBehaviour, IPointerClickHandler
{
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        return;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}