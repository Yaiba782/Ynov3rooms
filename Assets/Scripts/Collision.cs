using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    //Pour faire disparaître les murs dans le sol
    bool open = false;
    bool[] sphynx = new bool[] { false, false, false, false };

    void verification(int numero,bool[] sphynx)
    {
        //Debug.Log("On entre dans la verif");
        for (int numerobis = numero; numerobis >= 0; numerobis--){
            if (sphynx[numerobis] == false)
            {
                reset(sphynx);
                /*Debug.Log("L'ordre n'était pas bon, recommencer.");

                Debug.Log("O : " + sphynx[0]);
                Debug.Log("1 : " + sphynx[1]);
                Debug.Log("2 : " + sphynx[2]);
                Debug.Log("3 : " + sphynx[3]); */
                return;
            }
            if(sphynx[3] == true && sphynx[2] == true)
            {
                // Ouvrir le portail et le dernier trap
                var trap = GameObject.Find("Trap_Cutter3.7");
                trap.transform.Translate(Vector3.down * 5);
                var portal = GameObject.Find("Portal");
                portal.GetComponent<Renderer>().enabled = true;
            }
        }
    }
    void reset(bool[] sphynx)
    {
        sphynx[0] = false;
        sphynx[1] = false;
        sphynx[2] = false;
        sphynx[3] = false;
    }

    void Start() {
        var portal = GameObject.Find("Portal");
        portal.GetComponent<Renderer>().enabled = false;
    }

    void Update() {
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "AntiIntroDetector")
        {
            var Canvas = GameObject.Find("Intro");
            Destroy(Canvas);
        }
        if (collider.gameObject.name == "Trap_Cutter" || collider.gameObject.name == "Trap_Needle" || collider.gameObject.name == "Axe" || collider.gameObject.name == "HolePit" || collider.gameObject.name == "Quicksand")
        {
            Debug.Log("Game over");
            var player = GameObject.Find("Player");
            player.transform.position = new Vector3(-52.96f, 9f, -27.32f);
        }

        // Ouverture/ fermeture de trap
        if (collider.gameObject.name == "ButtonTrapCover")
        {
            var trapCover = GameObject.Find("TrapCover");
            if (open)
            {
                trapCover.transform.Translate(Vector3.up * 5);
                open = false;
            }
            else
            {
                trapCover.transform.Translate(Vector3.down * 5);
                open = true;
            }
        }
        // Ouverture de murs
        if (collider.gameObject.name == "ButtonWall1")
        {
            var wall = GameObject.Find("WallRoom1");
            wall.transform.Translate(Vector3.down * 5);
        }
        if (collider.gameObject.name == "ButtonPillar1")
        {
            var wall = GameObject.Find("Pillar1");
            wall.transform.Translate(Vector3.down * 5);
            var trap = GameObject.Find("TrapNeedle1");
            trap.transform.Translate(Vector3.down * 5);
        }
        if (collider.gameObject.name == "ButtonPillar2")
        {
            var wall = GameObject.Find("Pillar2");
            wall.transform.Translate(Vector3.down * 5);
        }
        if (collider.gameObject.name == "ButtonWall2")
        {
            var wall = GameObject.Find("WallRoom2");
            wall.transform.Translate(Vector3.down * 5);
            var trap = GameObject.Find("TrapNeedle2");
            trap.transform.Translate(Vector3.down * 5);
        }

        // Room 3

        if (collider.gameObject.name == "ButtonAxe")
        {
            var trap = GameObject.Find("Axe");
            trap.transform.Translate(Vector3.down * 5);
        }
        if (collider.gameObject.name == "Button3.1")
        {
            var trap = GameObject.Find("Block3.1");
            trap.transform.Translate(Vector3.down * 5);
        }
        if (collider.gameObject.name == "ButtonTrap3.2")
        {
            var trap = GameObject.Find("Trap3.2");
            trap.transform.Translate(Vector3.down * 5);
        }
        if (collider.gameObject.name == "Button3.3")
        {
            var trap = GameObject.Find("Block3.3");
            trap.transform.Translate(Vector3.down * 5);
        }
        if (collider.gameObject.name == "ButtonTrap3.4")
        {
            var trap = GameObject.Find("Trap3.4");
            trap.transform.Translate(Vector3.down * 5);
        }
        if (collider.gameObject.name == "Button3.5")
        {
            var trap = GameObject.Find("Block3.5");
            trap.transform.Translate(Vector3.down * 5);
        }
        if (collider.gameObject.name == "Button3.6")
        {
            var block = GameObject.Find("Block3.6");
            block.transform.Translate(Vector3.down * 5);
            var trap = GameObject.Find("Trap3.6");
            trap.transform.Translate(Vector3.down * 5);
        }
        // Sphynx 

        if (collider.gameObject.name == "ButtonSphynx1" || collider.gameObject.name == "ButtonSphynx2" || collider.gameObject.name == "ButtonSphynx3" || collider.gameObject.name == "ButtonSphynx4")
        {
            if (collider.gameObject.name == "ButtonSphynx1")
            {
                sphynx[0] = true;
                verification(0, sphynx);
            }
            if (collider.gameObject.name == "ButtonSphynx2")
            {
                sphynx[1] = true;
                verification(1, sphynx);
            }
            if (collider.gameObject.name == "ButtonSphynx3")
            {
                sphynx[2] = true;
                verification(2, sphynx);
            }
            if (collider.gameObject.name == "ButtonSphynx4")
            {
                sphynx[3] = true;
                verification(3, sphynx);
            }
            Debug.Log("Bouton touché");
        }
        // Exit
        if (sphynx[3] == true && sphynx[2] == true)
        {
            if (collider.gameObject.name == "PortalTrigger")
            {
                var player = GameObject.Find("Player");
                player.transform.position = new Vector3(32.74156f, 3.5f, 169.9382f);
            }
        }
    }
}
