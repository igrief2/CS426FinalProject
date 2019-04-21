using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLobbyUI : MonoBehaviour
{
    [SerializeField] private Canvas UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideUI()
    {
        UI.enabled = false;
    }
}
