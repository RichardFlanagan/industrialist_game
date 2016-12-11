using UnityEngine;
using System.Collections;

[System.Serializable]
public class Loadable<T> {
	public static T fromJSON(string jsonString){
		return JsonUtility.FromJson<T>(jsonString);
	}
}
