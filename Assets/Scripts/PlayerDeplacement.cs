using UnityEngine;

public class PlayerDeplacement : MonoBehaviour
{
    bool floorTouch = true;

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);


        if (Input.GetKey("space"))
        {
            if (floorTouch)
            {
                GetComponent<Rigidbody>().AddForce(0, 5f, 0, ForceMode.VelocityChange);
                floorTouch = false;
            }
        }


    }
    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("On touche le sol");
        if (collider.gameObject.name == "Sol")
        {
            floorTouch = true;
         //   Debug.Log("On touche le gameObject");
        }
    }
}