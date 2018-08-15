using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NodeContent : MonoBehaviour {

    // Use this for initialization

    [SerializeField]
    Text text;
    public void SetContent(NodeInfo nodeInfo)
    {
        this.text.text = nodeInfo.title;
    }
}
