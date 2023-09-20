using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [HideInInspector]
    [Header("Path Points")]
    [SerializeField] public List<Waypoints> path;
    int currentPointIndex;
    public List<GameObject> prefabPoints;

    public GameObject Prefabe;
    public List<Waypoints> GetPath()
    {
        if (path == null)
        {
            path = new List<Waypoints>();
        }
        return path;
    }

    public void createAddPoint()
    {
        Waypoints go = new Waypoints();
        path.Add(go);
    }

    public Waypoints GetNextTarget()
    {
        int nextPointIndex = (currentPointIndex + 1) % (path.Count);
        currentPointIndex = nextPointIndex;
        return path[nextPointIndex];
    }
    private void Start()
    {
        prefabPoints = new List<GameObject>();
        foreach (Waypoints p in path)
        {
            GameObject go = Instantiate(Prefabe);
            go.transform.position = p.getPos();
            prefabPoints.Add(go);
        }
    }
    private void Update()
    {
        for (int i = 0; i < path.Count; i++)
        {
            Waypoints p = path[i];
            GameObject g = prefabPoints[i];
            g.transform.position = p.getPos();
        }
    }
}
