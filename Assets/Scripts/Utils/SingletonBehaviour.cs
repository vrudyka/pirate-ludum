using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DR.Utils
{
	public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T instance;

		public static T Instance
		{
			get
			{
				if (instance != null)
					return instance;

				instance = FindObjectOfType<T>();

				if (instance != null)
				{
					return instance;
				}

				var holderGO = new GameObject($"Singleton - {typeof(T).Name}");
				instance = holderGO.AddComponent<T>();

                DontDestroyOnLoad(holderGO);

				return instance;
			}
		}
	}
}