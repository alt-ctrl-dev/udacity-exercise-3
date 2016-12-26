using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	private static int coinCount;

	void Start ()
	{
		print ("Coin count = " + coinCount);
	}

	//Create a reference to the CoinPoofPrefab
	public void OnCoinClicked (GameObject poof)
	{
		// Instantiate the CoinPoof Prefab where this coin is located
		// Make sure the poof animates vertically
		Object.Instantiate (poof, gameObject.transform.position, Quaternion.Euler (Camera.main.transform.rotation.eulerAngles));

		// Destroy this coin. Check the Unity documentation on how to use Destroy
		Destroy (gameObject);
		coinCount++;
		print ("New Coin count = " + coinCount);
		UpdateText ();
	}

	private void UpdateText ()
	{
		var textObj = GameObject.FindGameObjectWithTag ("CoinText").GetComponent<TextMesh>();
		textObj.text = string.Format ("Coins {0}/5", coinCount);
	}

}
