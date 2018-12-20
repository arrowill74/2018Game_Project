using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearHand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RemoveAll ();
	}
	void RemoveAll () {
    List<GameObject> children = new List<GameObject> ();
    
    // Getting all children and putting them to a new list
    for ( int i = 0; i < transform.childCount; i++ )
    {
      children.Add (transform.GetChild (i).gameObject );
    }
    
    // Loop through children and destroy them
    foreach (GameObject go in children )
    {
      if (Application.isEditor )
			{
				GameObject.DestroyImmediate ( go );
			}
			else
			{
				GameObject.Destroy ( go );
			}
    }
}
}
