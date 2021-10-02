using UnityEngine;

public static class PrefabUtils
{
    public static T InstantiateAndGetComponent<T>(string path, GameObject root = null) 
        where T : class
    {
        var prefab = (GameObject)Resources.Load(path);

        if (prefab == null)
        {
            Debug.LogError($"LoadPrefab: Unable to load prefab on {path}");
            return null;
        }

        GameObject instance;

        if (root != null)
        {
            // Initialize with parent of provided.
            instance = GameObject.Instantiate(prefab, root.transform);
        }
        else
        {
            instance = GameObject.Instantiate(prefab);
        }

        // Apply prefab name to avoid (Clone).
        instance.name = prefab.name;

        // If requested type is GameObject, return it without cast.
        if (instance is T gameObject)
        {
            return gameObject;
        }

        var component = instance.GetComponent<T>();

        if (component == null)
        {
            Debug.LogError($"PrefabController: Unable to get component {typeof(T).Name} form the loaded prefab {path}");
        }

        return component;
    }

    public static T InstantiateAndGetComponent<T>(GameObject prefab, GameObject root = null)
        where T : class
    {
        GameObject instance;

        if (root != null)
        {
            // Initialize with parent of provided.
            instance = GameObject.Instantiate(prefab, root.transform);
        }
        else
        {
            instance = GameObject.Instantiate(prefab);
        }

        // Apply prefab name to avoid (Clone).
        instance.name = prefab.name;

        // If requested type is GameObject, return it without cast.
        if (instance is T gameObject)
        {
            return gameObject;
        }

        var component = instance.GetComponent<T>();

        if (component == null)
        {
            Debug.LogError($"PrefabController: Unable to get component {typeof(T).Name} form the loaded prefab {prefab.name}");
        }

        return component;
    }
}