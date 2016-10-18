using UnityEngine;
using System.Collections;

public interface ICommonItem
{
    int GotItem();
}

public class ItemTypeA : MonoBehaviour,ICommonItem {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GotItem()
    {
        print("gotitem - " + this.gameObject.tag.ToString() );

        Destroy(this.gameObject);
        return 2;
    }
}
