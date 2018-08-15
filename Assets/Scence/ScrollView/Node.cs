using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Node : MonoBehaviour
{

    // Use this for initialization
    float top, bottom;
    NodeInfo nodeInfo;
    NodeContent nodeContent;
    Func<NodeContent> GetNodeContent;
    Action<NodeContent> ReturnNodeContent;


    // public void showNode
    public void SetUp(float top, float bottom)
    {
        this.top = top;
        this.bottom = bottom;
    }
    public void Setup(float top, float bottom, NodeInfo nodeInfo, Func<NodeContent> GetNodeContent, Action<NodeContent> ReturnNodeContent)
    {
        this.top = top;
        this.bottom = bottom;
        this.nodeInfo = nodeInfo;
        this.GetNodeContent = GetNodeContent;
        this.ReturnNodeContent = ReturnNodeContent;
    }
    void LateUpdate()
    {
        if (this.transform.position.y > top || this.transform.position.y < bottom)
        {

            if (nodeContent != null)
            {
                ReturnNodeContent(nodeContent);
                nodeContent = null;
            }

        }
        else
        {
            if (nodeContent == null)
            {
                nodeContent = GetNodeContent();

                nodeContent.transform.SetParent(this.transform, false);
                nodeContent.SetContent(nodeInfo);
            }

        }
    }
}
public struct NodeInfo
{
    public string title;
    // public Sprite sprite;
    public NodeInfo(string title)
    {
        this.title = title;
    }
}