using UnityEngine;
using System.Collections;

public class BillboardLightsManager : MonoBehaviour {

	public Light light1;
	public Light light2;
	
	public Texture level1Tex;
	public Texture level2Tex;
	public Texture level3Tex;
	public Texture level4Tex;

	void Start () {
		gameObject.GetComponent<Renderer>().materials[0].mainTexture = level1Tex;
	}

	void Update () {
		int j = Random.Range(0, 100);
		
		if(j > 80) {
			int i = Random.Range(0, 100);
			if(i > 90) {
				//Disable light 1
				light1.enabled = false;
			}
			i = Random.Range(0, 100);
			if(i > 90) {
				//Disable light 2
				light2.enabled = false;
			}
			
			i = Random.Range(0, 100);
			if(i > 80) {
				light1.enabled = true;
			}
			
			i = Random.Range(0, 100);
			if(i > 80) {
				light2.enabled = true;
			}
		}
		
	}
}
