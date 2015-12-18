using UnityEngine;
using System.Collections;

public class cloudMover : MonoBehaviour {

    #region ### Public Fields #########################################################################################
    #endregion

    public float speed;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (this.transform.position.z == -1)
        {
            speed = 2;
        }
        else if (this.transform.position.z == -2)
        {
            speed = 3;
        }
        else if (this.transform.position.z == -3)
        {
            speed = 4;
        }

        if (this.transform.position.y > 12)
        {
            Destroy(this.gameObject);
        }

	}
}
