using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door
    public GameObject keyPoof;
    public Door door;

    private static int keyCount;

    void Start()
    {
        keyCount = 0;
        print("key count = " + keyCount);
    }

    void Update()
	{
		//Bonus: Key Animation
	}

	public void OnKeyClicked()
	{
        // Instatiate the KeyPoof Prefab where this key is located
        // Make sure the poof animates vertically
        Object.Instantiate(keyPoof, gameObject.transform.position, Quaternion.Euler(Camera.main.transform.rotation.eulerAngles));

        // Call the Unlock() method on the Door

        // Destroy the key. Check the Unity documentation on how to use Destroy
        Destroy(gameObject);
        UpdateText();
    }

    private void UpdateText()
    {
        var textObj = GameObject.FindGameObjectWithTag("KeyText").GetComponent<TextMesh>();
        textObj.text = string.Format("Key {0}/1", keyCount);
    }

}
