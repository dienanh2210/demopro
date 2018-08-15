using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class ScrollView : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    GameObject nodePrefab;
    [SerializeField]
    GameObject nodeContentPrefab;
    [SerializeField]
    Transform content;
    [SerializeField]
    Transform top;
    [SerializeField]
    Transform bottom;
    List<NodeInfo> nodeData = new List<NodeInfo>();
    List<NodeContent> nodeContentPool = new List<NodeContent>();

    
    private void Awake()
    {

        for (int i = 0; i < 100; i++)
        {
            NodeInfo nodeInf = new NodeInfo("Node: " + i.ToString());
            nodeData.Add(nodeInf);

        }
        foreach (NodeInfo nodeInfo in nodeData)
        {
            GameObject ob = Instantiate(nodePrefab);
            ob.transform.SetParent(content, false);

            Node node = ob.transform.GetComponent<Node>();
            node.Setup(top.position.y, bottom.position.y, nodeInfo, GetNodeContent, ReturnNodeContent);
        
        }
  
    }

    NodeContent GetNodeContent()
    {
        NodeContent nodeContent=null;
        if (nodeContentPool.Count > 0)
        {
            // if nodeContentPool has object, return it.
            nodeContent = nodeContentPool[0];
            nodeContentPool.RemoveAt(0);
        }
        else
        {
            // if not has, create object and return.
            createNodeContent();
            nodeContent = nodeContentPool[0];
            nodeContentPool.RemoveAt(0);
        }
        return nodeContent;
    }
    void ReturnNodeContent(NodeContent nodeContent)
    {
        nodeContentPool.Add(nodeContent);
    }
    void createNodeContent()
    {
        GameObject ob = Instantiate(nodeContentPrefab);
        nodeContentPool.Add(ob.GetComponent<NodeContent>());
    }
}
