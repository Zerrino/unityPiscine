using System.Collections.Generic;
using UnityEngine;

public class Filling : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Renderer sphere;
    [SerializeField] string groupName = "";

    bool isActive = false;


    static Dictionary<string, List<Filling>> groups = new Dictionary<string, List<Filling>>();
    static Dictionary<string, int> activeCountPerGroup = new Dictionary<string, int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (!groups.TryGetValue(groupName, out var list))
        {
            list = new List<Filling>();
            groups[groupName] = list;
            activeCountPerGroup[groupName] = 0;
        }
        if (!list.Contains(this))
        {
            list.Add(this);
        }
    }
    void Start()
    {
        sphere.enabled = false;
    }

    void OnDestroy()
    {
        if (!string.IsNullOrEmpty(groupName) && activeCountPerGroup.ContainsKey(groupName) && isActive)
            activeCountPerGroup[groupName] = Mathf.Max(0, activeCountPerGroup[groupName] - 1);
        if (!string.IsNullOrEmpty(groupName) && groups.TryGetValue(groupName, out var list))
        {
            list.Remove(this);
            if (list.Count == 0)
            {
                groups.Remove(groupName);
                activeCountPerGroup.Remove(groupName);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == controller.gameObject && !isActive)
        {
            isActive = true;
            activeCountPerGroup[groupName]++;
            RefreshAll(groupName);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == controller.gameObject && !isActive)
        {
            isActive = true;
            activeCountPerGroup[groupName]++;
            RefreshAll(groupName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == controller.gameObject && isActive)
        {
            isActive = false;
            activeCountPerGroup[groupName] = Mathf.Max(0, activeCountPerGroup[groupName] - 1);
            RefreshAll(groupName);
        }
    }

    static void RefreshAll(string gName)
    {
        int total = groups[gName].Count;
        bool allTouched = (activeCountPerGroup[gName] > 0 && activeCountPerGroup[gName] == total);
        if (groups[gName][0])
            groups[gName][0].sphere.enabled = allTouched;

        foreach (var gNameX in groups.Keys)
        {
            if (groups[gNameX][0].sphere.enabled == false)
                return;
        }
        SceneController.instance.NextLevel();
        Debug.Log("Every Sphere activated!");
    }

}
