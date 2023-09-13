using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    int lastDepth;
    int currDepth;
    PlayerController player;
    public Animator bgAnimator;

    private void Start()
    {
        player = PlayerController.instance;
    }
    void Update()
    {
        currDepth = player.depth;

        if (currDepth != lastDepth)
        {


            switch (currDepth)
            {
                case -3:

                    bgAnimator.SetTrigger("Dirt");
                    break;
                case -30:
                    bgAnimator.SetTrigger("Rock");
                    break;
                case -131:
                    bgAnimator.SetTrigger("Hardstone");
                    break;
                case -211:
                    bgAnimator.SetTrigger("Magmastone");
                    break;
            }
            



        }


        lastDepth = currDepth;
    }
}
