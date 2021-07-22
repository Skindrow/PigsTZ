using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{

    [SerializeField] private int sortingOrderBase;
    [SerializeField] private float offset;
    [SerializeField] private bool runOnlyOnce;
    [SerializeField] private Renderer rendererOnObject;

    private void Start()
    {
        if (rendererOnObject == null)
            rendererOnObject = gameObject.GetComponent<Renderer>();
    }
    private void LateUpdate()
    {
        rendererOnObject.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
        if (runOnlyOnce)
        {
            Destroy(this);
        }
    }
}
